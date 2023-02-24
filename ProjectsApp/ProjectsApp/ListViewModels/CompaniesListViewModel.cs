using Microsoft.Extensions.DependencyInjection;
using ProjectsApp.Services;
using ProjectsApp.Views;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace ProjectsApp.ViewModels
{
    public class CompaniesListViewModel : ListViewModel
    {
        public ObservableCollection<CompanyViewModel> Companies { get; set; }

        private CompanyViewModel selectedCompany;

        private readonly ICompanyService companyService;

        public CompaniesListViewModel()
        {
            companyService = App.ServiceProvider.GetService<ICompanyService>();
            Companies = new ObservableCollection<CompanyViewModel>();
            ReloadTable();
            CreateCommand = new Command(CreateCompany);
            DeleteCommand = new Command(DeleteCompany);
            SaveCommand = new Command(SaveCompany);
            BackCommand = new Command(Back);
            PageDisappearingCommand = new Command(ReloadTable);
        }

        public void ReloadTable()
        {
            Companies.Clear();
            Companies.Add(companyService.GetCompanyItems().Select(x => new CompanyViewModel(x) { ListViewModel = this }));
        }

        public CompanyViewModel SelectedCompany
        {
            get { return selectedCompany; }
            set
            {
                if (selectedCompany != value)
                {
                    CompanyViewModel tempCompany = value;
                    selectedCompany = null;
                    OnPropertyChanged("SelectedCompany");
                    Navigation.PushAsync(new CompanyPage(tempCompany));
                }
            }
        }

        private void CreateCompany()
        {
            Navigation.PushAsync(new CompanyPage(new CompanyViewModel() { ListViewModel = this }));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private async void SaveCompany(object companyObject)
        {
            if (companyObject is CompanyViewModel company && company.IsValid)
            {
                if (!Companies.Contains(company))
                {
                    Companies.Add(company);
                }

                companyService.SaveCompanyItem(company.Company);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Уведомление", "Компания не добавлена/изменена", "Ok");
            }

            Back();
        }

        private void DeleteCompany(object companyObject)
        {
            if (companyObject is CompanyViewModel company)
            {
                Companies.Remove(company);
                companyService.DeleteCompanyItem(company.Company);
            }
            Back();
        }
    }
}
