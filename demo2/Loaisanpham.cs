using System;
using System.Collections.Generic;

namespace demo2
{
    public partial class Loaisanpham
    {
        public Loaisanpham()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int Maloaisanpham { get; set; }
        public string? Tenloaisanpham { get; set; }
        public string? HinhAnh { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
