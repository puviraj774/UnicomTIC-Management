using project.Controller;
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

namespace project.View
{
    public partial class SubjectForm : Form
    {
        private readonly LecturerController lecturerController;
        private readonly CourseController courseController;
        private readonly SubjectController subjectController;
        public SubjectForm()
        {
            InitializeComponent();
            lecturerController = new LecturerController();
            courseController = new CourseController();
            subjectController = new SubjectController();
        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {
            LoadLecturerToCombobox();
            LoadCourseToCombobox();
        }

        private void LoadLecturerToCombobox()
        {
            var lecturers = lecturerController.GetLecturerList();
            if (lecturers != null && lecturers.Count>0)
            {
                coblecturer.DataSource = lecturers;
                coblecturer.DisplayMember = "Name";
                coblecturer.ValueMember = "Id";
            }
        }

        private void LoadCourseToCombobox()
        {
            var courses = courseController.GetCourseList();
            if (courses.Count>0 && courses != null)
            {
                cobcourse.DataSource = courses;
                cobcourse.DisplayMember = "Name";
                cobcourse.ValueMember = "Id";
            }
        }

        private void ClearSelection()
        {
            txtsubname.Clear();
            cobcourse.SelectedIndex = -1;
            coblecturer.SelectedIndex = -1;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtsubname.Text) ||
                string.IsNullOrWhiteSpace(cobcourse.Text) ||
                string.IsNullOrWhiteSpace(coblecturer.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            Subject subject = new Subject
            {
                Name = txtsubname.Text,
                CourseName = cobcourse.Text,
                LecturerName = coblecturer.Text,
                LecturerId = Convert.ToInt32(coblecturer.SelectedValue),
                CourseId = Convert.ToInt32(cobcourse.SelectedValue)
            };

            subjectController.AddSubject(subject);
            MessageBox.Show("Subject added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearSelection();

        }
    }
}
