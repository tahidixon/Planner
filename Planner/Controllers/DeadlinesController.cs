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
using Planner.Models;
using Planner.dao;
using Planner.Services;

namespace Planner.Controllers
{
    [RoutePrefix("api/deadlines")]
    public class DeadlinesController : ApiController
    {
        DeadlineService _Deadlines = new DeadlineService();

        [HttpGet]
        [Route("")]
        // GET: api/Deadlines
        public IEnumerable<Deadline> GetDeadlines()
        {
            return _Deadlines.GetDeadlines();
        }

        [HttpGet]
        [Route("{id:int}")]
        // GET: api/Deadlines/5
        [ResponseType(typeof(Deadline))]
        public IHttpActionResult GetDeadline(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            Deadline deadline = _Deadlines.GetDeadlineById(id);
            if (deadline == null)
            {
                return NotFound();
            }

            return Ok(deadline);
        }

        [HttpGet]
        [Route("{id:int}")]
        // PUT: api/Deadlines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeadline(int id, Deadline deadline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deadline.DeadlineID)
            {
                return BadRequest();
            }

            _Deadlines.UpdateDeadline(deadline);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("")]
        // POST: api/Deadlines
        [ResponseType(typeof(Deadline))]
        public IHttpActionResult PostDeadline(Deadline deadline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _Deadlines.AddDeadline(deadline);
            return CreatedAtRoute("DefaultApi", new { id = deadline.DeadlineID }, deadline);
        }

        [HttpGet]
        [Route("{id:int}")]
        // DELETE: api/Deadlines/5
        [ResponseType(typeof(Deadline))]
        public IHttpActionResult DeleteDeadline(int id)
        {
            Deadline deadline = _Deadlines.GetDeadlineById(id);
            if (deadline == null)
            {
                return NotFound();
            }

            _Deadlines.DeleteDeadline(id);

            return Ok(deadline);
        }

        
    }
}