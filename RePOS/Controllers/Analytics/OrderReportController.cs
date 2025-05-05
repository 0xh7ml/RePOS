using Microsoft.AspNetCore.Mvc;

namespace RePOS.Controllers.Analytics
{
    public class OrderReportController : Controller
    {
        [Route("Analytics/Order/Report")]
        public IActionResult Index()
        {
            return View("~/Views/Analytics/OrderReport.cshtml");
        }
    }
}
