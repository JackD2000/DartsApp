using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DartsScoreApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DartsScoreApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all users from db and set them as the data source for the collectionview
            userCollection.ItemsSource = await App.UserDatabase.GetUsersAsync();
        }

        // Displays prompt for adding a new user to the database
        async void OnAddUserButtonClicked(Object sender, EventArgs e)
        {
            string username = await DisplayPromptAsync("New User", "Enter your name:", maxLength: 20);

            if (username != null)
            {
                if (App.UserDatabase.GetUserAsync(username).Result != default(User))
                {
                    await DisplayAlert("Error", "User with this name already exists!", "Oops...");
                    return;
                }
                else
                {
                    var user = new User { Username = username, Wins = 0 };
                    await App.UserDatabase.SaveUserAsync(user);
                }
            }
        }

        async void UserCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}