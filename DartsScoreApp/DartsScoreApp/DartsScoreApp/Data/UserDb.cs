using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using SQLite;
using DartsScoreApp.Models;

namespace DartsScoreApp.Data
{
    internal class UserDb
    {
        readonly SQLiteAsyncConnection db;

        public UserDb(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<User>().Wait();
        }

        // Returns all users as list
        public Task<List<User>> GetUsersAsync()
        {
            return db.Table<User>().ToListAsync();
        }

        // Returns a specific user from ID
        public Task<User> GetUserAsync(int id)
        {
            return db.Table<User>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        // Save a new user to the db
        public Task<int> SaveUserAsync(User user)
        {
                return db.InsertAsync(user);
        }

        // Delete a user from the db by ID
        public Task<int> DeleteUserAsync(User user)
        {
            return db.DeleteAsync(user);
        }
    }
}
