using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using RePOS.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RePOS.Controllers.Auth
{
    public class AuthController : Controller
    {
        private readonly RePosDBContext _context;

        public AuthController(RePosDBContext context)
        {
            _context = context;
        }


        // Controller Main
        [HttpGet, Route("")]
        public IActionResult Index()
        {
            return View("~/Views/Auth/Index.cshtml");
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                TempData["ErrorMessage"] = "Email and password are required.";
                return View("~/Views/Auth/Index.cshtml");
            }

            var user = _context.Staffs
                .FirstOrDefault(s => s.Email == email && s.Password == password && s.Status);

            if (user == null)
            {
                TempData["ErrorMessage"] = "Invalid email or password.";
                return View("~/Views/Auth/Index.cshtml");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("IsAdmin", user.IsAdmin.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet, Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Auth");
        }

    }
}
