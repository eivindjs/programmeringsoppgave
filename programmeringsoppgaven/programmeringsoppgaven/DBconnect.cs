using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace projectcsharp
{
    /// <summary>
    /// Tord 
    /// DBConnect.cs
    /// 
    /// Klasse som kobler opp mot databasen og inneholder metoder for
    /// å hente ut data, sett inn, oppdatere og slette data.
    /// </summary>
    public class DBConnect
    {
        private MySqlConnection connection; 
        private MySqlDataAdapter adapter; 
        private DataTable dataTable; 
        private string server; 
        private string database; 
        private string uid; 
        private string password; 

        public DBConnect()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            server = "kark.hin.no";
            database = "TMKF_DB1";
            uid = "tordm";
            password = "tordm123";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Åpner tilkoblig mot database
        /// </summary>
        /// <returns>true</returns>
        private bool OpenConnection()
        {
            connection.Open();
            return true;
        }
        /// <summary>
        /// Lukker tilkoblingen mot databasen
        /// </summary>
        /// <returns>true</returns>
        private bool CloseConnection()
        {
            connection.Close();
            return true;
        }

        /// <summary>
        /// Henter ut data fra databasen(SELECT)
        /// </summary>
        /// <param name="query">Sql spørring</param>
        /// <returns>Datatable med data</returns>
        public DataTable getAll(string query)
        {
            if (this.OpenConnection() == true)
            {
                dataTable = new DataTable();
                adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
                this.CloseConnection();
            }
            return dataTable;
        }

        /// <summary>
        /// Metode for å sette inn, slette og oppdatere data i databasen
        /// </summary>
        /// <param name="query">Sql spørring</param>
        public void InsertDeleteUpdate(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("An error occurred: '{0}'", e);
                }
                this.CloseConnection();
            }
        }
    }
}