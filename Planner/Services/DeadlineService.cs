/**
 * Author tahidixon
 * 12.15.2020
 * Purpose: To provide a business logic / transactional layer to the database's 'Deadlines' table
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

    public class DeadlineService
    {
        //Global utils
        private static TimeUtil time = new TimeUtil();

        //Db
        private DeadlinesDao _deadlinesDb;

        //Memory list
        private List<Deadline> _deadlines;
        public IReadOnlyCollection<Deadline> Deadlines => _deadlines;

        //Boolean to determine whether the deadline list in memory is up to date
        private static bool _deadlineListStale = true;

        public DeadlineService()
        {
            _deadlinesDb = new DeadlinesDao();
        }

        //Loads objects to memory if null or stale
        public IEnumerable<Deadline> GetDeadlines()
        {
            if (_deadlines == null || _deadlineListStale)
            {
                _deadlines = _deadlinesDb.GetDeadlines().ToList();
                _deadlineListStale = false;
            }
            return _deadlines;
        }

        // Returns a given deadline within memory in O1 time
        // @param deadlineId = the ID of the deadline being retrieved from memory
        // @return Type: Deadline
        public Deadline GetDeadlineById(int deadlineId)
        {
            if (_deadlines != null && !_deadlineListStale)
            {
                return _deadlines.Where(deadline => deadline.DeadlineID == deadlineId).First();
            }
            else
            {
                return _deadlinesDb.GetDeadline(deadlineId);
            }
        }

        //POSTS a given deadline instance
        public void AddDeadline(Deadline deadline)
        {
            _deadlinesDb.PostDeadline(deadline);
            _deadlineListStale = true;
        }

        //PUTs to a given deadline with the provided ID
        public void UpdateDeadline (Deadline deadline)
        {
            _deadlinesDb.PutDeadline(deadline);
            _deadlineListStale = true;
        }

        public void DeleteDeadline(int deadlineId)
        {
            _deadlinesDb.DeleteDeadline(deadlineId);
            _deadlineListStale = true;

        }

        public override string ToString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }

    }
}
