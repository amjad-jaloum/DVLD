namespace _19___Project___DVLD.Driving_Licenses.International_Licenses
{
    partial class frmAddNewInternationalDrivingLicenseApplication
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
            this.ctrlShowLicenseInfo1 = new _19___Project___DVLD.Driving_License_Services.ctrlShowLicenseInfo();
            this.SuspendLayout();
            // 
            // ctrlShowLicenseInfo1
            // 
            this.ctrlShowLicenseInfo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlShowLicenseInfo1.Location = new System.Drawing.Point(30, 30);
            this.ctrlShowLicenseInfo1.Name = "ctrlShowLicenseInfo1";
            this.ctrlShowLicenseInfo1.Size = new System.Drawing.Size(803, 387);
            this.ctrlShowLicenseInfo1.TabIndex = 0;
            // 
            // frmAddNewInternationalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 624);
            this.Controls.Add(this.ctrlShowLicenseInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddNewInternationalDrivingLicenseApplication";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.ShowIcon = false;
            this.Text = "frmAddNewInternationalDrivingLicenseApplication";
            this.ResumeLayout(false);

        }

        #endregion

        private Driving_License_Services.ctrlShowLicenseInfo ctrlShowLicenseInfo1;
    }
}