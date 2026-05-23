namespace _19___Project___DVLD.Driving_License_Services
{
    partial class frmLicensesHistory
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
            this.ctrlPersonCardWithFilter1 = new _19___Project___DVLD.People.ctrlPersonCardWithFilter();
            this.ctrlDriverLicenses1 = new _19___Project___DVLD.Licenses.Controls.ctrlDriverLicenses();
            this.SuspendLayout();
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.FilterEnabled = false;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(30, 30);
            this.ctrlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(729, 411);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            this.ctrlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCardWithFilter1_OnPersonSelected);
            // 
            // ctrlDriverLicenses1
            // 
            this.ctrlDriverLicenses1.BackColor = System.Drawing.Color.White;
            this.ctrlDriverLicenses1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ctrlDriverLicenses1.Location = new System.Drawing.Point(40, 445);
            this.ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            this.ctrlDriverLicenses1.Size = new System.Drawing.Size(710, 254);
            this.ctrlDriverLicenses1.TabIndex = 1;
            // 
            // frmLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(789, 732);
            this.Controls.Add(this.ctrlDriverLicenses1);
            this.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLicensesHistory";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.ShowIcon = false;
            this.Text = "Licenses History";
            this.Load += new System.EventHandler(this.frmLicensesHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private People.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private Licenses.Controls.ctrlDriverLicenses ctrlDriverLicenses1;
    }
}