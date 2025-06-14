using project.Controller;
using project.Data;
using project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.View
{
    public partial class CourseManagement : Form
    {
        private readonly CourseControllers coursecontroller;
        private readonly Course course;
        private int selectedcourseId = -1;

        public CourseManagement()
        {
            InitializeComponent();
            coursecontroller = new CourseControllers();
            course = new Course();
        }

        private bool isLoading = false;

        private void loaddata()
        {
            isLoading = true;

            var courses = coursecontroller.GetCourseList();
            course_dgv.DataSource = courses;
            this.BeginInvoke((Action)(() =>
            {
                course_dgv.ClearSelection();
                selectedcourseId = -1;
                course_txt.Clear();
                isLoading = false;
            }));
        }


        private void add_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(course_txt.Text))
            {
                MessageBox.Show("Course cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Course course = new Course
            {
                Name = course_txt.Text
            };

            coursecontroller.AddCourse(course);
            loaddata();
            course_txt.Clear();
        }

        private void course_dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (course_dgv.SelectedRows.Count > 0)
            {
                var row = course_dgv.SelectedRows[0];
                selectedcourseId = Convert.ToInt32(row.Cells["Id"].Value);
                course_txt.Text = row.Cells["Name"].Value.ToString();
            }
            else
            {
                selectedcourseId = -1;
                course_txt.Clear();
            }
        }

        private void CourseManagement_Load(object sender, EventArgs e)
        {
            loaddata();
            course_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            course_dgv.MultiSelect = false;
        }

        private void delete_btn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(course_txt.Text))
            {
                MessageBox.Show("Please Select a Course to delete");
                return;
            }

            var result = MessageBox.Show("Are you Sure to delete this Course?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                CourseControllers courseControllers = new CourseControllers();
                courseControllers.DeleteCourse(selectedcourseId);
                course_txt.Clear();
            }
        }
    }
}
