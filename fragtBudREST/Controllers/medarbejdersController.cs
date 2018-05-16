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
    public class medarbejdersController : ApiController
    {
        private FragtDBContext db = new FragtDBContext();

        // GET: api/medarbejders
        public IQueryable<medarbejder> Getmedarbejder()
        {
            return db.medarbejder;
        }

        // GET: api/medarbejders/5
        [ResponseType(typeof(medarbejder))]
        public IHttpActionResult Getmedarbejder(int id)
        {
            medarbejder medarbejder = db.medarbejder.Find(id);
            if (medarbejder == null)
            {
                return NotFound();
            }

            return Ok(medarbejder);
        }

        // PUT: api/medarbejders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmedarbejder(int id, medarbejder medarbejder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medarbejder.medarbejderID)
            {
                return BadRequest();
            }

            db.Entry(medarbejder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!medarbejderExists(id))
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

        // POST: api/medarbejders
        [ResponseType(typeof(medarbejder))]
        public IHttpActionResult Postmedarbejder(medarbejder medarbejder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.medarbejder.Add(medarbejder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medarbejder.medarbejderID }, medarbejder);
        }

        // DELETE: api/medarbejders/5
        [ResponseType(typeof(medarbejder))]
        public IHttpActionResult Deletemedarbejder(int id)
        {
            medarbejder medarbejder = db.medarbejder.Find(id);
            if (medarbejder == null)
            {
                return NotFound();
            }

            db.medarbejder.Remove(medarbejder);
            db.SaveChanges();

            return Ok(medarbejder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool medarbejderExists(int id)
        {
            return db.medarbejder.Count(e => e.medarbejderID == id) > 0;
        }
    }
}