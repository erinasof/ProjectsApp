using ProjectsApp.Models;
using ProjectsApp.Services;

namespace ProjectsApp.Repositories.Impl
{
    class EmployeeRepo : GenericRepo<Employee, int>
    {
        public EmployeeRepo(ISQLiteService db) : base(db)
        {
        }
    }
}
