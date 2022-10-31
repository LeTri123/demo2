using System;
using System.Collections.Generic;

namespace demo2
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public int Manhanvien { get; set; }
        public string? Tennhanvien { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string? Gioitinh { get; set; }
        public string? Sdt { get; set; }
        public string? Diachi { get; set; }
        public string? Cmnd { get; set; }
        public double? Luong { get; set; }
        public string? Hinhanh { get; set; }
        public DateTime? Ngayvaolam { get; set; }
        public string? Tinhtrang { get; set; }
        public string? Email { get; set; }
        public string? Chucvu { get; set; }

        public virtual Taikhoannhanvien? Taikhoannhanvien { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
