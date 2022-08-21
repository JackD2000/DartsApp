using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DartsScoreApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Username { get; set; }
        public int Wins { get; set; }
    }
}
