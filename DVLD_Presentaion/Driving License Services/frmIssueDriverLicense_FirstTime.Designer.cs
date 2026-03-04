namespace _19___Project___DVLD.Driving_License_Services
{
    partial class frmIssueDriverLicense_FirstTime
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
            this.ctrlShowDrivingLicenseAppInfo1 = new _19___Project___DVLD.Driving_License_Services.ctrlShowDrivingLicenseAppInfo();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlShowDrivingLicenseAppInfo1
            // 
            this.ctrlShowDrivingLicenseAppInfo1.appDate = new System.DateTime(((long)(0)));
            this.ctrlShowDrivingLicenseAppInfo1.applicantFullName = null;
            this.ctrlShowDrivingLicenseAppInfo1.appStatus = null;
            this.ctrlShowDrivingLicenseAppInfo1.AutoSize = true;
            this.ctrlShowDrivingLicenseAppInfo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlShowDrivingLicenseAppInfo1.licenseName = null;
            this.ctrlShowDrivingLicenseAppInfo1.LocalDrivingLicenseAppID = 0;
            this.ctrlShowDrivingLicenseAppInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowDrivingLicenseAppInfo1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlShowDrivingLicenseAppInfo1.Name = "ctrlShowDrivingLicenseAppInfo1";
            this.ctrlShowDrivingLicenseAppInfo1.Padding = new System.Windows.Forms.Padding(20);
            this.ctrlShowDrivingLicenseAppInfo1.passedTests = ((short)(0));
            this.ctrlShowDrivingLicenseAppInfo1.Size = new System.Drawing.Size(1200, 582);
            this.ctrlShowDrivingLicenseAppInfo1.TabIndex = 2;
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(112, 589);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(1068, 141);
            this.tbNotes.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 585);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 32);
            this.label8.TabIndex = 27;
            this.label8.Text = "Notes:";
            // 
            // btnIssue
            // 
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Location = new System.Drawing.Point(996, 740);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(188, 46);
            this.btnIssue.TabIndex = 29;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // frmIssueDriverLicense_FirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 803);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ctrlShowDrivingLicenseAppInfo1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIssueDriverLicense_FirstTime";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Issue Driver License First Time";
            this.Load += new System.EventHandler(this.frmIssueDriverLicense_FirstTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlShowDrivingLicenseAppInfo ctrlShowDrivingLicenseAppInfo1;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnIssue;
    }
}