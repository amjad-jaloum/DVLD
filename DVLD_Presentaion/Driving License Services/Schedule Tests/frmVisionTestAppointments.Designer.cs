namespace _19___Project___DVLD.Driving_License_Services.Schedule_Tests
{
    partial class frmVisionTestAppointments
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewAppointment = new System.Windows.Forms.Button();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvVisionTestAppointments = new System.Windows.Forms.DataGridView();
            this.ctrlShowDrivingLicenseAppInfo1 = new _19___Project___DVLD.Driving_License_Services.ctrlShowDrivingLicenseAppInfo();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisionTestAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 68);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(153, 32);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(153, 32);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNewAppointment);
            this.panel1.Controls.Add(this.lblRecordsCount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvVisionTestAppointments);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 582);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 271);
            this.panel1.TabIndex = 10;
            // 
            // btnNewAppointment
            // 
            this.btnNewAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewAppointment.AutoSize = true;
            this.btnNewAppointment.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnNewAppointment.Location = new System.Drawing.Point(747, 208);
            this.btnNewAppointment.Name = "btnNewAppointment";
            this.btnNewAppointment.Size = new System.Drawing.Size(300, 46);
            this.btnNewAppointment.TabIndex = 11;
            this.btnNewAppointment.Text = "New Appointment";
            this.btnNewAppointment.UseVisualStyleBackColor = true;
            this.btnNewAppointment.Click += new System.EventHandler(this.btnNewAppointment_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecordsCount.Location = new System.Drawing.Point(130, 208);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(56, 32);
            this.lblRecordsCount.TabIndex = 13;
            this.lblRecordsCount.Text = "###";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(22, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "Records: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Appointments:";
            // 
            // dgvVisionTestAppointments
            // 
            this.dgvVisionTestAppointments.AllowUserToAddRows = false;
            this.dgvVisionTestAppointments.AllowUserToDeleteRows = false;
            this.dgvVisionTestAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisionTestAppointments.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvVisionTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisionTestAppointments.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvVisionTestAppointments.Location = new System.Drawing.Point(21, 65);
            this.dgvVisionTestAppointments.MultiSelect = false;
            this.dgvVisionTestAppointments.Name = "dgvVisionTestAppointments";
            this.dgvVisionTestAppointments.ReadOnly = true;
            this.dgvVisionTestAppointments.RowHeadersWidth = 62;
            this.dgvVisionTestAppointments.RowTemplate.Height = 28;
            this.dgvVisionTestAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVisionTestAppointments.Size = new System.Drawing.Size(1026, 131);
            this.dgvVisionTestAppointments.TabIndex = 9;
            // 
            // ctrlShowDrivingLicenseAppInfo1
            // 
            this.ctrlShowDrivingLicenseAppInfo1.appDate = new System.DateTime(((long)(0)));
            this.ctrlShowDrivingLicenseAppInfo1.applicantFullName = null;
            this.ctrlShowDrivingLicenseAppInfo1.appStatus = null;
            this.ctrlShowDrivingLicenseAppInfo1.AutoSize = true;
            this.ctrlShowDrivingLicenseAppInfo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlShowDrivingLicenseAppInfo1.licenseName = null;
            this.ctrlShowDrivingLicenseAppInfo1.LocalDrivingLicenseAppID = 0;
            this.ctrlShowDrivingLicenseAppInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowDrivingLicenseAppInfo1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrlShowDrivingLicenseAppInfo1.Name = "ctrlShowDrivingLicenseAppInfo1";
            this.ctrlShowDrivingLicenseAppInfo1.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.ctrlShowDrivingLicenseAppInfo1.passedTests = ((short)(0));
            this.ctrlShowDrivingLicenseAppInfo1.Size = new System.Drawing.Size(1068, 582);
            this.ctrlShowDrivingLicenseAppInfo1.TabIndex = 1;
            // 
            // frmVisionTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1068, 875);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ctrlShowDrivingLicenseAppInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVisionTestAppointments";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vision Test Appointments";
            this.Load += new System.EventHandler(this.frmVisionTestAppointments_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisionTestAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlShowDrivingLicenseAppInfo ctrlShowDrivingLicenseAppInfo1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewAppointment;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvVisionTestAppointments;
    }
}