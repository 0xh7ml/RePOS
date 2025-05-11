using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RePOS.Data;
using RePOS.Models;

namespace RePOS.Controllers.Setup
{
    public class PaymentMethodController : Controller
    {
        private readonly RePosDBContext _context;
        public PaymentMethodController(RePosDBContext context)
        {
            _context = context;
        }


        [Route("PaymentMethods"), Authorize]
        public IActionResult Index()
        {
            var payment_methods = _context.PaymentMethods.ToList();
            return View("~/Views/Setup/PaymentMethod/Index.cshtml", payment_methods);
        }
        [Route("PaymentMethod/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PaymentMethod pm)
        {
            if (ModelState.IsValid)
            {
                _context.PaymentMethods.Add(pm);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pm);

        } // Create a new category

        [Route("PaymentMethod/Edit/{id}")]
        [HttpPost]
        public IActionResult Edit(int id, PaymentMethod pm)
        {

            var paymentMethod = _context.PaymentMethods.Find(id);
            if (paymentMethod == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                paymentMethod.Name = pm.Name;
                _context.PaymentMethods.Update(paymentMethod);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pm);
        }

        [Route("PaymentMethod/Delete/{id}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var pm = _context.PaymentMethods.Find(id);
            if (pm == null)
            {
                return RedirectToAction("Index");
            }
            _context.PaymentMethods.Remove(pm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
