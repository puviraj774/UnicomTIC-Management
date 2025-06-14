namespace project.View
{
    partial class CourseManagement
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
            this.add_btn = new System.Windows.Forms.Button();
            this.course_dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.course_txt = new System.Windows.Forms.TextBox();
            this.delete_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.course_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(315, 115);
            this.add_btn.Margin = new System.Windows.Forms.Padding(2);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(77, 23);
            this.add_btn.TabIndex = 0;
            this.add_btn.Text = "ADD";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // course_dgv
            // 
            this.course_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.course_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.course_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.course_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.course_dgv.Location = new System.Drawing.Point(107, 168);
            this.course_dgv.Margin = new System.Windows.Forms.Padding(2);
            this.course_dgv.Name = "course_dgv";
            this.course_dgv.RowHeadersWidth = 62;
            this.course_dgv.RowTemplate.Height = 28;
            this.course_dgv.Size = new System.Drawing.Size(284, 98);
            this.course_dgv.TabIndex = 1;
            this.course_dgv.SelectionChanged += new System.EventHandler(this.course_dgv_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // course_txt
            // 
            this.course_txt.Location = new System.Drawing.Point(198, 68);
            this.course_txt.Margin = new System.Windows.Forms.Padding(2);
            this.course_txt.Name = "course_txt";
            this.course_txt.Size = new System.Drawing.Size(195, 20);
            this.course_txt.TabIndex = 3;
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(198, 115);
            this.delete_btn.Margin = new System.Windows.Forms.Padding(2);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(67, 23);
            this.delete_btn.TabIndex = 4;
            this.delete_btn.Text = "DELETE";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click_1);
            // 
            // CourseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 308);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.course_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.course_dgv);
            this.Controls.Add(this.add_btn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CourseManagement";
            this.Text = "CourseManagement";
            this.Load += new System.EventHandler(this.CourseManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.course_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.DataGridView course_dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox course_txt;
        private System.Windows.Forms.Button delete_btn;
    }
}