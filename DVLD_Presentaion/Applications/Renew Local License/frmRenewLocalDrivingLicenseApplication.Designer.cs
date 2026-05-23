namespace _19___Project___DVLD.Renewed_Licenses
{
    partial class frmRenewLocalDrivingLicenseApplication
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
            this.btnShowLicensesInfo = new System.Windows.Forms.Button();
            this.btnShowLicensesHistory = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.gbAppInfo = new System.Windows.Forms.GroupBox();
            this.tbLicenseNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.lblRenewedLicenseID = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.R_L_ApplicationID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfoWithFilter1 = new _19___Project___DVLD.Licenses.Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter();
            this.gbAppInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowLicensesInfo
            // 
            this.btnShowLicensesInfo.Enabled = false;
            this.btnShowLicensesInfo.Location = new System.Drawing.Point(171, 695);
            this.btnShowLicensesInfo.Name = "btnShowLicensesInfo";
            this.btnShowLicensesInfo.Size = new System.Drawing.Size(135, 37);
            this.btnShowLicensesInfo.TabIndex = 18;
            this.btnShowLicensesInfo.Text = "Show Licenses Info";
            this.btnShowLicensesInfo.UseVisualStyleBackColor = true;
            this.btnShowLicensesInfo.Click += new System.EventHandler(this.btnShowLicensesInfo_Click);
            // 
            // btnShowLicensesHistory
            // 
            this.btnShowLicensesHistory.Enabled = false;
            this.btnShowLicensesHistory.Location = new System.Drawing.Point(30, 695);
            this.btnShowLicensesHistory.Name = "btnShowLicensesHistory";
            this.btnShowLicensesHistory.Size = new System.Drawing.Size(135, 37);
            this.btnShowLicensesHistory.TabIndex = 17;
            this.btnShowLicensesHistory.Text = "Show Licenses History";
            this.btnShowLicensesHistory.UseVisualStyleBackColor = true;
            this.btnShowLicensesHistory.Click += new System.EventHandler(this.btnShowLicensesHistory_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.Enabled = false;
            this.btnRenew.Location = new System.Drawing.Point(790, 695);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(135, 37);
            this.btnRenew.TabIndex = 16;
            this.btnRenew.Text = "Renew";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenewLicense_Click);
            // 
            // gbAppInfo
            // 
            this.gbAppInfo.Controls.Add(this.tbLicenseNotes);
            this.gbAppInfo.Controls.Add(this.label7);
            this.gbAppInfo.Controls.Add(this.lblTotalFees);
            this.gbAppInfo.Controls.Add(this.label4);
            this.gbAppInfo.Controls.Add(this.lblLicenseFees);
            this.gbAppInfo.Controls.Add(this.label2);
            this.gbAppInfo.Controls.Add(this.lblCreatedBy);
            this.gbAppInfo.Controls.Add(this.lblExpirationDate);
            this.gbAppInfo.Controls.Add(this.lblApplicationFees);
            this.gbAppInfo.Controls.Add(this.lblIssueDate);
            this.gbAppInfo.Controls.Add(this.label24);
            this.gbAppInfo.Controls.Add(this.label6);
            this.gbAppInfo.Controls.Add(this.label18);
            this.gbAppInfo.Controls.Add(this.lblOldLicenseID);
            this.gbAppInfo.Controls.Add(this.lbl);
            this.gbAppInfo.Controls.Add(this.lblRenewedLicenseID);
            this.gbAppInfo.Controls.Add(this.label22);
            this.gbAppInfo.Controls.Add(this.label16);
            this.gbAppInfo.Controls.Add(this.lblApplicationDate);
            this.gbAppInfo.Controls.Add(this.label14);
            this.gbAppInfo.Controls.Add(this.R_L_ApplicationID);
            this.gbAppInfo.Controls.Add(this.label10);
            this.gbAppInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAppInfo.Location = new System.Drawing.Point(32, 488);
            this.gbAppInfo.Margin = new System.Windows.Forms.Padding(2);
            this.gbAppInfo.Name = "gbAppInfo";
            this.gbAppInfo.Padding = new System.Windows.Forms.Padding(2);
            this.gbAppInfo.Size = new System.Drawing.Size(893, 202);
            this.gbAppInfo.TabIndex = 15;
            this.gbAppInfo.TabStop = false;
            this.gbAppInfo.Text = "New Application License Info";
            // 
            // tbLicenseNotes
            // 
            this.tbLicenseNotes.Location = new System.Drawing.Point(596, 68);
            this.tbLicenseNotes.Multiline = true;
            this.tbLicenseNotes.Name = "tbLicenseNotes";
            this.tbLicenseNotes.Size = new System.Drawing.Size(273, 116);
            this.tbLicenseNotes.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(592, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 21);
            this.label7.TabIndex = 32;
            this.label7.Text = "Notes:";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Location = new System.Drawing.Point(490, 163);
            this.lblTotalFees.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(47, 21);
            this.lblTotalFees.TabIndex = 31;
            this.lblTotalFees.Text = "[$$$]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(292, 163);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 21);
            this.label4.TabIndex = 30;
            this.label4.Text = "Total Fees:";
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.AutoSize = true;
            this.lblLicenseFees.Location = new System.Drawing.Point(170, 163);
            this.lblLicenseFees.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.Size = new System.Drawing.Size(47, 21);
            this.lblLicenseFees.TabIndex = 29;
            this.lblLicenseFees.Text = "[$$$]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 163);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "License Fees:";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(490, 129);
            this.lblCreatedBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(48, 21);
            this.lblCreatedBy.TabIndex = 27;
            this.lblCreatedBy.Text = "None";
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Location = new System.Drawing.Point(490, 98);
            this.lblExpirationDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(41, 21);
            this.lblExpirationDate.TabIndex = 26;
            this.lblExpirationDate.Text = "[???]";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Location = new System.Drawing.Point(170, 133);
            this.lblApplicationFees.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(47, 21);
            this.lblApplicationFees.TabIndex = 25;
            this.lblApplicationFees.Text = "[$$$]";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Location = new System.Drawing.Point(170, 100);
            this.lblIssueDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(48, 21);
            this.lblIssueDate.TabIndex = 24;
            this.lblIssueDate.Text = "None";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(292, 131);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(96, 21);
            this.label24.TabIndex = 23;
            this.label24.Text = "Created By:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 133);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "Application Fees:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(292, 99);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(133, 21);
            this.label18.TabIndex = 14;
            this.label18.Text = "Expiration Date:";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Location = new System.Drawing.Point(490, 67);
            this.lblOldLicenseID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(41, 21);
            this.lblOldLicenseID.TabIndex = 13;
            this.lblOldLicenseID.Text = "[???]";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(292, 67);
            this.lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(122, 21);
            this.lbl.TabIndex = 12;
            this.lbl.Text = "Old License ID:";
            // 
            // lblRenewedLicenseID
            // 
            this.lblRenewedLicenseID.AutoSize = true;
            this.lblRenewedLicenseID.Location = new System.Drawing.Point(490, 36);
            this.lblRenewedLicenseID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRenewedLicenseID.Name = "lblRenewedLicenseID";
            this.lblRenewedLicenseID.Size = new System.Drawing.Size(41, 21);
            this.lblRenewedLicenseID.TabIndex = 11;
            this.lblRenewedLicenseID.Text = "[???]";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(292, 36);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(178, 21);
            this.label22.TabIndex = 10;
            this.label22.Text = "Rewnewed License ID:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(18, 100);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 21);
            this.label16.TabIndex = 8;
            this.label16.Text = "Issue Date:";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Location = new System.Drawing.Point(170, 68);
            this.lblApplicationDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(48, 21);
            this.lblApplicationDate.TabIndex = 7;
            this.lblApplicationDate.Text = "None";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 68);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 21);
            this.label14.TabIndex = 6;
            this.label14.Text = "Application Date:";
            // 
            // R_L_ApplicationID
            // 
            this.R_L_ApplicationID.AutoSize = true;
            this.R_L_ApplicationID.Location = new System.Drawing.Point(170, 36);
            this.R_L_ApplicationID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.R_L_ApplicationID.Name = "R_L_ApplicationID";
            this.R_L_ApplicationID.Size = new System.Drawing.Size(41, 21);
            this.R_L_ApplicationID.TabIndex = 5;
            this.R_L_ApplicationID.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 21);
            this.label10.TabIndex = 4;
            this.label10.Text = "R.L. ApplicationID";
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ctrlDriverLicenseInfoWithFilter1.AutoSize = true;
            this.ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(30, 14);
            this.ctrlDriverLicenseInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(913, 467);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 35;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelecetd += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // frmRenewLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 771);
            this.Controls.Add(this.btnShowLicensesHistory);
            this.Controls.Add(this.btnShowLicensesInfo);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.gbAppInfo);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenewLocalDrivingLicenseApplication";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew Local Driving License";
            this.Activated += new System.EventHandler(this.frmRenewLocalDrivingLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.frmRenewLocalDrivingLicense_Load);
            this.gbAppInfo.ResumeLayout(false);
            this.gbAppInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowLicensesInfo;
        private System.Windows.Forms.Button btnShowLicensesHistory;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.GroupBox gbAppInfo;
        private System.Windows.Forms.TextBox tbLicenseNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblRenewedLicenseID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label R_L_ApplicationID;
        private System.Windows.Forms.Label label10;
        private Licenses.Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
    }
}