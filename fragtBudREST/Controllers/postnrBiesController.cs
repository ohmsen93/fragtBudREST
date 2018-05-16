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
    public class postnrBiesController : ApiController
    {
        private FragtDBContext db = new FragtDBContext();

        // GET: api/postnrBies
        public IQueryable<postnrBy> GetpostnrBy()
        {
            return db.postnrBy;
        }

        // GET: api/postnrBies/5
        [ResponseType(typeof(postnrBy))]
        public IHttpActionResult GetpostnrBy(int id)
        {
            postnrBy postnrBy = db.postnrBy.Find(id);
            if (postnrBy == null)
            {
                return NotFound();
            }

            return Ok(postnrBy);
        }

        // PUT: api/postnrBies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutpostnrBy(int id, postnrBy postnrBy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postnrBy.Postnr)
            {
                return BadRequest();
            }

            db.Entry(postnrBy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!postnrByExists(id))
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

        // POST: api/postnrBies
        [ResponseType(typeof(postnrBy))]
        public IHttpActionResult PostpostnrBy(postnrBy postnrBy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.postnrBy.Add(postnrBy);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (postnrByExists(postnrBy.Postnr))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = postnrBy.Postnr }, postnrBy);
        }

        // DELETE: api/postnrBies/5
        [ResponseType(typeof(postnrBy))]
        public IHttpActionResult DeletepostnrBy(int id)
        {
            postnrBy postnrBy = db.postnrBy.Find(id);
            if (postnrBy == null)
            {
                return NotFound();
            }

            db.postnrBy.Remove(postnrBy);
            db.SaveChanges();

            return Ok(postnrBy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool postnrByExists(int id)
        {
            return db.postnrBy.Count(e => e.Postnr == id) > 0;
        }
    }
}