using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




using System.Web.Helpers;
using _2001207369_Thuan_LTWeb.Identity;
using _2001207369_Thuan_LTWeb.ViewModel;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.UI.WebControls;
using _2001207369_Thuan_LTWeb.Models;

namespace _2001207369_Thuan_LTWeb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register dk)
        {
            if (ModelState.IsValid)
            {
                var appDB = new AppDBContext();
                var userStore = new AppUserStore(appDB);
                var userManager = new AppUserManager(userStore);
                var passHasd = Crypto.HashPassword(dk.Password);
                var user = new AppUser
                {
                    Email = dk.Email,
                    UserName = dk.UserName,
                    PasswordHash = passHasd,
                    City = dk.City,
                    BrithDay = dk.BrithDay,
                    Address = dk.Address,
                    PhoneNumber = dk.Phone,

                };
                IdentityResult identity = userManager.Create(user);
                if (identity.Succeeded)//tao thanh cong
                {
                    userManager.AddToRole(user.Id, "Customer");
                    // dang ky xong dang nhap luon

                    var checkTk = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);//xasc thuc tai khoan

                    // dang nhap luon cho user
                    checkTk.SignIn(new AuthenticationProperties(), userIdentity);

                }
                return RedirectToAction("TrangChu", "Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "Error");
                return View();
            }

        }


        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LogIn dgNhap)
        {
            var appDB = new AppDBContext();
            var userStore = new AppUserStore(appDB);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(dgNhap.UserName, dgNhap.Password);
            if (user != null)
            {
                var checkTk = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);//xasc thuc tai khoan

                // dang nhap luon cho user
                checkTk.SignIn(new AuthenticationProperties(), userIdentity);

                ///kiem tra user co phai admin hay ko
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("TrangChu", "Home");
                }



            }
            else
            {

                ModelState.AddModelError("Lỗi", "Không tìm Thấy Tài Khoản");
                return View();
            }


        }
        public ActionResult LogOut()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("TrangChu", "Home");
        }
        public ActionResult Detail()
        {
            var db = new AppDBContext();
            var userS = new AppUserStore(db);
            var manager = new AppUserManager(userS);

            

            return View();
        }
    }
}