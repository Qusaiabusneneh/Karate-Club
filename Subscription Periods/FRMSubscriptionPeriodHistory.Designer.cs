namespace Karate.App.Subscription_Periods
{
    partial class FRMSubscriptionPeriodHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMSubscriptionPeriodHistory));
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlFindMember1 = new Karate.App.Members.ctrlFindMember();
            this.dgvSubscriptionPeriodHistory = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewSubscription = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscriptionPeriodHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(225, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 40);
            this.label1.TabIndex = 24;
            this.label1.Text = "Subscription Period History";
            // 
            // ctrlFindMember1
            // 
            this.ctrlFindMember1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ctrlFindMember1.Location = new System.Drawing.Point(12, 47);
            this.ctrlFindMember1.Name = "ctrlFindMember1";
            this.ctrlFindMember1.Size = new System.Drawing.Size(721, 349);
            this.ctrlFindMember1.TabIndex = 25;
            // 
            // dgvSubscriptionPeriodHistory
            // 
            this.dgvSubscriptionPeriodHistory.AllowUserToAddRows = false;
            this.dgvSubscriptionPeriodHistory.AllowUserToDeleteRows = false;
            this.dgvSubscriptionPeriodHistory.AllowUserToResizeRows = false;
            this.dgvSubscriptionPeriodHistory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSubscriptionPeriodHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubscriptionPeriodHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSubscriptionPeriodHistory.Location = new System.Drawing.Point(13, 432);
            this.dgvSubscriptionPeriodHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSubscriptionPeriodHistory.MultiSelect = false;
            this.dgvSubscriptionPeriodHistory.Name = "dgvSubscriptionPeriodHistory";
            this.dgvSubscriptionPeriodHistory.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubscriptionPeriodHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSubscriptionPeriodHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubscriptionPeriodHistory.Size = new System.Drawing.Size(720, 150);
            this.dgvSubscriptionPeriodHistory.TabIndex = 139;
            this.dgvSubscriptionPeriodHistory.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 30);
            this.label2.TabIndex = 138;
            this.label2.Text = "Period History:";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.White;
            this.lblRecord.Location = new System.Drawing.Point(112, 587);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(61, 40);
            this.lblRecord.TabIndex = 140;
            this.lblRecord.Text = "[???]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(10, 587);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 40);
            this.label6.TabIndex = 141;
            this.label6.Text = "#Record:";
            // 
            // btnClose
            // 
            this.btnClose.AutoEllipsis = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(598, 591);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 36);
            this.btnClose.TabIndex = 142;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewSubscription
            // 
            this.btnAddNewSubscription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewSubscription.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewSubscription.Image")));
            this.btnAddNewSubscription.Location = new System.Drawing.Point(684, 395);
            this.btnAddNewSubscription.Name = "btnAddNewSubscription";
            this.btnAddNewSubscription.Size = new System.Drawing.Size(49, 36);
            this.btnAddNewSubscription.TabIndex = 143;
            this.btnAddNewSubscription.UseVisualStyleBackColor = true;
            // 
            // FRMSubscriptionPeriodHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(748, 633);
            this.Controls.Add(this.btnAddNewSubscription);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvSubscriptionPeriodHistory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlFindMember1);
            this.Controls.Add(this.label1);
            this.Name = "FRMSubscriptionPeriodHistory";
            this.Text = "Subscription Period History";
            this.Load += new System.EventHandler(this.FRMSubscriptionPeriodHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscriptionPeriodHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Members.ctrlFindMember ctrlFindMember1;
        private System.Windows.Forms.DataGridView dgvSubscriptionPeriodHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddNewSubscription;
    }
}