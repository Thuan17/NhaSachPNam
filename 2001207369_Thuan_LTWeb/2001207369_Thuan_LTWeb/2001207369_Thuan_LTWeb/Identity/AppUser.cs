﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity.EntityFramework;
namespace _2001207369_Thuan_LTWeb.Identity
{
    public class AppUser : IdentityUser
    {
        public DateTime? BrithDay { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Anh { get; set; }
    }
}