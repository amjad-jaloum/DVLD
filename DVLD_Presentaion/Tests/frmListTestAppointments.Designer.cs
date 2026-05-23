namespace _19___Project___DVLD.Driving_License_Services.Schedule_Tests
{
    partial class frmListTestAppointments
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
            this.dgvLicenseTestAppointments = new System.Windows.Forms.DataGridView();
            this.ctrlDrivingLicenseApplicationInfo1 = new _19___Project___DVLD.Applications.Local_Driving_Licenses.ctrlDrivingLicenseApplicationInfo();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseTestAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNewAppointment);
            this.panel1.Controls.Add(this.lblRecordsCount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvLicenseTestAppointments);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 361);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 239);
            this.panel1.TabIndex = 10;
            // 
            // btnNewAppointment
            // 
            this.btnNewAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewAppointment.AutoSize = true;
            this.btnNewAppointment.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnNewAppointment.Location = new System.Drawing.Point(548, 198);
            this.btnNewAppointment.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewAppointment.Name = "btnNewAppointment";
            this.btnNewAppointment.Size = new System.Drawing.Size(200, 30);
            this.btnNewAppointment.TabIndex = 11;
            this.btnNewAppointment.Text = "New Appointment";
            this.btnNewAppointment.UseVisualStyleBackColor = true;
            this.btnNewAppointment.Click += new System.EventHandler(this.btnNewAppointment_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecordsCount.Location = new System.Drawing.Point(87, 202);
            this.lblRecordsCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(37, 21);
            this.lblRecordsCount.TabIndex = 13;
            this.lblRecordsCount.Text = "###";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(15, 202);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "Records: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Appointments:";
            // 
            // dgvLicenseTestAppointments
            // 
            this.dgvLicenseTestAppointments.AllowUserToAddRows = false;
            this.dgvLicenseTestAppointments.AllowUserToDeleteRows = false;
            this.dgvLicenseTestAppointments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLicenseTestAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLicenseTestAppointments.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLicenseTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLicenseTestAppointments.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLicenseTestAppointments.Location = new System.Drawing.Point(14, 42);
            this.dgvLicenseTestAppointments.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLicenseTestAppointments.MultiSelect = false;
            this.dgvLicenseTestAppointments.Name = "dgvLicenseTestAppointments";
            this.dgvLicenseTestAppointments.ReadOnly = true;
            this.dgvLicenseTestAppointments.RowHeadersWidth = 62;
            this.dgvLicenseTestAppointments.RowTemplate.Height = 28;
            this.dgvLicenseTestAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLicenseTestAppointments.Size = new System.Drawing.Size(734, 152);
            this.dgvLicenseTestAppointments.TabIndex = 9;
            // 
            // ctrlDrivingLicenseApplicationInfo1
            // 
            this.ctrlDrivingLicenseApplicationInfo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDrivingLicenseApplicationInfo1.Name = "ctrlDrivingLicenseApplicationInfo1";
            this.ctrlDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(762, 361);
            this.ctrlDrivingLicenseApplicationInfo1.TabIndex = 11;
            // 
            // frmListTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(762, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListTestAppointments";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Appointments";
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseTestAppointments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewAppointment;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLicenseTestAppointments;
        private Applications.Local_Driving_Licenses.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
    }
}