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
    public class MUONSACHesController : ApiController
    {
        private QuanLiThuVienSEntities db = new QuanLiThuVienSEntities();

        // GET: api/MUONSACHes
        public IQueryable<MUONSACH> GetMUONSACHes()
        {
            return db.MUONSACHes;
        }

        // GET: api/MUONSACHes/5
        [ResponseType(typeof(MUONSACH))]
        public IHttpActionResult GetMUONSACH(string id)
        {
            MUONSACH mUONSACH = db.MUONSACHes.Find(id);
            if (mUONSACH == null)
            {
                return NotFound();
            }

            return Ok(mUONSACH);
        }

        // PUT: api/MUONSACHes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMUONSACH(string id, MUONSACH mUONSACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mUONSACH.SoPhieu)
            {
                return BadRequest();
            }

            db.Entry(mUONSACH).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MUONSACHExists(id))
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

        // POST: api/MUONSACHes
        [ResponseType(typeof(MUONSACH))]
        public IHttpActionResult PostMUONSACH(MUONSACH mUONSACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MUONSACHes.Add(mUONSACH);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MUONSACHExists(mUONSACH.SoPhieu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mUONSACH.SoPhieu }, mUONSACH);
        }

        // DELETE: api/MUONSACHes/5
        [ResponseType(typeof(MUONSACH))]
        public IHttpActionResult DeleteMUONSACH(string id)
        {
            MUONSACH mUONSACH = db.MUONSACHes.Find(id);
            if (mUONSACH == null)
            {
                return NotFound();
            }

            db.MUONSACHes.Remove(mUONSACH);
            db.SaveChanges();

            return Ok(mUONSACH);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MUONSACHExists(string id)
        {
            return db.MUONSACHes.Count(e => e.SoPhieu == id) > 0;
        }
    }
}