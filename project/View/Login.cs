﻿using project.Controller;
using project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private void Login_Load(object sender, EventArgs e)
        {
            txtusername.Text = "Username";
            txtpassword.Text = "Password";
            txtusername.ForeColor = Color.Gray;
            txtpassword.ForeColor = Color.Gray;

            btnhide.Visible = false;
        }

        private void txtusername_Enter(object sender, EventArgs e)
        {
            if (txtusername.Text == "Username")
            {
                txtusername.Text = string.Empty;
                txtusername.ForeColor = Color.Black;
            }
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text))
            {
                txtusername.Text = "Username";
                txtusername.ForeColor = Color.Gray;
            }
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Password")
            {
                txtpassword.Text = string.Empty;
                txtpassword.ForeColor = Color.Black;
                txtpassword.UseSystemPasswordChar = true; 
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                txtpassword.Text = "Password";
                txtpassword.ForeColor = Color.Gray;
                txtpassword.UseSystemPasswordChar = false; 
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "Username" || txtpassword.Text == "Password" || string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Please enter a valid username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User user = new User
            {
                UserName = txtusername.Text.Trim(),
                Password = txtpassword.Text.Trim()
            };

            UserController userController = new UserController();
            string role = userController.GetRole(user.UserName, user.Password);

            if (role == "Admin")
            {
                this.Hide();
                DashboardAdmin dashboardAdmin = new DashboardAdmin();
                dashboardAdmin.ShowDialog();
                this.Close();
            }
            txtusername.Clear();
            txtpassword.Clear();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

            
        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Password")
            {
                txtpassword.UseSystemPasswordChar = false; // If the password is still the placeholder, don't hide it
                return;
            }
            txtpassword.UseSystemPasswordChar = true;
            btnhide.Visible = false;
            btnshow1.Visible = true;
        }

        private void btnshow1_Click(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = false;
            btnshow1.Visible = false;
            btnhide.Visible = true;
        }
    }
}
