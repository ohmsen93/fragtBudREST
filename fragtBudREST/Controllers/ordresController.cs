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
    public class ordresController : ApiController
    {
        private FragtDBContext db = new FragtDBContext();

        // GET: api/ordres
        public IQueryable<ordre> Getordre()
        {
            return db.ordre;
        }

        // GET: api/ordres/5
        [ResponseType(typeof(ordre))]
        public async Task<IHttpActionResult> Getordre(int id)
        {
            ordre ordre = await db.ordre.FindAsync(id);
            if (ordre == null)
            {
                return NotFound();
            }

            return Ok(ordre);
        }

        // GET: api/ordres/kunde/id
        [Route("api/ordres/kunde/{id}")]
        [ResponseType(typeof(ordre))]
        public IQueryable<ordre> GetordreByKunde(int id)
        {
            return db.ordre.Where(s => s.kundeID == id);
        }

        // PUT: api/ordres/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putordre(int id, ordre ordre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ordre.ordreID)
            {
                return BadRequest();
            }

            db.Entry(ordre).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ordreExists(id))
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

        // POST: api/ordres
        [ResponseType(typeof(ordre))]
        public async Task<IHttpActionResult> Postordre(ordre ordre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ordre.Add(ordre);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ordre.ordreID }, ordre);
        }

        // DELETE: api/ordres/5
        [ResponseType(typeof(ordre))]
        public async Task<IHttpActionResult> Deleteordre(int id)
        {
            ordre ordre = await db.ordre.FindAsync(id);
            if (ordre == null)
            {
                return NotFound();
            }

            db.ordre.Remove(ordre);
            await db.SaveChangesAsync();

            return Ok(ordre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ordreExists(int id)
        {
            return db.ordre.Count(e => e.ordreID == id) > 0;
        }
    }
}