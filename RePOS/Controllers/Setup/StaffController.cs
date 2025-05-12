using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RePOS.Data;
using RePOS.Models;

namespace RePOS.Controllers.Setup
{
    public class StaffController : Controller
    {
        private readonly RePosDBContext _context;

        public StaffController(RePosDBContext context)
        {
            _context = context;
        }

        [Route("Staffs"), Authorize]
        public IActionResult Index()
        {
            var staffs = _context.Staffs.ToList();
            return View("~/Views/Setup/Staff/Index.cshtml", staffs);
        }

        [Route("Staff/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(staff);
                _context.Staffs.Add(staff);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        [Route("Staff/Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Staff staff)
        {
            if (id != staff.Id)
            {
                return BadRequest();
            }

            var existingStaff = _context.Staffs.Find(id);
            if (existingStaff == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                existingStaff.FullName = staff.FullName;
                existingStaff.Email = staff.Email;
                if (!string.IsNullOrEmpty(staff.Password))
                {
                    existingStaff.Password = staff.Password; // Update password only if provided
                }
                existingStaff.IsAdmin = staff.IsAdmin;
                existingStaff.Status = staff.Status;
                _context.Staffs.Update(existingStaff);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}