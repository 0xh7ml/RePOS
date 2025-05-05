using Microsoft.AspNetCore.Mvc;

namespace RePOS.Controllers.Home
{
    public class HomeController : Controller
    {
        [Route("Home")]
        public IActionResult Index()
        {
            return View(); // Not Calling the Index.cshtml as It's follow by the controller Name
        }
    }
}
