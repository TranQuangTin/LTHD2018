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
    public class TAIKHOANsController : ApiController
    {
        private QuanLiThuVienSEntities db = new QuanLiThuVienSEntities();

        // GET: api/TAIKHOANs
        public IQueryable<TAIKHOAN> GetTAIKHOANs()
        {
            return db.TAIKHOANs;
        }

        // GET: api/TAIKHOANs/5
        [ResponseType(typeof(TAIKHOAN))]
        public IHttpActionResult GetTAIKHOAN(string id)
        {
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return NotFound();
            }

            return Ok(tAIKHOAN);
        }

        // POST: api/TAIKHOANs
        [ActionName("login")]
        public IHttpActionResult PostLogin(TAIKHOAN tAIKHOAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (TAIKHOANExists("*", tAIKHOAN.TaiKhoan1, tAIKHOAN.MatKhau))
            {
                return Ok("Login success, waiting for token validate...");
            }
            return BadRequest();
        }

        // PUT: api/TAIKHOANs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTAIKHOAN(string id, TAIKHOAN tAIKHOAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tAIKHOAN.MaNV)
            {
                return BadRequest();
            }

            db.Entry(tAIKHOAN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TAIKHOANExists(id))
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

        // POST: api/TAIKHOANs
        [ResponseType(typeof(TAIKHOAN))]
        public IHttpActionResult PostTAIKHOAN(TAIKHOAN tAIKHOAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TAIKHOANs.Add(tAIKHOAN);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TAIKHOANExists(tAIKHOAN.MaNV))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tAIKHOAN.MaNV }, tAIKHOAN);
        }

        // DELETE: api/TAIKHOANs/5
        [ResponseType(typeof(TAIKHOAN))]
        public IHttpActionResult DeleteTAIKHOAN(string id)
        {
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return NotFound();
            }

            db.TAIKHOANs.Remove(tAIKHOAN);
            db.SaveChanges();

            return Ok(tAIKHOAN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TAIKHOANExists(string id = "*", string username = "*", string password = "*")
        {
            return db.TAIKHOANs.Count(e => (id == "*" || e.MaNV == id) && (username == "*" || username == e.TaiKhoan1) && (password == "*" || password == e.MatKhau)) > 0;
        }
    }
}