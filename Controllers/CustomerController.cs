using Laptop_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Store.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext context;

        public CustomerController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Laptops.Include(c => c.Seller));
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            try
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("login");
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CustomerLoginViewModel c)
        {
            var customer = context.Customers.Single(x => x.Email == c.Email);
            if(c.Password == customer.Password)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "Invalid Credentials";
                return View();
            }
        }
    }
}
