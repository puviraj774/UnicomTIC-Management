namespace project.View
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_left = new System.Windows.Forms.Panel();
            this.pnl_up = new System.Windows.Forms.Panel();
            this.pnl_center = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.stumanagement_btn = new System.Windows.Forms.Button();
            this.coursemanagement_btn = new System.Windows.Forms.Button();
            this.pnl_left.SuspendLayout();
            this.pnl_up.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_left
            // 
            this.pnl_left.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl_left.Controls.Add(this.coursemanagement_btn);
            this.pnl_left.Controls.Add(this.stumanagement_btn);
            this.pnl_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_left.Location = new System.Drawing.Point(0, 0);
            this.pnl_left.Name = "pnl_left";
            this.pnl_left.Size = new System.Drawing.Size(236, 685);
            this.pnl_left.TabIndex = 0;
            // 
            // pnl_up
            // 
            this.pnl_up.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnl_up.Controls.Add(this.label1);
            this.pnl_up.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_up.Location = new System.Drawing.Point(236, 0);
            this.pnl_up.Name = "pnl_up";
            this.pnl_up.Size = new System.Drawing.Size(694, 100);
            this.pnl_up.TabIndex = 1;
            // 
            // pnl_center
            // 
            this.pnl_center.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnl_center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_center.Location = new System.Drawing.Point(236, 100);
            this.pnl_center.Name = "pnl_center";
            this.pnl_center.Size = new System.Drawing.Size(694, 585);
            this.pnl_center.TabIndex = 2;
            this.pnl_center.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_center_Paint);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(490, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin Dashboard";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stumanagement_btn
            // 
            this.stumanagement_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.stumanagement_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.stumanagement_btn.Location = new System.Drawing.Point(12, 149);
            this.stumanagement_btn.Name = "stumanagement_btn";
            this.stumanagement_btn.Size = new System.Drawing.Size(209, 40);
            this.stumanagement_btn.TabIndex = 0;
            this.stumanagement_btn.Text = "Student Management";
            this.stumanagement_btn.UseVisualStyleBackColor = false;
            this.stumanagement_btn.Click += new System.EventHandler(this.stumanagement_btn_Click);
            // 
            // coursemanagement_btn
            // 
            this.coursemanagement_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.coursemanagement_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.coursemanagement_btn.Location = new System.Drawing.Point(12, 209);
            this.coursemanagement_btn.Name = "coursemanagement_btn";
            this.coursemanagement_btn.Size = new System.Drawing.Size(209, 40);
            this.coursemanagement_btn.TabIndex = 1;
            this.coursemanagement_btn.Text = "Course Management";
            this.coursemanagement_btn.UseVisualStyleBackColor = false;
            this.coursemanagement_btn.Click += new System.EventHandler(this.coursemanagement_btn_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 685);
            this.Controls.Add(this.pnl_center);
            this.Controls.Add(this.pnl_up);
            this.Controls.Add(this.pnl_left);
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            this.pnl_left.ResumeLayout(false);
            this.pnl_up.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_left;
        private System.Windows.Forms.Panel pnl_up;
        private System.Windows.Forms.Panel pnl_center;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button stumanagement_btn;
        private System.Windows.Forms.Button coursemanagement_btn;
    }
}