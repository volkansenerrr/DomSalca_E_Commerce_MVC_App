using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomSalca_E_Commerce_MVC_App.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}