using Microsoft.AspNetCore.Mvc;

namespace RePOS.Controllers.Setup
{
    public class StaffController : Controller
    {
        [Route("Staff")]
        public IActionResult Index()
        {
            return View("~/Views/Setup/Staff.cshtml");
        }
    }
}
