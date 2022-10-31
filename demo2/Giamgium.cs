using System;
using System.Collections.Generic;

namespace demo2
{
    public partial class Giamgium
    {
        public Giamgium()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public int Magiamgia { get; set; }
        public string? Tengiamgia { get; set; }
        public string? Mota { get; set; }
        public int? Giatritoida { get; set; }
        public int? Donhangtu { get; set; }
        public DateTime? Ngaybd { get; set; }
        public DateTime? Ngaykt { get; set; }
        public double? Mucgiamgia { get; set; }

        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
