using ProjectsApp.Models;
using System.Collections.Generic;

namespace ProjectsApp.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetCompanyItems();

        Company GetCompanyItem(int id);

        void DeleteCompanyItem(Company company);

        void SaveCompanyItem(Company item);
    }
}
