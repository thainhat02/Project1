using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index(int? id)
        {

            var item = db.Products.ToList();
            if (id != null)
            {
                item = item.Where(x => x.ProductCategoryID == id).ToList();
            }
            return View(item);
        }
        public ActionResult Detail(string alias, int id)
        {
            var item = db.Products.Find(id);
            var countReview = db.ReviewProducts.Where(x => x.ProductId == id).Count();
            ViewBag.Count = countReview;
            return View(item);
        }
        public ActionResult ProductCategory(string alias, int id)
        {

            var item = db.Products.ToList();
            if (id >0)
            {
                item = item.Where(x => x.ProductCategoryID == id).ToList();
            }
            var cate = db.ProductCategories.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.Title;
            }
            ViewBag.CateId = id;
            return View(item);
        }
        public ActionResult Partial_ItemByCateID()
        {
            var items = db.Products.Where(x => x.IsHome && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
        public ActionResult Partial_ProductSales()
        {
            var items = db.Products.Where(x => x.IsSale && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
        public ActionResult TimKiemSP(string search)
        {
           
              var item = db.Products.Where(x => x.Alias.Contains(search) || x.Title.Contains(search)).ToList();
                if (string.IsNullOrEmpty(search))
                {
                    item = db.Products.ToList();
                }

            return View("Index", item);
        }
        
    }
}