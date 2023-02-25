using ProjectsApp.Services;
using ProjectsApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace ProjectsApp.ViewModels
{
    public class EmployeesListViewModel : ListViewModel
    {
        public ObservableCollection<EmployeeViewModel> Employees { get; set; }

        private EmployeeViewModel selectedEmployee;

        private readonly IEmployeeService employeeService;

        public EmployeesListViewModel()
        {
            employeeService = App.GetService<IEmployeeService>();
            Employees = new ObservableCollection<EmployeeViewModel>();
            ReloadTable();
            CreateCommand = new Command(CreateEmployee);
            DeleteCommand = new Command(DeleteEmployee);
            SaveCommand = new Command(SaveEmployee);
            BackCommand = new Command(Back);
            PageDisappearingCommand = new Command(ReloadTable);
        }

        public EmployeeViewModel SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (selectedEmployee != value)
                {
                    EmployeeViewModel tempEmployee = value;
                    selectedEmployee = null;
                    OnPropertyChanged("SelectedEmployee");
                    Navigation.PushAsync(new EmployeePage(tempEmployee));
                }
            }
        }

        public void ReloadTable()
        {
            Employees.Clear();
            Employees.Add(employeeService.GetItems().Select(x => new EmployeeViewModel(x) { ListViewModel = this }));
        }

        private void CreateEmployee()
        {
            Navigation.PushAsync(new EmployeePage(new EmployeeViewModel() { ListViewModel = this }));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private async void SaveEmployee(object employeeObject)
        {
            if (employeeObject is EmployeeViewModel employee && employee.IsValid)
            {
                if (!Employees.Contains(employee))
                {
                    Employees.Add(employee);
                }
                employeeService.SaveItem(employee.Employee);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Уведомление", "Сотрудник не добавлен/изменен", "Ok");
            }

            Back();
        }
        private void DeleteEmployee(object employeeObject)
        {
            if (employeeObject is EmployeeViewModel employee)
            {
                Employees.Remove(employee);
                employeeService.DeleteItem(employee.Employee);
            }
            Back();
        }
    }
}
