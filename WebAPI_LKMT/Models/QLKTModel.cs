namespace WebAPI_LKMT.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLKTModel : DbContext
    {
        public QLKTModel()
            : base("name=QLKTModel")
        {
        }

        public virtual DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LinhKien> LinhKiens { get; set; }
        public virtual DbSet<LoaiLK> LoaiLKs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhaSX> NhaSXes { get; set; }
        public virtual DbSet<PhieuXuat> PhieuXuats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietPhieuXuat>()
                .Property(e => e.MaLK)
                .IsUnicode(false);

            modelBuilder.Entity<ChucVu>()
                .Property(e => e.MaCV)
                .IsUnicode(false);

            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.ChucVu1)
                .HasForeignKey(e => e.ChucVu);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LinhKien>()
                .Property(e => e.MaLK)
                .IsUnicode(false);

            modelBuilder.Entity<LinhKien>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<LinhKien>()
                .Property(e => e.MaNSX)
                .IsUnicode(false);

            modelBuilder.Entity<LinhKien>()
                .HasMany(e => e.ChiTietPhieuXuats)
                .WithRequired(e => e.LinhKien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiLK>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiLK>()
                .HasMany(e => e.LinhKiens)
                .WithRequired(e => e.LoaiLK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SoDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.ChucVu)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaSX>()
                .Property(e => e.MaNhaSX)
                .IsUnicode(false);

            modelBuilder.Entity<NhaSX>()
                .HasMany(e => e.LinhKiens)
                .WithRequired(e => e.NhaSX)
                .HasForeignKey(e => e.MaNSX)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuXuat>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuat>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuat>()
                .HasMany(e => e.ChiTietPhieuXuats)
                .WithRequired(e => e.PhieuXuat)
                .WillCascadeOnDelete(false);
        }
    }
}
