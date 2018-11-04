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
    public class TINHTRANGsController : ApiController
    {
        private QuanLiThuVienSEntities db = new QuanLiThuVienSEntities();

        // GET: api/TINHTRANGs
        public IQueryable<TINHTRANG> GetTINHTRANGs()
        {
            return db.TINHTRANGs;
        }

        // GET: api/TINHTRANGs/5
        [ResponseType(typeof(TINHTRANG))]
        public IHttpActionResult GetTINHTRANG(string id)
        {
            TINHTRANG tINHTRANG = db.TINHTRANGs.Find(id);
            if (tINHTRANG == null)
            {
                return NotFound();
            }

            return Ok(tINHTRANG);
        }

        // PUT: api/TINHTRANGs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTINHTRANG(string id, TINHTRANG tINHTRANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tINHTRANG.MaSach)
            {
                return BadRequest();
            }

            db.Entry(tINHTRANG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TINHTRANGExists(id))
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

        // POST: api/TINHTRANGs
        [ResponseType(typeof(TINHTRANG))]
        public IHttpActionResult PostTINHTRANG(TINHTRANG tINHTRANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TINHTRANGs.Add(tINHTRANG);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TINHTRANGExists(tINHTRANG.MaSach))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tINHTRANG.MaSach }, tINHTRANG);
        }

        // DELETE: api/TINHTRANGs/5
        [ResponseType(typeof(TINHTRANG))]
        public IHttpActionResult DeleteTINHTRANG(string id)
        {
            TINHTRANG tINHTRANG = db.TINHTRANGs.Find(id);
            if (tINHTRANG == null)
            {
                return NotFound();
            }

            db.TINHTRANGs.Remove(tINHTRANG);
            db.SaveChanges();

            return Ok(tINHTRANG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TINHTRANGExists(string id)
        {
            return db.TINHTRANGs.Count(e => e.MaSach == id) > 0;
        }
    }
}