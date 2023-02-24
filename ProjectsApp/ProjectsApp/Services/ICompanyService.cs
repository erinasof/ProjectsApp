using ProjectsApp.Models;
using System.Collections.Generic;

namespace ProjectsApp.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetCompanyItems();

        Company GetCompanyItem(int id);

        int DeleteCompanyItem(int id);

        int SaveCompanyItem(Company item);
    }
}
