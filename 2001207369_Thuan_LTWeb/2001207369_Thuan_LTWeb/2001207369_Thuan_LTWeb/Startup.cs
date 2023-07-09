using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using _2001207369_Thuan_LTWeb.Identity;

[assembly: OwinStartup(typeof(_2001207369_Thuan_LTWeb.Startup))]

namespace _2001207369_Thuan_LTWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/login")
            });
            this.CreateRolesAndUser();
        }
        public void CreateRolesAndUser()
        {
            var roleManage = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDBContext()));
            var appDBContext = new AppDBContext();
            var appUserStore = new AppUserStore(appDBContext);
            var userManager = new AppUserManager(appUserStore);


            // admin
            if (!roleManage.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManage.Create(role);
            }
            if (userManager.FindByName("admin") == null)
            {
                var user = new AppUser();
                user.UserName = "Thuanhuynh";
                user.Email = "thuanhuynh941@gmail.com";
                user.Anh = "admin.png";
                string userPwd = "mapuu17";




                var checkUser = userManager.Create(user, userPwd);//save kq
                if (checkUser.Succeeded)//tao thanh cong
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            // Manager
            if (!roleManage.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManage.Create(role);
            }
            if (userManager.FindByName("manager") == null)
            {
                var user = new AppUser();
                user.UserName = "ThanhAn";
                user.Email = "thanhan123@gmail.com";
                string userPwd = "anle123";

                var checkUser = userManager.Create(user, userPwd);
                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }

            //Customer
            if (!roleManage.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManage.Create(role);
            }

        }
    }
}
