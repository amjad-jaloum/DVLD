namespace _19___Project___DVLD.Driving_License_Services
{
    partial class frmShowDrivingLicenseApp
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
            this.ctrlShowDrivingLicenseAppInfo1 = new _19___Project___DVLD.Driving_License_Services.ctrlDrivingLicenseApplicationInfo();
            this.SuspendLayout();
            // 
            // ctrlShowDrivingLicenseAppInfo1
            // 
            this.ctrlShowDrivingLicenseAppInfo1.AutoSize = true;
            this.ctrlShowDrivingLicenseAppInfo1.Location = new System.Drawing.Point(24, -7);
            this.ctrlShowDrivingLicenseAppInfo1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlShowDrivingLicenseAppInfo1.Name = "ctrlShowDrivingLicenseAppInfo1";
            this.ctrlShowDrivingLicenseAppInfo1.Padding = new System.Windows.Forms.Padding(13);
            this.ctrlShowDrivingLicenseAppInfo1.Size = new System.Drawing.Size(725, 383);
            this.ctrlShowDrivingLicenseAppInfo1.TabIndex = 0;
            // 
            // frmShowDrivingLicenseApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 378);
            this.Controls.Add(this.ctrlShowDrivingLicenseAppInfo1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowDrivingLicenseApp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Driving License Application Info";
            this.Load += new System.EventHandler(this.frmShowDrivingLicenseApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlDrivingLicenseApplicationInfo ctrlShowDrivingLicenseAppInfo1;
    }
}