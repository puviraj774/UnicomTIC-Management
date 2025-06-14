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

namespace project.View
{
    public partial class StudentManagement : Form
    {
        public StudentManagement()
        {
            InitializeComponent();
            LoadCourses();
        }
        private void LoadCourses()
        {
            CourseControllers courseControllers = new CourseControllers();
            var courses = courseControllers.GetCourseList();

            course_cob.Items.Clear();
            foreach ( var course in courses )
            {
                course_cob.Items.Add( course.Name );
            }
        }
    }
}
