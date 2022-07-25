using ProjectsApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CompaniesClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CompaniesListPage());
        }

        private void EmployeesClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EmployeesListPage());
        }

        private void ProjectsClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProjectsListPage());
        }

        private void LinksClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProjectEmployeesListPage());
        }
    }
}
