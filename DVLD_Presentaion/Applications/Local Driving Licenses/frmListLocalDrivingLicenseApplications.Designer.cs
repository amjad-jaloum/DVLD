namespace _19___Project___DVLD.Driving_License_Services
{
    partial class frmListLocalDrivingLicenseApplications
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
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.dgvLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelApplicaitonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ScheduleTestsMenue = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicensesHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMainHeader = new System.Windows.Forms.TableLayoutPanel();
            this.MainHeaderPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtFilterValue = new System.Windows.Forms.MaskedTextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewLocalLicense = new System.Windows.Forms.Button();
            this.tplMainFooter = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.plMainfooterLable = new System.Windows.Forms.Panel();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.lblRecordsNumber = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tlpForm.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tlpMainHeader.SuspendLayout();
            this.MainHeaderPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tplMainFooter.SuspendLayout();
            this.plMainfooterLable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 2;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.tlpForm.Controls.Add(this.tlpMain, 0, 0);
            this.tlpForm.Controls.Add(this.pictureBox1, 1, 0);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Margin = new System.Windows.Forms.Padding(2);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 1;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tlpForm.Size = new System.Drawing.Size(1092, 470);
            this.tlpForm.TabIndex = 1;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.dgvLocalDrivingLicenseApplications, 0, 1);
            this.tlpMain.Controls.Add(this.tlpMainHeader, 0, 0);
            this.tlpMain.Controls.Add(this.tplMainFooter, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(2, 2);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpMain.Size = new System.Drawing.Size(889, 466);
            this.tlpMain.TabIndex = 1;
            // 
            // dgvLocalDrivingLicenseApplications
            // 
            this.dgvLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLocalDrivingLicenseApplications.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseApplications.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLocalDrivingLicenseApplications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocalDrivingLicenseApplications.Location = new System.Drawing.Point(2, 55);
            this.dgvLocalDrivingLicenseApplications.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLocalDrivingLicenseApplications.MultiSelect = false;
            this.dgvLocalDrivingLicenseApplications.Name = "dgvLocalDrivingLicenseApplications";
            this.dgvLocalDrivingLicenseApplications.ReadOnly = true;
            this.dgvLocalDrivingLicenseApplications.RowHeadersWidth = 62;
            this.dgvLocalDrivingLicenseApplications.RowTemplate.Height = 28;
            this.dgvLocalDrivingLicenseApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalDrivingLicenseApplications.Size = new System.Drawing.Size(885, 356);
            this.dgvLocalDrivingLicenseApplications.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.DeleteApplicationToolStripMenuItem,
            this.toolStripSeparator5,
            this.CancelApplicaitonToolStripMenuItem,
            this.toolStripSeparator1,
            this.ScheduleTestsMenue,
            this.toolStripSeparator2,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.toolStripSeparator4,
            this.showLicenseToolStripMenuItem,
            this.toolStripSeparator3,
            this.showPersonLicensesHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(242, 210);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.editToolStripMenuItem.Text = "Edit Application";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // DeleteApplicationToolStripMenuItem
            // 
            this.DeleteApplicationToolStripMenuItem.Name = "DeleteApplicationToolStripMenuItem";
            this.DeleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.DeleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.DeleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(238, 6);
            // 
            // CancelApplicaitonToolStripMenuItem
            // 
            this.CancelApplicaitonToolStripMenuItem.Name = "CancelApplicaitonToolStripMenuItem";
            this.CancelApplicaitonToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.CancelApplicaitonToolStripMenuItem.Text = "Cancel Application";
            this.CancelApplicaitonToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(238, 6);
            // 
            // ScheduleTestsMenue
            // 
            this.ScheduleTestsMenue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.ScheduleTestsMenue.Name = "ScheduleTestsMenue";
            this.ScheduleTestsMenue.Size = new System.Drawing.Size(241, 22);
            this.ScheduleTestsMenue.Text = "Schedule Test";
            this.ScheduleTestsMenue.Click += new System.EventHandler(this.schedulTestToolStripMenuItem_Click);
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.scheduleVisionTestToolStripMenuItem.Text = "Vision Test";
            this.scheduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.visionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Enabled = false;
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Written Test";
            this.scheduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.writtenTestToolStripMenuItem_Click);
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Enabled = false;
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.scheduleStreetTestToolStripMenuItem.Text = "Street Test";
            this.scheduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.streetTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(238, 6);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (first time)";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.IssueDrivingLicense_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(238, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Enabled = false;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(238, 6);
            // 
            // showPersonLicensesHistoryToolStripMenuItem
            // 
            this.showPersonLicensesHistoryToolStripMenuItem.Name = "showPersonLicensesHistoryToolStripMenuItem";
            this.showPersonLicensesHistoryToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.showPersonLicensesHistoryToolStripMenuItem.Text = "Show Person Licenses History";
            this.showPersonLicensesHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicensesHistoryToolStripMenuItem_Click);
            // 
            // tlpMainHeader
            // 
            this.tlpMainHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMainHeader.ColumnCount = 2;
            this.tlpMainHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tlpMainHeader.Controls.Add(this.MainHeaderPanel, 0, 0);
            this.tlpMainHeader.Controls.Add(this.btnNewLocalLicense, 1, 0);
            this.tlpMainHeader.Location = new System.Drawing.Point(2, 2);
            this.tlpMainHeader.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMainHeader.Name = "tlpMainHeader";
            this.tlpMainHeader.RowCount = 1;
            this.tlpMainHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainHeader.Size = new System.Drawing.Size(885, 49);
            this.tlpMainHeader.TabIndex = 1;
            // 
            // MainHeaderPanel
            // 
            this.MainHeaderPanel.Controls.Add(this.flowLayoutPanel1);
            this.MainHeaderPanel.Controls.Add(this.cbFilterBy);
            this.MainHeaderPanel.Controls.Add(this.label1);
            this.MainHeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainHeaderPanel.Location = new System.Drawing.Point(2, 2);
            this.MainHeaderPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainHeaderPanel.Name = "MainHeaderPanel";
            this.MainHeaderPanel.Size = new System.Drawing.Size(679, 45);
            this.MainHeaderPanel.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtFilterValue);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(197, 22);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(249, 31);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(2, 2);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(116, 20);
            this.txtFilterValue.TabIndex = 5;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.mtxbSearch_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(59, 24);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(135, 21);
            this.cbFilterBy.TabIndex = 1;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter by";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnNewLocalLicense
            // 
            this.btnNewLocalLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewLocalLicense.AutoSize = true;
            this.btnNewLocalLicense.Location = new System.Drawing.Point(728, 17);
            this.btnNewLocalLicense.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewLocalLicense.Name = "btnNewLocalLicense";
            this.btnNewLocalLicense.Size = new System.Drawing.Size(155, 30);
            this.btnNewLocalLicense.TabIndex = 2;
            this.btnNewLocalLicense.Text = "New Local License ";
            this.btnNewLocalLicense.UseVisualStyleBackColor = true;
            this.btnNewLocalLicense.Click += new System.EventHandler(this.btnNewLocalLicense_Click);
            // 
            // tplMainFooter
            // 
            this.tplMainFooter.ColumnCount = 2;
            this.tplMainFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.07446F));
            this.tplMainFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.92554F));
            this.tplMainFooter.Controls.Add(this.btnClose, 1, 0);
            this.tplMainFooter.Controls.Add(this.plMainfooterLable, 0, 0);
            this.tplMainFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplMainFooter.Location = new System.Drawing.Point(2, 415);
            this.tplMainFooter.Margin = new System.Windows.Forms.Padding(2);
            this.tplMainFooter.Name = "tplMainFooter";
            this.tplMainFooter.RowCount = 1;
            this.tplMainFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplMainFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tplMainFooter.Size = new System.Drawing.Size(885, 49);
            this.tplMainFooter.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(746, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 45);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // plMainfooterLable
            // 
            this.plMainfooterLable.Controls.Add(this.lblRecordsCount);
            this.plMainfooterLable.Controls.Add(this.lblRecordsNumber);
            this.plMainfooterLable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMainfooterLable.Location = new System.Drawing.Point(2, 2);
            this.plMainfooterLable.Margin = new System.Windows.Forms.Padding(2);
            this.plMainfooterLable.Name = "plMainfooterLable";
            this.plMainfooterLable.Size = new System.Drawing.Size(740, 45);
            this.plMainfooterLable.TabIndex = 1;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(79, 0);
            this.lblRecordsCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lblRecordsCount.Size = new System.Drawing.Size(66, 45);
            this.lblRecordsCount.TabIndex = 3;
            this.lblRecordsCount.Text = "### ";
            // 
            // lblRecordsNumber
            // 
            this.lblRecordsNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRecordsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNumber.Location = new System.Drawing.Point(0, 0);
            this.lblRecordsNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordsNumber.Name = "lblRecordsNumber";
            this.lblRecordsNumber.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lblRecordsNumber.Size = new System.Drawing.Size(79, 45);
            this.lblRecordsNumber.TabIndex = 2;
            this.lblRecordsNumber.Text = "# Records: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::_19___Project___DVLD.Properties.Resources.papers;
            this.pictureBox1.Location = new System.Drawing.Point(913, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(13);
            this.pictureBox1.Size = new System.Drawing.Size(159, 430);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmListLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 470);
            this.Controls.Add(this.tlpForm);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListLocalDrivingLicenseApplications";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenseApplications_Load);
            this.tlpForm.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tlpMainHeader.ResumeLayout(false);
            this.tlpMainHeader.PerformLayout();
            this.MainHeaderPanel.ResumeLayout(false);
            this.MainHeaderPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tplMainFooter.ResumeLayout(false);
            this.plMainfooterLable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseApplications;
        private System.Windows.Forms.TableLayoutPanel tlpMainHeader;
        private System.Windows.Forms.Button btnNewLocalLicense;
        private System.Windows.Forms.TableLayoutPanel tplMainFooter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel plMainfooterLable;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label lblRecordsNumber;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel MainHeaderPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MaskedTextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CancelApplicaitonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ScheduleTestsMenue;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicensesHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}