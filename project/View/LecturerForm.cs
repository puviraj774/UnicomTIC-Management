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
using System.Text.RegularExpressions;

namespace project.View
{
    public partial class LecturerForm : Form
    {
        int SelectedLecturerId = -1; // Default value indicating no selection
        private readonly  LecturerController controller = new LecturerController();
        private readonly Lecturer lecturer = new Lecturer();
        private Form parentForm;
        public LecturerForm(Form parent)
        {
            InitializeComponent();
            this.parentForm = parent;
        }

        private void LecturerForm_Load(object sender, EventArgs e)
        {
            LoadLecturersToGrid();
            dgvlecturer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvlecturer.MultiSelect = false;
            dgvlecturer.ClearSelection();
        }

        public void LoadLecturersToGrid()
        {
            LecturerController lecturerController = new LecturerController();
            var lecturerList = lecturerController.GetLecturerList();

            dgvlecturer.DataSource = lecturerList;

            dgvlecturer.Columns["SubjectId"].Visible = false;
            dgvlecturer.Columns["Subject"].Visible = false;
            dgvlecturer.Columns["Username"].Visible = false;
            dgvlecturer.Columns["Password"].Visible = false;
        }        

        public void ClearFields()
        {
            txtname.Clear();
            txtnic.Clear();
            txtusername.Clear();
            txtpassword.Clear();
        }
        public static bool IsValidNIC(string nic)
        {
            if (string.IsNullOrEmpty(nic)) return false;

            var oldNicPattern = @"^\d{9}[vVxX]$";
            var newNicPattern = @"^\d{12}$";

            return Regex.IsMatch(nic, oldNicPattern) || Regex.IsMatch(nic, newNicPattern);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtnic.Text) ||
                string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsValidNIC(txtnic.Text))
            {
                MessageBox.Show("Please enter a valid NIC.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Lecturer lecturer = new Lecturer
            {
                Name = txtname.Text,
                NIC = txtnic.Text,
                Username = txtusername.Text,
                Password = txtpassword.Text
            };
           
            controller.AddLecturer(lecturer);

            MessageBox.Show("Lecturer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
        }

        private void dgvlecturer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvlecturer.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvlecturer.SelectedRows[0];

                SelectedLecturerId = Convert.ToInt32(row.Cells["Id"].Value);
                txtname.Text = row.Cells["Name"].Value.ToString();
                txtnic.Text = row.Cells["NIC"].Value.ToString();

                Lecturer Logindetails= controller.FindUsernamePassword(SelectedLecturerId);
                txtusername.Text = Logindetails.Username;
                txtpassword.Text = Logindetails.Password;
            }
            else
            {
                SelectedLecturerId = -1;
                ClearFields();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (SelectedLecturerId == -1)
            {
                MessageBox.Show("Please select a lecturer to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = MessageBox.Show("Are you sure you want to delete this lecturer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    controller.DeleteLecturer(SelectedLecturerId);
                    LoadLecturersToGrid();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting lecturer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (SelectedLecturerId == -1)
            {
                MessageBox.Show("Please select a lecturer to edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtnic.Text) ||
                string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsValidNIC(txtnic.Text))
            {
                MessageBox.Show("Please enter a valid NIC.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lecturer.Id = SelectedLecturerId;
            lecturer.Name = txtname.Text;
            lecturer.NIC = txtnic.Text;
            lecturer.Username = txtusername.Text;
            lecturer.Password = txtpassword.Text;

            controller.UpdateLecturer(SelectedLecturerId,txtusername.Text,txtpassword.Text);
            MessageBox.Show("Lecturer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearFields();
            LoadLecturersToGrid();
            dgvlecturer.ClearSelection();
            SelectedLecturerId = -1; 
        }

        private void pbback_Click(object sender, EventArgs e)
        {
            this.Close();
            parentForm.Show();
        }
    }
}
