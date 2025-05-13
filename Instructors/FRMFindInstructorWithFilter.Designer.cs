namespace Karate.App.Instructors
{
    partial class FRMFindInstructorWithFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMFindInstructorWithFilter));
            this.ctrlFindIndtructorWithFilter1 = new Karate.App.Instructors.ctrlFindIndtructorWithFilter();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // ctrlFindIndtructorWithFilter1
            // 
            this.ctrlFindIndtructorWithFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ctrlFindIndtructorWithFilter1.FilterEnable = true;
            this.ctrlFindIndtructorWithFilter1.Location = new System.Drawing.Point(0, 0);
            this.ctrlFindIndtructorWithFilter1.Name = "ctrlFindIndtructorWithFilter1";
            this.ctrlFindIndtructorWithFilter1.ShowAddInstructor = true;
            this.ctrlFindIndtructorWithFilter1.Size = new System.Drawing.Size(726, 572);
            this.ctrlFindIndtructorWithFilter1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(603, 571);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 32);
            this.btnClose.TabIndex = 104;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FRMFindInstructorWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(729, 615);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlFindIndtructorWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FRMFindInstructorWithFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instructor with filter";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlFindIndtructorWithFilter ctrlFindIndtructorWithFilter1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}