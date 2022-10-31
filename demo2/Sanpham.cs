using System;
using System.Collections.Generic;

namespace demo2
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Chitietsanphams = new HashSet<Chitietsanpham>();
        }

        public int Masanpham { get; set; }
        public string? Tensanpham { get; set; }
        public int? Dongia { get; set; }
        public double? Khuyenmai { get; set; }
        public bool? Trangthai { get; set; }
        public string? Hinhanh { get; set; }
        public string? Mota { get; set; }
        public int Maloaisanpham { get; set; }

        public virtual Loaisanpham MaloaisanphamNavigation { get; set; } = null!;
        public virtual ICollection<Chitietsanpham> Chitietsanphams { get; set; }
    }
}
