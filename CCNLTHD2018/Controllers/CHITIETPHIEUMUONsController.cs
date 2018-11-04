using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CCNLTHD2018.Data;

namespace CCNLTHD2018.Controllers
{
    public class CHITIETPHIEUMUONsController : ApiController
    {
        private QuanLiThuVienSEntities db = new QuanLiThuVienSEntities();

        // GET: api/CHITIETPHIEUMUONs
        public IQueryable<CHITIETPHIEUMUON> GetCHITIETPHIEUMUONs()
        {
            return db.CHITIETPHIEUMUONs;
        }

        // GET: api/CHITIETPHIEUMUONs/5
        [ResponseType(typeof(CHITIETPHIEUMUON))]
        public IHttpActionResult GetCHITIETPHIEUMUON(string id)
        {
            CHITIETPHIEUMUON cHITIETPHIEUMUON = db.CHITIETPHIEUMUONs.Find(id);
            if (cHITIETPHIEUMUON == null)
            {
                return NotFound();
            }

            return Ok(cHITIETPHIEUMUON);
        }

        // PUT: api/CHITIETPHIEUMUONs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCHITIETPHIEUMUON(string id, CHITIETPHIEUMUON cHITIETPHIEUMUON)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cHITIETPHIEUMUON.SoPhieu)
            {
                return BadRequest();
            }

            db.Entry(cHITIETPHIEUMUON).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CHITIETPHIEUMUONExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CHITIETPHIEUMUONs
        [ResponseType(typeof(CHITIETPHIEUMUON))]
        public IHttpActionResult PostCHITIETPHIEUMUON(CHITIETPHIEUMUON cHITIETPHIEUMUON)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CHITIETPHIEUMUONs.Add(cHITIETPHIEUMUON);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CHITIETPHIEUMUONExists(cHITIETPHIEUMUON.SoPhieu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cHITIETPHIEUMUON.SoPhieu }, cHITIETPHIEUMUON);
        }

        // DELETE: api/CHITIETPHIEUMUONs/5
        [ResponseType(typeof(CHITIETPHIEUMUON))]
        public IHttpActionResult DeleteCHITIETPHIEUMUON(string id)
        {
            CHITIETPHIEUMUON cHITIETPHIEUMUON = db.CHITIETPHIEUMUONs.Find(id);
            if (cHITIETPHIEUMUON == null)
            {
                return NotFound();
            }

            db.CHITIETPHIEUMUONs.Remove(cHITIETPHIEUMUON);
            db.SaveChanges();

            return Ok(cHITIETPHIEUMUON);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CHITIETPHIEUMUONExists(string id)
        {
            return db.CHITIETPHIEUMUONs.Count(e => e.SoPhieu == id) > 0;
        }
    }
}