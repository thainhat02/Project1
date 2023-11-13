using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: News
        public ActionResult Index(int? page)
        {
            var pageSize = 4;

            if (page == null)
            {
                page = 1;
            }
            IEnumerable<New> item = db.News.OrderByDescending(x=>x.CreatedDate).ToList();
            var pageNumber = page.HasValue ? Convert.ToInt32(page) : 1;
            item =  item.ToPagedList(pageNumber, pageSize); // chiều giảm dần thì bản ghi mới nhất lên đầu
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(item);
        }
        public ActionResult Detail(int id)
        {
            var item = db.News.Find(id);
            return View(item);
        }
        public ActionResult Partial_News_Home()
        {
            var items = db.News.Take(3).ToList();
            return PartialView(items);
        }
    }
}