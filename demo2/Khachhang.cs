using System;
using System.Collections.Generic;

namespace demo2
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public int Makhachhang { get; set; }
        public string? Tenkhachhang { get; set; }
        public string? Diachi { get; set; }
        public string? Gioitinh { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string? Sdt { get; set; }
        public string? Email { get; set; }
        public string? Hinhanh { get; set; }
        public int? Diemtichluy { get; set; }

        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
