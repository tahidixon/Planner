namespace Disciplanner.Resources
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Script.Serialization;

    public class Deadline
    {
        TimeUtil time = new TimeUtil();
        DisciplannerEntities dbcon = new DisciplannerEntities();
        public Deadline()
        {
            this.Name = "Deadline";
            this.CreationTime = time.getCurrentTime();
            this.Category = "000000";
            this.Notes = "Notes";
            this.Priority = 5;
            this.StartTime = "undefined";
            this.EndTime = "undefined";
            this.ParentEntity = -1;
            dbcon.Deadlines.Add(this);
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
            dbcon.Deadlines.Add(this);
        }
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
        public override string ToString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}
