using project.Controller;
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


namespace project.View
{
    public partial class CourseForm : Form
    {
        int SelectedCourseId = -1;
        private Form parentForm;

        public CourseForm(Form parent)
        {
            InitializeComponent();    
            this.parentForm = parent;
        }

        // This is the event handler for the form load event.
        private void CourseForm_Load(object sender, EventArgs e)
        {
            LoadCoursesToGrid();
            dgvcourse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvcourse.MultiSelect = false;

            dgvcourse.ClearSelection();
        }

        //This Method Loads the courses into the DataGridView when the form loads.
        private void LoadCoursesToGrid()
        {
            CourseController courseController = new CourseController();
            var courseList = courseController.GetCourseList();

            dgvcourse.DataSource = courseList;
        }

        // This is the event handler for the Add button click event.
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text))
            {
                MessageBox.Show("Course Name Cannot be empty!","Error",MessageBoxButtons.OK);
                return;
            }

            Course course = new Course
            {
                Name = txtname.Text.Trim()  
            };           

            CourseController courseController = new CourseController();
            courseController.AddCourse(course);

            MessageBox.Show("Course Added Successfully!", "Success", MessageBoxButtons.OK);

            txtname.Clear();
            LoadCoursesToGrid(); 
        }

        // This is the event handler for the DataGridView selection changed event.
        private void dgvcourse_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvcourse.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvcourse.SelectedRows[0];

                SelectedCourseId = Convert.ToInt32(row.Cells["Id"].Value);
                txtname.Text = row.Cells["Name"].Value.ToString();
            }
            else
            {
                SelectedCourseId = -1;
                txtname.Clear();
            }
        }

        // This is the event handler for the Delete button click event.
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (SelectedCourseId <= 0)
            {
                MessageBox.Show("Select a Course to delete!", "Error", MessageBoxButtons.OK);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                CourseController courseController = new CourseController();
                courseController.DeleteCourse(SelectedCourseId);
            }

            SelectedCourseId = -1;
            txtname.Clear();
            LoadCoursesToGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            parentForm.Show();
        }
    }
}
