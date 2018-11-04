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
    public class VIPHAMsController : ApiController
    {
        private QuanLiThuVienSEntities db = new QuanLiThuVienSEntities();

        // GET: api/VIPHAMs
        public IQueryable<VIPHAM> GetVIPHAMs()
        {
            return db.VIPHAMs;
        }

        // GET: api/VIPHAMs/5
        [ResponseType(typeof(VIPHAM))]
        public IHttpActionResult GetVIPHAM(string id)
        {
            VIPHAM vIPHAM = db.VIPHAMs.Find(id);
            if (vIPHAM == null)
            {
                return NotFound();
            }

            return Ok(vIPHAM);
        }

        // PUT: api/VIPHAMs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVIPHAM(string id, VIPHAM vIPHAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vIPHAM.MaDG)
            {
                return BadRequest();
            }

            db.Entry(vIPHAM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VIPHAMExists(id))
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

        // POST: api/VIPHAMs
        [ResponseType(typeof(VIPHAM))]
        public IHttpActionResult PostVIPHAM(VIPHAM vIPHAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VIPHAMs.Add(vIPHAM);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VIPHAMExists(vIPHAM.MaDG))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vIPHAM.MaDG }, vIPHAM);
        }

        // DELETE: api/VIPHAMs/5
        [ResponseType(typeof(VIPHAM))]
        public IHttpActionResult DeleteVIPHAM(string id)
        {
            VIPHAM vIPHAM = db.VIPHAMs.Find(id);
            if (vIPHAM == null)
            {
                return NotFound();
            }

            db.VIPHAMs.Remove(vIPHAM);
            db.SaveChanges();

            return Ok(vIPHAM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VIPHAMExists(string id)
        {
            return db.VIPHAMs.Count(e => e.MaDG == id) > 0;
        }
    }
}