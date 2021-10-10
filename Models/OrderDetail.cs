using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Store.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int LaptopId { get; set; }
        public int qty { get; set; }
        public decimal Price { get; set; }
        public Laptop Laptop { get; set; }
        public Order Order { get; set; }
    }
}
