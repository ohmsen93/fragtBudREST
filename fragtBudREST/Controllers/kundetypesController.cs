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
using fragtBudREST.Context;
using fragtBudREST.Models;

namespace fragtBudREST.Controllers
{
    public class kundetypesController : ApiController
    {
        private FragtDBContext db = new FragtDBContext();

        // GET: api/kundetypes
        public IQueryable<kundetype> Getkundetype()
        {
            return db.kundetype;
        }

        // GET: api/kundetypes/5
        [ResponseType(typeof(kundetype))]
        public IHttpActionResult Getkundetype(int id)
        {
            kundetype kundetype = db.kundetype.Find(id);
            if (kundetype == null)
            {
                return NotFound();
            }

            return Ok(kundetype);
        }

        // PUT: api/kundetypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putkundetype(int id, kundetype kundetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kundetype.typeID)
            {
                return BadRequest();
            }

            db.Entry(kundetype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!kundetypeExists(id))
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

        // POST: api/kundetypes
        [ResponseType(typeof(kundetype))]
        public IHttpActionResult Postkundetype(kundetype kundetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.kundetype.Add(kundetype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kundetype.typeID }, kundetype);
        }

        // DELETE: api/kundetypes/5
        [ResponseType(typeof(kundetype))]
        public IHttpActionResult Deletekundetype(int id)
        {
            kundetype kundetype = db.kundetype.Find(id);
            if (kundetype == null)
            {
                return NotFound();
            }

            db.kundetype.Remove(kundetype);
            db.SaveChanges();

            return Ok(kundetype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool kundetypeExists(int id)
        {
            return db.kundetype.Count(e => e.typeID == id) > 0;
        }
    }
}