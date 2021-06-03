using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_LKMT.Models;

namespace WebAPI_LKMT.Controllers
{
    public class KhachHangController : ApiController
    {
        private QLKTModel dc = new QLKTModel();
        public IHttpActionResult getDanhSachKhacHang()
        {
            var kq = dc.KhachHangs.Select(x => new Models.CKhachHang
            {
                MaKH = x.MaKH,
                TenKh = x.TenKh,
                DiaChi = x.DiaChi,
                GioiTinh = x.GioiTinh,
                NamSinh = x.NamSinh,
                SoDT = x.SoDT,
                status = x.status,
            });
            return Ok(kq.ToList());
        }
        public IHttpActionResult postThemKhachHang(CKhachHang x)
        {
            if (ModelState.IsValid == false) return BadRequest();
            KhachHang a = new KhachHang
            {
                MaKH = x.MaKH,
                TenKh = x.TenKh,
                DiaChi = x.DiaChi,
                GioiTinh = x.GioiTinh,
                NamSinh = x.NamSinh,
                SoDT = x.SoDT,
                status = x.status,
            };
            KhachHang khTemp = dc.KhachHangs.Find(a.MaKH);
            if (khTemp == null)
            {
                dc.KhachHangs.Add(a);
                dc.SaveChanges();
            }
            else return BadRequest();
            return Ok();
        }
        public IHttpActionResult deleteKhachHang(string id)
        {
            KhachHang kh = dc.KhachHangs.Find(id);
            if (kh != null)
            {
                if(kh.PhieuXuats.Count > 0 || kh.HoaDons.Count >0)
                {
                    return BadRequest();
                }
                else
                {
                    dc.KhachHangs.Remove(kh);
                    dc.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        public IHttpActionResult putKhachHang(CKhachHang x)
        {
            if (ModelState.IsValid == false) return BadRequest();
            KhachHang khTemp = dc.KhachHangs.Find(x.MaKH);
            if (khTemp != null)
            {
                khTemp.TenKh = x.TenKh;
                khTemp.DiaChi = x.DiaChi;
                khTemp.GioiTinh = x.GioiTinh;
                khTemp.NamSinh = x.NamSinh;
                khTemp.SoDT = x.SoDT;
                khTemp.status = x.status;
                dc.SaveChanges();
            }
            else return NotFound();
            return Ok();
        }
    }
}
