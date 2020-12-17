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

        public Deadline()
        {

        }
        public Deadline(string Name, string Category, string Notes, int Priority, string StartTime = "undefined", string EndTime = "undefined", int ParentEntity = -1)
        {
            this.Name = Name;
            this.CreationTime = time.getCurrentTime();
            this.Category = Category;
            this.Notes = Notes;
            this.Priority = Priority;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.ParentEntity = ParentEntity;
        }
        public override string ToString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}
