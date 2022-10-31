using System;
using System.Collections.Generic;

namespace demo2
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
        }

        public int Mahoadon { get; set; }
        public DateTime? Ngaytao { get; set; }
        public int? Thanhtien { get; set; }
        public int Manhanvien { get; set; }
        public int? Makhachhang { get; set; }
        public int? Magiamgia { get; set; }

        public virtual Giamgium? MagiamgiaNavigation { get; set; }
        public virtual Khachhang? MakhachhangNavigation { get; set; }
        public virtual Nhanvien ManhanvienNavigation { get; set; } = null!;
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
    }
}
