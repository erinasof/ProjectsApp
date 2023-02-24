
using ProjectsApp.Models;
using ProjectsApp.Repositories.Impl;
using System.Collections.Generic;

namespace ProjectsApp.Services.Impl
{
    class CompanyService : ICompanyService
    {

        private readonly CompanyRepository repository;

        public CompanyService(CompanyRepository repository)
        {
            this.repository = repository;
        }

        public void DeleteCompanyItem(Company company)
        {
            repository.Delete(company);
        }

        public Company GetCompanyItem(int id)
        {
            return repository.GetOne(id);
        }

        public IEnumerable<Company> GetCompanyItems()
        {
            return repository.GetAll();
        }

        public void SaveCompanyItem(Company item)
        {
            if (item.Id != 0)
            {
                repository.Update(item);
            }
            else
            {
                repository.Add(item);
            }
        }

    }
}
