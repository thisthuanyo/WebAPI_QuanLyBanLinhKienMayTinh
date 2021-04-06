using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_LKMT.Models;

namespace WebAPI_LKMT.Controllers
{
    public class NhaSanXuatController : ApiController
    {
        private QLKTModel dc = new QLKTModel();
        public IHttpActionResult getDanhSachNSX()
        {
            var kq = dc.NhaSXes.Select(x => new CNhaSX
            {
                MaNhaSX = x.MaNhaSX,
                status = x.status,
                TenNhaSX = x.TenNhaSX,
            });
            return Ok(kq.ToList());
        }
        public IHttpActionResult postThemNhaSanXuat(CNhaSX nsx)
        {
            if (ModelState.IsValid == false) return BadRequest();
            NhaSX a = new NhaSX
            {
                TenNhaSX = nsx.TenNhaSX,
                status = nsx.status,
                MaNhaSX = nsx.MaNhaSX
            };
            NhaSX nsxTemp = dc.NhaSXes.Find(a.MaNhaSX);
            if (nsxTemp == null)
            {
                dc.NhaSXes.Add(a);
                dc.SaveChanges();
            }
            else return BadRequest();
            return Ok();
        }
        public IHttpActionResult deleteNhaSanXuat(string id)
        {
            NhaSX nsx = dc.NhaSXes.Find(id);
            if(nsx != null)
            {
                dc.NhaSXes.Remove(nsx);
                dc.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        public IHttpActionResult putNhaSanXuat(CNhaSX nsx)
        {
            if (ModelState.IsValid == false) return BadRequest();
            NhaSX nsxTemp = dc.NhaSXes.Find(nsx.MaNhaSX);
            if (nsxTemp != null)
            {
                nsxTemp.TenNhaSX = nsx.TenNhaSX;
                nsxTemp.status = nsx.status;
                dc.SaveChanges();
            }
            else return NotFound();
            return Ok();
        }
    }
}
