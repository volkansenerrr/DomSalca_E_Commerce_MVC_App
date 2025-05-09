using DomSalca_E_Commerce_MVC_App.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomSalca_E_Commerce_MVC_App.Models.Home
{
    public class Item
    {
        public Tbl_Product Product { get; set; }
        public int Quantity { get; set; }
    }
}