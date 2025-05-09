using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DomSalca_E_Commerce_MVC_App.Models
{
    public class CategoryDetail
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "En az 3 ve en fazla 100 karakter girmelisiniz.",  MinimumLength = 3)]
        public string CategoryName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }

    public class ProductDetail
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Ürün adı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "En az 3 ve en fazla 100 karakter girmelisiniz.", MinimumLength = 3)]
        public string ProductName { get; set; }
        [Required]
        [Range(1,50)]
        public Nullable<int> CategoryID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [Required(ErrorMessage ="Açıklama boş bırakılamaz.")]
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        [Required]
        [Range(typeof(int), "1", "500", ErrorMessage = "Geçersiz Miktar")]
        public Nullable<int> Quantity { get; set; }
        [Required]
        [Range(typeof(decimal), "1", "200000", ErrorMessage = "Geçersiz Fiyat")]
        public Nullable<decimal> Price { get; set; }
        public SelectList Categories { get; set; }
    }
}