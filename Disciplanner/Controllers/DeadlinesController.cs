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
using Disciplanner.Resources;


namespace Disciplanner.Controllers
{
    public class DeadlinesController : ApiController
    {
        private DisciplannerEntities db = new DisciplannerEntities();

        // GET: api/Deadlines
        [HttpGet]
        public IQueryable<Deadline> GetDeadlines()
        {
            return db.Deadlines;
        }

        // GET: api/Deadlines/5
        [ResponseType(typeof(Deadline))]
        [HttpGet]
        public async Task<IHttpActionResult> GetDeadline(int id)
        {
            Deadline deadline = await db.Deadlines.FindAsync(id);
            if (deadline == null)
            {
                return NotFound();
            }

            return Ok(deadline);
        }

        // PUT: api/Deadlines/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> PutDeadline(int id, Deadline deadline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deadline.DeadlineID)
            {
                return BadRequest();
            }

            db.Entry(deadline).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeadlineExists(id))
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

        // POST: api/Deadlines
        [ResponseType(typeof(Deadline))]
        [HttpPost]
        public async Task<IHttpActionResult> PostDeadline(Deadline deadline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Deadlines.Add(deadline);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeadlineExists(deadline.DeadlineID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = deadline.DeadlineID }, deadline);
        }

        // DELETE: api/Deadlines/5
        [ResponseType(typeof(Deadline))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteDeadline(int id)
        {
            Deadline deadline = await db.Deadlines.FindAsync(id);
            if (deadline == null)
            {
                return NotFound();
            }

            db.Deadlines.Remove(deadline);
            await db.SaveChangesAsync();

            return Ok(deadline);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeadlineExists(int id)
        {
            return db.Deadlines.Count(e => e.DeadlineID == id) > 0;
        }
    }
}