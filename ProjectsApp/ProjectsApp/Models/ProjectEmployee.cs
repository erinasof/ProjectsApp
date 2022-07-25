using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProjectsApp.Models
{
    [Table("ProjectEmployeess")]
    public class ProjectEmployee
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        
        [ForeignKey(typeof(Project))]
        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        [Column("_project_id")]
        public int ProjectId { get; set; }

        [ForeignKey(typeof(Employee))]
        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        [Column("_employee_id")]
        public int EmployeeId { get; set; }
    }
}
