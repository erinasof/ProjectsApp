using System;
using ProjectsApp.Views;
using ProjectsApp.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace ProjectsApp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "projects.db";
        public static Repository database;
        public static Repository Database
        {
            get
            {
                if (database == null)
                {
                    database = new Repository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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
