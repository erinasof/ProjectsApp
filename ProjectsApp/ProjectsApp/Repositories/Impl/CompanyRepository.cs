using ProjectsApp.Models;
using ProjectsApp.Services;
using SQLite;
using System.Collections.Generic;

namespace ProjectsApp.Repositories.Impl
{
    class CompanyRepository : IRepository<Company>
    {
        private readonly SQLiteConnection dbConnect;

        public CompanyRepository(ISQLiteService db)
        {
            dbConnect = db.GetConnection(App.DATABASE_NAME);
            dbConnect.CreateTable<Company>();
        }

        public void Add(Company entity)
        {
            dbConnect.Insert(entity);
        }

        public void Delete(Company entity)
        {
            dbConnect.Delete(entity);
        }

        public IEnumerable<Company> GetAll()
        {
            return dbConnect.Table<Company>().ToList();
        }

        public Company GetOne(int id)
        {
            return dbConnect.Get<Company>(id);
        }

        public void Update(Company entity)
        {
            dbConnect.Update(entity);
        }
    }
}
