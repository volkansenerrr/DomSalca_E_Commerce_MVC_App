using DomSalca_E_Commerce_MVC_App.DAL;
using DomSalca_E_Commerce_MVC_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DomSalca_E_Commerce_MVC_App.Controllers
{
    public class CartController : Controller
    {
        DomSalca_DBEntities db = new DomSalca_DBEntities();

        [HttpPost]
        public JsonResult AddToCart(int id)
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();

            var p = db.Tbl_Product.FirstOrDefault(x => x.ProductID == id);
            if (p == null)
                return Json(new { success = false, message = "Ürün bulunamadı." });

            var existing = cart.FirstOrDefault(c => c.ProductId == id);
            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = p.ProductID,
                    ProductName = p.ProductName,
                    ProductImage = p.ProductImage,
                    Price = p.Price ?? 0,
                    Quantity = 1
                });
            }

            Session["Cart"] = cart;

            return Json(new { success = true, message = "Ürün sepete eklendi!", cartCount = cart.Sum(c => c.Quantity) });
        }

        public ActionResult Index()
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
            return View(cart);
        }

        [HttpPost]
        public JsonResult UpdateQuantity(int id, int qty)
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
            var item = cart.FirstOrDefault(x => x.ProductId == id);
            if (item != null)
            {
                item.Quantity = qty;
                Session["Cart"] = cart;
                return Json(new { success = true, total = cart.Sum(c => c.Price * c.Quantity) });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult RemoveFromCart(int id)
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
            var item = cart.FirstOrDefault(x => x.ProductId == id);
            if (item != null)
            {
                cart.Remove(item);
                Session["Cart"] = cart;
                return Json(new { success = true, total = cart.Sum(c => c.Price * c.Quantity) });
            }
            return Json(new { success = false });
        }

        // GET: /Cart/Checkout
        public ActionResult Checkout()
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
            return View(cart);
        }

        // POST: /Cart/Checkout
        // POST Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Checkout(string fullName, string address, string paymentMethod)
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();

            if (!cart.Any())
            {
                ModelState.AddModelError("", "Sepetiniz boş.");
                return View(cart);
            }

            // Eğer kredi kartı ile ödeme seçilmişse, fake ödeme API’sine istek gönder
            if (paymentMethod == "Kredi Kartı")
            {
                var totalAmount = cart.Sum(x => x.Price * x.Quantity);

                var paymentData = new
                {
                    CardNumber = "4111111111111111",
                    Expiry = "12/25",
                    CVC = "123",
                    Amount = totalAmount
                };

                var json = JsonConvert.SerializeObject(paymentData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync("https://fakestoreapi.com/pay", content);

                    if (!response.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError("", "Ödeme başarısız oldu. Lütfen tekrar deneyin.");
                        return View(cart);
                    }
                }
            }

            // Ödeme başarılıysa devam ediyoruz
            var order = new Tbl_Order
            {
                FullName = fullName,
                Address = address,
                PaymentMethod = paymentMethod,
                OrderDate = DateTime.Now
            };
            db.Tbl_Order.Add(order);
            db.SaveChanges();

            foreach (var item in cart)
            {
                var detail = new Tbl_OrderDetail
                {
                    OrderID = order.OrderID,
                    ProductID = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                };
                db.Tbl_OrderDetail.Add(detail);
            }
            db.SaveChanges();

            Session["Cart"] = null;
            TempData["SuccessMessage"] = "Siparişiniz başarıyla alındı, teşekkürler!";
            return RedirectToAction("OrderConfirmation");
        }



        [HttpGet]
        public ActionResult OrderConfirmation()
        {
            ViewBag.Message = TempData["SuccessMessage"];
            return View();
        }
    }
}
