using DartsScoreApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DartsScoreApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Navigates to user management page
        async void OnUsersButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsersPage());
        }
    }
}
