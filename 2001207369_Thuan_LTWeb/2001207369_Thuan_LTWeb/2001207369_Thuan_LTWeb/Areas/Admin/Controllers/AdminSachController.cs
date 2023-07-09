using _2001207369_Thuan_LTWeb.Filters;
using _2001207369_Thuan_LTWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace _2001207369_Thuan_LTWeb.Areas.Admin.Controllers
{
    public class AdminSachController : Controller
    {
        // GET: Admin/Sach
        BookStoreDbContext db = new BookStoreDbContext();
        [AdminAuthorization]
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
        public ActionResult Detail(int? id)
        {
            Sach s = db.Saches.Where(row => row.MaSach == id).FirstOrDefault();
            return View(s);
        }

        public ActionResult Delete(int id)
        {

            Sach s = db.Saches.Where(row => row.MaSach == id).FirstOrDefault();
            return View(s);
        }
        [HttpPost]
        public ActionResult Delete(int id, Sach p)
        {

            Sach s = db.Saches.Where(row => row.MaSach == id).FirstOrDefault();
            db.Saches.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Tao
        public ActionResult Create()
        {

            ViewBag.LoaiSach = db.LoaiSaches.ToList();
            ViewBag.TacGia = db.TacGias.ToList();


            return View();
        }
        [HttpPost]
        public ActionResult Create(Sach p,HttpPostedFileBase uphinh)
        {

            db.Saches.Add(p);
            db.SaveChanges();

            if (uphinh != null && uphinh.ContentLength > 0)
            {
                int id = int.Parse(db.Saches.ToList().Last().MaSach.ToString());
                string _FileName ="" ;
                int index = uphinh.FileName.IndexOf('.');
                _FileName = "S" + id.ToString() + "." + uphinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~Photo/SanPham"), _FileName);
                uphinh.SaveAs(_path);
                Sach product = db.Saches.Where(row => row.MaSach == id).FirstOrDefault();
                product.Anh = _FileName;
                db.SaveChanges();

            }

            return RedirectToAction("index");
           
        }


        public ActionResult Edit(int id)
        {

            Sach product = db.Saches.Where(row => row.MaSach == id).FirstOrDefault();
            ViewBag.LoaiSach = db.LoaiSaches.ToList();
            ViewBag.TacGia = db.TacGias.ToList();
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Sach pro)
        {

            Sach product = db.Saches.Where(row => row.MaSach == pro.MaSach).FirstOrDefault();


            product.TenSach = pro.TenSach;
            product.GiaBan = pro.GiaBan;
            product.GiaGiam = pro.GiaGiam;
            product.NgayXuatBan = pro.NgayXuatBan;
            product.MaTacGia = pro.MaTacGia;
            product.MaLoai = pro.MaLoai;
            product.SoLuong = pro.SoLuong;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}