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
    public class AspNetUserRolesController : ApiController
    {
        private FragtDBContext db = new FragtDBContext();

        // GET: api/AspNetUserRoles
        public IQueryable<AspNetUserRoles> GetAspNetUserRoles()
        {
            return db.AspNetUserRoles;
        }

        // GET: api/AspNetUserRoles/5
        [ResponseType(typeof(AspNetUserRoles))]
        public async Task<IHttpActionResult> GetAspNetUserRoles(string user)
        {
            AspNetUserRoles aspNetUserRoles = await db.AspNetUserRoles.SingleAsync(s => s.UserId == user); ;
            if (aspNetUserRoles == null)
            {
                return NotFound();
            }

            return Ok(aspNetUserRoles);
        }

        // PUT: api/AspNetUserRoles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAspNetUserRoles(string id, AspNetUserRoles aspNetUserRoles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspNetUserRoles.UserId)
            {
                return BadRequest();
            }

            db.Entry(aspNetUserRoles).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserRolesExists(id))
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

        // POST: api/AspNetUserRoles
        [ResponseType(typeof(AspNetUserRoles))]
        public async Task<IHttpActionResult> PostAspNetUserRoles(AspNetUserRoles aspNetUserRoles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AspNetUserRoles.Add(aspNetUserRoles);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUserRolesExists(aspNetUserRoles.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspNetUserRoles.UserId }, aspNetUserRoles);
        }

        // DELETE: api/AspNetUserRoles/5
        [ResponseType(typeof(AspNetUserRoles))]
        public async Task<IHttpActionResult> DeleteAspNetUserRoles(string id)
        {
            AspNetUserRoles aspNetUserRoles = await db.AspNetUserRoles.FindAsync(id);
            if (aspNetUserRoles == null)
            {
                return NotFound();
            }

            db.AspNetUserRoles.Remove(aspNetUserRoles);
            await db.SaveChangesAsync();

            return Ok(aspNetUserRoles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AspNetUserRolesExists(string id)
        {
            return db.AspNetUserRoles.Count(e => e.UserId == id) > 0;
        }
    }
}