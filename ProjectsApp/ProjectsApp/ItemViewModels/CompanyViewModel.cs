using ProjectsApp.Models;

namespace ProjectsApp.ViewModels
{
    public class CompanyViewModel : ItemViewModel
    {

        public Company Company { get; private set; }

        public CompanyViewModel(Company c = null)
        {
            Company = c ?? new Company();
        }

        public int Id
        {
            get => Company.Id;
            set
            {
                if (Company.Id != value)
                {
                    Company.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get => Company.Name;
            set
            {
                if (Company.Name != value)
                {
                    Company.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public override bool IsValid => !string.IsNullOrEmpty(Name);
    }
}
