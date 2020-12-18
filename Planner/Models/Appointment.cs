/**
 * Author tahidixon
 * 12.15.2020
 * Purpose: I'm sure bundling the data transfer object and the object model & associated constructors is bad practice somehow. We'll find out why once we write unit tests
 * */

namespace Planner.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;
    using System.IO;
    using System.Web.Script.Serialization;

    public class Appointment
    {
        public int AppointmentID { get; set; }

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

        [Required]
        public int Priority { get; set; }

        [Required]
        [StringLength(30)]
        public string StartTime { get; set; }

        [Required]
        [StringLength(30)]
        public string EndTime { get; set; }

        public int ParentEntity { get; set; }

        public int UserID { get; set; }

        public Appointment()
        {
            //Default constructor should do nothing
        }

        public Appointment (string Name, string Category, string Notes, int Priority, string StartTime = "undefined", string EndTime = "undefined", int ParentEntity = -1, int UserID = -1)
        {
            this.Name = Name;
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
            return JsonConvert.SerializeObject(this);
        }

        


    }
}
