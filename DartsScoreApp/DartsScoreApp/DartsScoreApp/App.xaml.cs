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

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
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
