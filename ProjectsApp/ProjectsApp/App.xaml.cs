using System;
using ProjectsApp.Repositories;
using System.IO;
using ProjectsApp.Services;
using ProjectsApp.Services.Impl;
using ProjectsApp.ViewModels;
using MvvmHelpers;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using ProjectsApp.Repositories.Impl;

namespace ProjectsApp
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public const string DATABASE_NAME = "projects.db";

        public static GenericRepository database;
        public static GenericRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new GenericRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App(Action<IServiceCollection> addPlatformServices = null)
        {
            InitializeComponent();

            SetupServices(addPlatformServices);

            MainPage = new NavigationPage(new MainPage());
        }

        void SetupServices(Action<IServiceCollection> addPlatformServices = null)
        {            
            //DependencyService.Get<ISQLiteService>().GetConnectionWithCreateDatabase();
            var services = new ServiceCollection();

            // Add platform specific services
            addPlatformServices?.Invoke(services);

            services.AddTransient<CompaniesListViewModel>();

            // Add core services
            services.AddSingleton<ICompanyService, CompanyService>();
            // Add core repositories
            services.AddSingleton<CompanyRepository>();

            ServiceProvider = services.BuildServiceProvider();
        }

        public static BaseViewModel GetViewModel<TViewModel>() 
            where TViewModel : BaseViewModel => ServiceProvider.GetService<TViewModel>();

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
