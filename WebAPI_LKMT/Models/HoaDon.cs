namespace WebAPI_LKMT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int MaHD { get; set; }

        [Required]
        [StringLength(50)]
        public string MaKH { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLapHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiao { get; set; }

        public double? TongTien { get; set; }

        public bool? status { get; set; }

        public int? MaPX { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual PhieuXuat PhieuXuat { get; set; }
    }
}
