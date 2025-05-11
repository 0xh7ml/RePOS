using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace RePOS.Controllers.Home
{
    public class HomeController : Controller
    {
        [Route("Home"), Authorize]
        public IActionResult Index()
        {
            return View(); // Not Calling the Index.cshtml as It's follow by the controller Name
        }
    }
}
