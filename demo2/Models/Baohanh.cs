using System;
using System.Collections.Generic;

namespace demo2.Models
{
    public partial class Baohanh
    {
        public Baohanh()
        {
            Chitietbaohanhs = new HashSet<Chitietbaohanh>();
        }

        public int Maphieubh { get; set; }
        public string? Mota { get; set; }
        public DateTime? Ngaylapbh { get; set; }

        public virtual ICollection<Chitietbaohanh> Chitietbaohanhs { get; set; }
    }
}
