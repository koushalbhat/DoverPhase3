using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laptop_Store.Models;

namespace Laptop_Store.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Laptop_Store.Models.SellerLoginViewModel> SellerLoginViewModel { get; set; }
        public DbSet<Laptop_Store.Models.CustomerLoginViewModel> CustomerLoginViewModel { get; set; }
        public DbSet<Laptop_Store.Models.AdminLoginViewModel> AdminLoginViewModel { get; set; }

    }
}
