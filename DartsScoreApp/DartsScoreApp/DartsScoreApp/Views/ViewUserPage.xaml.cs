using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DartsScoreApp.Models;
//using DartsScoreApp.Data;

namespace DartsScoreApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewUserPage : ContentPage
    {
        public User UserContext { get; set; }

        // Sets the binding context of the page to a specific user
        public ViewUserPage(User _user)
        {
            InitializeComponent();
            UserContext = _user;
        }

        // Sets page context to selected user on page appearing
        // Prevents bug where no user data would display
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = UserContext;
        }

        // Deletes selected user and returns to previous page
        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            UserContext.DeleteUser();
            await Navigation.PopAsync();
        }

        // Changes a user's name if the name is not already taken
        private async void OnNameChangeClicked(object sender, EventArgs e)
        {
            string username = await DisplayPromptAsync("Update User", "Enter new name:", maxLength: 20);

            if (username.Length > 0)
            {
                bool changed = await UserContext.UpdateUsername(username);

                // Returns to previous page if successful or displays error if username is taken
                if (changed)
                {
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Username is already taken.", "Oops...");
                }
            }
        }

    }
}