using Microsoft.AspNetCore.Mvc;
using RePOS.Models;
using RePOS.Data;
using Microsoft.EntityFrameworkCore;

namespace RePOS.Controllers.Analytics
{
    public class OrderReportController : Controller
        {
        private readonly RePosDBContext _context;
        public OrderReportController(RePosDBContext context)
        {
            _context = context;
        }
        [HttpGet, Route("Analytics/Order/Report")]
        public IActionResult Index()
        {
            var orders = _context.Orders
                .Include(o => o.PaymentMethod)
                .ToList();

             ViewBag.Orders = orders;
            return View("~/Views/Analytics/OrderReport.cshtml");
        }
    }
}
