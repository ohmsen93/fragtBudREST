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
using fragtBudRESTwebAPI.Context;
using fragtBudRESTwebAPI.Models;

namespace fragtBudRESTwebAPI.Controllers
{
    public class ordresController : ApiController
    {
        private FragtContextEDM db = new FragtContextEDM();

        // GET: api/ordres
        public IQueryable<ordre> Getordre()
        {
            return db.ordre;
        }

        // GET: api/ordres/5
        [ResponseType(typeof(ordre))]
        public IHttpActionResult Getordre(int id)
        {
            ordre ordre = db.ordre.Find(id);
            if (ordre == null)
            {
                return NotFound();
            }

            return Ok(ordre);
        }

        // PUT: api/ordres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putordre(int id, ordre ordre)
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
                db.SaveChanges();
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
        public IHttpActionResult Postordre(ordre ordre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ordre.Add(ordre);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ordre.ordreID }, ordre);
        }

        // DELETE: api/ordres/5
        [ResponseType(typeof(ordre))]
        public IHttpActionResult Deleteordre(int id)
        {
            ordre ordre = db.ordre.Find(id);
            if (ordre == null)
            {
                return NotFound();
            }

            db.ordre.Remove(ordre);
            db.SaveChanges();

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