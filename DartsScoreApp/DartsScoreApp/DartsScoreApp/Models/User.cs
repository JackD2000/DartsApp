using System;
using System.Collections.Generic;
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
    }
}
