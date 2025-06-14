using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using project.Models;
using project.Data;
using System.Data.SQLite;

namespace project.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login_btn_Click_1(object sender, EventArgs e)
        {
            string username = username_txt.Text;
            string password = password_txt.Text;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    var role = command.ExecuteScalar() as string;
                    if (role == null)
                    {
                        MessageBox.Show("Invalid Username or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        password_txt.Clear();
                        username_txt.Clear();
                        return;
                    }
                    if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        AdminDashboard adminDashboard = new AdminDashboard();
                        adminDashboard.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Access denied. You are not an admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
