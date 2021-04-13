using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_LKMT.Models;
namespace WebAPI_LKMT.Controllers
{
    public class LinhKienController : ApiController
    {
        private QLKTModel dc = new QLKTModel();
        public IHttpActionResult getDanhSachLinhKien()
        {
            var kq = dc.LinhKiens.Select(x => new CLinhKien
            {
                MaLK= x.MaLK,
                TenLK = x.TenLK,
                MaNSX = x.MaNSX,
                MaLoai = x.MaLoai,
                GiaBan = x.GiaBan,
                status = x.status,
                
            });
            return Ok(kq.ToList());
        }

        public IHttpActionResult getChiTietLinhKien(string malk)
        {
            var kq = dc.LinhKiens.Find(malk);
            if (kq == null) return BadRequest();
            if (kq.status == false) return BadRequest();
            CLinhKien lk = new CLinhKien()
            {
                MaLK = kq.MaLK,
                TenLK = kq.TenLK,
                MaLoai = kq.MaLoai,
                MaNSX = kq.MaNSX,
                GiaBan = kq.GiaBan,
                status = kq.status
            };

            return Ok(lk);
        }

        public IHttpActionResult postLinhKien(CLinhKien lk)
        {
            if (ModelState.IsValid == false) return BadRequest();
            var linhkien = dc.LinhKiens.Find(lk.MaLK);
            if (linhkien != null) return BadRequest();
            LinhKien temp_lk = new LinhKien()
            {
                MaLK = lk.MaLK,
                TenLK = lk.TenLK,
                MaLoai = lk.MaLoai,
                MaNSX = lk.MaNSX,
                GiaBan = lk.GiaBan,
                status = true,
                LoaiLK = dc.LoaiLKs.Find(lk.MaLoai),
                NhaSX = dc.NhaSXes.Find(lk.MaNSX),
            };
            dc.LinhKiens.Add(temp_lk);
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult putLinhKien(CLinhKien lk)
        {
            if (ModelState.IsValid == false) return BadRequest();
            LinhKien temp_lk = dc.LinhKiens.Find(lk.MaLK);
            if (temp_lk == null) return NotFound();
            temp_lk.MaLoai = lk.MaLoai;
            temp_lk.MaNSX = lk.MaNSX;
            temp_lk.TenLK = lk.TenLK;
            temp_lk.GiaBan = lk.GiaBan;
            temp_lk.LoaiLK = dc.LoaiLKs.Find(lk.MaLoai);
            temp_lk.NhaSX = dc.NhaSXes.Find(lk.MaNSX);

            dc.SaveChanges();
            return Ok();

        }

        public IHttpActionResult deleteLinhKien(string malk)
        {
            LinhKien lk = dc.LinhKiens.Find(malk);
            if (lk == null) return BadRequest();
            dc.LinhKiens.Remove(lk);
            dc.SaveChanges();
            return Ok();
        }
    }
}
