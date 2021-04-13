using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_LKMT.Models;

namespace WebAPI_LKMT.Controllers
{
    public class PhieuXuatController : ApiController
    {
        private Models.QLKTModel dc = new Models.QLKTModel();
        public IHttpActionResult getDSPhieuXuat()
        {
            var kq = dc.PhieuXuats.Select(x => new Models.CPhieuXuat
            {
                MaKH = x.MaKH,
                MaNV = x.MaNV,
                MaPX = x.MaPX,
                NgayXuat = x.NgayXuat,
                status = x.status,
                TongTien = x.TongTien
            });
            return Ok(kq.ToList());
        }
        public IHttpActionResult getPhieuXuat(String id)
        {
            Models.PhieuXuat pxTemp = dc.PhieuXuats.Find(id);
            if (pxTemp == null) return NotFound();
            Models.CPhieuXuat px = new Models.CPhieuXuat
            {
                MaKH = pxTemp.MaKH,
                MaNV = pxTemp.MaNV,
                MaPX = pxTemp.MaPX,
                NgayXuat = pxTemp.NgayXuat,
                status = pxTemp.status,
                TongTien = pxTemp.TongTien,
                ChiTietPhieuXuats = new List<CChiTietPhieuXuat>(),
            };
            foreach (Models.ChiTietPhieuXuat t in pxTemp.ChiTietPhieuXuats)
            {
                Models.CChiTietPhieuXuat ct = new Models.CChiTietPhieuXuat
                {
                    DonGia = t.DonGia,
                    MaLK = t.MaLK,
                    MaPX = t.MaPX,
                    SoLuong = t.SoLuong,
                    LinhKien = new Models.CLinhKien
                    {
                        MaLK = t.LinhKien.MaLK,
                        TenLK = t.LinhKien.TenLK,
                        GiaBan = t.LinhKien.GiaBan,
                        MaLoai = t.LinhKien.MaLoai,
                        MaNSX = t.LinhKien.MaNSX,
                        status = t.LinhKien.status
                    }         
                };
                px.ChiTietPhieuXuats.Add(ct);
            }
            return Ok(px);
        }
        public IHttpActionResult postThemPX(Models.CPhieuXuat px)
        {
            if (ModelState.IsValid == false) return BadRequest();
            Models.PhieuXuat a = new Models.PhieuXuat
            {
                MaKH = px.MaKH,
                MaNV = px.MaNV,
                MaPX = px.MaPX,
                NgayXuat = px.NgayXuat,
                status = px.status,
                TongTien = px.TongTien,
                ChiTietPhieuXuats = px.ChiTietPhieuXuats.Select(x => new ChiTietPhieuXuat
                {
                    DonGia = x.DonGia,
                    MaLK = x.MaLK,
                    MaPX = x.MaPX,
                    SoLuong = x.SoLuong,
                }).ToList()
            };
            Models.PhieuXuat b = dc.PhieuXuats.Find(a.MaPX);
            if (b != null) return BadRequest();
            dc.PhieuXuats.Add(a);
            dc.SaveChanges();
            return Ok();
        }
    }
}
