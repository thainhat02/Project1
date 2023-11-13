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
    [Authorize]
    public class WishListController : Controller
    {
        // GET: WishList
        public ActionResult Index(int? page)
        {
            var pageSize = 4;

            if (page == null)
            {
                page = 1;
            }
            IEnumerable<WishList> item = db.WishLists.Where(x => x.UserName == User.Identity.Name).ToList().OrderByDescending(x=>x.CreatedDate);
            var pageNumber = page.HasValue ? Convert.ToInt32(page) : 1;
            item = item.ToPagedList(pageNumber, pageSize); // chiều giảm dần thì bản ghi mới nhất lên đầu
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(item);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostWishList(int productId)
        {
            if (Request.IsAuthenticated==false)
            {
                return Json(new { Success = false, Message = "Bạn chưa đăng nhập" });
            }
            var checkItem = db.WishLists.FirstOrDefault(x => x.ProductId == productId && x.UserName == User.Identity.Name);
            if (checkItem != null)
            {
                return Json(new { Success = false, Message = "Sản phẩm đã được yêu thích" });
            }
            var item = new WishList();
            item.ProductId = productId;
            item.UserName = User.Identity.Name;
            item.CreatedDate = DateTime.Now;
            db.WishLists.Add(item);
            db.SaveChanges();
            return Json(new { Success = true });
        }
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.WishLists.Find(id);
            if (item != null)
            {
                db.WishLists.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostDeleteWishlist(int productId)
        {
            var checkItem = db.WishLists.FirstOrDefault(x => x.ProductId == productId && x.UserName == User.Identity.Name);
            if (checkItem != null)
            {
                db.WishLists.Remove(checkItem);
                db.SaveChanges();
                return Json(new { Success = true, Message = "Xóa thành công" });
            }
            return Json(new { Success = false, Message = "Xóa thất bại" });
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}