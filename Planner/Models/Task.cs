/**
 * Author tahidixon
 * 12.15.2020
 * Purpose: I'm sure bundling the data transfer object and the object model & associated constructors is bad practice somehow. We'll find out why once we write unit tests
 * */

namespace Planner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;
    using Planner.Util;


    public class Task
    {
        TimeUtil time = new TimeUtil();
        //Name, Category, Priority, Notes
        
        public int TaskID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string CreationTime { get; set; }

        [Required]
        [StringLength(6)]
        public string Category { get; set; }

        public int Priority { get; set; }

        internal static Task<ClaimsIdentity> FromResult(ClaimsIdentity claimsIdentity)
        {
            throw new NotImplementedException();
        }

        [Required]
        public string Notes { get; set; }

        [Required]
        [StringLength(30)]
        public string StartTime { get; set; }

        [Required]
        [StringLength(30)]
        public string EndTime { get; set; }

        public int ParentEntity { get; set; }

        public Task()
        {
            this.Name = "Task";
            this.CreationTime = time.getCurrentTime();
            this.Category = "000000";
            this.Notes = "Notes";
            this.Priority = 5;
            this.StartTime = "undefined";
            this.EndTime = "undefined";
            this.ParentEntity = -1;
        }
        public Task (IDataReader reader)
        {
            this.TaskID = Convert.ToInt32(reader["AppointmentID"]);
            this.Name = reader["Name"] as string;
            this.CreationTime = reader["CreationTime"] as string;
            this.Category = reader["Category"] as string;
            this.Notes = reader["Notes"] as string;
            this.Priority = Convert.ToInt32(reader["Priority"]);
            this.StartTime = reader["StartTime"] as string;
            this.EndTime = reader["EndTime"] as string;
            this.ParentEntity = Convert.ToInt32(reader["ParentEntity"]);
        }
        public Task(string Name, string Category, int Priority, string Notes, string StartTime = "undefined", string EndTime = "undefined", int ParentEntity = -1)
        {
            this.Name = Name;
            this.CreationTime = time.getCurrentTime();
            this.Category = Category;
            this.Priority = Priority;
            this.Notes = Notes;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.ParentEntity = ParentEntity;
        }

    }
}
