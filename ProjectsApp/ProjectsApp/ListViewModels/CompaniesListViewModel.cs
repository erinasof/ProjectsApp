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

        public CompaniesListViewModel()
        {
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
            Companies.Add(App.Database.GetCompanyItems().Select(x => new CompanyViewModel(x) { ListViewModel = this }));
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

                App.Database.SaveCompanyItem(company.Company);
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
                App.Database.DeleteCompanyItem(company.Id);
            }
            Back();
        }
    }
}
