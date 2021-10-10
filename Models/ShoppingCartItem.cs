using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptop_Store.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Laptop Laptop { get; set; }
        public int qty { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
