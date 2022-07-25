using ProjectsApp.Models;
using ProjectsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesListPage : ContentPage
    {
        public EmployeesListPage()
        {
            InitializeComponent();
            BindingContext = new EmployeesListViewModel() { Navigation = this.Navigation };
        }
    }
}