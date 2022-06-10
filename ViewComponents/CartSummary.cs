using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LapTopStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace LapTopStore.ViewComponents
{
    public class CartSummary : ViewComponent
    {
        private MyCart cart;
        public CartSummary(MyCart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
