namespace WebAPI_LKMT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
            PhieuXuats = new HashSet<PhieuXuat>();
        }

        [Key]
        [StringLength(50)]
        public string MaKH { get; set; }

        [Required]
        [StringLength(100)]
        public string TenKh { get; set; }

        public bool GioiTinh { get; set; }

        public int NamSinh { get; set; }

        [Required]
        [StringLength(255)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(50)]
        public string SoDT { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }
    }
}
