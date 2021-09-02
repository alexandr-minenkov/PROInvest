using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Security.Permissions;

namespace Server
{
    class DatabaseConnection
    {
        static string host = "127.0.0.1";
        static int port = 3306;
        static string database = "database";
        static string username = "HP";
        static string password = "00114115";

        static MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;username=HP;password=00114115;database=database;");
        public static MySqlConnection GetConnection()
        {
            // Connection String.
            //String connString;
            //connString = "Server=" + host + ";Database=" + database
            //    + ";port=" + port + ";User Id=" + username + ";password=" + password;

            //MySqlConnection connection = new MySqlConnection(connString);

            return connection;
        }

        public static void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

        }

        public static void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

        }

        public static void ConnectToDatabase()
        {
            Console.WriteLine("Getting Connection ...");
            try
            {
                Console.WriteLine("Openning Connection ...");
                connection.Open();
                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            connection.Close();
        }
    }
}
