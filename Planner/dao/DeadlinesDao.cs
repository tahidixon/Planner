/**
 * Author tahidixon
 * 12.15.2020
 * Purpose: To provide a data access object layer to the database's 'Deadlines' table
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
    internal class DeadlinesDao
    {
        //Returns a list of all Deadlines within the db, ordered by start time by default
        public IEnumerable<Deadline> GetDeadlines()
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                IEnumerable<Deadline> deadlines = (from x in dbcon.Deadlines
                                                   orderby x.StartTime
                                                   select x).AsEnumerable<Deadline>();
                return deadlines.ToList();
            }
        }

        //Returns a specific Deadline by its ID within the database
        public Deadline GetDeadline(int id)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                Deadline deadline = (from x in dbcon.Deadlines
                                     where x.DeadlineID == id
                                     select x).First();
                return deadline;
            }
        }
        public Deadline PutDeadline(Deadline deadline)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {

                //Load old object
                Deadline oldDeadline = (from x in dbcon.Deadlines
                                        where x.DeadlineID == deadline.DeadlineID
                                        select x).First();

                //Detach object in db
                dbcon.Entry(oldDeadline).State = EntityState.Detached;
                //Attach the new one
                dbcon.Deadlines.Attach(deadline);
                dbcon.Entry(deadline).State = EntityState.Modified;
                return deadline;
            }
        }
        public Deadline PostDeadline(Deadline deadline)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                dbcon.Deadlines.Add(deadline);
                dbcon.Entry(deadline).State = EntityState.Added;
                return deadline;
            }
        }
        public void DeleteDeadline(int deadline)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                Deadline deletedTask = (from x in dbcon.Deadlines
                                        where x.DeadlineID == deadline
                                        select x).First();
                dbcon.Deadlines.Remove(deletedTask);
                dbcon.Entry(deadline).State = EntityState.Deleted;
            }
        }

        private bool DeadlineExists(int id)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                return dbcon.Deadlines.Count(e => e.DeadlineID == id) > 0;
            }
        }


    }
}