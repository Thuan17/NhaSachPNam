using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001207369_Thuan_LTWeb.Filters
{
    public class AdminAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //kiem tra co phai la admin hay ko
            if (filterContext.HttpContext.User.IsInRole("Admin") == false)//khong phải admin
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}