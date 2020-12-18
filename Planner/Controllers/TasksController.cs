using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
        [Route("", Name = "GetTasks"), HttpGet]
        [ResponseType(typeof(IQueryable<Task>))]
        public IQueryable<Task> GetTasks()
        {
            return _Tasks.GetTasks().AsQueryable();
        }

        // GET: api/Tasks/5
        
        [Route("{id:int}", Name = "GetTaskById"), HttpGet]
        [ResponseType(typeof(Task))]
        public HttpResponseMessage GetTask(int id)
        {
            var response = Request.CreateResponse();
            if (id < 0)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            Task task = _Tasks.GetTaskById(id);
            if (task == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            } else
            {
                //Set status code
                response.StatusCode = HttpStatusCode.OK;
                //Set content of response to JSON
                var httpContent = new StringContent(task.ToString(), Encoding.UTF8, "application/json");
                response.Content = httpContent;
                return response;
            }
        }

        // PUT: api/Tasks/5
        
        [Route("{id:int}", Name = "PutTask"), HttpPut]
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutTask(int id, [FromBody] Task task)
        {
            var response = Request.CreateResponse();
            if (!ModelState.IsValid)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }

            if (id != task.TaskID)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            } else
            {
                _Tasks.UpdateTask(task);

                //Set status code
                response.StatusCode = HttpStatusCode.OK;
                //Set content of response to JSON
                var httpContent = new StringContent(task.ToString(), Encoding.UTF8, "application/json");
                response.Content = httpContent;
                return response;
            }
        }
        
        [Route("", Name = "PostTask"), HttpPost]
        [ResponseType(typeof(Task))]
        public HttpResponseMessage PostTask([FromBody] Task task)
        {
            var response = Request.CreateResponse();
            if (!ModelState.IsValid)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            else
            {
                _Tasks.AddTask(task);
                //Set status code
                response.StatusCode = HttpStatusCode.Created;
                //Set content of response to JSON
                var httpContent = new StringContent(task.ToString(), Encoding.UTF8, "application/json");
                response.Content = httpContent;
                return response;
            }
            
        }

        // DELETE: api/Tasks/5

        [Route("{id:int}", Name = "DeleteTask"), HttpDelete]
        [ResponseType(typeof(Task))]
        public HttpResponseMessage DeleteTask(int id)
        {
            var response = Request.CreateResponse();
            if (_Tasks.GetTaskById(id) == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }else
            {
                _Tasks.DeleteTask(id);
                response.StatusCode = HttpStatusCode.NoContent;
                return response;
            }
        }
    }
}