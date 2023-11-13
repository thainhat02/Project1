using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuTop()
        {
            var items = db.Categories.OrderBy(x => x.Position).ToList(); // tăng dần số thứ tự 
            return PartialView(items);
        }
        public ActionResult MenuProductCategory()
        {
            var item = db.ProductCategories.ToList();
            return PartialView(item);
        }
        public ActionResult MenuLeft(int? id)
        {
            if (id != null)
            {
                ViewBag.CateId = id;
            }
            var item = db.ProductCategories.ToList();
            return PartialView(item);
        }
        public ActionResult Menuarrivals()
        {
            var item = db.ProductCategories.ToList();
            return PartialView(item);
        }
    }
}