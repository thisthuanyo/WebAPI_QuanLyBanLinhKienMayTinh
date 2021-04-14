using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_LKMT.Models;

namespace WebAPI_LKMT.Controllers
{
    public class LoaiLinhKienController : ApiController
    {
        private QLKTModel dc = new QLKTModel();
        public IHttpActionResult getDanhSachLoaiLK()
        {
            var kq = dc.LoaiLKs.Select(x => new CLoaiLK
            {
                MaLoai = x.MaLoai,
                status = x.status,
                TenLoai = x.TenLoai,
            });
            return Ok(kq.ToList());
        }
        public IHttpActionResult postThemLoaiLinhKien(CLoaiLK llk)
        {
            if (ModelState.IsValid == false) return BadRequest();
            LoaiLK a = new LoaiLK
            {
                TenLoai = llk.TenLoai,
                status = llk.status,
                MaLoai = llk.MaLoai
            };
            LoaiLK llkTemp = dc.LoaiLKs.Find(a.MaLoai);
            if (llkTemp == null)
            {
                dc.LoaiLKs.Add(a);
                dc.SaveChanges();
            }
            else return BadRequest();
            return Ok();
        }
        public IHttpActionResult deleteLoaiLinhKien(string id)
        {
            LoaiLK llk = dc.LoaiLKs.Find(id);
            if (llk != null)
            {
                if(llk.LinhKiens.Count > 0)
                {
                    return BadRequest();
                } else
                {
                    dc.LoaiLKs.Remove(llk);
                    dc.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        public IHttpActionResult putLoaiLinhKien(CLoaiLK llk)
        {
            if (ModelState.IsValid == false) return BadRequest();
            LoaiLK llkTemp = dc.LoaiLKs.Find(llk.MaLoai);
            if (llkTemp != null)
            {
                llkTemp.TenLoai = llk.TenLoai;
                llkTemp.status = llk.status;
                dc.SaveChanges();
            }
            else return NotFound();
            return Ok();
        }
    }
}
