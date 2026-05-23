namespace _19___Project___DVLD.Driving_Licenses.Detained_Licenses
{
    partial class frmDetainLicenseApplication
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
            this.components = new System.ComponentModel.Container();
            this.btnShowLicensesInfo = new System.Windows.Forms.Button();
            this.btnShowLicensesHistory = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.gbAppInfo = new System.Windows.Forms.GroupBox();
            this.txtFineFees = new System.Windows.Forms.TextBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlDriverLicenseInfoWithFilter1 = new _19___Project___DVLD.Licenses.Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter();
            this.gbAppInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowLicensesInfo
            // 
            this.btnShowLicensesInfo.Enabled = false;
            this.btnShowLicensesInfo.Location = new System.Drawing.Point(162, 714);
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
            this.btnShowLicensesHistory.Location = new System.Drawing.Point(27, 714);
            this.btnShowLicensesHistory.Name = "btnShowLicensesHistory";
            this.btnShowLicensesHistory.Size = new System.Drawing.Size(135, 37);
            this.btnShowLicensesHistory.TabIndex = 17;
            this.btnShowLicensesHistory.Text = "Show Licenses History";
            this.btnShowLicensesHistory.UseVisualStyleBackColor = true;
            this.btnShowLicensesHistory.Click += new System.EventHandler(this.btnShowLicensesHistory_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.Enabled = false;
            this.btnDetain.Location = new System.Drawing.Point(785, 714);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(135, 37);
            this.btnDetain.TabIndex = 16;
            this.btnDetain.Text = "Detain";
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // gbAppInfo
            // 
            this.gbAppInfo.Controls.Add(this.txtFineFees);
            this.gbAppInfo.Controls.Add(this.lblCreatedBy);
            this.gbAppInfo.Controls.Add(this.label24);
            this.gbAppInfo.Controls.Add(this.lblLicenseID);
            this.gbAppInfo.Controls.Add(this.label22);
            this.gbAppInfo.Controls.Add(this.label16);
            this.gbAppInfo.Controls.Add(this.lblDetainDate);
            this.gbAppInfo.Controls.Add(this.label14);
            this.gbAppInfo.Controls.Add(this.lblDetainID);
            this.gbAppInfo.Controls.Add(this.label10);
            this.gbAppInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAppInfo.Location = new System.Drawing.Point(27, 506);
            this.gbAppInfo.Margin = new System.Windows.Forms.Padding(2);
            this.gbAppInfo.Name = "gbAppInfo";
            this.gbAppInfo.Padding = new System.Windows.Forms.Padding(2);
            this.gbAppInfo.Size = new System.Drawing.Size(893, 203);
            this.gbAppInfo.TabIndex = 15;
            this.gbAppInfo.TabStop = false;
            this.gbAppInfo.Text = "Detain Info";
            // 
            // txtFineFees
            // 
            this.txtFineFees.Location = new System.Drawing.Point(174, 100);
            this.txtFineFees.Name = "txtFineFees";
            this.txtFineFees.Size = new System.Drawing.Size(92, 29);
            this.txtFineFees.TabIndex = 8;
            this.txtFineFees.Validating += new System.ComponentModel.CancelEventHandler(this.txtFineFees_Validating);
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(588, 66);
            this.lblCreatedBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(48, 21);
            this.lblCreatedBy.TabIndex = 27;
            this.lblCreatedBy.Text = "None";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(390, 68);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(96, 21);
            this.label24.TabIndex = 23;
            this.label24.Text = "Created By:";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Location = new System.Drawing.Point(588, 38);
            this.lblLicenseID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(41, 21);
            this.lblLicenseID.TabIndex = 11;
            this.lblLicenseID.Text = "[???]";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(390, 38);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(91, 21);
            this.label22.TabIndex = 10;
            this.label22.Text = "License ID:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(18, 100);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 21);
            this.label16.TabIndex = 8;
            this.label16.Text = "Fine Fees: ";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Location = new System.Drawing.Point(170, 68);
            this.lblDetainDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(48, 21);
            this.lblDetainDate.TabIndex = 7;
            this.lblDetainDate.Text = "None";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 68);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 21);
            this.label14.TabIndex = 6;
            this.label14.Text = "Detain Date:";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Location = new System.Drawing.Point(170, 36);
            this.lblDetainID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(41, 21);
            this.lblDetainID.TabIndex = 5;
            this.lblDetainID.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 21);
            this.label10.TabIndex = 4;
            this.label10.Text = "Detain ID:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(27, 34);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(893, 468);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 19;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelecetd += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelecetd);
            // 
            // frmDetainLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 776);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.btnShowLicensesInfo);
            this.Controls.Add(this.btnShowLicensesHistory);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.gbAppInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetainLicenseApplication";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detain License";
            this.Activated += new System.EventHandler(this.frmDetainLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.frmDetainLicenseApplication_Load);
            this.gbAppInfo.ResumeLayout(false);
            this.gbAppInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowLicensesInfo;
        private System.Windows.Forms.Button btnShowLicensesHistory;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.GroupBox gbAppInfo;
        private System.Windows.Forms.TextBox txtFineFees;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Licenses.Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
    }
}