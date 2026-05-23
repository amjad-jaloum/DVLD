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
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.ctrlDrivingLicenseApplicationInfo1 = new _19___Project___DVLD.Applications.Local_Driving_Licenses.ctrlDrivingLicenseApplicationInfo();
            this.SuspendLayout();
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(12, 405);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(776, 71);
            this.tbNotes.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 381);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 21);
            this.label8.TabIndex = 27;
            this.label8.Text = "Notes:";
            // 
            // btnIssue
            // 
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Location = new System.Drawing.Point(664, 481);
            this.btnIssue.Margin = new System.Windows.Forms.Padding(2);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(125, 30);
            this.btnIssue.TabIndex = 29;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // ctrlDrivingLicenseApplicationInfo1
            // 
            this.ctrlDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(15, 13);
            this.ctrlDrivingLicenseApplicationInfo1.Name = "ctrlDrivingLicenseApplicationInfo1";
            this.ctrlDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(760, 361);
            this.ctrlDrivingLicenseApplicationInfo1.TabIndex = 30;
            // 
            // frmIssueDriverLicense_FirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 522);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.label8);
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

        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnIssue;
        private Applications.Local_Driving_Licenses.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
    }
}