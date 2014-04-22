using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
/**
 * Her skjer alle oppkoblinger mot DB.
 * 
 **/
namespace projectcsharp
{
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

        //Åpner tilkoblig mot database
        private bool OpenConnection()
        {
            connection.Open();
            return true;
        }
        //Lukker tilkobling mot database
        private bool CloseConnection()
        {
            connection.Close();
            return true;
        }

        //for SELECT
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

        //For INSERT, DELETE og UPDATE
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