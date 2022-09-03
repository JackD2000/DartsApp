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

            // Adds user to db if username is not taken
            if (username.Length > 0)
            {
                var result = await App.UserDatabase.GetUserAsync(username);

                if (result != null)
                {
                    await DisplayAlert("Error", "User with this name already exists!", "Oops...");
                }
                else
                {
                    var user = new User { Username = username, Wins = 0 };
                    await App.UserDatabase.SaveUserAsync(user);
                }
            }
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Navigate to user settings/score page with selected user as binding context
            User user = (User)e.CurrentSelection.FirstOrDefault();
            await Navigation.PushAsync(new ViewUserPage(user));
        }
    }
}