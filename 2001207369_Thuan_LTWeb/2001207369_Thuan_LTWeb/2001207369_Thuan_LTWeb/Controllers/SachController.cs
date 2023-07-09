using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001207369_Thuan_LTWeb.Filters;
using _2001207369_Thuan_LTWeb.Models;
namespace _2001207369_Thuan_LTWeb.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        BookStoreDbContext db = new BookStoreDbContext();
        [MyExeption]
        public ActionResult Index(string search = "", string SortColumn = "ProductsID", string IconClass = "fa-sort-asc", int page = 1)
        {
            List<Sach> s = db.Saches.Where(row => row.TenSach.Contains(search)).ToList();

            //sap xep 
            int BuocNhay = 12;/// 5 dong 1 rtnag
            int TInh = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(s.Count) / Convert.ToDouble(BuocNhay)));///chia cho moi trng 
            int BuocNhaySkip = (page - 1) * BuocNhay;
            ViewBag.Page = page;
            ViewBag.tinh = TInh;
            s = s.Skip(BuocNhaySkip).Take(BuocNhay).ToList();


            if (SortColumn == "MaSach")
            {
                if (IconClass == "fa-sort-asc")//tang dan
                {
                    s = s.OrderBy(row => row.MaSach).ToList();
                }
                else
                {
                    s = s.OrderByDescending(row => row.MaSach).ToList();
                }
            }
            else if (SortColumn == "TenSach")
            {
                if (IconClass == "fa-sort-asc")
                {
                    s = s.OrderBy(row => row.TenSach).ToList();
                }
                else
                {
                    s = s.OrderByDescending(row => row.TenSach).ToList();
                }
            }
            else if (SortColumn == "GiaBan")
            {
                if (IconClass == "fa-sort-asc")
                {
                    s = s.OrderBy(row => row.GiaBan).ToList();
                }
                else
                {
                    s = s.OrderByDescending(row => row.GiaBan).ToList();
                }
            }

            return View(s);
        }
        public ActionResult Sale()
        {
            List<Sach> s = db.Saches.ToList();
            return View(s);
        }
        public ActionResult Detail(int? id)
        {
            Sach s = db.Saches.Where(row => row.MaSach == id).FirstOrDefault();
            return View(s);
        }
    }
}