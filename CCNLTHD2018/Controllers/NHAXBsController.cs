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
    public class NHAXBsController : ApiController
    {
        private QuanLiThuVienSEntities db = new QuanLiThuVienSEntities();

        // GET: api/NHAXBs
        public IQueryable<NHAXB> GetNHAXBs()
        {
            return db.NHAXBs;
        }

        // GET: api/NHAXBs/5
        [ResponseType(typeof(NHAXB))]
        public IHttpActionResult GetNHAXB(string id)
        {
            NHAXB nHAXB = db.NHAXBs.Find(id);
            if (nHAXB == null)
            {
                return NotFound();
            }

            return Ok(nHAXB);
        }

        // PUT: api/NHAXBs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNHAXB(string id, NHAXB nHAXB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nHAXB.MaNXB)
            {
                return BadRequest();
            }

            db.Entry(nHAXB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NHAXBExists(id))
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

        // POST: api/NHAXBs
        [ResponseType(typeof(NHAXB))]
        public IHttpActionResult PostNHAXB(NHAXB nHAXB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NHAXBs.Add(nHAXB);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NHAXBExists(nHAXB.MaNXB))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nHAXB.MaNXB }, nHAXB);
        }

        // DELETE: api/NHAXBs/5
        [ResponseType(typeof(NHAXB))]
        public IHttpActionResult DeleteNHAXB(string id)
        {
            NHAXB nHAXB = db.NHAXBs.Find(id);
            if (nHAXB == null)
            {
                return NotFound();
            }

            db.NHAXBs.Remove(nHAXB);
            db.SaveChanges();

            return Ok(nHAXB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NHAXBExists(string id)
        {
            return db.NHAXBs.Count(e => e.MaNXB == id) > 0;
        }
    }
}