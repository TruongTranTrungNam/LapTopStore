using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LapTopStore.Models;

namespace LapTopStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private MyCart cart;
        public OrderController(IOrderRepository repoService, MyCart cartService)
        {
            repository = repoService;
            cart = cartService;
        }
        public ViewResult Checkout() => View(new Order());[HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Giỏ hàng của bạn trống");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Hoàn tất", new { orderId = order.OrderID });
            }
            else
            {
                return View();
            }
        }
    }
}
