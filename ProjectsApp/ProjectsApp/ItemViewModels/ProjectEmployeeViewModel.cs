using ProjectsApp.Models;
using ProjectsApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProjectsApp.ViewModels
{
    public class ProjectEmployeeViewModel : ItemViewModel
    {
        public ProjectEmployee ProjectEmployee { get; private set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Project> Projects { get; set; }
        private ProjectEmployeesListViewModel Lvm => ListViewModel as ProjectEmployeesListViewModel;

        private Employee _selectedEmployee;
        private Project _selectedProject;

        public ProjectEmployeeViewModel(ProjectEmployee pe = null)
        {
            ProjectEmployee = pe ?? new ProjectEmployee();
            Employees = new ObservableCollection<Employee>(App.GetService<IEmployeeService>().GetItems());
            Projects = new ObservableCollection<Project>(App.Database.GetProjectItems());

            _selectedEmployee = Employees.FirstOrDefault(e => ProjectEmployee.EmployeeId == e.Id);
            _selectedProject = Projects.FirstOrDefault(p => ProjectEmployee.ProjectId == p.Id);
        }

        public int Id
        {
            get => ProjectEmployee.Id;
            set
            {
                if (ProjectEmployee.Id != value)
                {
                    ProjectEmployee.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                ProjectEmployee.EmployeeId = value == null ? 0 : Employees.FirstOrDefault(e => e == value).Id;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        public Project SelectedProject
        {
            get => _selectedProject;
            set
            {
                _selectedProject = value;
                ProjectEmployee.ProjectId = value == null ? 0 : Projects.FirstOrDefault(p => p == value).Id;
                OnPropertyChanged("SelectedProject");
            }
        }

        private bool IsUnique => Lvm.ProjectEmployees.FirstOrDefault(pe =>
                                                   pe.SelectedProject.Id == SelectedProject.Id &&
                                                   pe.SelectedEmployee.Id == SelectedEmployee.Id &&
                                                   pe.Id != Id) == null;

        public override bool IsValid => _selectedProject != null && _selectedEmployee != null && IsUnique;
    }
}
