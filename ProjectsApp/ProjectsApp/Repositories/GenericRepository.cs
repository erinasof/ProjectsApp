using System.Collections.Generic;
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
