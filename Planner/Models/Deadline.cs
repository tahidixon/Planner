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
    using System.Web.Script.Serialization;
    using Planner.Util;

    public class Deadline
    {
        TimeUtil time = new TimeUtil();
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeadlineID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string CreationTime { get; set; }

        [Required]
        [StringLength(6)]
        public string Category { get; set; }

        [Required]
        public string Notes { get; set; }

        public int Priority { get; set; }

        [Required]
        [StringLength(30)]
        public string StartTime { get; set; }

        [Required]
        [StringLength(30)]
        public string EndTime { get; set; }

        public int ParentEntity { get; set; }

        public int UserID { get; set; }

        public Deadline()
        {

        }
        public Deadline(IDataReader reader)
        {
            this.DeadlineID = Convert.ToInt32(reader["AppointmentID"]);
            this.Name = reader["Name"] as string;
            this.CreationTime = reader["CreationTime"] as string;
            this.Category = reader["Category"] as string;
            this.Notes = reader["Notes"] as string;
            this.Priority = Convert.ToInt32(reader["Priority"]);
            this.StartTime = reader["StartTime"] as string;
            this.EndTime = reader["EndTime"] as string;
            this.ParentEntity = Convert.ToInt32(reader["ParentEntity"]);
            this.UserID = Convert.ToInt32(reader["UserID"]);
        }
        public Deadline(string Name, string Category, string Notes, int Priority, string StartTime = "undefined", string EndTime = "undefined", int ParentEntity = -1, int UserID = -1)
        {
            this.Name = Name;
            this.CreationTime = time.getCurrentTime();
            this.Category = Category;
            this.Notes = Notes;
            this.Priority = Priority;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.ParentEntity = ParentEntity;
            this.UserID = UserID;
        }
        public override string ToString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}
