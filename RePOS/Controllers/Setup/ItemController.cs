using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RePOS.Data;
using RePOS.Models;

namespace RePOS.Controllers.Setup
{
    public class ItemController : Controller
    {
        private readonly RePosDBContext _context;

        public ItemController(RePosDBContext context)
        {
            _context = context;
        }
        
        [Route("Item")]
        [HttpGet]
        public IActionResult Index()
        {
            var items = _context.Items.Include(i=>i.TbCategory).ToList();
            var categories = _context.Categories.ToList();
            
            ViewBag.Categories = categories;
            ViewBag.Items = items;
            
            return View("~/Views/Setup/Item/MenuItem.cshtml");
        }

        [Route("Item/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }
            
    }
}
