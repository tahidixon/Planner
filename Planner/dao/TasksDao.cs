/**
 * Author tahidixon
 * 12.15.2020
 * Purpose: To provide a data access object layer to the database's 'Tasks' table
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
    internal class TasksDao
    {
        //Returns a list of all tasks within the db, ordered by start time by default
        public IEnumerable<Task> GetTasks()
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                IEnumerable<Task> tasks = (from x in dbcon.Tasks
                                           orderby x.StartTime
                                           select x).AsEnumerable<Task>();
                return tasks.ToList<Task>();
            }
        }

        //Returns a specific task by its ID within the database
        public Task GetTask(int id)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                Task task = (from x in dbcon.Tasks
                                           where x.TaskID == id
                                           select x).First();
                return task;
            }
        }
        //Overwrites a task with the same TaskID within the database
        public Task PutTask(Task task)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                
                //Load old object
                Task oldTask = (from x in dbcon.Tasks
                                where x.TaskID == task.TaskID
                                select x).First();

                //Detach object in db
                dbcon.Entry(oldTask).State = EntityState.Detached;
                //Attach the new one
                dbcon.Tasks.Attach(task);
                dbcon.Entry(task).State = EntityState.Modified;
                return task;
            }
        }

        //Adds a provided ta
        public Task PostTask(Task task)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                dbcon.Tasks.Add(task);
                dbcon.Entry(task).State = EntityState.Added;
                return task;
            }
        }
        public void DeleteTask(int taskId)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                Task deletedTask = (from x in dbcon.Tasks
                                    where x.TaskID == taskId
                                    select x).First();
                dbcon.Tasks.Remove(deletedTask);
                dbcon.Entry(deletedTask).State = EntityState.Deleted;
            }
        }

        private bool TaskExists(int id)
        {
            using (PlannerContext dbcon = new PlannerContext())
            {
                return dbcon.Tasks.Count(e => e.TaskID == id) > 0;
            }
        }

    }
}