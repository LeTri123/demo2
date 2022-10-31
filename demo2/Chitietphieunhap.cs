using System;
using System.Collections.Generic;

namespace demo2
{
    public partial class Chitietphieunhap
    {
        public int Mactphieunhap { get; set; }
        public int? Maphieunhap { get; set; }
        public int Machitietsp { get; set; }
        public int? Soluong { get; set; }
        public int? Dongia { get; set; }
        public int? Thanhtien { get; set; }

        public virtual Chitietsanpham MachitietspNavigation { get; set; } = null!;
        public virtual Phieunhap? MaphieunhapNavigation { get; set; }
    }
}
