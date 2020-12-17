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
using Planner.Services;

namespace Planner.Controllers
{
    [RoutePrefix("api/tasks")]
    public class TasksController : ApiController
    {
        TaskService _Tasks = new TaskService();

        
        // GET: api/Tasks
        [HttpGet]
        [Route("")]
        public IQueryable<Task> GetTasks()
        {
            return _Tasks.GetTasks().AsQueryable<Task>();
        }

        // GET: api/Tasks/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Task))]
        public IHttpActionResult GetTask(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            Task task = _Tasks.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.TaskID)
            {
                return BadRequest();
            }

            _Tasks.UpdateTask(task);

            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Task))]

        public IHttpActionResult PostTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _Tasks.AddTask(task);

            return CreatedAtRoute("DefaultApi", new { id = task.TaskID }, task);
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(Task))]
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteTask(int id)
        {
            
            if (_Tasks.GetTaskById(id) == null)
            {
                return NotFound();
            }

            _Tasks.DeleteTask(id);

            return Ok(_Tasks.GetTaskById(id));
        }
    }
}