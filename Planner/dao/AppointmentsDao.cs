/**
 * Author tahidixon
 * 12.15.2020
 * Purpose: To provide a data access object layer to the database's 'Appointments' table
 * 
 * */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Planner.dao;
using Planner.Models;

namespace Planner.dao
{
    internal class AppointmentsDao
    {
        //Returns a list of all Appointments within the db, ordered by start time by default
        public IEnumerable<Appointment> GetAppointments()
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                IEnumerable<Appointment> appointments = (from x in dbcon.Appointments
                                                         orderby x.StartTime
                                                         select x).AsEnumerable<Appointment>();
                return appointments;
            }
        }

        //Returns a specific appointment by its ID within the database
        public Appointment GetAppointment(int id)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                Appointment appointment = (from x in dbcon.Appointments
                                           where x.AppointmentID == id
                                           select x).First();
                return appointment;
            }
        }
        public Appointment PutAppointment(Appointment appointment)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {

                //Load old object
                Appointment oldAppointment = (from x in dbcon.Appointments
                                              where x.AppointmentID == appointment.AppointmentID
                                              select x).First();

                //Detach object in db
                dbcon.Entry(oldAppointment).State = EntityState.Detached;
                //Attach the new one
                dbcon.Appointments.Attach(appointment);
                dbcon.Entry(appointment).State = EntityState.Modified;
                return appointment;
            }
        }
        public Appointment PostAppointment(Appointment appointment)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                dbcon.Appointments.Add(appointment);
                dbcon.Entry(appointment).State = EntityState.Added;
                return appointment;
            }
        }
        public void DeleteAppointment(int appointment)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                Appointment deletedAppointment = (from x in dbcon.Appointments
                                                  where x.AppointmentID == appointment
                                                  select x).First();
                dbcon.Appointments.Remove(deletedAppointment);
                dbcon.Entry(deletedAppointment).State = EntityState.Deleted;
            }
        }
        
        private bool AppointmentExists(int id)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                return dbcon.Appointments.Count(e => e.AppointmentID == id) > 0;
            }
        }


    }
}