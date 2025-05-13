namespace Karate.App.Subscription_Periods
{
    partial class FRMManageSubscribtionPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMManageSubscribtionPeriod));
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVSubscriptionPeriod = new System.Windows.Forms.DataGridView();
            this.cmsSubscribtionPeriod = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPeriodDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPeriodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPeriodHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecord = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddNewSubscriptionPeriod = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSubscriptionPeriod)).BeginInit();
            this.cmsSubscribtionPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 40);
            this.label4.TabIndex = 27;
            this.label4.Text = "Filter By :";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(298, 225);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(152, 32);
            this.txtFilter.TabIndex = 26;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // cmbFilter
            // 
            this.cmbFilter.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(117, 225);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(154, 32);
            this.cmbFilter.TabIndex = 25;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(375, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 40);
            this.label1.TabIndex = 23;
            this.label1.Text = "Manage Subscription Period";
            // 
            // DGVSubscriptionPeriod
            // 
            this.DGVSubscriptionPeriod.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DGVSubscriptionPeriod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSubscriptionPeriod.ContextMenuStrip = this.cmsSubscribtionPeriod;
            this.DGVSubscriptionPeriod.Location = new System.Drawing.Point(13, 263);
            this.DGVSubscriptionPeriod.Name = "DGVSubscriptionPeriod";
            this.DGVSubscriptionPeriod.Size = new System.Drawing.Size(1063, 311);
            this.DGVSubscriptionPeriod.TabIndex = 28;
            // 
            // cmsSubscribtionPeriod
            // 
            this.cmsSubscribtionPeriod.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsSubscribtionPeriod.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPeriodDetailsToolStripMenuItem,
            this.addNewPeriodToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.payToolStripMenuItem,
            this.renewToolStripMenuItem,
            this.showPeriodHistoryToolStripMenuItem});
            this.cmsSubscribtionPeriod.Name = "cmsSubscribtionPeriod";
            this.cmsSubscribtionPeriod.Size = new System.Drawing.Size(189, 222);
            // 
            // showPeriodDetailsToolStripMenuItem
            // 
            this.showPeriodDetailsToolStripMenuItem.Name = "showPeriodDetailsToolStripMenuItem";
            this.showPeriodDetailsToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.showPeriodDetailsToolStripMenuItem.Text = "Show Period Details";
            this.showPeriodDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPeriodDetailsToolStripMenuItem_Click);
            // 
            // addNewPeriodToolStripMenuItem
            // 
            this.addNewPeriodToolStripMenuItem.Name = "addNewPeriodToolStripMenuItem";
            this.addNewPeriodToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.addNewPeriodToolStripMenuItem.Text = "Add New Period";
            this.addNewPeriodToolStripMenuItem.Click += new System.EventHandler(this.addNewPeriodToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // payToolStripMenuItem
            // 
            this.payToolStripMenuItem.Name = "payToolStripMenuItem";
            this.payToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.payToolStripMenuItem.Text = "Pay";
            this.payToolStripMenuItem.Click += new System.EventHandler(this.payToolStripMenuItem_Click);
            // 
            // renewToolStripMenuItem
            // 
            this.renewToolStripMenuItem.Name = "renewToolStripMenuItem";
            this.renewToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.renewToolStripMenuItem.Text = "Renew Period";
            // 
            // showPeriodHistoryToolStripMenuItem
            // 
            this.showPeriodHistoryToolStripMenuItem.Name = "showPeriodHistoryToolStripMenuItem";
            this.showPeriodHistoryToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.showPeriodHistoryToolStripMenuItem.Text = "Show Period History";
            this.showPeriodHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPeriodHistoryToolStripMenuItem_Click);
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.White;
            this.lblRecord.Location = new System.Drawing.Point(108, 590);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(61, 40);
            this.lblRecord.TabIndex = 30;
            this.lblRecord.Text = "[???]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(6, 590);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 40);
            this.label6.TabIndex = 31;
            this.label6.Text = "#Record:";
            // 
            // btnAddNewSubscriptionPeriod
            // 
            this.btnAddNewSubscriptionPeriod.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewSubscriptionPeriod.Image")));
            this.btnAddNewSubscriptionPeriod.Location = new System.Drawing.Point(1015, 211);
            this.btnAddNewSubscriptionPeriod.Name = "btnAddNewSubscriptionPeriod";
            this.btnAddNewSubscriptionPeriod.Size = new System.Drawing.Size(61, 49);
            this.btnAddNewSubscriptionPeriod.TabIndex = 29;
            this.btnAddNewSubscriptionPeriod.UseVisualStyleBackColor = true;
            this.btnAddNewSubscriptionPeriod.Click += new System.EventHandler(this.btnAddNewSubscriptionPeriod_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Karate.App.Properties.Resources.subscription_model;
            this.pictureBox1.Location = new System.Drawing.Point(414, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // FRMManageSubscribtionPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1088, 639);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAddNewSubscriptionPeriod);
            this.Controls.Add(this.DGVSubscriptionPeriod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FRMManageSubscribtionPeriod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Subscribtion Period";
            this.Load += new System.EventHandler(this.FRMManageSubscribtionPeriod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSubscriptionPeriod)).EndInit();
            this.cmsSubscribtionPeriod.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVSubscriptionPeriod;
        private System.Windows.Forms.Button btnAddNewSubscriptionPeriod;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip cmsSubscribtionPeriod;
        private System.Windows.Forms.ToolStripMenuItem showPeriodDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPeriodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPeriodHistoryToolStripMenuItem;
    }
}