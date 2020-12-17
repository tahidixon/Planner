/**
 * Author tahidixon
 * 12.15.2020
 * Purpose: To provide a business logic / transactional layer to the database's 'Appointments' table
 * */

namespace Planner.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Script.Serialization;
    using Planner.Util;
    using Planner.Models;
    using Planner.dao;
    using System.Linq;

    public class AppointmentService
    {
        //Global utils
        private static TimeUtil time = new TimeUtil();

        //Db
        private AppointmentsDao _appointmentsDb;

        //Memory list
        private List<Appointment> _appointments;
        public IReadOnlyCollection<Appointment> Appointments => _appointments;

        //Boolean to determine whether the appointment list in memory is up to date
        private static bool _appointmentListStale = true;

        public AppointmentService()
        {
            _appointmentsDb = new AppointmentsDao();
        }

        //Loads objects to memory if null or stale
        public IEnumerable<Appointment> GetAppointments()
        {
            if (_appointments == null || _appointmentListStale)
            {
                _appointments = _appointmentsDb.GetAppointments().ToList();
                _appointmentListStale = false;
            }
            return _appointments;
        }

        // Returns a given appointment within memory in O1 time
        // @param appointmentId = the ID of the appointment being retrieved from memory
        // @return Type: Appointment
        public Appointment GetAppointmentById(int appointmentId)
        {
            if (_appointments != null && !_appointmentListStale)
            {
                return _appointments.Where(appointment => appointment.AppointmentID == appointmentId).First();
            }
            else
            {
                return _appointmentsDb.GetAppointment(appointmentId);
            }
        }

        //POSTS a given appointment instance
        public void AddAppointment(Appointment appointment)
        {
            _appointmentsDb.PostAppointment(appointment);
            _appointmentListStale = true;
        }

        //PUTs to a given appointment with the provided ID
        public void UpdateAppointment(Appointment appointment)
        {
            _appointmentsDb.PutAppointment(appointment);
            _appointmentListStale = true;
        }

        public void DeleteAppointment(int appointmentId)
        {
            _appointmentsDb.DeleteAppointment(appointmentId);
            _appointmentListStale = true;

        }

        public override string ToString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }

    }
}
