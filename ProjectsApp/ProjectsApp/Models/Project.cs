using System;
using System.Collections.Generic;
using ProjectsApp.Models.Base;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProjectsApp.Models
{
    [Table("Projects22")]
    public class Project : PKNamedEntity<int>
    {
        [ForeignKey(typeof(Company))]
        public int CustomerCompanyId { get; set; }

        [ForeignKey(typeof(Company))]
        public int ExecutorCompanyId { get; set; }

        [ForeignKey(typeof(Employee))]
        public int HeadId { get; set; }
        
        [ManyToMany(typeof(ProjectEmployee), CascadeOperations = CascadeOperation.All)]
        public List<Employee> Employees { get; set; }

        [Column("_start_date")]
        public DateTime StartDate { get; set; }

        [Column("_finish_date")]
        public DateTime FinishDate { get; set; }

        [Column("_priority")]
        public int Priority { get; set; }

        public Project()
        {
            StartDate = DateTime.Today;
            FinishDate = DateTime.Today;
        }

    }
}
