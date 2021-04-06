using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_LKMT.Models
{
    public class CLoaiLK
    {
        public string MaLoai { get; set; }

        public string TenLoai { get; set; }

        public bool? status { get; set; }

        public virtual ICollection<CLinhKien> LinhKiens { get; set; }
    }
}