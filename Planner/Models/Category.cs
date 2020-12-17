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

    public class Category
    {
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

        public Category()
        {

        }
        public Category(string CategoryID, string Name, string Notes)
        {
            this.CategoryID = CategoryID;
            this.Name = Name;
            this.Notes = Notes;
        }

        public Category(IDataReader reader)
        {
            this.CategoryID = reader["CategoryID"] as string;
            this.Name = reader["Name"] as string;
            this.Notes = reader["Notes"] as string;
        }
    }
}
