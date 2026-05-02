namespace _19___Project___DVLD.Users
{
    partial class frmUserInfo
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
            this.ctrlPersonWithLoggedUserDetails1 = new _19___Project___DVLD.Users.ctrlUserCard();
            this.SuspendLayout();
            // 
            // ctrlPersonWithLoggedUserDetails1
            // 
            this.ctrlPersonWithLoggedUserDetails1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPersonWithLoggedUserDetails1.AutoSize = true;
            this.ctrlPersonWithLoggedUserDetails1.Location = new System.Drawing.Point(79, 44);
            this.ctrlPersonWithLoggedUserDetails1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ctrlPersonWithLoggedUserDetails1.Name = "ctrlPersonWithLoggedUserDetails1";
            this.ctrlPersonWithLoggedUserDetails1.Size = new System.Drawing.Size(667, 395);
            this.ctrlPersonWithLoggedUserDetails1.TabIndex = 0;
            // 
            // frmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 476);
            this.Controls.Add(this.ctrlPersonWithLoggedUserDetails1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserInfo";
            this.Text = "Show User Details";
            this.Load += new System.EventHandler(this.frmUserInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlUserCard ctrlPersonWithLoggedUserDetails1;
    }
}