using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RePOS.Models;

namespace RePOS.Controllers.Auth
{
    public class LoginController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View("~/Views/Auth/Index.cshtml");
        }
    }
}
