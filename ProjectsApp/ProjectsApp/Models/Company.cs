using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProjectsApp.Models
{
    [Table("Companies")]
    public class Company
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Unique, Column("_name")]
        public string Name { get; set; }

        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        //public List<Project> Projects { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
