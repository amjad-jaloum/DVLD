namespace _19___Project___DVLD
{
    partial class frmMain
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
            this.msMainNavBar = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem_People = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCurrentUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainNavBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainNavBar
            // 
            this.msMainNavBar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.msMainNavBar.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.msMainNavBar.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.msMainNavBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMainNavBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.peopleToolStripMenuItem_People,
            this.driversToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountToolStripMenuItem});
            this.msMainNavBar.Location = new System.Drawing.Point(0, 0);
            this.msMainNavBar.Name = "msMainNavBar";
            this.msMainNavBar.Size = new System.Drawing.Size(1062, 46);
            this.msMainNavBar.TabIndex = 0;
            this.msMainNavBar.Text = "menuStrip1";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(184, 42);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // peopleToolStripMenuItem_People
            // 
            this.peopleToolStripMenuItem_People.Name = "peopleToolStripMenuItem_People";
            this.peopleToolStripMenuItem_People.Size = new System.Drawing.Size(117, 42);
            this.peopleToolStripMenuItem_People.Text = "People";
            this.peopleToolStripMenuItem_People.Click += new System.EventHandler(this.peopleToolStripMenuItem_People_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(120, 42);
            this.driversToolStripMenuItem.Text = "Drivers";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(101, 42);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCurrentUserToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(250, 42);
            this.accountToolStripMenuItem.Text = "Account Setttings";
            // 
            // showCurrentUserToolStripMenuItem
            // 
            this.showCurrentUserToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.showCurrentUserToolStripMenuItem.Name = "showCurrentUserToolStripMenuItem";
            this.showCurrentUserToolStripMenuItem.Size = new System.Drawing.Size(295, 38);
            this.showCurrentUserToolStripMenuItem.Text = "Show current user";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(295, 38);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::_19___Project___DVLD.Properties.Resources.driver_config__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1062, 620);
            this.Controls.Add(this.msMainNavBar);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMainNavBar;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msMainNavBar.ResumeLayout(false);
            this.msMainNavBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainNavBar;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem_People;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCurrentUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    }
}

