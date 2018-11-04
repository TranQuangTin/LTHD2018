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
    public class DOCGIAsController : ApiController
    {
        private QuanLiThuVienSEntities db = new QuanLiThuVienSEntities();

        // GET: api/DOCGIAs
        public IQueryable<DOCGIA> GetDOCGIAs()
        {
            return db.DOCGIAs;
        }

        // GET: api/DOCGIAs/5
        [ResponseType(typeof(DOCGIA))]
        public IHttpActionResult GetDOCGIA(string id)
        {
            DOCGIA dOCGIA = db.DOCGIAs.Find(id);
            if (dOCGIA == null)
            {
                return NotFound();
            }

            return Ok(dOCGIA);
        }

        // PUT: api/DOCGIAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDOCGIA(string id, DOCGIA dOCGIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dOCGIA.MaDG)
            {
                return BadRequest();
            }

            db.Entry(dOCGIA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DOCGIAExists(id))
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

        // POST: api/DOCGIAs
        [ResponseType(typeof(DOCGIA))]
        public IHttpActionResult PostDOCGIA(DOCGIA dOCGIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DOCGIAs.Add(dOCGIA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DOCGIAExists(dOCGIA.MaDG))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dOCGIA.MaDG }, dOCGIA);
        }

        // DELETE: api/DOCGIAs/5
        [ResponseType(typeof(DOCGIA))]
        public IHttpActionResult DeleteDOCGIA(string id)
        {
            DOCGIA dOCGIA = db.DOCGIAs.Find(id);
            if (dOCGIA == null)
            {
                return NotFound();
            }

            db.DOCGIAs.Remove(dOCGIA);
            db.SaveChanges();

            return Ok(dOCGIA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DOCGIAExists(string id)
        {
            return db.DOCGIAs.Count(e => e.MaDG == id) > 0;
        }
    }
}