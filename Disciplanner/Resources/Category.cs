namespace Disciplanner.Resources
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Script.Serialization;

    public class Category
    {
        DisciplannerEntities dbcon = new DisciplannerEntities();
        //I really don't want anything to happen if someone calls the parameterless constructor, so we won't define anything
        public Category()
        {

        }
        public Category(string CategoryID, string Name, string Notes)
        {
            this.CategoryID = CategoryID;
            this.Name = Name;
            this.Notes = Notes;
            dbcon.Categories.Add(this);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(6)]
        public string CategoryID { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        public string Notes { get; set; }
        public override string ToString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}
