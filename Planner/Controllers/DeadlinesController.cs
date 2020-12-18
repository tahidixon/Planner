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
    [RoutePrefix("api/deadlines")]
    public class DeadlinesController : ApiController
    {
        DeadlineService _Deadlines = new DeadlineService();


        // GET: api/Deadlines
        [Route("", Name = "GetDeadlines"), HttpGet]
        [ResponseType(typeof(IQueryable<Deadline>))]
        public IQueryable<Deadline> GetDeadlines()
        {
            return _Deadlines.GetDeadlines().AsQueryable();
        }

        // GET: api/Deadlines/5

        [Route("{id:int}", Name = "GetDeadlineById"), HttpGet]
        [ResponseType(typeof(Deadline))]
        public HttpResponseMessage GetDeadline(int id)
        {
            var response = Request.CreateResponse();
            if (id < 0)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            Deadline deadline = _Deadlines.GetDeadlineById(id);
            if (deadline == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }
            else
            {
                //Set status code
                response.StatusCode = HttpStatusCode.OK;
                //Set content of response to JSON
                var httpContent = new StringContent(deadline.ToString(), Encoding.UTF8, "application/json");
                response.Content = httpContent;
                return response;
            }
        }

        // PUT: api/Deadlines/5

        [Route("{id:int}", Name = "PutDeadline"), HttpPut]
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutDeadline(int id, [FromBody] Deadline deadline)
        {
            var response = Request.CreateResponse();
            if (!ModelState.IsValid)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }

            if (id != deadline.DeadlineID)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            else
            {
                _Deadlines.UpdateDeadline(deadline);

                //Set status code
                response.StatusCode = HttpStatusCode.OK;
                //Set content of response to JSON
                var httpContent = new StringContent(deadline.ToString(), Encoding.UTF8, "application/json");
                response.Content = httpContent;
                return response;
            }
        }

        [Route("", Name = "PostDeadline"), HttpPost]
        [ResponseType(typeof(Deadline))]
        public HttpResponseMessage PostDeadline([FromBody] Deadline deadline)
        {
            var response = Request.CreateResponse();
            if (!ModelState.IsValid)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            else
            {
                _Deadlines.AddDeadline(deadline);
                //Set status code
                response.StatusCode = HttpStatusCode.Created;
                //Set content of response to JSON
                var httpContent = new StringContent(deadline.ToString(), Encoding.UTF8, "application/json");
                response.Content = httpContent;
                return response;
            }

        }

        // DELETE: api/Deadlines/5

        [Route("{id:int}", Name = "DeleteDeadline"), HttpDelete]
        [ResponseType(typeof(Deadline))]
        public HttpResponseMessage DeleteDeadline(int id)
        {
            var response = Request.CreateResponse();
            if (_Deadlines.GetDeadlineById(id) == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }
            else
            {
                _Deadlines.DeleteDeadline(id);
                response.StatusCode = HttpStatusCode.NoContent;
                return response;
            }
        }
    }
}