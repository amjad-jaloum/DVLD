namespace _19___Project___DVLD.Driving_Licenses.Detained_Licenses
{
    partial class frmDetainLicense
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
            this.ctrlShowLicenseAndDetainInfo1 = new _19___Project___DVLD.Driving_Licenses.Detained_Licenses.ctrlShowLicenseAndDetainInfo();
            this.SuspendLayout();
            // 
            // ctrlShowLicenseAndDetainInfo1
            // 
            this.ctrlShowLicenseAndDetainInfo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlShowLicenseAndDetainInfo1.Location = new System.Drawing.Point(30, 30);
            this.ctrlShowLicenseAndDetainInfo1.Name = "ctrlShowLicenseAndDetainInfo1";
            this.ctrlShowLicenseAndDetainInfo1.Padding = new System.Windows.Forms.Padding(5);
            this.ctrlShowLicenseAndDetainInfo1.Size = new System.Drawing.Size(913, 738);
            this.ctrlShowLicenseAndDetainInfo1.TabIndex = 0;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 776);
            this.Controls.Add(this.ctrlShowLicenseAndDetainInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetainLicense";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detain License";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowLicenseAndDetainInfo ctrlShowLicenseAndDetainInfo1;
    }
}