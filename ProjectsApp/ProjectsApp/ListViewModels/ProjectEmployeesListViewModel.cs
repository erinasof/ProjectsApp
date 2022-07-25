using ProjectsApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace ProjectsApp.ViewModels
{
    public class ProjectEmployeesListViewModel : ListViewModel
    {
        private ProjectEmployeeViewModel selectedProjectEmployee;

        public ObservableCollection<ProjectEmployeeViewModel> ProjectEmployees { get; set; }

        public ProjectEmployeesListViewModel()
        {
            ProjectEmployees = new ObservableCollection<ProjectEmployeeViewModel>();
            ReloadTable();
            CreateCommand = new Command(CreateProjectEmployee);
            DeleteCommand = new Command(DeleteProjectEmployee);
            SaveCommand = new Command(SaveProjectEmployeeAsync);
            BackCommand = new Command(Back);
            PageDisappearingCommand = new Command(ReloadTable);
        }

        private void ReloadTable()
        {
            ProjectEmployees.Clear();
            ProjectEmployees.Add(App.Database.GetProjectEmployeeItems().Select(x => new ProjectEmployeeViewModel(x) { ListViewModel = this }));
        }

        public ProjectEmployeeViewModel SelectedProjectEmployee
        {
            get { return selectedProjectEmployee; }
            set
            {
                if (selectedProjectEmployee != value)
                {
                    ProjectEmployeeViewModel tempProjectEmployee = value;
                    selectedProjectEmployee = null;
                    OnPropertyChanged("SelectedProjectEmployee");
                    Navigation.PushAsync(new ProjectEmployeePage(tempProjectEmployee));
                }
            }
        }

        private void CreateProjectEmployee()
        {
            Navigation.PushAsync(new ProjectEmployeePage(new ProjectEmployeeViewModel() { ListViewModel = this }));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private async void SaveProjectEmployeeAsync(object projectEmployeeObject)
        {
            if (projectEmployeeObject is ProjectEmployeeViewModel projectEmployee && projectEmployee.IsValid)
            {
                if (!ProjectEmployees.Contains(projectEmployee))
                {
                    ProjectEmployees.Add(projectEmployee);
                }
                App.Database.SaveProjectEmployeeItem(projectEmployee.ProjectEmployee);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Уведомление", "Связь не добавлена/изменена", "Ok");
            }

            Back();
        }

        private void DeleteProjectEmployee(object projectEmployeeObject)
        {
            if (projectEmployeeObject is ProjectEmployeeViewModel projectEmployee)
            {
                ProjectEmployees.Remove(projectEmployee);
                App.Database.DeleteProjectEmployeeItem(projectEmployee.Id);
            }

            Back();
        }
    }
}
