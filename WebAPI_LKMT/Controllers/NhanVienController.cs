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
            try
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
            catch (Exception)
            {
                return BadRequest();
            }
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
        public IHttpActionResult postThemNhanVien(CNhanVien nv)
        {
            if (ModelState.IsValid == false) return BadRequest();
            NhanVien a = new NhanVien
            {
                TenNV = nv.TenNV,
                status = nv.status,
                MaNV = nv.MaNV,
                ChucVu = nv.ChucVu,
                DiaChi = nv.DiaChi,
                GioiTinh = nv.GioiTinh,
                HoaDons = new List<HoaDon>(),
                PhieuXuats = new List<PhieuXuat>(),
                NamSinh = nv.NamSinh,
                Pass = nv.Pass,
                SoDT = nv.SoDT,
                UserName = nv.UserName
            };
            NhanVien nvTemp = dc.NhanViens.Find(a.MaNV);
            NhanVien nvTemp2 = dc.NhanViens.Where(x => x.UserName == nv.UserName).SingleOrDefault();
            if (nvTemp == null && nvTemp2 == null)
            {
                dc.NhanViens.Add(a);
                dc.SaveChanges();
            }
            else return BadRequest();
            return Ok();
        }
        public IHttpActionResult deleteNhanVien(string id)
        {
            NhanVien nv = dc.NhanViens.Find(id);
            if (nv != null)
            {
                dc.NhanViens.Remove(nv);
                dc.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        public IHttpActionResult putNhanVien(CNhanVien nv)
        {
            if (ModelState.IsValid == false) return BadRequest();
            NhanVien nvTemp = dc.NhanViens.Find(nv.MaNV);
            if (nvTemp != null)
            {
                nvTemp.TenNV = nv.TenNV;
                nvTemp.status = nv.status;
                nvTemp.ChucVu = nv.ChucVu;
                nvTemp.DiaChi = nv.DiaChi;
                nvTemp.GioiTinh = nv.GioiTinh;
                nvTemp.NamSinh = nv.NamSinh;
                nvTemp.Pass = nv.Pass;
                nvTemp.SoDT = nv.SoDT;
                nvTemp.UserName = nv.UserName;
                dc.SaveChanges();
            }
            else return NotFound();
            return Ok();
        }
    }
}
