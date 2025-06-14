namespace project.View
{
    partial class StudentManagement
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
            this.label1 = new System.Windows.Forms.Label();
            this.add_btn = new System.Windows.Forms.Button();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nic_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.course_cob = new System.Windows.Forms.ComboBox();
            this.delete_btn = new System.Windows.Forms.Button();
            this.edit_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(45, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(547, 50);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(106, 38);
            this.add_btn.TabIndex = 1;
            this.add_btn.Text = "ADD";
            this.add_btn.UseVisualStyleBackColor = true;
            // 
            // name_txt
            // 
            this.name_txt.Location = new System.Drawing.Point(210, 56);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(256, 26);
            this.name_txt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(45, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "NIC";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nic_txt
            // 
            this.nic_txt.Location = new System.Drawing.Point(210, 100);
            this.nic_txt.Name = "nic_txt";
            this.nic_txt.Size = new System.Drawing.Size(256, 26);
            this.nic_txt.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(45, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Course";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // course_cob
            // 
            this.course_cob.FormattingEnabled = true;
            this.course_cob.Location = new System.Drawing.Point(210, 144);
            this.course_cob.Name = "course_cob";
            this.course_cob.Size = new System.Drawing.Size(256, 28);
            this.course_cob.TabIndex = 6;
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(547, 94);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(106, 38);
            this.delete_btn.TabIndex = 7;
            this.delete_btn.Text = "DELETE";
            this.delete_btn.UseVisualStyleBackColor = true;
            // 
            // edit_btn
            // 
            this.edit_btn.Location = new System.Drawing.Point(547, 138);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(106, 38);
            this.edit_btn.TabIndex = 8;
            this.edit_btn.Text = "EDIT";
            this.edit_btn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(75, 214);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(578, 233);
            this.dataGridView1.TabIndex = 9;
            // 
            // StudentManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 512);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.edit_btn);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.course_cob);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nic_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name_txt);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.label1);
            this.Name = "StudentManagement";
            this.Text = "StudentManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nic_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox course_cob;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button edit_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}