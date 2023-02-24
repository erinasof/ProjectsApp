using ProjectsApp.Models;
using ProjectsApp.Services;

namespace ProjectsApp.Repositories.Impl
{
    class EmployeeRepository : GenericRepo<Employee, int>
    {
        public EmployeeRepository(ISQLiteService db) : base(db)
        {
        }
    }
}
