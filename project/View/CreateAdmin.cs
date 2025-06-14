using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using project.Controller;
using project.Models;

namespace project.View
{
    public partial class CreateAdmin : Form
    {
        private readonly AdminController _adminController = new AdminController();
        public CreateAdmin()
        {
            InitializeComponent();
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(username_txt.Text) || string.IsNullOrWhiteSpace(password_txt.Text))
            {
                MessageBox.Show("Username and Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Admin admin = new Admin
            {
                Username = username_txt.Text,
                Password = password_txt.Text,
                Role = "Admin"
            };

            _adminController.CreateAdmin(admin);
            MessageBox.Show("Admin account created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            username_txt.Clear();
            password_txt.Clear();

            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.ShowDialog();
        }
    }
}
