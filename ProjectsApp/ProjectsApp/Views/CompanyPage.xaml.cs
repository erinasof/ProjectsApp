using System;
using System.Collections.Generic;
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
    public partial class CompanyPage : ContentPage
    {
        public CompanyViewModel ViewModel { get; private set; }
        public CompanyPage(CompanyViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}