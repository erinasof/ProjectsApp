
using ProjectsApp.Models;
using SQLite;
using System.Collections.Generic;

namespace ProjectsApp.Services.Impl
{
    class CompanyService : ICompanyService
    {

        private readonly SQLiteConnection dbConnect;

        public CompanyService(ISQLiteService db)
        {
            dbConnect = db.GetConnection(App.DATABASE_NAME);
            dbConnect.CreateTable<Company>();
        }

        public int DeleteCompanyItem(int id)
        {
            return dbConnect.Delete<Company>(id);
        }

        public Company GetCompanyItem(int id)
        {
            return dbConnect.Get<Company>(id);
        }

        public IEnumerable<Company> GetCompanyItems()
        {
            return dbConnect.Table<Company>().ToList();
        }

        public int SaveCompanyItem(Company item)
        {
            if (item.Id != 0)
            {
                dbConnect.Update(item);
                return item.Id;
            }
            else
            {
                return dbConnect.Insert(item);
            }
        }

    }
}
