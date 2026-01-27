namespace _19___Project___DVLD.Users
{
    partial class frmShowUserDetails
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
            this.ctrlPersonWithLoggedUserDetails1 = new _19___Project___DVLD.Users.ctrlPersonWithLoggedUserDetails();
            this.SuspendLayout();
            // 
            // ctrlPersonWithLoggedUserDetails1
            // 
            this.ctrlPersonWithLoggedUserDetails1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPersonWithLoggedUserDetails1.AutoSize = true;
            this.ctrlPersonWithLoggedUserDetails1.Location = new System.Drawing.Point(119, 68);
            this.ctrlPersonWithLoggedUserDetails1.Name = "ctrlPersonWithLoggedUserDetails1";
            this.ctrlPersonWithLoggedUserDetails1.Size = new System.Drawing.Size(1001, 607);
            this.ctrlPersonWithLoggedUserDetails1.TabIndex = 0;
            // 
            // frmShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 732);
            this.Controls.Add(this.ctrlPersonWithLoggedUserDetails1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowDetails";
            this.Text = "Show User Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonWithLoggedUserDetails ctrlPersonWithLoggedUserDetails1;
    }
}