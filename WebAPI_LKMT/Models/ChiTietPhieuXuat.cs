namespace WebAPI_LKMT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuXuat")]
    public partial class ChiTietPhieuXuat
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaPX { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MaLK { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public virtual LinhKien LinhKien { get; set; }

        public virtual PhieuXuat PhieuXuat { get; set; }
    }
}
