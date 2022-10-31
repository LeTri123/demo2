using System;
using System.Collections.Generic;

namespace demo2
{
    public partial class Chitiethoadon
    {
        public Chitiethoadon()
        {
            Chitietbaohanhs = new HashSet<Chitietbaohanh>();
        }

        public int Machitiethd { get; set; }
        public int Machitietsp { get; set; }
        public int? Soluong { get; set; }
        public int? Dongiaban { get; set; }
        public int? Thanhtien { get; set; }
        public int Mahoadon { get; set; }

        public virtual Chitietsanpham MachitietspNavigation { get; set; } = null!;
        public virtual Hoadon MahoadonNavigation { get; set; } = null!;
        public virtual ICollection<Chitietbaohanh> Chitietbaohanhs { get; set; }
    }
}
