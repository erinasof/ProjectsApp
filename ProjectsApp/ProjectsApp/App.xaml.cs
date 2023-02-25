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
        private static IServiceProvider ServiceProvider;

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
            var services = new ServiceCollection();

            // Add platform specific services
            addPlatformServices?.Invoke(services);

            // Add core services
            services.AddSingleton<ICompanyService, CompanyService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IProjectService, ProjectService>();
            services.AddSingleton<IProjectEmployeeService, ProjectEmployeeService>();

            // Add core repositories
            services.AddSingleton<CompanyRepo>();
            services.AddSingleton<EmployeeRepo>();
            services.AddSingleton<ProjectRepo>();
            services.AddSingleton<ProjectEmployeeRepo>();

            ServiceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

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
