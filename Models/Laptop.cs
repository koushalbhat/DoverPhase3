using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Store.Models
{
    public class Laptop
    {
        public int LaptopId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
