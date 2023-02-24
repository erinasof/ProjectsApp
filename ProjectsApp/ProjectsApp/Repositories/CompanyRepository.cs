using ProjectsApp.Models;
using ProjectsApp.Services;

namespace ProjectsApp.Repositories.Impl
{
    public class CompanyRepository : GenericRepo<Company, int>
    {
        public CompanyRepository(ISQLiteService db) : base(db)
        {
        }
    }
}
