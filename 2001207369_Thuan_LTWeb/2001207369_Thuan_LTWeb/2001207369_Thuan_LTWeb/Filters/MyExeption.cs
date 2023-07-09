using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace _2001207369_Thuan_LTWeb.Filters
{
    public class MyExeption : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
           string s ="Message:"+ filterContext.Exception.Message;
            StreamWriter stream = File.AppendText(filterContext.RequestContext.HttpContext.Request.PhysicalApplicationPath + "\\Loi.txt");
            stream.WriteLine(s);
            stream.Close();
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Home/error");
        }
    }
}