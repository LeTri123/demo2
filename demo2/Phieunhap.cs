using System;
using System.Collections.Generic;

namespace demo2
{
    public partial class Phieunhap
    {
        public Phieunhap()
        {
            Chitietphieunhaps = new HashSet<Chitietphieunhap>();
        }

        public int Maphieunhap { get; set; }
        public int? Tongtien { get; set; }
        public string? Trangthai { get; set; }

        public virtual ICollection<Chitietphieunhap> Chitietphieunhaps { get; set; }
    }
}
