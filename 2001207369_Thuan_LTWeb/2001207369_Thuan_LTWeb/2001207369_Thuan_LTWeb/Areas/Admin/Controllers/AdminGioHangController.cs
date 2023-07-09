using _2001207369_Thuan_LTWeb.Filters;
using _2001207369_Thuan_LTWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001207369_Thuan_LTWeb.Areas.Admin.Controllers
{
    public class AdminGioHangController : Controller
    {
       
        BookStoreDbContext db = new BookStoreDbContext();
        private const string CartSession = "CartSession";
        [AdminAuthorization]
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<GioHang>();
            if (cart != null)
            {
                list = (List<GioHang>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(int productId, int SoLuong)
        {

            Sach product = db.Saches.FirstOrDefault(c => c.MaSach == productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<GioHang>)cart;
                if (list.Exists(x => x.Sach.MaSach == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Sach.MaSach == productId)
                        {
                            item.SoLuong = SoLuong;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng giỏ hàng
                    var item = new GioHang();
                    item.Sach = product;
                    item.SoLuong = SoLuong;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new GioHang();
                item.Sach = product;
                item.SoLuong = SoLuong;
                var list = new List<GioHang>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        //Xoa 
        public ActionResult Delete(int id)
        {
            var sessionCart = (List<GioHang>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Sach.MaSach == id);
            Session[CartSession] = sessionCart;
            return RedirectToAction("index");
        }

        public ActionResult DeleteAll()
        {
            Session[CartSession] = null;
            return RedirectToAction("index");
        }
        //cap nhat gio hang
        public ActionResult Update(int id, int quantity)
        {
            Sach product = db.Saches.FirstOrDefault(c => c.MaSach == id);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<GioHang>)cart;
                if (list.Exists(x => x.Sach.MaSach == id))
                {

                    foreach (var item in list)
                    {
                        if (item.Sach.MaSach == id)
                        {
                            item.SoLuong = quantity;
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}