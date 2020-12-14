namespace Disciplanner.Resources
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Script.Serialization;

    public class Task
    {
        TimeUtil time = new TimeUtil();
        DisciplannerEntities dbcon = new DisciplannerEntities();
        //Name, Category, Priority, Notes
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
            dbcon.Tasks.Add(this);
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
            dbcon.Tasks.Add(this);
        }
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

        [Required]
        public string Notes { get; set; }

        [Required]
        [StringLength(30)]
        public string StartTime { get; set; }

        [Required]
        [StringLength(30)]
        public string EndTime { get; set; }

        public int ParentEntity { get; set; }
        
    }
}
