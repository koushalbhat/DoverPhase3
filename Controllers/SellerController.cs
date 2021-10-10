using Laptop_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Store.Controllers
{
    public class SellerController : Controller
    {
        private readonly AppDbContext context;

        public SellerController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(int id)
        {
            return View(context.Laptops.Include(c=>c.Seller).Where(x=>x.SellerId==id));
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Seller s)
        {
            try
            {
                context.Add(s);
                context.SaveChanges();
                return RedirectToAction("Login");
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
        public IActionResult Login(SellerLoginViewModel s)
        {
            var seller = context.Sellers.Single(x => x.Email == s.Email);
            if(s.Password == seller.Password)
            {
                return RedirectToAction("Index", new { Id = seller.SellerId });
            }
            else
            {
                ViewBag.msg = "Invalid Credentials";
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Laptop laptop)
        {
            context.Laptops.Add(laptop);
            await context.SaveChangesAsync();
            return RedirectToAction("Index",new { Id = laptop.SellerId });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var laptopmodel = await context.Laptops.FindAsync(id);
            if (laptopmodel == null)
            {
                return NotFound();
            }
            return View(laptopmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Laptop laptop)
        {
            context.Update(laptop);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", new { Id = laptop.SellerId });
        }

        public IActionResult Details(int id)
        {
            return View(context.Laptops.Single(x => x.LaptopId == id));
        }

        public IActionResult Delete(int id)
        {
            return View(context.Laptops.Single(x => x.LaptopId == id));
        }
        [HttpPost]
        public IActionResult Delete(int id, Laptop laptop)
        {
            try
            {
                context.Laptops.Remove(laptop);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
