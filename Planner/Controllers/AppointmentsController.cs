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
    [RoutePrefix("api/appointments")]
    public class AppointmentsController : ApiController
    {
        AppointmentService _Appointments = new AppointmentService();


        // GET: api/Appointments
        [Route("", Name = "GetAppointments"), HttpGet]
        [ResponseType(typeof(IQueryable<Appointment>))]
        public IQueryable<Appointment> GetAppointments()
        {
            return _Appointments.GetAppointments().AsQueryable();
        }

        // GET: api/Appointments/5

        [Route("{id:int}", Name = "GetAppointmentById"), HttpGet]
        [ResponseType(typeof(Appointment))]
        public HttpResponseMessage GetAppointment(int id)
        {
            var response = Request.CreateResponse();
            if (id < 0)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            Appointment appointment = _Appointments.GetAppointmentById(id);
            if (appointment == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }
            else
            {
                //Set status code
                response.StatusCode = HttpStatusCode.OK;
                //Set content of response to JSON
                var httpContent = new StringContent(appointment.ToString(), Encoding.UTF8, "application/json");
                response.Content = httpContent;
                return response;
            }
        }

        // PUT: api/Appointments/5

        [Route("{id:int}", Name = "PutAppointment"), HttpPut]
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutAppointment(int id, [FromBody] Appointment appointment)
        {
            var response = Request.CreateResponse();
            if (!ModelState.IsValid)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }

            if (id != appointment.AppointmentID)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            else
            {
                _Appointments.UpdateAppointment(appointment);

                //Set status code
                response.StatusCode = HttpStatusCode.OK;
                //Set content of response to JSON
                var httpContent = new StringContent(appointment.ToString(), Encoding.UTF8, "application/json");
                response.Content = httpContent;
                return response;
            }
        }

        [Route("", Name = "PostAppointment"), HttpPost]
        [ResponseType(typeof(Appointment))]
        public HttpResponseMessage PostAppointment([FromBody] Appointment appointment)
        {
            var response = Request.CreateResponse();
            if (!ModelState.IsValid)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            else
            {
                _Appointments.AddAppointment(appointment);
                //Set status code
                response.StatusCode = HttpStatusCode.Created;
                //Set content of response to JSON
                var httpContent = new StringContent(appointment.ToString(), Encoding.UTF8, "application/json");
                response.Content = httpContent;
                return response;
            }

        }

        // DELETE: api/Appointments/5

        [Route("{id:int}", Name = "DeleteAppointment"), HttpDelete]
        [ResponseType(typeof(Appointment))]
        public HttpResponseMessage DeleteAppointment(int id)
        {
            var response = Request.CreateResponse();
            if (_Appointments.GetAppointmentById(id) == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }
            else
            {
                _Appointments.DeleteAppointment(id);
                response.StatusCode = HttpStatusCode.NoContent;
                return response;
            }
        }
    }
}