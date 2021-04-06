namespace WebAPI_LKMT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiLK")]
    public partial class LoaiLK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiLK()
        {
            LinhKiens = new HashSet<LinhKien>();
        }

        [Key]
        [StringLength(50)]
        public string MaLoai { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoai { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LinhKien> LinhKiens { get; set; }
    }
}
