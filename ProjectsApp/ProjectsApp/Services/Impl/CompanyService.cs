
using ProjectsApp.Models;
using ProjectsApp.Repositories;
using ProjectsApp.Repositories.Impl;
using System.Collections.Generic;

namespace ProjectsApp.Services.Impl
{
    class CompanyService : CRUDService<Company, int>, ICompanyService
    {
        public CompanyService(CompanyRepo repository) : base(repository)
        {
        }
    }
}
