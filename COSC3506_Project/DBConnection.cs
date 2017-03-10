using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace COSC3506_Project
{
    class DBConnection
    {
        private MySqlConnection connection;
        private string server, database, password, username;

        public DBConnection (string server, string database, string password, string username)
        {
            this.server = server;
            this.database = database;
            this.username = username;
            this.password = password;
        }

        private void Initialize()
        {
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" +
                "UID=" + username + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        Console.WriteLine("A connection to the database could not be established.");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid database credentials.");
                        break;
                }
                return false;
            }
        }
    }
}
