using project.Data;
using project.View;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Tablemanagement.CreateTables();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (IsUsersTableEmpty())
            {
                Application.Run(new AdminForm());
            }
            else
            {
                Application.Run(new Login());
            }
        }

        private static bool IsUsersTableEmpty()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {

                    string query = "SELECT COUNT(*) FROM Users";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        long count = (long)command.ExecuteScalar();
                        return count == 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking Users table: " + ex.Message);
                return false;
            }
        }                  
    }
}
