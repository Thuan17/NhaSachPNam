
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _2001207369_Thuan_LTWeb.Models
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext() : base("ConnecString") { }
        public DbSet<LoaiSach> LoaiSaches { get; set; }
        public DbSet<TacGia> TacGias { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<Sach> Saches { get; set; }
    }
}