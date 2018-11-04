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
    public class TRASACHesController : ApiController
    {
        private QuanLiThuVienSEntities db = new QuanLiThuVienSEntities();

        // GET: api/TRASACHes
        public IQueryable<TRASACH> GetTRASACHes()
        {
            return db.TRASACHes;
        }

        // GET: api/TRASACHes/5
        [ResponseType(typeof(TRASACH))]
        public IHttpActionResult GetTRASACH(string id)
        {
            TRASACH tRASACH = db.TRASACHes.Find(id);
            if (tRASACH == null)
            {
                return NotFound();
            }

            return Ok(tRASACH);
        }

        // PUT: api/TRASACHes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTRASACH(string id, TRASACH tRASACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tRASACH.SoPhieu)
            {
                return BadRequest();
            }

            db.Entry(tRASACH).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TRASACHExists(id))
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

        // POST: api/TRASACHes
        [ResponseType(typeof(TRASACH))]
        public IHttpActionResult PostTRASACH(TRASACH tRASACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TRASACHes.Add(tRASACH);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TRASACHExists(tRASACH.SoPhieu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tRASACH.SoPhieu }, tRASACH);
        }

        // DELETE: api/TRASACHes/5
        [ResponseType(typeof(TRASACH))]
        public IHttpActionResult DeleteTRASACH(string id)
        {
            TRASACH tRASACH = db.TRASACHes.Find(id);
            if (tRASACH == null)
            {
                return NotFound();
            }

            db.TRASACHes.Remove(tRASACH);
            db.SaveChanges();

            return Ok(tRASACH);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TRASACHExists(string id)
        {
            return db.TRASACHes.Count(e => e.SoPhieu == id) > 0;
        }
    }
}