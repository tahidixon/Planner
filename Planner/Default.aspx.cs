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
            foreach (var x in AllTasksInDb)
            {
                outBox.Items.Add("Item exists in list. ID: " + x.TaskID);
            }
            rptTaskPanel.DataSource = tList;
            rptTaskPanel.DataBind();


            //End of Body
            //
            //Day footer items(remove, add, sort)
            //
            //Gets elements needed from categories to display in the sort panel

            dbcon.Categories.Load();
            var cats = (from x in dbcon.Categories.Local
                        select new
                        {
                            cats_Names = x.Name,
                            cats_ID = x.CategoryID
                        });

            btnDaySort_Categories.DataTextField = "cats_Names";
            btnDaySort_Categories.DataValueField = "cats_ID";
            btnDaySort_Categories.DataSource = cats;
            btnDaySort_Categories.DataBind();


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
            IEnumerable<Appointment> apts = (from x in dbcon.Appointments
                                             orderby x.StartTime
                                             select x).AsEnumerable();
            //Create instance data if none exists within current scope
            if (!apts.Any()) populateAppointments();

            //Bind viewer data
            var aptList = (from x in dbcon.Appointments
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
    
        

        protected void btnConfirmTask_Click(object sender, EventArgs e)
        {
            
            string name = txtTaskName.Text;
            string category = ddCategory.DataValueField;
            string notes = txtTaskNotes.Text;
            Category cat = 
            dbcon.Tasks.Add(new Models.Task(name, cat.CategoryID, 5, notes));
            
        }

        protected void taskGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            object tRow = from x in dbcon.Tasks
                          where sender.Equals(x)
                          select x;
            outBox.Items.Add("Selected " + tRow.ToString());
            
        }
        protected void rptTaskPanel_setActiveElement(object sender, RepeaterCommandEventArgs e)
        {
            string panelID = (string)e.CommandArgument;
            string[] tmp_Split = Regex.Split(panelID, "_");
            outBox.Items.Add("Item " + panelID + " selected as active element.");
        }
    
        
    } 
}