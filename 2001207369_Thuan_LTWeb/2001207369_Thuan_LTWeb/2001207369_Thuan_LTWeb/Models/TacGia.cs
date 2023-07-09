using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2001207369_Thuan_LTWeb.Models
{
    public class TacGia
    {
        [Key]
        public int MaTacGia { get; set; }
        public string TenTacGia { get; set; }
        public string MieuTa { get; set; }
        public DateTime NgaySinh { get; set; }
        public string QueQuan { get; set; }
    }
}