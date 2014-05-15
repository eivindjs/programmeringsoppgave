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
        /// Statisk klasse for å ta vare på brukernavn og id, så det blir 
        /// letter å hente ut info i andre klasser.
        /// </summary>
        private static int id; //Bruker id
        private static string username; //Brukernavn
        private static string password; //Passord til innlogget bruker
      
        public static int Id
        {
            get { return id; }
            set { id = value; }
        }
        public static string Username
        {
            get { return username; }
            set { username = value; }
        }
        public static string Password
        {
            get { return password; }
            set { password = value;}
        }
    }
}
