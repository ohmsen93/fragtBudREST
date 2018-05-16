using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using fragtBudREST.Context;
using fragtBudREST.Models;

namespace fragtBudREST.Controllers
{
    public class kundesController : ApiController
    {
        private FragtDBContext db = new FragtDBContext();

        // GET: api/kundes
        public IQueryable<kunde> Getkunde()
        {
            return db.kunde;
        }

        // GET: api/kundes/5
        [ResponseType(typeof(kunde))]
        public async Task<IHttpActionResult> Getkunde(string user)
        {
            kunde kunde = await db.kunde.SingleAsync(s => s.AspUserID == user);
            if (kunde == null)
            {
                return NotFound();
            }

            return Ok(kunde);
        }


        // PUT: api/kundes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putkunde(int id, kunde kunde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kunde.kundeID)
            {
                return BadRequest();
            }

            db.Entry(kunde).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!kundeExists(id))
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

        // POST: api/kundes
        [ResponseType(typeof(kunde))]
        public async Task<IHttpActionResult> Postkunde(kunde kunde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.kunde.Add(kunde);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = kunde.kundeID }, kunde);
        }

        // DELETE: api/kundes/5
        [ResponseType(typeof(kunde))]
        public async Task<IHttpActionResult> Deletekunde(int id)
        {
            kunde kunde = await db.kunde.FindAsync(id);
            if (kunde == null)
            {
                return NotFound();
            }

            db.kunde.Remove(kunde);
            await db.SaveChangesAsync();

            return Ok(kunde);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool kundeExists(int id)
        {
            return db.kunde.Count(e => e.kundeID == id) > 0;
        }
    }
}