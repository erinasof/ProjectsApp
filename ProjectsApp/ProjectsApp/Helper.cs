using ProjectsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectsApp
{
    public static class Helper
    {
        public static bool EmailIsValid(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        }

        public static void Add(this ObservableCollection<CompanyViewModel> thisColllection, IEnumerable<CompanyViewModel> secondCollection)
        {
            foreach (var item in secondCollection)
            {
                thisColllection.Add(item);
            }
        }

        public static void Add(this ObservableCollection<EmployeeViewModel> thisColllection, IEnumerable<EmployeeViewModel> secondCollection)
        {
            foreach (var item in secondCollection)
            {
                thisColllection.Add(item);
            }
        }

        public static void Add(this ObservableCollection<ProjectEmployeeViewModel> thisColllection, IEnumerable<ProjectEmployeeViewModel> secondCollection)
        {
            foreach (var item in secondCollection)
            {
                thisColllection.Add(item);
            }
        }

        public static void SetCollection(this ObservableCollection<ProjectViewModel> thisColllection, IEnumerable<ProjectViewModel> secondCollection)
        {
            thisColllection.Clear();
            foreach (var item in secondCollection)
            {
                thisColllection.Add(item);
            }
        }

        public static ObservableCollection<ProjectViewModel> ReplaceCollection(this ObservableCollection<ProjectViewModel> thisCollection)
        {
            var NewCollection = new ObservableCollection<ProjectViewModel>();
            NewCollection.SetCollection(thisCollection);
            thisCollection.Clear();
            return NewCollection;
        }
    }
}
