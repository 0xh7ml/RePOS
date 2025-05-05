using Microsoft.AspNetCore.Mvc;

namespace RePOS.Controllers.Setup
{
    public class PaymentMethodController : Controller
    {
        [Route("PaymentMethods")]
        public IActionResult Index()
        {
            return View("~/Views/Setup/PaymentMethods.cshtml");
        }
    }
}
