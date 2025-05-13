namespace Karate.App.Member_Instructors
{
    partial class FRMManageMemberInstructors
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DGVMemberInstructor = new System.Windows.Forms.DataGridView();
            this.CMSMemberInstructor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewMemeberInstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMemberInstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateMemberInstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findMemberInstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMemberIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.btnAddNewMemberInstructor = new System.Windows.Forms.Button();
            this.lblRecord = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMemberInstructor)).BeginInit();
            this.CMSMemberInstructor.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(301, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 40);
            this.label1.TabIndex = 18;
            this.label1.Text = "Manage Member Instructor";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Karate.App.Properties.Resources.master;
            this.pictureBox1.Location = new System.Drawing.Point(335, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // DGVMemberInstructor
            // 
            this.DGVMemberInstructor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVMemberInstructor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVMemberInstructor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMemberInstructor.ContextMenuStrip = this.CMSMemberInstructor;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVMemberInstructor.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVMemberInstructor.Location = new System.Drawing.Point(5, 295);
            this.DGVMemberInstructor.Name = "DGVMemberInstructor";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVMemberInstructor.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVMemberInstructor.Size = new System.Drawing.Size(855, 276);
            this.DGVMemberInstructor.TabIndex = 20;
            // 
            // CMSMemberInstructor
            // 
            this.CMSMemberInstructor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewMemeberInstructorToolStripMenuItem,
            this.deleteMemberInstructorToolStripMenuItem,
            this.updateMemberInstructorToolStripMenuItem,
            this.findMemberInstructorToolStripMenuItem,
            this.showMemberIToolStripMenuItem});
            this.CMSMemberInstructor.Name = "CMSMemberInstructor";
            this.CMSMemberInstructor.Size = new System.Drawing.Size(232, 114);
            // 
            // addNewMemeberInstructorToolStripMenuItem
            // 
            this.addNewMemeberInstructorToolStripMenuItem.Name = "addNewMemeberInstructorToolStripMenuItem";
            this.addNewMemeberInstructorToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.addNewMemeberInstructorToolStripMenuItem.Text = "Add New Memeber Instructor";
            this.addNewMemeberInstructorToolStripMenuItem.Click += new System.EventHandler(this.addNewMemeberInstructorToolStripMenuItem_Click);
            // 
            // deleteMemberInstructorToolStripMenuItem
            // 
            this.deleteMemberInstructorToolStripMenuItem.Name = "deleteMemberInstructorToolStripMenuItem";
            this.deleteMemberInstructorToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.deleteMemberInstructorToolStripMenuItem.Text = "Delete Member Instructor";
            this.deleteMemberInstructorToolStripMenuItem.Click += new System.EventHandler(this.deleteMemberInstructorToolStripMenuItem_Click);
            // 
            // updateMemberInstructorToolStripMenuItem
            // 
            this.updateMemberInstructorToolStripMenuItem.Name = "updateMemberInstructorToolStripMenuItem";
            this.updateMemberInstructorToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.updateMemberInstructorToolStripMenuItem.Text = "Update Member Instructor";
            this.updateMemberInstructorToolStripMenuItem.Click += new System.EventHandler(this.updateMemberInstructorToolStripMenuItem_Click);
            // 
            // findMemberInstructorToolStripMenuItem
            // 
            this.findMemberInstructorToolStripMenuItem.Name = "findMemberInstructorToolStripMenuItem";
            this.findMemberInstructorToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.findMemberInstructorToolStripMenuItem.Text = "Find Member Instructor";
            this.findMemberInstructorToolStripMenuItem.Click += new System.EventHandler(this.findMemberInstructorToolStripMenuItem_Click);
            // 
            // showMemberIToolStripMenuItem
            // 
            this.showMemberIToolStripMenuItem.Name = "showMemberIToolStripMenuItem";
            this.showMemberIToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.showMemberIToolStripMenuItem.Text = "Show Member Instructor Info";
            this.showMemberIToolStripMenuItem.Click += new System.EventHandler(this.showMemberIToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 40);
            this.label4.TabIndex = 25;
            this.label4.Text = "Filter By :";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(298, 257);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(152, 32);
            this.txtFilter.TabIndex = 24;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // cmbFilter
            // 
            this.cmbFilter.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(117, 257);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(154, 32);
            this.cmbFilter.TabIndex = 23;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // btnAddNewMemberInstructor
            // 
            this.btnAddNewMemberInstructor.Image = global::Karate.App.Properties.Resources.add;
            this.btnAddNewMemberInstructor.Location = new System.Drawing.Point(799, 243);
            this.btnAddNewMemberInstructor.Name = "btnAddNewMemberInstructor";
            this.btnAddNewMemberInstructor.Size = new System.Drawing.Size(61, 49);
            this.btnAddNewMemberInstructor.TabIndex = 26;
            this.btnAddNewMemberInstructor.UseVisualStyleBackColor = true;
            this.btnAddNewMemberInstructor.Click += new System.EventHandler(this.btnAddNewMemberInstructor_Click);
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.White;
            this.lblRecord.Location = new System.Drawing.Point(106, 578);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(61, 40);
            this.lblRecord.TabIndex = 27;
            this.lblRecord.Text = "[???]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(4, 578);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 40);
            this.label6.TabIndex = 28;
            this.label6.Text = "#Record:";
            // 
            // FRMManageMemberInstructors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(872, 627);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAddNewMemberInstructor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.DGVMemberInstructor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FRMManageMemberInstructors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Member Instructors";
            this.Load += new System.EventHandler(this.FRMManageMemberInstructors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMemberInstructor)).EndInit();
            this.CMSMemberInstructor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView DGVMemberInstructor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Button btnAddNewMemberInstructor;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip CMSMemberInstructor;
        private System.Windows.Forms.ToolStripMenuItem addNewMemeberInstructorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMemberInstructorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateMemberInstructorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findMemberInstructorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMemberIToolStripMenuItem;
    }
}