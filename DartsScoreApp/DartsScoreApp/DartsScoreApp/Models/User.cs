using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using SQLite;

namespace DartsScoreApp.Models
{
    [Table("users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id
        { get; set; }

        [Column("username")]
        public string Username
        { get; set; }

        [Column("wins")]
        public int Wins
        { get; set; }

        // Deletes the user from the db
        public async void DeleteUser()
        {
            await App.UserDatabase.DeleteUserAsync(Id);
        }

        // Updates username, returns true if successful
        public async Task<bool> UpdateUsername(string _name)
        {
            var result = await App.UserDatabase.GetUserAsync(_name);

            if (result != null)
            {
                return false;
            }
            else
            {
                await App.UserDatabase.UpdateUsernameAsync(Id, _name);
                return true;
            }
        }
    }
}
