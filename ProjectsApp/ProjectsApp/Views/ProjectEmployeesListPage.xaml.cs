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
    public partial class ProjectEmployeesListPage : ContentPage
    {
        public ProjectEmployeesListPage()
        {
            InitializeComponent();
            BindingContext = new ProjectEmployeesListViewModel() { Navigation = this.Navigation };
        }
    }
}