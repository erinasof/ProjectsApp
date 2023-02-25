using ProjectsApp.Models;
using ProjectsApp.Repositories.Impl;
using ProjectsApp.Services;

namespace ProjectsApp.Repositories
{
    class ProjectRepo : GenericRepo<Project, int>
    {
        public ProjectRepo(ISQLiteService db) : base(db)
        {
        }
    }
}
