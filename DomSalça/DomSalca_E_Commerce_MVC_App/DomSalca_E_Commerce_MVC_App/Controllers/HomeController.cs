using DomSalca_E_Commerce_MVC_App.DAL;
using DomSalca_E_Commerce_MVC_App.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DomSalca_E_Commerce_MVC_App.Controllers
{
    public class HomeController : Controller
    {
        DomSalca_DBEntities ctx = new DomSalca_DBEntities();
        public ActionResult Index(string search, int? page)
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            return View(model.CreateModel(search,3, page));
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Location()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddToCart(int id, DomSalca_DBEntities domSalca_DBEntities)
        {
            // Sepeti session'dan al
            var cart = Session["Cart"] as List<Tbl_Product> ?? new List<Tbl_Product>();

            // Ürünü veritabanından çek
            var product = domSalca_DBEntities.Tbl_Product.FirstOrDefault(p => p.ProductID == id);
            if (product != null)
            {
                cart.Add(product);
                Session["Cart"] = cart;
                return Json(new { success = true, message = "Ürün sepete eklendi!" });
            }

            return Json(new { success = false, message = "Ürün bulunamadı." });
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}