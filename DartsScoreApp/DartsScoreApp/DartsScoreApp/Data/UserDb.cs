﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using SQLite;
using DartsScoreApp.Models;

namespace DartsScoreApp.Data
{
    public class UserDb
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
            return db.QueryAsync<User>("SELECT * FROM users");

            // Same query but using LINQ:
            //return db.Table<User>().ToListAsync();
        }

        // Returns a specific user from ID or returns null if no such user exists
        public async Task<User> GetUserAsync(int id)
        {
            try
            {
                User user = (await db.QueryAsync<User>("SELECT * FROM users WHERE id = ?", id.ToString()))[0];
                return user;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }

            /*List<User> results = await db.QueryAsync<User>("SELECT * FROM users WHERE id = ?", id.ToString());

            if (results.Count > 0)
            {
                return results[0];
            }
            else
            {
                return null;
            }*/

            // A simpler query using LINQ:
            //return db.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        // Returns a specific user from username or returns null if no such user exists
        public async Task<User> GetUserAsync(string username)
        {
            try
            {
                User user = (await db.QueryAsync<User>("SELECT * FROM users WHERE username = ?", username))[0];
                return user;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }

            /*
            List<User> results = await db.QueryAsync<User>("SELECT * FROM users WHERE username = ?", username);

            if (results != null)
            {
                return results[0];
            }
            else
            {
                return null;
            }*/

            // A simpler query using LINQ:
            //return db.Table<User>().Where(i => i.Username == username).FirstOrDefaultAsync();
        }

        // Save a new user to the db
        public Task<int> SaveUserAsync(User user)
        {
                return db.InsertAsync(user);
        }

        // Delete a user from the db by reference
        public Task<int> DeleteUserAsync(User user)
        {
            return db.DeleteAsync(user);
        }

        // Delete a user from the db by id
        public async Task DeleteUserAsync(int id)
        {
            try
            {
                await db.QueryAsync<User>("DELETE FROM users WHERE id = ?", id);
            }
            catch
            {
                Console.WriteLine("Failed to delete user, ID = " + id);
            }
        }
    }
}
