using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_LKMT.Models;
namespace WebAPI_LKMT.Controllers
{
    public class NhanVienController : ApiController
    {
        private QLKTModel dc = new QLKTModel();
        public IHttpActionResult getCheckLogin(string username)
        {
            NhanVien nv = dc.NhanViens.Where(x => x.UserName == username).SingleOrDefault();
            if (nv == null) return NotFound();
            CNhanVien a = new CNhanVien
            {
                ChucVu = nv.ChucVu,
                DiaChi = nv.DiaChi,
                GioiTinh = nv.GioiTinh,
                MaNV = nv.MaNV,
                NamSinh = nv.NamSinh,
                Pass = nv.Pass,
                SoDT = nv.SoDT,
                status = nv.status,
                TenNV = nv.TenNV,
                UserName = nv.UserName,
            };
            return Ok(a);
        }
        public IHttpActionResult getDanhSachNhanVien()
        {
            var kq = dc.NhanViens.Select(x => new Models.CNhanVien
            {
                ChucVu = x.ChucVu,
                DiaChi = x.DiaChi,
                GioiTinh = x.GioiTinh,
                MaNV = x.MaNV,
                NamSinh = x.NamSinh,
                Pass = x.Pass,
                SoDT = x.SoDT,
                status = x.status,
                TenNV = x.TenNV,
                UserName = x.UserName,
                
            });
            return Ok(kq.ToList());
        }
    }
}
