using _2001207369_Thuan_LTWeb.Filters;
using _2001207369_Thuan_LTWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001207369_Thuan_LTWeb.Areas.Admin.Controllers
{
    public class AdminTacGiaController : Controller
    {
        // GET: Admin/AdminTacGia
        BookStoreDbContext db = new BookStoreDbContext();
        [AdminAuthorization]
        public ActionResult Index(string search = "")
        {
            List<TacGia> s = db.TacGias.Where(row => row.TenTacGia.Contains(search)).ToList();
           
            return View(s);
        }
        public ActionResult Detail(int? id)
        {
            TacGia s = db.TacGias.Where(row => row.MaTacGia == id).FirstOrDefault();
            return View(s);
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(TacGia p)
        {

            db.TacGias.Add(p);
            db.SaveChanges();
            return RedirectToAction("index");
            //return View();

        }


        public ActionResult Delete(int id)
        {

            TacGia s = db.TacGias.Where(row => row.MaTacGia == id).FirstOrDefault();
            return View(s);
        }
        [HttpPost]
        public ActionResult Delete(int id, TacGia p)
        {

            TacGia s = db.TacGias.Where(row => row.MaTacGia == id).FirstOrDefault();
            db.TacGias.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            TacGia product = db.TacGias.Where(row => row.MaTacGia == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(TacGia pro)
        {

            TacGia product = db.TacGias.Where(row => row.MaTacGia == pro.MaTacGia).FirstOrDefault();

            product.TenTacGia = pro.TenTacGia;
            product.NgaySinh = pro.NgaySinh;
            product.QueQuan = pro.QueQuan;
            product.MieuTa = pro.MieuTa;  
            db.SaveChanges();
            return RedirectToAction("Index");
        }






    }
}