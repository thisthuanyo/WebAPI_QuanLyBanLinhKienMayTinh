namespace WebAPI_LKMT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuXuat")]
    public partial class PhieuXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuXuat()
        {
            ChiTietPhieuXuats = new HashSet<ChiTietPhieuXuat>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int MaPX { get; set; }

        [StringLength(50)]
        public string MaKH { get; set; }

        [StringLength(50)]
        public string MaNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXuat { get; set; }

        public double? TongTien { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
