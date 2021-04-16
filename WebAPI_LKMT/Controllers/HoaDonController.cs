using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_LKMT.Controllers
{
    public class HoaDonController : ApiController
    {
        private Models.QLKTModel dc = new Models.QLKTModel();
        public IHttpActionResult getDSHoaDon()
        {
            var kq = dc.HoaDons.Select(x => new Models.CHoaDon
            {
                MaKH = x.MaKH,
                MaNV = x.MaNV,
                MaPX = x.MaPX,
                status = x.status,
                TongTien = x.TongTien,
                MaHD = x.MaHD,
                NgayGiao = x.NgayGiao,
                NgayLapHD = x.NgayLapHD,
                
            });
            return Ok(kq.ToList());
        }
        public IHttpActionResult getHoaDon(int id)
        {
            Models.HoaDon hdTemp = dc.HoaDons.Find(id);
            if (hdTemp == null) return NotFound();
            Models.CHoaDon hd = new Models.CHoaDon
            {
                MaKH = hdTemp.MaKH,
                MaNV = hdTemp.MaNV,
                MaPX = hdTemp.MaPX,
                status = hdTemp.status,
                TongTien = hdTemp.TongTien,
                MaHD = hdTemp.MaHD,
                NgayGiao = hdTemp.NgayGiao,
                NgayLapHD = hdTemp.NgayLapHD
            };
            return Ok(hd);
        }
        public IHttpActionResult getHoaDonbyMaPX(int mapx)
        {
            Models.HoaDon hdTemp = dc.HoaDons.Where(x=>x.MaPX == mapx).SingleOrDefault();
            if (hdTemp == null) return NotFound();
            Models.CHoaDon hd = new Models.CHoaDon
            {
                MaKH = hdTemp.MaKH,
                MaNV = hdTemp.MaNV,
                MaPX = hdTemp.MaPX,
                status = hdTemp.status,
                TongTien = hdTemp.TongTien,
                MaHD = hdTemp.MaHD,
                NgayGiao = hdTemp.NgayGiao,
                NgayLapHD = hdTemp.NgayLapHD
            };
            return Ok(hd);
        }
        public IHttpActionResult postThemHoaDon(Models.CHoaDon hd)
        {
            if (ModelState.IsValid == false) return BadRequest();
            Models.HoaDon a = new Models.HoaDon
            {
                MaKH = hd.MaKH,
                MaNV = hd.MaNV,
                status = hd.status,
                TongTien = hd.TongTien,
                MaHD = hd.MaHD,
                NgayLapHD = hd.NgayLapHD,
                NgayGiao = hd.NgayGiao,
                MaPX = hd.MaPX,
            };
            Models.HoaDon b = dc.HoaDons.Find(a.MaPX);
            if (b != null) return BadRequest();
            dc.HoaDons.Add(a);
            dc.SaveChanges();
            return Ok();
        }
    }
}
