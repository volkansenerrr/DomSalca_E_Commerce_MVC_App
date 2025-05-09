using DomSalca_E_Commerce_MVC_App.DAL;
using DomSalca_E_Commerce_MVC_App.Models;
using DomSalca_E_Commerce_MVC_App.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using System.Data.Entity;    

namespace DomSalca_E_Commerce_MVC_App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        public List<System.Web.Mvc.SelectListItem> GetCategory()
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(item: new System.Web.Mvc.SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });
            }
            return list;
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Categories()
        {
            var allcategories = _unitOfWork.GetRepositoryInstance<Tbl_Category>()
                                           .GetAllRecordsIQueryable()
                                           .Where(i => i.IsDelete == false || i.IsDelete == null)
                                           .ToList();

            return View(allcategories);
        }


        public ActionResult AddCategory()
        {
            return UpdateCategory(0);
        }

        public ActionResult UpdateCategory(int CategoryID)
        {
            CategoryDetail cD;

            if (CategoryID != 0)
            {
                var category = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstorDefault(CategoryID);

                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                cD = JsonConvert.DeserializeObject<CategoryDetail>(
                    JsonConvert.SerializeObject(category, settings));
            }
            else
            {
                cD = new CategoryDetail();
            }

            return View("UpdateCategory", cD);
        }
        [HttpPost]
        public ActionResult CategoryDelete(int[] categoryIds, bool isHardDelete = false)
        {
            if (categoryIds != null && categoryIds.Length > 0)
            {
                var categoryRepo = _unitOfWork.GetRepositoryInstance<Tbl_Category>();

                foreach (var id in categoryIds)
                {
                    var category = categoryRepo.GetFirstorDefault(id);
                    if (category != null)
                    {
                        if (isHardDelete)
                            categoryRepo.Remove(category);
                        else
                        {
                            category.IsDelete = true;
                            categoryRepo.Update(category);
                        }
                    }
                }

                _unitOfWork.SaveChanges();
            }

            return RedirectToAction("Categories");
        }

        [HttpPost]
        public ActionResult SaveCategory(CategoryDetail model)
        {
            if (ModelState.IsValid)
            {
                Tbl_Category category;

                if (model.CategoryID == 0)
                {
                    category = new Tbl_Category
                    {
                        CategoryName = model.CategoryName,
                        IsDelete = false
                    };
                    _unitOfWork.GetRepositoryInstance<Tbl_Category>().Add(category);
                }
                else
                {
                    category = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstorDefault(model.CategoryID);
                    if (category != null)
                    {
                        category.CategoryName = model.CategoryName;
                    }
                }

                _unitOfWork.SaveChanges();
                return RedirectToAction("Categories");
            }

            return View("UpdateCategory", model);
        }

        public ActionResult Product()
        {
            var products = _unitOfWork.GetRepositoryInstance<Tbl_Product>()
                                      .GetAllRecordsIQueryable()
                                      .Where(x => x.IsDelete == false || x.IsDelete == null)
                                      .ToList();

            return View(products);
        }

        [HttpGet]
        public ActionResult ProductAdd()
        {
            ViewBag.CategoryList = new SelectList(
                _unitOfWork.GetRepositoryInstance<Tbl_Category>()
                    .GetAllRecordsIQueryable()
                    .Where(c => c.IsDelete.GetValueOrDefault() == false)
                    .ToList(),
                "CategoryID", "CategoryName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductAdd(Tbl_Product tbl, HttpPostedFileBase ProductImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ProductImageFile != null && ProductImageFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(ProductImageFile.FileName);
                    string folderPath = Server.MapPath("~/Images/Product/");

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string filePath = Path.Combine(folderPath, fileName);
                    ProductImageFile.SaveAs(filePath);

                    tbl.ProductImage = "/Images/Product/" + fileName;
                }

                tbl.CreatedDate = DateTime.Now;
                tbl.ModifiedDate = DateTime.Now;
                tbl.IsDelete = false;

                _unitOfWork.GetRepositoryInstance<Tbl_Product>().Add(tbl);
                _unitOfWork.SaveChanges();

                return RedirectToAction("Product");
            }

            ViewBag.CategoryList = new SelectList(
                _unitOfWork.GetRepositoryInstance<Tbl_Category>()
                    .GetAllRecordsIQueryable()
                    .Where(c => c.IsDelete.GetValueOrDefault() == false)
                    .ToList(),
                "CategoryID", "CategoryName");

            return View(tbl);
        }

        [HttpGet]
        public ActionResult ProductEdit(int productID)
        {
            var product = _unitOfWork.GetRepositoryInstance<Tbl_Product>().GetFirstorDefault(productID);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryList = new SelectList(
            _unitOfWork.GetRepositoryInstance<Tbl_Category>()
                .GetAllRecordsIQueryable()
                .Where(c => c.IsDelete == false)
                .ToList(),
            "CategoryID", "CategoryName",
            product.CategoryID);


            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductEdit(Tbl_Product tbl, HttpPostedFileBase ProductImageFile)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = _unitOfWork.GetRepositoryInstance<Tbl_Product>().GetFirstorDefault(tbl.ProductID);

                if (existingProduct != null)
                {
                    existingProduct.ProductName = tbl.ProductName;
                    existingProduct.Price = tbl.Price;
                    existingProduct.Quantity = tbl.Quantity;
                    existingProduct.Description = tbl.Description;
                    existingProduct.CategoryID = tbl.CategoryID;
                    existingProduct.ModifiedDate = DateTime.Now;

                    if (ProductImageFile != null && ProductImageFile.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(ProductImageFile.FileName);
                        string path = Path.Combine(Server.MapPath("~/Images/Product/"), fileName);
                        ProductImageFile.SaveAs(path);

                        existingProduct.ProductImage = "/Images/Product/" + fileName;
                    }

                    _unitOfWork.GetRepositoryInstance<Tbl_Product>().Update(existingProduct);
                    _unitOfWork.SaveChanges();

                    return RedirectToAction("Product");
                }
            }

            ViewBag.CategoryList = new SelectList(
                _unitOfWork.GetRepositoryInstance<Tbl_Category>()
                    .GetAllRecordsIQueryable()
                    .Where(c => c.IsDelete.GetValueOrDefault() == false)
                    .ToList(),
                "CategoryID", "CategoryName",
                tbl.CategoryID);

            return View(tbl);
        }

        [HttpPost]
        public ActionResult ProductDelete(int productID, bool isHardDelete = false)
        {
            System.Diagnostics.Debug.WriteLine("isHardDelete değeri: " + isHardDelete); // Test için

            var productRepo = _unitOfWork.GetRepositoryInstance<Tbl_Product>();
            var product = productRepo.GetFirstorDefault(productID);

            if (product != null)
            {
                if (isHardDelete)
                {
                    productRepo.Remove(product);
                }
                else
                {
                    product.IsDelete = true;
                    productRepo.Update(product);
                }

                _unitOfWork.SaveChanges();
            }

            return RedirectToAction("Product");
        }


        public ActionResult Orders()
        {
            // _unitOfWork üzerinden Tbl_Order repository’sini alıp ToList() yapıyoruz
            var orders = _unitOfWork
                .GetRepositoryInstance<Tbl_Order>()
                .GetAllRecordsIQueryable()
                .OrderByDescending(o => o.OrderDate)  // son siparişler önce gelsin
                .ToList();

            return View(orders);
        }

        // 2) Belirli bir siparişin detay satırlarını göster
        public ActionResult OrderDetails(int id /* OrderID */)
        {
            var details = _unitOfWork
                .GetRepositoryInstance<Tbl_OrderDetail>()
                .GetAllRecordsIQueryable()
                .Where(d => d.OrderID == id)
                .Include(d => d.Tbl_Product)    // ürün adını çekmek için
                .ToList();

            ViewBag.OrderID = id;
            return View(details);
        }
    }
}
