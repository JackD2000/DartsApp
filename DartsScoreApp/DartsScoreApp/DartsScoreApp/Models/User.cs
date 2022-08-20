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
        public string Name { get; set; }
    }
}
