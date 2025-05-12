using Microsoft.AspNetCore.Mvc;
using RePOS.Data;
using RePOS.Models;
using RePOS.Dtos;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace RePOS.Controllers
{
    public class PosController : Controller
    {
        private readonly RePosDBContext _context;

        public PosController(RePosDBContext context)
        {
            _context = context;
        }

        [HttpGet, Route("Order/Create"), Authorize]
        public IActionResult Index()
        {
            ViewBag.Items = _context.Items.ToList();
            ViewBag.PaymentMethods = _context.PaymentMethods.ToList();
            return View("~/Views/POS/Create.cshtml");
        }

        [HttpPost, Route("Order/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderCreateDto dto)
        {
            if (!ModelState.IsValid || dto.OrderItems == null || !dto.OrderItems.Any())
            {
                return RedirectToAction("Index");
            }

            var paymentMethod = _context.PaymentMethods.FirstOrDefault(pm => pm.Id == dto.PaymentMethodId);
            if (paymentMethod == null)
            {
                TempData["ErrorMessage"] = "Invalid payment method.";
                return RedirectToAction("Index");
            }

            decimal totalAmount = 0;

            var order = new Order
            {
                PaymentMethodId = dto.PaymentMethodId,
                OrderItems = new List<OrderItem>()
            };

            foreach (var itemDto in dto.OrderItems)
            {
                var item = _context.Items.FirstOrDefault(i => i.Id == itemDto.ItemId);
                if (item == null)
                    continue;

                var orderItem = new OrderItem
                {
                    ItemId = item.Id,
                    Quantity = itemDto.Quantity,
                };

                totalAmount += item.Price * itemDto.Quantity;

                order.OrderItems.Add(orderItem);
            }

            order.Total = totalAmount;

            _context.Orders.Add(order);
            _context.SaveChanges();
            TempData["Success"] = "Order created successfully.";

            return RedirectToAction("Index");
        }
    }
}
