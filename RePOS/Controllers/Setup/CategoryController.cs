using Microsoft.AspNetCore.Mvc;
using RePOS.Data;
using RePOS.Models;

namespace RePOS.Controllers.Setup
{
    public class CategoryController : Controller
    {
        private readonly RePosDBContext _context;

        public CategoryController(RePosDBContext context)
        {
            _context = context;
        }

        [Route("Category")]
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View("~/Views/Setup/Category/MenuCategory.cshtml", categories);
        } // Get all categories

        [Route("Category/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TbCategory category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);

        } // Create a new category

        [Route("Category/Edit/{id}")]
        [HttpPost]
        public IActionResult Edit(int id, TbCategory category)
        {

            var cat  = _context.Categories.Find(id);
            if (cat == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                cat.Name = category.Name;
                _context.Categories.Update(cat);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [Route("Category/Delete/{id}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
