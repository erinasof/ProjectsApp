using ProjectsApp.Models;
using ProjectsApp.Services;
using SQLite;
using System.Collections.Generic;

namespace ProjectsApp.Repositories.Impl
{
    public abstract class GenericRepo<T, TKey> : IRepository<T, TKey> where T : PKEntity<TKey>, new()
    {
        private readonly SQLiteConnection dbConnect;

        public GenericRepo(ISQLiteService db)
        {
            dbConnect = db.GetConnection(App.DATABASE_NAME);
            dbConnect.CreateCommand("PRAGMA foreign_keys = ON;").ExecuteNonQuery();
            dbConnect.CreateTables<Company, Employee, Project, ProjectEmployee>();
        }

        public void Add(T entity)
        {
            dbConnect.Insert(entity);
        }

        public void Delete(T entity)
        {
            dbConnect.Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbConnect.Table<T>().ToList();
        }

        public T GetOne(TKey id)
        {
            return dbConnect.Get<T>(id);
        }

        public void Update(T entity)
        {
            dbConnect.Update(entity);
        }
    }
}
