using System;
using System.Collections.Generic;
using demo2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace demo2
{
    public partial class QLSHOPTHOITRANGContext : DbContext
    {
        public QLSHOPTHOITRANGContext()
        {
        }

        public QLSHOPTHOITRANGContext(DbContextOptions<QLSHOPTHOITRANGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Baohanh> Baohanhs { get; set; } = null!;
        public virtual DbSet<Barcode> Barcodes { get; set; } = null!;
        public virtual DbSet<Chitietbaohanh> Chitietbaohanhs { get; set; } = null!;
        public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; } = null!;
        public virtual DbSet<Chitietphieunhap> Chitietphieunhaps { get; set; } = null!;
        public virtual DbSet<Chitietsanpham> Chitietsanphams { get; set; } = null!;
        public virtual DbSet<Giamgium> Giamgia { get; set; } = null!;
        public virtual DbSet<Hoadon> Hoadons { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Loaisanpham> Loaisanphams { get; set; } = null!;
        public virtual DbSet<Mau> Maus { get; set; } = null!;
        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<Phieunhap> Phieunhaps { get; set; } = null!;
        public virtual DbSet<Sanpham> Sanphams { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<Taikhoannhanvien> Taikhoannhanviens { get; set; } = null!;
        public virtual DbSet<ViewDsctsp> ViewDsctsps { get; set; } = null!;
        public virtual DbSet<VwCthd> VwCthds { get; set; } = null!;
        public virtual DbSet<VwHoaDon> VwHoaDons { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=TRI123\\MAYAO;Initial Catalog=QLSHOPTHOITRANG;User ID=sa;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Baohanh>(entity =>
            {
                entity.HasKey(e => e.Maphieubh);

                entity.ToTable("BAOHANH");

                entity.Property(e => e.Maphieubh).HasColumnName("MAPHIEUBH");

                entity.Property(e => e.Mota).HasColumnName("MOTA");

                entity.Property(e => e.Ngaylapbh)
                    .HasColumnType("date")
                    .HasColumnName("NGAYLAPBH");
            });

            modelBuilder.Entity<Barcode>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("barcode");

                entity.Property(e => e.MaMau).HasColumnName("maMau");

                entity.Property(e => e.Maloaisanpham).HasColumnName("MALOAISANPHAM");

                entity.Property(e => e.Masanpham).HasColumnName("MASANPHAM");

                entity.Property(e => e.Masize).HasColumnName("masize");

                entity.Property(e => e.TenSanPham)
                    .HasMaxLength(100)
                    .HasColumnName("tenSanPham");
            });

            modelBuilder.Entity<Chitietbaohanh>(entity =>
            {
                entity.HasKey(e => new { e.Machitietbh, e.Maphieubh, e.Machitiethd })
                    .HasName("PK_CTBAOHANH");

                entity.ToTable("CHITIETBAOHANH");

                entity.Property(e => e.Machitietbh)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MACHITIETBH");

                entity.Property(e => e.Maphieubh).HasColumnName("MAPHIEUBH");

                entity.Property(e => e.Machitiethd).HasColumnName("MACHITIETHD");

                entity.Property(e => e.Machitietsp).HasColumnName("MACHITIETSP");

                entity.Property(e => e.Mahoadon).HasColumnName("MAHOADON");

                entity.HasOne(d => d.MaphieubhNavigation)
                    .WithMany(p => p.Chitietbaohanhs)
                    .HasForeignKey(d => d.Maphieubh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTBH_BH");

                entity.HasOne(d => d.Ma)
                    .WithMany(p => p.Chitietbaohanhs)
                    .HasForeignKey(d => new { d.Machitiethd, d.Mahoadon, d.Machitietsp })
                    .HasConstraintName("FK_CTBH_CTHD");
            });

            modelBuilder.Entity<Chitiethoadon>(entity =>
            {
                entity.HasKey(e => new { e.Machitiethd, e.Mahoadon, e.Machitietsp })
                    .HasName("PK__CHITIETH__FCD5B889B92B9801");

                entity.ToTable("CHITIETHOADON");

                entity.Property(e => e.Machitiethd)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MACHITIETHD");

                entity.Property(e => e.Mahoadon).HasColumnName("MAHOADON");

                entity.Property(e => e.Machitietsp).HasColumnName("MACHITIETSP");

                entity.Property(e => e.Dongiaban).HasColumnName("DONGIABAN");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Thanhtien).HasColumnName("THANHTIEN");

                entity.HasOne(d => d.MachitietspNavigation)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.Machitietsp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTHD_SP");

                entity.HasOne(d => d.MahoadonNavigation)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.Mahoadon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTHD_HD");
            });

            modelBuilder.Entity<Chitietphieunhap>(entity =>
            {
                entity.HasKey(e => e.Mactphieunhap)
                    .HasName("PK__CHITIETP__E3CB334A16494776");

                entity.ToTable("CHITIETPHIEUNHAP");

                entity.Property(e => e.Mactphieunhap).HasColumnName("MACTPHIEUNHAP");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Machitietsp).HasColumnName("MACHITIETSP");

                entity.Property(e => e.Maphieunhap).HasColumnName("MAPHIEUNHAP");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Thanhtien).HasColumnName("THANHTIEN");

                entity.HasOne(d => d.MachitietspNavigation)
                    .WithMany(p => p.Chitietphieunhaps)
                    .HasForeignKey(d => d.Machitietsp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTPN_CTSP");

                entity.HasOne(d => d.MaphieunhapNavigation)
                    .WithMany(p => p.Chitietphieunhaps)
                    .HasForeignKey(d => d.Maphieunhap)
                    .HasConstraintName("FK_CTPN_PN");
            });

            modelBuilder.Entity<Chitietsanpham>(entity =>
            {
                entity.HasKey(e => e.Machitietsp)
                    .HasName("PK__CHITIETS__0E9003B92603F223");

                entity.ToTable("CHITIETSANPHAM");

                entity.Property(e => e.Machitietsp).HasColumnName("MACHITIETSP");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HINHANH");

                entity.Property(e => e.Mamau).HasColumnName("MAMAU");

                entity.Property(e => e.Masanpham).HasColumnName("MASANPHAM");

                entity.Property(e => e.Masize).HasColumnName("MASIZE");

                entity.Property(e => e.Mavach)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MAVACH");

                entity.Property(e => e.Soluongton).HasColumnName("SOLUONGTON");

                entity.HasOne(d => d.MamauNavigation)
                    .WithMany(p => p.Chitietsanphams)
                    .HasForeignKey(d => d.Mamau)
                    .HasConstraintName("FK_SP_MAU");

                entity.HasOne(d => d.MasanphamNavigation)
                    .WithMany(p => p.Chitietsanphams)
                    .HasForeignKey(d => d.Masanpham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTSP_SP");

                entity.HasOne(d => d.MasizeNavigation)
                    .WithMany(p => p.Chitietsanphams)
                    .HasForeignKey(d => d.Masize)
                    .HasConstraintName("FK_SP_SIZE");
            });

            modelBuilder.Entity<Giamgium>(entity =>
            {
                entity.HasKey(e => e.Magiamgia);

                entity.ToTable("GIAMGIA");

                entity.Property(e => e.Magiamgia).HasColumnName("MAGIAMGIA");

                entity.Property(e => e.Donhangtu).HasColumnName("DONHANGTU");

                entity.Property(e => e.Giatritoida).HasColumnName("GIATRITOIDA");

                entity.Property(e => e.Mota).HasColumnName("MOTA");

                entity.Property(e => e.Mucgiamgia).HasColumnName("MUCGIAMGIA");

                entity.Property(e => e.Ngaybd)
                    .HasColumnType("date")
                    .HasColumnName("NGAYBD");

                entity.Property(e => e.Ngaykt)
                    .HasColumnType("date")
                    .HasColumnName("NGAYKT");

                entity.Property(e => e.Tengiamgia)
                    .HasMaxLength(50)
                    .HasColumnName("TENGIAMGIA");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahoadon)
                    .HasName("PK__HOADON__A4999DF56411B642");

                entity.ToTable("HOADON");

                entity.Property(e => e.Mahoadon).HasColumnName("MAHOADON");

                entity.Property(e => e.Magiamgia).HasColumnName("MAGIAMGIA");

                entity.Property(e => e.Makhachhang).HasColumnName("MAKHACHHANG");

                entity.Property(e => e.Manhanvien).HasColumnName("MANHANVIEN");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("NGAYTAO");

                entity.Property(e => e.Thanhtien).HasColumnName("THANHTIEN");

                entity.HasOne(d => d.MagiamgiaNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Magiamgia)
                    .HasConstraintName("FK_GG_HD");

                entity.HasOne(d => d.MakhachhangNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Makhachhang)
                    .HasConstraintName("FK_HD_KH");

                entity.HasOne(d => d.ManhanvienNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Manhanvien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HD_NV");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makhachhang)
                    .HasName("PK__KHACHHAN__30035C2FBC873DEA");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Makhachhang).HasColumnName("MAKHACHHANG");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Diemtichluy).HasColumnName("DIEMTICHLUY");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(10)
                    .HasColumnName("GIOITINH");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HINHANH");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.Tenkhachhang)
                    .HasMaxLength(50)
                    .HasColumnName("TENKHACHHANG");
            });

            modelBuilder.Entity<Loaisanpham>(entity =>
            {
                entity.HasKey(e => e.Maloaisanpham)
                    .HasName("PK_NHOMSANPHAM");

                entity.ToTable("LOAISANPHAM");

                entity.Property(e => e.Maloaisanpham).HasColumnName("MALOAISANPHAM");

                entity.Property(e => e.HinhAnh).HasColumnName("hinhAnh");

                entity.Property(e => e.Tenloaisanpham).HasColumnName("TENLOAISANPHAM");
            });

            modelBuilder.Entity<Mau>(entity =>
            {
                entity.HasKey(e => e.Mamau)
                    .HasName("PK__MAU__7B7346CFAF73B903");

                entity.ToTable("MAU");

                entity.Property(e => e.Mamau).HasColumnName("MAMAU");

                entity.Property(e => e.Tenmau)
                    .HasMaxLength(50)
                    .HasColumnName("TENMAU");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manhanvien)
                    .HasName("PK__NHANVIEN__7E46DD9135AE420D");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Manhanvien).HasColumnName("MANHANVIEN");

                entity.Property(e => e.Chucvu)
                    .HasMaxLength(50)
                    .HasColumnName("CHUCVU");

                entity.Property(e => e.Cmnd)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("CMND");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(10)
                    .HasColumnName("GIOITINH");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HINHANH");

                entity.Property(e => e.Luong).HasColumnName("LUONG");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Ngayvaolam)
                    .HasColumnType("date")
                    .HasColumnName("NGAYVAOLAM");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.Tennhanvien)
                    .HasMaxLength(50)
                    .HasColumnName("TENNHANVIEN");

                entity.Property(e => e.Tinhtrang)
                    .HasMaxLength(20)
                    .HasColumnName("TINHTRANG");
            });

            modelBuilder.Entity<Phieunhap>(entity =>
            {
                entity.HasKey(e => e.Maphieunhap)
                    .HasName("PK__PHIEUNHA__0F2275AB739BBBA0");

                entity.ToTable("PHIEUNHAP");

                entity.Property(e => e.Maphieunhap).HasColumnName("MAPHIEUNHAP");

                entity.Property(e => e.Tongtien).HasColumnName("TONGTIEN");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(50)
                    .HasColumnName("TRANGTHAI");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.Masanpham)
                    .HasName("PK__SANPHAM__9534C89297A25A91");

                entity.ToTable("SANPHAM");

                entity.Property(e => e.Masanpham).HasColumnName("MASANPHAM");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HINHANH");

                entity.Property(e => e.Khuyenmai).HasColumnName("KHUYENMAI");

                entity.Property(e => e.Maloaisanpham).HasColumnName("MALOAISANPHAM");

                entity.Property(e => e.Mota).HasColumnName("MOTA");

                entity.Property(e => e.Tensanpham)
                    .HasMaxLength(100)
                    .HasColumnName("TENSANPHAM");

                entity.Property(e => e.Trangthai).HasColumnName("TRANGTHAI");

                entity.HasOne(d => d.MaloaisanphamNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.Maloaisanpham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SP_LSP");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.Masize);

                entity.ToTable("SIZE");

                entity.Property(e => e.Masize).HasColumnName("MASIZE");

                entity.Property(e => e.Mota)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOTA");

                entity.Property(e => e.Tensize)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TENSIZE");
            });

            modelBuilder.Entity<Taikhoannhanvien>(entity =>
            {
                entity.HasKey(e => e.Mataikhoan)
                    .HasName("PK__TAIKHOAN__2ED8B517D6989033");

                entity.ToTable("TAIKHOANNHANVIEN");

                entity.HasIndex(e => e.Manhanvien, "UQ__TAIKHOAN__7E46DD90EB3E70B5")
                    .IsUnique();

                entity.Property(e => e.Mataikhoan).HasColumnName("MATAIKHOAN");

                entity.Property(e => e.Manhanvien).HasColumnName("MANHANVIEN");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MATKHAU");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("NGAYTAO");

                entity.Property(e => e.Tentaikhoan)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TENTAIKHOAN");

                entity.Property(e => e.Trangthai).HasColumnName("TRANGTHAI");

                entity.HasOne(d => d.ManhanvienNavigation)
                    .WithOne(p => p.Taikhoannhanvien)
                    .HasForeignKey<Taikhoannhanvien>(d => d.Manhanvien)
                    .HasConstraintName("FK_TK_NV");
            });

            modelBuilder.Entity<ViewDsctsp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_DSCTSP");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HINHANH");

                entity.Property(e => e.Khuyenmai).HasColumnName("KHUYENMAI");

                entity.Property(e => e.Machitietsp).HasColumnName("MACHITIETSP");

                entity.Property(e => e.Mamau).HasColumnName("MAMAU");

                entity.Property(e => e.Masanpham).HasColumnName("MASANPHAM");

                entity.Property(e => e.Masize).HasColumnName("MASIZE");

                entity.Property(e => e.Mavach)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MAVACH");

                entity.Property(e => e.Mota).HasColumnName("MOTA");

                entity.Property(e => e.Tenmau)
                    .HasMaxLength(50)
                    .HasColumnName("TENMAU");

                entity.Property(e => e.Tensanpham)
                    .HasMaxLength(100)
                    .HasColumnName("TENSANPHAM");

                entity.Property(e => e.Tensize)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TENSIZE");
            });

            modelBuilder.Entity<VwCthd>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_CTHD");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Machitietsp).HasColumnName("MACHITIETSP");

                entity.Property(e => e.Mahoadon).HasColumnName("MAHOADON");

                entity.Property(e => e.Mavach)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MAVACH");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Tenmau)
                    .HasMaxLength(50)
                    .HasColumnName("TENMAU");

                entity.Property(e => e.Tensanpham)
                    .HasMaxLength(100)
                    .HasColumnName("TENSANPHAM");

                entity.Property(e => e.Tensize)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TENSIZE");

                entity.Property(e => e.Thanhtien).HasColumnName("THANHTIEN");
            });

            modelBuilder.Entity<VwHoaDon>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_HoaDon");

                entity.Property(e => e.Mahoadon).HasColumnName("MAHOADON");

                entity.Property(e => e.Mota).HasColumnName("MOTA");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("NGAYTAO");

                entity.Property(e => e.Tenkhachhang)
                    .HasMaxLength(50)
                    .HasColumnName("TENKHACHHANG");

                entity.Property(e => e.Tennhanvien)
                    .HasMaxLength(50)
                    .HasColumnName("TENNHANVIEN");

                entity.Property(e => e.Thanhtien).HasColumnName("THANHTIEN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
