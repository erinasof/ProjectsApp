using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectsApp.Models;
using SQLite;

namespace ProjectsApp.Repositories
{
    public class Repository
    {
        private SQLiteConnection database;
        public Repository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Company>();
            database.CreateTable<Employee>();
            database.CreateTable<Project>();
            database.CreateTable<ProjectEmployee>();
        }
        #region company
        public IEnumerable<Company> GetCompanyItems()
        {
            return database.Table<Company>().ToList();
        }
        public Company GetCompanyItem(int id)
        {
            return database.Get<Company>(id);
        }
        public int DeleteCompanyItem(int id)
        {
            return database.Delete<Company>(id);
        }
        public int SaveCompanyItem(Company item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        #endregion company

        #region employee
        public IEnumerable<Employee> GetEmployeeItems()
        {
            return database.Table<Employee>().ToList();
        }
        public Employee GetEmployeeItem(int id)
        {
            return database.Get<Employee>(id);
        }
        public int DeleteEmployeeItem(int id)
        {
            var linksOfEmployee = GetProjectEmployeeItems().Where(pe => pe.EmployeeId == id);
            foreach (var link in linksOfEmployee)
            {
                database.Delete<ProjectEmployee>(link.Id);
            }
            
            return database.Delete<Employee>(id);
        }
        public int SaveEmployeeItem(Employee item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        #endregion employee

        #region project
        public IEnumerable<Project> GetProjectItems()
        {
            return database.Table<Project>().ToList();
        }
        public Project GetProjectItem(int id)
        {
            return database.Get<Project>(id);
        }
        public int DeleteProjectItem(int id)
        {
            var linksOfProject = GetProjectEmployeeItems().Where(pe => pe.ProjectId == id);
            foreach (var link in linksOfProject)
            {
                database.Delete<ProjectEmployee>(link.Id);
            }

            return database.Delete<Project>(id);
        }
        public int SaveProjectItem(Project item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        #endregion project

        #region projectemployee
        public IEnumerable<ProjectEmployee> GetProjectEmployeeItems()
        {
            return database.Table<ProjectEmployee>().ToList();
        }
        public ProjectEmployee GetProjectEmployeeItem(int id)
        {
            return database.Get<ProjectEmployee>(id);
        }
        public int DeleteProjectEmployeeItem(int id)
        {
            return database.Delete<ProjectEmployee>(id);
        }
        public int SaveProjectEmployeeItem(ProjectEmployee item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        #endregion projectemployee
    }
}
