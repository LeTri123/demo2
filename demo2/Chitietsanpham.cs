using System;
using System.Collections.Generic;

namespace demo2
{
    public partial class Chitietsanpham
    {
        public Chitietsanpham()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
            Chitietphieunhaps = new HashSet<Chitietphieunhap>();
        }

        public int Machitietsp { get; set; }
        public int? Masize { get; set; }
        public int? Mamau { get; set; }
        public int? Soluongton { get; set; }
        public string? Hinhanh { get; set; }
        public string? Mavach { get; set; }
        public int Masanpham { get; set; }

        public virtual Mau? MamauNavigation { get; set; }
        public virtual Sanpham MasanphamNavigation { get; set; } = null!;
        public virtual Size? MasizeNavigation { get; set; }
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
        public virtual ICollection<Chitietphieunhap> Chitietphieunhaps { get; set; }
    }
}
