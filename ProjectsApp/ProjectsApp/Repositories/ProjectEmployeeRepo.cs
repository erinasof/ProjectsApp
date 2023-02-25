using ProjectsApp.Models;
using ProjectsApp.Repositories.Impl;
using ProjectsApp.Services;

namespace ProjectsApp.Repositories
{
    class ProjectEmployeeRepo : GenericRepo<ProjectEmployee, int>
    {
        public ProjectEmployeeRepo(ISQLiteService db) : base(db)
        {
        }
    }
}
