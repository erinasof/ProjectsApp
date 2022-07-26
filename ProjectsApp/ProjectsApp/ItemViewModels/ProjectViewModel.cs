﻿using ProjectsApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectsApp.ViewModels
{
    public class ProjectViewModel : ItemViewModel
    {
        public ObservableCollection<Employee> EmployeesOfProject { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Company> Companies { get; set; }
        public Project Project { get; private set; }

        private ProjectsListViewModel lvm => ListViewModel as ProjectsListViewModel;
        private Employee _selectedEmployee;
        private Company _selectedExecutorCompany;
        private Company _selectedCustomerCompany;
        private string _priority;

        public ProjectViewModel(Project project = null)
        {
            Project = project ?? new Project();
            Employees = new ObservableCollection<Employee>( App.Database.GetEmployeeItems());
            Companies = new ObservableCollection<Company>(App.Database.GetCompanyItems());

            var empIds = App.Database.GetProjectEmployeeItems().Where(pe => pe.ProjectId == Project.Id).Select(pe => pe.EmployeeId);

            EmployeesOfProject = new ObservableCollection<Employee>(
                App.Database.GetEmployeeItems().Where(employee => empIds.Contains(employee.Id)));

            _selectedEmployee = Employees.FirstOrDefault(e => Project.HeadId == e.Id);
            _selectedExecutorCompany = Companies.FirstOrDefault(e => Project.ExecutorCompanyId == e.Id);
            _selectedCustomerCompany = Companies.FirstOrDefault(e => Project.CustomerCompanyId == e.Id);
            _priority = Project.Priority.ToString();
        }

        public int Id
        {
            get => Project.Id;
            set
            {
                if (Project.Id != value)
                {
                    Project.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get => Project.Name;
            set
            {
                if (Project.Name != value)
                {
                    Project.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public DateTime FinishDate
        {
            get => Project.FinishDate;
            set
            {
                Project.FinishDate = value;
                OnPropertyChanged("FinishDate");
            }
        }

        public DateTime StartDate
        {
            get => Project.StartDate;
            set
            {
                Project.StartDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public string Priority
        {
            get => _priority;
            set
            {
                if (Project.Priority.ToString() != value)
                {
                    _priority = value;
                    if (int.TryParse(value, out int intVal))
                    {
                        Project.Priority = intVal;
                        OnPropertyChanged("Priority");
                    }
                }
            }
        }


        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                Project.HeadId = value == null ? 0 : Employees.FirstOrDefault(e => e == value).Id;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        public Company SelectedExecutorCompany
        {
            get => _selectedExecutorCompany;
            set
            {
                _selectedExecutorCompany = value;
                Project.ExecutorCompanyId = value == null ? 0 : Companies.FirstOrDefault(c => c == value).Id;
                OnPropertyChanged("SelectedExecutorCompany");
            }
        }

        public Company SelectedCustomerCompany
        {
            get => _selectedCustomerCompany;
            set
            {
                _selectedCustomerCompany = value;
                Project.CustomerCompanyId = value == null ? 0 : Companies.FirstOrDefault(c => c == value).Id;
                OnPropertyChanged("SelectedCustomerCompany");
            }
        }

        public override bool IsValid => !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Priority) && _priority == Project.Priority.ToString() && FinishDate >= StartDate;
    }
}
