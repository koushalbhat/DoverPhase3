using Laptop_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Store.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext context;

        public AdminController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Customers);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AdminLoginViewModel c)
        {
            var customer = context.Admins.Single(x => x.Email == c.Email);
            if (c.Password == customer.Password)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "Invalid Credentials";
                return View();
            }
        }
        public IActionResult CustomerDetails(int id)
        {
            return View(context.Customers.Single(x => x.CustomerId == id));
        }
        public IActionResult SellerDetails()
        {
            return View(context.Sellers);
        }
        public IActionResult SellerDetailsById(int id)
        {
            return View(context.Sellers.Single(x => x.SellerId == id));
        }
        public IActionResult OrdersRecievedDetails()
        {
            return View(context.OrderDetails.Include(c => c.Laptop).ThenInclude(s => s.Seller).Include(c => c.Order));
        }
        public IActionResult OrderDetails(int id)
        {
            return View(context.OrderDetails.Include(c => c.Laptop).ThenInclude(s => s.Seller).Include(o => o.Order).FirstOrDefault(x => x.OrderDetailId == id));
        }
    }
}
