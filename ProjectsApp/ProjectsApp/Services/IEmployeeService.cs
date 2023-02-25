using ProjectsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsApp.Services
{
    public interface IEmployeeService : ICRUDService<Employee, int>
    {
        //TODO: дополнительные методы, которых нет в ICRUDService
    }
}
