using ProjectsApp.Models;
using ProjectsApp.Repositories.Impl;

namespace ProjectsApp.Services.Impl
{
    class EmployeeService : CRUDService<Employee, int>, IEmployeeService
    {
        public EmployeeService(EmployeeRepo repository) : base(repository)
        {
        }
    }
}
