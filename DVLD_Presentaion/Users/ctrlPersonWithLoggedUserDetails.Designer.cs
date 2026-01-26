namespace _19___Project___DVLD.Users
{
    partial class ctrlPersonWithLoggedUserDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlShowPersonDetails1 = new _19___Project___DVLD.People.ctrlShowPersonDetails();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.lblIsActive);
            this.gbFilter.Controls.Add(this.label5);
            this.gbFilter.Controls.Add(this.lblUsername);
            this.gbFilter.Controls.Add(this.label3);
            this.gbFilter.Controls.Add(this.lblUserID);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbFilter.Location = new System.Drawing.Point(3, 485);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Padding = new System.Windows.Forms.Padding(10);
            this.gbFilter.Size = new System.Drawing.Size(995, 119);
            this.gbFilter.TabIndex = 4;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Loggin Details";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(836, 54);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(56, 32);
            this.lblIsActive.TabIndex = 5;
            this.lblIsActive.Text = "###";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(723, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Is Active:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(547, 54);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(56, 32);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "###";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(239, 54);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(56, 32);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "###";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID:";
            // 
            // ctrlShowPersonDetails1
            // 
            this.ctrlShowPersonDetails1.Location = new System.Drawing.Point(3, 3);
            this.ctrlShowPersonDetails1.Name = "ctrlShowPersonDetails1";
            this.ctrlShowPersonDetails1.Size = new System.Drawing.Size(995, 485);
            this.ctrlShowPersonDetails1.TabIndex = 0;
            // 
            // ctrlPersonWithLoggedUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ctrlShowPersonDetails1);
            this.Name = "ctrlPersonWithLoggedUserDetails";
            this.Size = new System.Drawing.Size(1004, 611);
            this.Load += new System.EventHandler(this.ctrlPersonWithLoggedUserDetails_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private People.ctrlShowPersonDetails ctrlShowPersonDetails1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label1;
    }
}
