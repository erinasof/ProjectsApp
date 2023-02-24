using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProjectsApp.Models
{
    [Table("Employees22")]
    public class Employee
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Column("_last_name")]
        public string LastName { get; set; }

        [Column("_name")]
        public string Name { get; set; }

        [Column("_patronymic")]
        public string Patronymic { get; set; }

        [Unique, Column("_email")]
        public string Email { get; set; }

        [ManyToMany(typeof(ProjectEmployee), CascadeOperations = CascadeOperation.All)]
        public List<Project> Projects { get; set; }

        public override string ToString()
        {
            return LastName + " " + Name[0] + "." + Patronymic[0] + ". (" + Email + ")";
        }
    }
}
