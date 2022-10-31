using System;
using System.Collections.Generic;
using demo2.Models;

namespace demo2
{
    public partial class Chitietbaohanh
    {
        public int Machitietbh { get; set; }
        public int Maphieubh { get; set; }
        public int Machitiethd { get; set; }
        public int? Mahoadon { get; set; }
        public int? Machitietsp { get; set; }

        public virtual Chitiethoadon? Ma { get; set; }
        public virtual Baohanh MaphieubhNavigation { get; set; } = null!;
    }
}
