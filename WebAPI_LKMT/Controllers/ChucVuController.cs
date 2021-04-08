using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_LKMT.Controllers
{
    public class ChucVuController : ApiController
    {
        private Models.QLKTModel dc = new Models.QLKTModel();
        public IHttpActionResult getDanhSachChucVu()
        {
            var kq = dc.ChucVus.Select(x => new Models.CChucVu
            {
                MaCV = x.MaCV,
                TenCV = x.TenCV,
                status = x.status,
            });
            return Ok(kq.ToList());
        }
        public IHttpActionResult getChucVu(string id)
        {
            Models.ChucVu cv = dc.ChucVus.Find(id);
            if (cv == null) return NotFound();
            Models.CChucVu chucvu = new Models.CChucVu
            {
                MaCV = cv.MaCV,
                TenCV = cv.TenCV,
                status = cv.status
            };
            return Ok(chucvu);
        }

    }
}
