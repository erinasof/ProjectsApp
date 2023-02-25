using ProjectsApp.Models;
using ProjectsApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectsApp.ViewModels
{
    public class EmployeeViewModel : ItemViewModel
    {
        public ObservableCollection<Project> ProjectsOfEmployee { get; set; }
        public Employee Employee { get; private set; }
        private EmployeesListViewModel Lvm => ListViewModel as EmployeesListViewModel;

        public EmployeeViewModel(Employee e = null)
        {
            Employee = e ?? new Employee();

            var projIds = App.Database.GetProjectEmployeeItems().Where(pe => pe.EmployeeId == Employee.Id).Select(pe => pe.ProjectId);

            ProjectsOfEmployee = new ObservableCollection<Project>(
                App.GetService<IProjectService>().GetItems().Where(project => projIds.Contains(project.Id)));
        }

        public int Id
        {
            get => Employee.Id;
            set
            {
                if (Employee.Id != value)
                {
                    Employee.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string LastName
        {
            get => Employee.LastName;
            set
            {
                if (Employee.LastName != value)
                {
                    Employee.LastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string Name
        {
            get => Employee.Name;
            set
            {
                if (Employee.Name != value)
                {
                    Employee.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Patronymic
        {
            get => Employee.Patronymic;
            set
            {
                if (Employee.Patronymic != value)
                {
                    Employee.Patronymic = value;
                    OnPropertyChanged("Patronymic");
                }
            }
        }

        public string Email
        {
            get => Employee.Email;
            set
            {
                if (Employee.Email != value)
                {
                    Employee.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private bool EmailIsUnique()
        {
            return Lvm.Employees.FirstOrDefault(e => e.Email == Email && e.Id != Id) == null;
        }

        public override bool IsValid => !string.IsNullOrEmpty(Name) &&
                    !string.IsNullOrEmpty(LastName) &&
                    !string.IsNullOrEmpty(Patronymic) &&
                    !string.IsNullOrEmpty(Email) &&
                    Helper.EmailIsValid(Email) && EmailIsUnique();
    }
}
