using ProjectsApp.Models;
using ProjectsApp.Repositories;

namespace ProjectsApp.Services.Impl
{
    class ProjectService : CRUDService<Project, int>, IProjectService
    {
        public ProjectService(ProjectRepo repository) : base(repository)
        {
        }
    }
}
