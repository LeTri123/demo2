using System;
using System.Collections.Generic;

namespace demo2
{
    public partial class Taikhoannhanvien
    {
        public int Mataikhoan { get; set; }
        public DateTime? Ngaytao { get; set; }
        public string? Tentaikhoan { get; set; }
        public string? Matkhau { get; set; }
        public bool? Trangthai { get; set; }
        public int? Manhanvien { get; set; }

        public virtual Nhanvien? ManhanvienNavigation { get; set; }
    }
}
