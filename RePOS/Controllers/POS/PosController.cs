using Microsoft.AspNetCore.Mvc;

namespace RePOS.Controllers.POS
{
    public class PosController : Controller
    {
        [Route("Pos")]
        public IActionResult Index()
        {
            return View("~/Views/POS/Pos.cshtml");
        }
    }
}
