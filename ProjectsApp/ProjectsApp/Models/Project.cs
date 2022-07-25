using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProjectsApp.Models
{
    [Table("Projects")]
    public class Project
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Column("_name")]
        public string Name { get; set; }
        //
        [ForeignKey(typeof(Company))]
        public int CustomerCompanyId { get; set; }
        //[ManyToOne("_customer_company_id")]
        //public Company CustomerCompany { get; set; }
        //
        [ForeignKey(typeof(Company))]
        public int ExecutorCompanyId { get; set; }
        //[ManyToOne("_executor_company_id")]
       // public Company ExecutorCompany { get; set; }
        //
        [ForeignKey(typeof(Employee))]
        public int HeadId { get; set; }
        //[ManyToOne("_head_id")]
        //public Employee Head { get; set; }


        [ManyToMany(typeof(ProjectEmployee))]
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

        public override string ToString()
        {
            return Name;
        }
    }
}
