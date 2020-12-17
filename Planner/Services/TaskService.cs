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

    public class TaskService
    {
        //Global utils
        private static TimeUtil time = new TimeUtil();

        //Db
        private TasksDao _tasksDb;

        //Memory list
        private List<Task> _tasks;
        public IReadOnlyCollection<Task> Tasks => _tasks;

        //Boolean to determine whether the task list in memory is up to date
        private static bool _taskListStale = true;

        public TaskService()
        {
            _tasksDb = new TasksDao();
        }

        //Loads objects to memory if null or stale
        public IEnumerable<Task> GetTasks()
        {
            if (_tasks == null || _taskListStale)
            {
                _tasks = _tasksDb.GetTasks().ToList();
                _taskListStale = false;
            }
            return _tasks;
        }

        // Returns a given task within memory in O1 time
        // @param taskId = the ID of the task being retrieved from memory
        // @return Type: Task
        public Task GetTaskById(int taskId)
        {
            if (_tasks != null && !_taskListStale)
            {
                return _tasks.Where(task => task.TaskID == taskId).First();
            } else
            {
                return _tasksDb.GetTask(taskId);
            }
        }

        //POSTS a given task instance
        public void AddTask(Task task)
        {
            _tasksDb.PostTask(task);
            _taskListStale = true;
        }

        //PUTs to a task with the same Task ID
        public void UpdateTask(Task task)
        {
            _tasksDb.PutTask(task);
            _taskListStale = true;
        }

        //DELETEs to a given task with the provided ID
        public void DeleteTask(int taskId)
        {
            _tasksDb.DeleteTask(taskId);
            _taskListStale = true;

        }

        public override string ToString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }

    }
}
