using Laptop_Store.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Store.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartController(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            this.appDbContext = appDbContext;
            this.shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }
        public RedirectToActionResult AddToShoppingCart(int laptopId)
        {
            var selectedLaptop = appDbContext.Laptops.FirstOrDefault(l => l.LaptopId == laptopId);
            if(selectedLaptop != null)
            {
                shoppingCart.AddToCart(selectedLaptop, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromCart(int laptopId)
        {
            var selectedLaptop = appDbContext.Laptops.FirstOrDefault(l => l.LaptopId == laptopId);
            if (selectedLaptop != null)
            {
                shoppingCart.RemoveFromCart(selectedLaptop);
            }
            return RedirectToAction("Index");
        }
    }
}
