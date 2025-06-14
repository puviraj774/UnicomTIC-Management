using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data
{
    internal class DatabaseConnection
    {
        private static String connectionString = "Data Source=U.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
