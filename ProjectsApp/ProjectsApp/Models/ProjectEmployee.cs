using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProjectsApp.Models
{
    [Table("ProjectEmployeess22")]
    public class ProjectEmployee : PKEntity<int>
    {        
        [ForeignKey(typeof(Project))]
        [Column("_project_id")]
        public int ProjectId { get; set; }

        [ForeignKey(typeof(Employee))]
        [Column("_employee_id")]
        public int EmployeeId { get; set; }
    }
}
