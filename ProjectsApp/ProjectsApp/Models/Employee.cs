using System.Collections.Generic;
using ProjectsApp.Models.Base;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProjectsApp.Models
{
    [Table("Employees22")]
    public class Employee : PKNamedEntity<int>
    {
        [Column("_last_name")]
        public string LastName { get; set; }

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
