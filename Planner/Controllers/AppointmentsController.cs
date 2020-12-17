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
    [RoutePrefix("api/appointments")]
    public class AppointmentsController : ApiController
    {
        AppointmentService _Appointments = new AppointmentService();

        [HttpGet]
        [Route("")]
        // GET: api/Appointments
        public IEnumerable<Appointment> GetAppointments()
        {
            return _Appointments.GetAppointments();
        }

        [HttpGet]
        [Route("{id:int}")]
        // GET: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult GetAppointment(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            Appointment appointment = _Appointments.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpGet]
        [Route("{id:int}")]
        // PUT: api/Appointments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppointment(int id, Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointment.AppointmentID)
            {
                return BadRequest();
            }

            _Appointments.UpdateAppointment(appointment);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("")]
        // POST: api/Appointments
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult PostAppointment(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _Appointments.AddAppointment(appointment);
            return CreatedAtRoute("DefaultApi", new { id = appointment.AppointmentID }, appointment);
        }

        [HttpGet]
        [Route("{id:int}")]
        // DELETE: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult DeleteAppointment(int id)
        {
            Appointment appointment = _Appointments.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _Appointments.DeleteAppointment(id);

            return Ok(appointment);
        }
    }
}