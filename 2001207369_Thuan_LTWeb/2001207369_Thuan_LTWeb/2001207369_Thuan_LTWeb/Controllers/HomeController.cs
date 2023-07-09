using _2001207369_Thuan_LTWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace _2001207369_Thuan_LTWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        BookStoreDbContext db = new BookStoreDbContext();
        public ActionResult TrangChu(int page = 1, string search = "")
        {

            List<Sach> s = db.Saches.Where(row => row.TenSach.Contains(search)).ToList();
            ViewBag.Search = search;


            int BuocNhay = 12;/// 5 dong 1 rtnag
            int TInh = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(s.Count) / Convert.ToDouble(BuocNhay)));///chia cho moi trng 
            int BuocNhaySkip = (page - 1) * BuocNhay;
            ViewBag.Page = page;
            ViewBag.tinh = TInh;
            s = s.Skip(BuocNhaySkip).Take(BuocNhay).ToList();

            return View(s);
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}