namespace WebAPI_LKMT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
            PhieuXuats = new HashSet<PhieuXuat>();
        }

        [Key]
        [StringLength(50)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNV { get; set; }

        public int NamSinh { get; set; }

        public bool? GioiTinh { get; set; }

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string SoDT { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Pass { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        public bool? status { get; set; }

        public virtual ChucVu ChucVu1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }
    }
}
