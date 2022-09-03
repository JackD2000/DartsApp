using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DartsScoreApp.Data;
using System.IO;

namespace DartsScoreApp
{
    public partial class App : Application
    {
        static UserDb db;

        // Creates database connection as a singleton
        public static UserDb UserDatabase
        {
            get
            {
                if (db == null)
                {
                    db = new UserDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Users.db3"));
                }
                return db;
            }
        }

        // Creates main page as a NavigationPage
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainMenuPage())
            {
                BarBackgroundColor = Color.ForestGreen,
            };
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
