namespace Karate.App.Belt_Test
{
    partial class FRMManageBeltTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMManageBeltTest));
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.DGVBeltTest = new System.Windows.Forms.DataGridView();
            this.lblRecord = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddNewBeltTest = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsBeltTest = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewBeltTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTestDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTestHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBeltTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmsBeltTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(381, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 40);
            this.label1.TabIndex = 26;
            this.label1.Text = "Manage Belt Test";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(2, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 40);
            this.label4.TabIndex = 32;
            this.label4.Text = "Filter By :";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(294, 233);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(152, 32);
            this.txtFilter.TabIndex = 31;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // cmbFilter
            // 
            this.cmbFilter.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(113, 233);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(154, 32);
            this.cmbFilter.TabIndex = 30;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // DGVBeltTest
            // 
            this.DGVBeltTest.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DGVBeltTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVBeltTest.ContextMenuStrip = this.cmsBeltTest;
            this.DGVBeltTest.Location = new System.Drawing.Point(9, 285);
            this.DGVBeltTest.Name = "DGVBeltTest";
            this.DGVBeltTest.Size = new System.Drawing.Size(925, 311);
            this.DGVBeltTest.TabIndex = 34;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.White;
            this.lblRecord.Location = new System.Drawing.Point(114, 599);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(61, 40);
            this.lblRecord.TabIndex = 35;
            this.lblRecord.Text = "[???]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 599);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 40);
            this.label6.TabIndex = 36;
            this.label6.Text = "#Record:";
            // 
            // btnAddNewBeltTest
            // 
            this.btnAddNewBeltTest.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewBeltTest.Image")));
            this.btnAddNewBeltTest.Location = new System.Drawing.Point(866, 227);
            this.btnAddNewBeltTest.Name = "btnAddNewBeltTest";
            this.btnAddNewBeltTest.Size = new System.Drawing.Size(61, 49);
            this.btnAddNewBeltTest.TabIndex = 33;
            this.btnAddNewBeltTest.UseVisualStyleBackColor = true;
            this.btnAddNewBeltTest.Click += new System.EventHandler(this.btnAddNewBeltTest_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(371, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // cmsBeltTest
            // 
            this.cmsBeltTest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewBeltTestToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.showTestDetailsToolStripMenuItem,
            this.showTestHistoryToolStripMenuItem});
            this.cmsBeltTest.Name = "cmsBeltTest";
            this.cmsBeltTest.Size = new System.Drawing.Size(181, 136);
            // 
            // addNewBeltTestToolStripMenuItem
            // 
            this.addNewBeltTestToolStripMenuItem.Name = "addNewBeltTestToolStripMenuItem";
            this.addNewBeltTestToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addNewBeltTestToolStripMenuItem.Text = "Add New Belt Test";
            this.addNewBeltTestToolStripMenuItem.Click += new System.EventHandler(this.addNewBeltTestToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // showTestDetailsToolStripMenuItem
            // 
            this.showTestDetailsToolStripMenuItem.Name = "showTestDetailsToolStripMenuItem";
            this.showTestDetailsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.showTestDetailsToolStripMenuItem.Text = "Show Test Details";
            // 
            // showTestHistoryToolStripMenuItem
            // 
            this.showTestHistoryToolStripMenuItem.Name = "showTestHistoryToolStripMenuItem";
            this.showTestHistoryToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.showTestHistoryToolStripMenuItem.Text = "Show Test History";
            // 
            // FRMManageBeltTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(939, 649);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DGVBeltTest);
            this.Controls.Add(this.btnAddNewBeltTest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FRMManageBeltTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Belt Test";
            this.Load += new System.EventHandler(this.FRMManageBeltTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVBeltTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmsBeltTest.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewBeltTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.DataGridView DGVBeltTest;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip cmsBeltTest;
        private System.Windows.Forms.ToolStripMenuItem addNewBeltTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTestDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTestHistoryToolStripMenuItem;
    }
}