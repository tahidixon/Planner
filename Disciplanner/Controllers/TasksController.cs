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
    [RoutePrefix("api/tasks")]
    public class TasksController : ApiController
    {
        private DisciplannerEntities db = new DisciplannerEntities();

        // GET: api/Tasks
        [HttpGet]
        [Route("")]
        public IEnumerable<Resources.Task> GetTasks()
        {
            return db.Tasks;
        }

        // GET: api/Tasks/5
        [ResponseType(typeof(Resources.Task))]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetTask(int id)
        {
            Resources.Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                //return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> PutTask(int id, Resources.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.TaskID)
            {
                return BadRequest();
            }

            db.Entry(task).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        // POST: api/Tasks
        [ResponseType(typeof(Resources.Task))]
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> PostTask(Resources.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasks.Add(task);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = task.TaskID }, task);
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(Resources.Task))]
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteTask(int id)
        {
            Resources.Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(task);
            await db.SaveChangesAsync();

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.Tasks.Count(e => e.TaskID == id) > 0;
        }
    }
}