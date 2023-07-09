using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2001207369_Thuan_LTWeb.Models
{
    public class GioHang
    {
        [Key]
        public int MaGioHang { get; set; }
        public Sach Sach { get; set; }
        public int SoLuong { get; set; }
    }
}