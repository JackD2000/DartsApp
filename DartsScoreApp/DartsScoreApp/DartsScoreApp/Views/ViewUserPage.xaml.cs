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
    // Passes in user id from GoToAsync call
    //[QueryProperty(nameof(Id), nameof(Id))]
    public partial class ViewUserPage : ContentPage
    {
        /*public new string Id
        {
            set
            {
                LoadUser(int.Parse(value));
            }
        }*/


        // Sets page's binding context to the selected user
        /*public string UserId
        {
            set
            {
                LoadUser(int.Parse(value));
            }
        }*/
        //public string UserName { get; set; }

        public User UserContext { get; set; }

        // Sets the binding context of the page to a specific user
        public ViewUserPage(User _user)
        {
            InitializeComponent();
            //username.Text = user.Username;
            //Title = user.Username;
            UserContext = _user;
        }

        /*async void LoadUser(int id)
        {
            try
            {
                user = await App.UserDatabase.GetUserAsync(id);
                BindingContext = user;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load user:\n" + ex.Message);
            }
        }*/

        // Delete selected user and return to previous screen
        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            UserContext.DeleteUser();
            await Navigation.PopAsync();
        }

        // Change a user's name if the name is not already taken
        private async void OnNameChangeClicked(object sender, EventArgs e)
        {
            string username = await DisplayPromptAsync("Update User", "Enter new name:", maxLength: 20);

            if (username.Length > 0)
            {
                bool changed = await UserContext.UpdateUsername(username);

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

        // Set page context to selected user on appearing
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = UserContext;
        }
    }
}