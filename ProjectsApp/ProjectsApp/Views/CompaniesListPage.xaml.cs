using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsApp.Models;
using ProjectsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompaniesListPage : ContentPage
    {
        public CompaniesListPage()
        {
            InitializeComponent();
            BindingContext = new CompaniesListViewModel() { Navigation = this.Navigation };
        }
    }
}
