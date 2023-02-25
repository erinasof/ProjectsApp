using ProjectsApp.Models;
using ProjectsApp.Services;

namespace ProjectsApp.Repositories.Impl
{
    public class CompanyRepo : GenericRepo<Company, int>
    {
        public CompanyRepo(ISQLiteService db) : base(db)
        {
        }
    }
}
