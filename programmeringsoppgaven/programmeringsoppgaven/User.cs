using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectcsharp
{
    static class User
    {
        /// <summary>
        /// Eivind
        /// Statisk klasse for å ta vare på brukernavn og id, så det blir 
        /// lettere å hente ut info i andre klasser.
        /// </summary>
        private static int id; //Bruker id
        private static string username; //Brukernavn
        private static string password; //Passord til innlogget bruker
        private static int difficulty_level;

        public static int Difficulty_level
        {
            get { return User.difficulty_level; }
            set { User.difficulty_level = value; }
        }

        public static int Id
        {
            get { return User.id; }
            set { User.id = value; }
        }
        public static string Username
        {
            get { return User.username; }
            set { User.username = value; }
        }
        public static string Password
        {
            get { return User.password; }
            set { User.password = value;}
        }
    }
}
