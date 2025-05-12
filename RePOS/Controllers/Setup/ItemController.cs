using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Route("Item"), Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var items = _context.Items.ToList();
            return View("~/Views/Setup/Item/Index.cshtml", items);
        }

        [HttpGet, Route("Item/Create")]
        public IActionResult Create()
        {
            return View("~/Views/Setup/Item/Create.cshtml");
        }
        [HttpPost, Route("Item/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                _context.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(item);
        }
        [Route("Item/Edit/{id}")]
        [HttpPost]
        public IActionResult Edit(int id, Item item)
        {

            var existingItem = _context.Items.Find(id);
            if (existingItem == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                existingItem.Name = item.Name;
                _context.Items.Update(existingItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [Route("Item/Delete/{id}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
