using Planner.Models;
using Planner.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using Planner.Controllers;

namespace Planner
{
    public partial class _Default : Page
    {
        TasksController _Tasks = new TasksController();
        AppointmentsController _Appointments = new AppointmentsController();

        TimeUtil time = new TimeUtil();
        public bool tempCreate = false;

        //Global scope variables
        
        
        //private string activeDayElement;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Begin day panel init
            //
            //Day body
            //
            //Declare tasks and categories

            TimeUtil time = new TimeUtil();




            //Populates the table with tasks if there isn't any, as a debugging tool.
            //We're leaving it in and going to have it print task ID's
            IEnumerable<Task> AllTasksInDb = _Tasks.GetTasks();
            rptTaskPanel.DataSource = AllTasksInDb;
            rptTaskPanel.DataBind();


            //End of Body
            //
            //Day footer items(remove, add, sort)
            //
            //Gets elements needed from categories to display in the sort panel




            //End of day footer
            //
            //End of Day Panel

            //Begin week panel init
            //
            //Week header

            //End of week header
            //
            //Week body

            //Create a enumerable list of appointments. Mainly to check to see if there is any.
            IEnumerable<Appointment> apts = _Appointments.GetAppointments();
            //Create instance data if none exists within current scope

            //Bind viewer data
            var aptList = (from x in apts
                           select new
                           {
                               aptID = x.AppointmentID,
                               aptName = x.Name,
                               aptStart = x.StartTime,
                               aptEnd = x.EndTime
                           }).ToList();

            //End of week body
            //
            //Week footer

            //End of week footer
            //
            //End of day panel

            //Begin Directive panel init
            //
            //Directive panel header

            //End of directive header
            //
            //Directive body

            //Set current time
            /**
             * Going to comment out the directives bit because I want to refactor where these LINQ queries are being made
             * Possibly create a DAO
             *
            long cur_Time = Convert.ToInt64(time.getCurrentTime());
            Appointment cur_Apt = (from x in dbcon.Appointments
                                   where Convert.ToInt64(x.StartTime) > cur_Time && Convert.ToInt64(x.EndTime) < cur_Time
                                   select x).First();
            lblCDirective.Text = cur_Apt.Name;

            Appointment nextAppointment = (from x in dbcon.Appointments
                                                        orderby x.StartTime
                                                        where Convert.ToInt64(x.StartTime) > cur_Time
                                                        select x).First();
            lblNDirective.InnerText = nextAppointment.Name;
            
            lblNDirective_deltaTime.InnerText = (Convert.ToInt64(nextAppointment.StartTime) - cur_Time).ToString();
            */
            //End of directive 

        }
    } 
}