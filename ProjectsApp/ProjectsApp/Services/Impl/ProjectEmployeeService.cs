using ProjectsApp.Models;
using ProjectsApp.Repositories;

namespace ProjectsApp.Services.Impl
{
    class ProjectEmployeeService : CRUDService<ProjectEmployee, int>, IProjectEmployeeService
    {
        public ProjectEmployeeService(ProjectEmployeeRepo repository) : base(repository)
        {
        }
    }
}
