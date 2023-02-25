
using ProjectsApp.Models;
using ProjectsApp.Repositories.Impl;

namespace ProjectsApp.Services.Impl
{
    class CompanyService : CRUDService<Company, int>, ICompanyService
    {
        public CompanyService(CompanyRepo repository) : base(repository)
        {
        }
    }
}
