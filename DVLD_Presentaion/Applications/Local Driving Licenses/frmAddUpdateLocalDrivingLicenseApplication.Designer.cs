namespace _19___Project___DVLD.Driving_License_Services
{
    partial class frmAddUpdateLocalDrivingLicenseApplication
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
            this.tcApplicationInfo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNextTab = new System.Windows.Forms.Button();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.gbUserDetails = new System.Windows.Forms.GroupBox();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDLAppID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlPersonCardWithFilter1 = new People.ctrlPersonCardWithFilter();
            this.tcApplicationInfo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpApplicationInfo.SuspendLayout();
            this.gbUserDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcApplicationInfo
            // 
            this.tcApplicationInfo.Controls.Add(this.tabPage1);
            this.tcApplicationInfo.Controls.Add(this.tpApplicationInfo);
            this.tcApplicationInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcApplicationInfo.Location = new System.Drawing.Point(0, 0);
            this.tcApplicationInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tcApplicationInfo.Name = "tcApplicationInfo";
            this.tcApplicationInfo.SelectedIndex = 0;
            this.tcApplicationInfo.Size = new System.Drawing.Size(799, 503);
            this.tcApplicationInfo.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tabPage1.Controls.Add(this.btnNextTab);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage1.Size = new System.Drawing.Size(791, 477);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Person info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnNextTab
            // 
            this.btnNextTab.AutoSize = true;
            this.btnNextTab.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnNextTab.Location = new System.Drawing.Point(640, 426);
            this.btnNextTab.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextTab.Name = "btnNextTab";
            this.btnNextTab.Size = new System.Drawing.Size(98, 31);
            this.btnNextTab.TabIndex = 8;
            this.btnNextTab.Text = "Next";
            this.btnNextTab.UseVisualStyleBackColor = true;
            this.btnNextTab.Click += new System.EventHandler(this.btnNextTab_Click);
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.Controls.Add(this.gbUserDetails);
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tpApplicationInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(67, 65, 67, 65);
            this.tpApplicationInfo.Size = new System.Drawing.Size(791, 442);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "Application info";
            this.tpApplicationInfo.UseVisualStyleBackColor = true;
            this.tpApplicationInfo.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // gbUserDetails
            // 
            this.gbUserDetails.Controls.Add(this.cbLicenseClass);
            this.gbUserDetails.Controls.Add(this.lblCreatedBy);
            this.gbUserDetails.Controls.Add(this.lblAppFees);
            this.gbUserDetails.Controls.Add(this.lblAppDate);
            this.gbUserDetails.Controls.Add(this.label5);
            this.gbUserDetails.Controls.Add(this.label4);
            this.gbUserDetails.Controls.Add(this.lblDLAppID);
            this.gbUserDetails.Controls.Add(this.label1);
            this.gbUserDetails.Controls.Add(this.btnClose);
            this.gbUserDetails.Controls.Add(this.btnSave);
            this.gbUserDetails.Controls.Add(this.label3);
            this.gbUserDetails.Controls.Add(this.label2);
            this.gbUserDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUserDetails.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbUserDetails.Location = new System.Drawing.Point(67, 65);
            this.gbUserDetails.Margin = new System.Windows.Forms.Padding(2);
            this.gbUserDetails.Name = "gbUserDetails";
            this.gbUserDetails.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gbUserDetails.Size = new System.Drawing.Size(657, 312);
            this.gbUserDetails.TabIndex = 0;
            this.gbUserDetails.TabStop = false;
            this.gbUserDetails.Text = "Local Driving License Application";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(197, 144);
            this.cbLicenseClass.Margin = new System.Windows.Forms.Padding(2);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(269, 29);
            this.cbLicenseClass.TabIndex = 23;
            this.cbLicenseClass.SelectedIndexChanged += new System.EventHandler(this.cbLicenseClass_SelectedIndexChanged);
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(197, 221);
            this.lblCreatedBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(37, 21);
            this.lblCreatedBy.TabIndex = 22;
            this.lblCreatedBy.Text = "###";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.Location = new System.Drawing.Point(197, 185);
            this.lblAppFees.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(37, 21);
            this.lblAppFees.TabIndex = 21;
            this.lblAppFees.Text = "###";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(197, 109);
            this.lblAppDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(37, 21);
            this.lblAppDate.TabIndex = 20;
            this.lblAppDate.Text = "###";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(69, 221);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 21);
            this.label5.TabIndex = 19;
            this.label5.Text = "Created By:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 184);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "App Fees:";
            // 
            // lblDLAppID
            // 
            this.lblDLAppID.AutoSize = true;
            this.lblDLAppID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLAppID.Location = new System.Drawing.Point(197, 73);
            this.lblDLAppID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDLAppID.Name = "lblDLAppID";
            this.lblDLAppID.Size = new System.Drawing.Size(25, 21);
            this.lblDLAppID.TabIndex = 17;
            this.lblDLAppID.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "License Class:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnClose.Location = new System.Drawing.Point(447, 259);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 32);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSave.Location = new System.Drawing.Point(540, 259);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 32);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "App Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "D.L App ID:";
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(49, 8);
            this.ctrlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(689, 403);
            this.ctrlPersonCardWithFilter1.TabIndex = 9;
            this.ctrlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCardWithFilter1_OnPersonSelected);
            // 
            // frmAddUpdateLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 503);
            this.Controls.Add(this.tcApplicationInfo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUpdateLocalDrivingLicenseApplication";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Local Driving License Applications";
            this.Activated += new System.EventHandler(this.frmAddUpdateLocalDrivingLicesnseApplication_Activated);
            this.Load += new System.EventHandler(this.frmNewLocalDrivingLicenseApplications_Load);
            this.tcApplicationInfo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tpApplicationInfo.ResumeLayout(false);
            this.gbUserDetails.ResumeLayout(false);
            this.gbUserDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcApplicationInfo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnNextTab;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private System.Windows.Forms.GroupBox gbUserDetails;
        private System.Windows.Forms.Label lblDLAppID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private People.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
    }
}