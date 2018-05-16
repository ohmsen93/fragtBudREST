using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class fragtsController : ApiController
    {
        private FragtDBContext db = new FragtDBContext();

        // GET: api/fragts
        public IQueryable<fragt> Getfragt()
        {
            return db.fragt;
        }

        // GET: api/fragts/5
        [ResponseType(typeof(fragt))]
        public IHttpActionResult Getfragt(int id)
        {
            fragt fragt = db.fragt.Find(id);
            if (fragt == null)
            {
                return NotFound();
            }

            return Ok(fragt);
        }

        // PUT: api/fragts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfragt(int id, fragt fragt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fragt.fragtID)
            {
                return BadRequest();
            }

            db.Entry(fragt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!fragtExists(id))
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

        // POST: api/fragts
        [ResponseType(typeof(fragt))]
        public IHttpActionResult Postfragt(fragt fragt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.fragt.Add(fragt);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fragt.fragtID }, fragt);
        }

        // DELETE: api/fragts/5
        [ResponseType(typeof(fragt))]
        public IHttpActionResult Deletefragt(int id)
        {
            fragt fragt = db.fragt.Find(id);
            if (fragt == null)
            {
                return NotFound();
            }

            db.fragt.Remove(fragt);
            db.SaveChanges();

            return Ok(fragt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool fragtExists(int id)
        {
            return db.fragt.Count(e => e.fragtID == id) > 0;
        }
    }
}