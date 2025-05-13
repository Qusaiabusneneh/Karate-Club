namespace Karate.App.Instructors
{
    partial class FrmManageInstructors
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVInstructors = new System.Windows.Forms.DataGridView();
            this.CMSInstructors = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewInstrucotrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateInstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteInstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findInstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInstructorInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddNewInstructor = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInstructors)).BeginInit();
            this.CMSInstructors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(433, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manage Instructors";
            // 
            // DGVInstructors
            // 
            this.DGVInstructors.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DGVInstructors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVInstructors.ContextMenuStrip = this.CMSInstructors;
            this.DGVInstructors.Location = new System.Drawing.Point(12, 264);
            this.DGVInstructors.Name = "DGVInstructors";
            this.DGVInstructors.Size = new System.Drawing.Size(855, 371);
            this.DGVInstructors.TabIndex = 4;
            // 
            // CMSInstructors
            // 
            this.CMSInstructors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewInstrucotrToolStripMenuItem,
            this.updateInstructorToolStripMenuItem,
            this.deleteInstructorToolStripMenuItem,
            this.findInstructorToolStripMenuItem,
            this.showInstructorInfoToolStripMenuItem});
            this.CMSInstructors.Name = "CMSInstructors";
            this.CMSInstructors.Size = new System.Drawing.Size(199, 114);
            // 
            // addNewInstrucotrToolStripMenuItem
            // 
            this.addNewInstrucotrToolStripMenuItem.Name = "addNewInstrucotrToolStripMenuItem";
            this.addNewInstrucotrToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.addNewInstrucotrToolStripMenuItem.Text = "Add New Instrucotr";
            this.addNewInstrucotrToolStripMenuItem.Click += new System.EventHandler(this.addNewInstrucotrToolStripMenuItem_Click);
            // 
            // updateInstructorToolStripMenuItem
            // 
            this.updateInstructorToolStripMenuItem.Name = "updateInstructorToolStripMenuItem";
            this.updateInstructorToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.updateInstructorToolStripMenuItem.Text = "Update Instructor";
            this.updateInstructorToolStripMenuItem.Click += new System.EventHandler(this.updateInstructorToolStripMenuItem_Click);
            // 
            // deleteInstructorToolStripMenuItem
            // 
            this.deleteInstructorToolStripMenuItem.Name = "deleteInstructorToolStripMenuItem";
            this.deleteInstructorToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.deleteInstructorToolStripMenuItem.Text = "DeleteInstructor";
            this.deleteInstructorToolStripMenuItem.Click += new System.EventHandler(this.deleteInstructorToolStripMenuItem_Click);
            // 
            // findInstructorToolStripMenuItem
            // 
            this.findInstructorToolStripMenuItem.Name = "findInstructorToolStripMenuItem";
            this.findInstructorToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.findInstructorToolStripMenuItem.Text = "Show Instructor Info";
            this.findInstructorToolStripMenuItem.Click += new System.EventHandler(this.findInstructorToolStripMenuItem_Click);
            // 
            // showInstructorInfoToolStripMenuItem
            // 
            this.showInstructorInfoToolStripMenuItem.Name = "showInstructorInfoToolStripMenuItem";
            this.showInstructorInfoToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.showInstructorInfoToolStripMenuItem.Text = "FindByUserID Instructor";
            this.showInstructorInfoToolStripMenuItem.Click += new System.EventHandler(this.showInstructorInfoToolStripMenuItem_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(263, 223);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(152, 32);
            this.txtFilter.TabIndex = 9;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // cmbFilter
            // 
            this.cmbFilter.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(103, 223);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(154, 32);
            this.cmbFilter.TabIndex = 8;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 40);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter By :";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.ForeColor = System.Drawing.Color.White;
            this.lblRecordCount.Location = new System.Drawing.Point(106, 638);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(61, 40);
            this.lblRecordCount.TabIndex = 11;
            this.lblRecordCount.Text = "[???]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 638);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 40);
            this.label3.TabIndex = 12;
            this.label3.Text = "#Record:";
            // 
            // btnAddNewInstructor
            // 
            this.btnAddNewInstructor.Image = global::Karate.App.Properties.Resources.add;
            this.btnAddNewInstructor.Location = new System.Drawing.Point(806, 209);
            this.btnAddNewInstructor.Name = "btnAddNewInstructor";
            this.btnAddNewInstructor.Size = new System.Drawing.Size(61, 49);
            this.btnAddNewInstructor.TabIndex = 10;
            this.btnAddNewInstructor.UseVisualStyleBackColor = true;
            this.btnAddNewInstructor.Click += new System.EventHandler(this.btnAddNewInstructor_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Karate.App.Properties.Resources.taekwondo;
            this.pictureBox1.Location = new System.Drawing.Point(440, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FrmManageInstructors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(880, 686);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNewInstructor);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGVInstructors);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmManageInstructors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Instructors";
            this.Load += new System.EventHandler(this.FrmManageInstructors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVInstructors)).EndInit();
            this.CMSInstructors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVInstructors;
        private System.Windows.Forms.Button btnAddNewInstructor;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip CMSInstructors;
        private System.Windows.Forms.ToolStripMenuItem addNewInstrucotrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateInstructorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteInstructorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findInstructorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInstructorInfoToolStripMenuItem;
    }
}