﻿using System.Collections.Generic;
using ProjectsApp.Models;
using SQLite;

namespace ProjectsApp.Repositories
{
    public class GenericRepository
    {
        private readonly SQLiteConnection database;
        public GenericRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
        }

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
