using ProjectsApp.Models;

namespace ProjectsApp.Services
{
    public interface IProjectService : ICRUDService<Project, int>
    {
        //TODO: дополнительные методы, которых нет в ICRUDService
    }
}
