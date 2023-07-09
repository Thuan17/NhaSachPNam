using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2001207369_Thuan_LTWeb.Models
{
    public class LoaiSach
    {
        [Key]
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
    }
}