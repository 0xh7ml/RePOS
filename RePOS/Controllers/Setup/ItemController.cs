using Microsoft.AspNetCore.Mvc;

namespace RePOS.Controllers.Setup
{
    public class ItemController : Controller
    {
        [Route("Item")]
        public IActionResult Index()
        {
            return View("~/Views/Setup/Item/MenuItem.cshtml");
        }
    }
}
