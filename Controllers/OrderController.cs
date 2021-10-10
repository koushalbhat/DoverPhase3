using Laptop_Store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Store.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderCheckout orderCheckout;
        private readonly ShoppingCart shoppingCart;

        public OrderController(OrderCheckout orderCheckout, ShoppingCart shoppingCart)
        {
            this.orderCheckout = orderCheckout;
            this.shoppingCart = shoppingCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            if(shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your Cart is empty");
            }
            if (ModelState.IsValid)
            {
                orderCheckout.CreateOrder(order);
                shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You will recieve your laptop soon!!";
            return View();
        }
    }
}
