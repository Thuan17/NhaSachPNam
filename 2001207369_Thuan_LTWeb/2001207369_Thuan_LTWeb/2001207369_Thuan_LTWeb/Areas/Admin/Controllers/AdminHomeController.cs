using _2001207369_Thuan_LTWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001207369_Thuan_LTWeb.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/AdminHome
        [AdminAuthorization]
        public ActionResult Index()
        {
            return View();
        }
    }
}