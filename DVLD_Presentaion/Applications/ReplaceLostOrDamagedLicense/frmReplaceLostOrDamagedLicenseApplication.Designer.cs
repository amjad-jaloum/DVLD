namespace _19___Project___DVLD.Driving_Licenses.Licenses_Replacement
{
    partial class frmReplaceLostOrDamagedLicenseApplication
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
            this.btnIssueReplacement = new System.Windows.Forms.Button();
            this.gbAppInfo = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.R_L_ApplicationID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfoWithFilter1 = new _19___Project___DVLD.Licenses.Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter();
            this.gbReplacementFor = new System.Windows.Forms.GroupBox();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.gbAppInfo.SuspendLayout();
            this.gbReplacementFor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowLicensesInfo
            // 
            this.btnShowLicensesInfo.Enabled = false;
            this.btnShowLicensesInfo.Location = new System.Drawing.Point(176, 676);
            this.btnShowLicensesInfo.Name = "btnShowLicensesInfo";
            this.btnShowLicensesInfo.Size = new System.Drawing.Size(132, 40);
            this.btnShowLicensesInfo.TabIndex = 18;
            this.btnShowLicensesInfo.Text = "Show Licenses Info";
            this.btnShowLicensesInfo.UseVisualStyleBackColor = true;
            this.btnShowLicensesInfo.Click += new System.EventHandler(this.btnShowLicensesInfo_Click);
            // 
            // btnShowLicensesHistory
            // 
            this.btnShowLicensesHistory.Enabled = false;
            this.btnShowLicensesHistory.Location = new System.Drawing.Point(44, 676);
            this.btnShowLicensesHistory.Name = "btnShowLicensesHistory";
            this.btnShowLicensesHistory.Size = new System.Drawing.Size(132, 40);
            this.btnShowLicensesHistory.TabIndex = 17;
            this.btnShowLicensesHistory.Text = "Show Licenses History";
            this.btnShowLicensesHistory.UseVisualStyleBackColor = true;
            this.btnShowLicensesHistory.Click += new System.EventHandler(this.btnShowLicensesHistory_Click);
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.Enabled = false;
            this.btnIssueReplacement.Location = new System.Drawing.Point(314, 676);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(132, 40);
            this.btnIssueReplacement.TabIndex = 16;
            this.btnIssueReplacement.Text = "Issue Replacement";
            this.btnIssueReplacement.UseVisualStyleBackColor = true;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
            // 
            // gbAppInfo
            // 
            this.gbAppInfo.Controls.Add(this.lblCreatedBy);
            this.gbAppInfo.Controls.Add(this.lblAppFees);
            this.gbAppInfo.Controls.Add(this.label24);
            this.gbAppInfo.Controls.Add(this.label6);
            this.gbAppInfo.Controls.Add(this.lblOldLicenseID);
            this.gbAppInfo.Controls.Add(this.lbl);
            this.gbAppInfo.Controls.Add(this.lblReplacedLicenseID);
            this.gbAppInfo.Controls.Add(this.label22);
            this.gbAppInfo.Controls.Add(this.lblAppDate);
            this.gbAppInfo.Controls.Add(this.label14);
            this.gbAppInfo.Controls.Add(this.R_L_ApplicationID);
            this.gbAppInfo.Controls.Add(this.label10);
            this.gbAppInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAppInfo.Location = new System.Drawing.Point(44, 506);
            this.gbAppInfo.Margin = new System.Windows.Forms.Padding(2);
            this.gbAppInfo.Name = "gbAppInfo";
            this.gbAppInfo.Padding = new System.Windows.Forms.Padding(2);
            this.gbAppInfo.Size = new System.Drawing.Size(884, 153);
            this.gbAppInfo.TabIndex = 15;
            this.gbAppInfo.TabStop = false;
            this.gbAppInfo.Text = "Application Info For License Replacement";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(490, 104);
            this.lblCreatedBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(48, 21);
            this.lblCreatedBy.TabIndex = 27;
            this.lblCreatedBy.Text = "None";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Location = new System.Drawing.Point(170, 104);
            this.lblAppFees.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(47, 21);
            this.lblAppFees.TabIndex = 25;
            this.lblAppFees.Text = "[$$$]";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(292, 104);
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
            this.label6.Location = new System.Drawing.Point(18, 104);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "Application Fees:";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Location = new System.Drawing.Point(490, 71);
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
            this.lbl.Location = new System.Drawing.Point(292, 71);
            this.lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(122, 21);
            this.lbl.TabIndex = 12;
            this.lbl.Text = "Old License ID:";
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.AutoSize = true;
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(490, 36);
            this.lblReplacedLicenseID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(41, 21);
            this.lblReplacedLicenseID.TabIndex = 11;
            this.lblReplacedLicenseID.Text = "[???]";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(292, 36);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(165, 21);
            this.label22.TabIndex = 10;
            this.label22.Text = "Replaced License ID:";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Location = new System.Drawing.Point(170, 68);
            this.lblAppDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(48, 21);
            this.lblAppDate.TabIndex = 7;
            this.lblAppDate.Text = "None";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 70);
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
            this.label10.Size = new System.Drawing.Size(142, 21);
            this.label10.TabIndex = 4;
            this.label10.Text = "R.L.ApplicationID";
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(44, 33);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(893, 468);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 19;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelecetd += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelecetd);
            // 
            // gbReplacementFor
            // 
            this.gbReplacementFor.Controls.Add(this.rbLost);
            this.gbReplacementFor.Controls.Add(this.rbDamaged);
            this.gbReplacementFor.Location = new System.Drawing.Point(743, 664);
            this.gbReplacementFor.Name = "gbReplacementFor";
            this.gbReplacementFor.Size = new System.Drawing.Size(185, 61);
            this.gbReplacementFor.TabIndex = 28;
            this.gbReplacementFor.TabStop = false;
            this.gbReplacementFor.Text = "License Replacement ";
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rbLost.Location = new System.Drawing.Point(115, 28);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(54, 24);
            this.rbLost.TabIndex = 1;
            this.rbLost.Text = "Lost";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.rbLost_CheckedChanged);
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Checked = true;
            this.rbDamaged.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rbDamaged.Location = new System.Drawing.Point(16, 28);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(93, 24);
            this.rbDamaged.TabIndex = 0;
            this.rbDamaged.TabStop = true;
            this.rbDamaged.Text = "Damaged";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.rbDamaged_CheckedChanged);
            // 
            // frmReplaceLostOrDamagedLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 746);
            this.Controls.Add(this.gbReplacementFor);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.btnShowLicensesInfo);
            this.Controls.Add(this.btnShowLicensesHistory);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.gbAppInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplaceLostOrDamagedLicenseApplication";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License Replacement";
            this.Activated += new System.EventHandler(this.frmReplaceLostOrDamagedLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.frmReplaceLostOrDamagedLicenseApplication_Load);
            this.gbAppInfo.ResumeLayout(false);
            this.gbAppInfo.PerformLayout();
            this.gbReplacementFor.ResumeLayout(false);
            this.gbReplacementFor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowLicensesInfo;
        private System.Windows.Forms.Button btnShowLicensesHistory;
        private System.Windows.Forms.Button btnIssueReplacement;
        private System.Windows.Forms.GroupBox gbAppInfo;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label R_L_ApplicationID;
        private System.Windows.Forms.Label label10;
        private Licenses.Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.GroupBox gbReplacementFor;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.RadioButton rbDamaged;
    }
}