using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2001207369_Thuan_LTWeb.Models
{
    public class Sach
    {
        [Key]
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public DateTime NgayXuatBan { get; set; }
        public string MieuTa { get; set; }
        public string Anh { get; set; }
        public double GiaBan { get; set; }
        public double GiaGiam { get; set; }
        public int SoLuong { get; set; }

        public Nullable<int> MaLoai { get; set; }
        public Nullable<int> MaTacGia { get; set; }

        public virtual LoaiSach LoaiSach { get; set; }
        public virtual TacGia TacGia { get; set; }
    }
}