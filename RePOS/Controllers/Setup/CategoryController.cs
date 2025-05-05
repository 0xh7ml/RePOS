using Microsoft.AspNetCore.Mvc;

namespace RePOS.Controllers.Setup
{
    public class CategoryController : Controller
    {
        [Route("Category")]
        public IActionResult Index()
        {
            return View("~/Views/Setup/MenuCategory.cshtml");
        }
    }
}
