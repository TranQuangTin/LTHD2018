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
    public class SACHesController : ApiController
    {
        private QuanLiThuVienSEntities db = new QuanLiThuVienSEntities();

        // GET: api/SACHes
        public IQueryable<SACH> GetSACHes()
        {
            return db.SACHes.AsQueryable();
        }

        // GET: api/SACHes/5
        [ResponseType(typeof(SACH))]
        public IHttpActionResult GetSACH(string id)
        {
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return NotFound();
            }

            return Ok(sACH);
        }

        // PUT: api/SACHes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSACH(string id, SACH sACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sACH.MaSach)
            {
                return BadRequest();
            }

            db.Entry(sACH).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SACHExists(id))
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

        // POST: api/SACHes
        [ResponseType(typeof(SACH))]
        public IHttpActionResult PostSACH(SACH sACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SACHes.Add(sACH);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SACHExists(sACH.MaSach))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sACH.MaSach }, sACH);
        }

        // DELETE: api/SACHes/5
        [ResponseType(typeof(SACH))]
        public IHttpActionResult DeleteSACH(string id)
        {
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return NotFound();
            }

            db.SACHes.Remove(sACH);
            db.SaveChanges();

            return Ok(sACH);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SACHExists(string id)
        {
            return db.SACHes.Count(e => e.MaSach == id) > 0;
        }
    }
}