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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void LoadForm(Form frm)
        {
            pnl_center.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnl_center.Controls.Add(frm);
            frm.Show();
        }


        private void pnl_center_Paint(object sender, PaintEventArgs e)
        {

        }

        private void stumanagement_btn_Click(object sender, EventArgs e)
        {
            LoadForm(new StudentManagement());
        }

        private void coursemanagement_btn_Click(object sender, EventArgs e)
        {
            LoadForm(new CourseManagement());
        }
    }
}
