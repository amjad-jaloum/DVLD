namespace _19___Project___DVLD.Users
{
    partial class frmAddAndUpdateUser
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNextTab = new System.Windows.Forms.Button();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.mtxbSearch = new System.Windows.Forms.MaskedTextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbUserDetails = new System.Windows.Forms.GroupBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chxIsActive = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlShowPersonDetails1 = new _19___Project___DVLD.People.ctrlShowPersonDetails();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbFilter.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbUserDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1092, 691);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click_1);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNextTab);
            this.tabPage1.Controls.Add(this.ctrlShowPersonDetails1);
            this.tabPage1.Controls.Add(this.gbFilter);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(1084, 658);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Person info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnNextTab
            // 
            this.btnNextTab.AutoSize = true;
            this.btnNextTab.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnNextTab.Location = new System.Drawing.Point(874, 563);
            this.btnNextTab.Name = "btnNextTab";
            this.btnNextTab.Size = new System.Drawing.Size(147, 42);
            this.btnNextTab.TabIndex = 8;
            this.btnNextTab.Text = "Next";
            this.btnNextTab.UseVisualStyleBackColor = true;
            this.btnNextTab.Click += new System.EventHandler(this.btnNextTab_Click);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFindPerson);
            this.gbFilter.Controls.Add(this.btnAddPerson);
            this.gbFilter.Controls.Add(this.mtxbSearch);
            this.gbFilter.Controls.Add(this.cbFilter);
            this.gbFilter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbFilter.Location = new System.Drawing.Point(51, 35);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Padding = new System.Windows.Forms.Padding(10);
            this.gbFilter.Size = new System.Drawing.Size(983, 106);
            this.gbFilter.TabIndex = 3;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.AutoSize = true;
            this.btnFindPerson.Location = new System.Drawing.Point(747, 45);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(70, 42);
            this.btnFindPerson.TabIndex = 6;
            this.btnFindPerson.Text = "Find";
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.AutoSize = true;
            this.btnAddPerson.Location = new System.Drawing.Point(823, 45);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(147, 42);
            this.btnAddPerson.TabIndex = 7;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // mtxbSearch
            // 
            this.mtxbSearch.BeepOnError = true;
            this.mtxbSearch.Location = new System.Drawing.Point(409, 48);
            this.mtxbSearch.Name = "mtxbSearch";
            this.mtxbSearch.Size = new System.Drawing.Size(332, 39);
            this.mtxbSearch.TabIndex = 5;
            this.mtxbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxbSearch_KeyDown);
            this.mtxbSearch.Leave += new System.EventHandler(this.mtxbSearch_Leave);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(13, 47);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(390, 40);
            this.cbFilter.TabIndex = 4;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbUserDetails);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage2.Size = new System.Drawing.Size(1084, 658);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Login info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gbUserDetails
            // 
            this.gbUserDetails.Controls.Add(this.lblUserID);
            this.gbUserDetails.Controls.Add(this.tbConfirmPassword);
            this.gbUserDetails.Controls.Add(this.label1);
            this.gbUserDetails.Controls.Add(this.chxIsActive);
            this.gbUserDetails.Controls.Add(this.btnClose);
            this.gbUserDetails.Controls.Add(this.btnSave);
            this.gbUserDetails.Controls.Add(this.tbPassword);
            this.gbUserDetails.Controls.Add(this.tbUsername);
            this.gbUserDetails.Controls.Add(this.label3);
            this.gbUserDetails.Controls.Add(this.label2);
            this.gbUserDetails.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbUserDetails.Location = new System.Drawing.Point(301, 69);
            this.gbUserDetails.Name = "gbUserDetails";
            this.gbUserDetails.Size = new System.Drawing.Size(483, 518);
            this.gbUserDetails.TabIndex = 0;
            this.gbUserDetails.TabStop = false;
            this.gbUserDetails.Text = "User Details";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(301, 71);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(91, 32);
            this.lblUserID.TabIndex = 17;
            this.lblUserID.Text = "ID: ###";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbConfirmPassword.Location = new System.Drawing.Point(90, 249);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(302, 35);
            this.tbConfirmPassword.TabIndex = 12;
            this.tbConfirmPassword.Leave += new System.EventHandler(this.tbConfirmPassword_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Confirm Password";
            // 
            // chxIsActive
            // 
            this.chxIsActive.AutoSize = true;
            this.chxIsActive.Checked = true;
            this.chxIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chxIsActive.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chxIsActive.Location = new System.Drawing.Point(178, 306);
            this.chxIsActive.Name = "chxIsActive";
            this.chxIsActive.Size = new System.Drawing.Size(125, 36);
            this.chxIsActive.TabIndex = 13;
            this.chxIsActive.Text = "Is active";
            this.chxIsActive.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnClose.Location = new System.Drawing.Point(90, 411);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(302, 41);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSave.Location = new System.Drawing.Point(89, 364);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(303, 41);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbPassword.Location = new System.Drawing.Point(90, 177);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(302, 35);
            this.tbPassword.TabIndex = 11;
            this.tbPassword.Leave += new System.EventHandler(this.tbPassword_Leave);
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbUsername.Location = new System.Drawing.Point(90, 106);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(302, 35);
            this.tbUsername.TabIndex = 10;
            this.tbUsername.Leave += new System.EventHandler(this.tbUsername_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Username";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlShowPersonDetails1
            // 
            this.ctrlShowPersonDetails1.Location = new System.Drawing.Point(51, 147);
            this.ctrlShowPersonDetails1.Name = "ctrlShowPersonDetails1";
            this.ctrlShowPersonDetails1.Size = new System.Drawing.Size(1003, 488);
            this.ctrlShowPersonDetails1.TabIndex = 4;
            // 
            // frmAddAndUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 691);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddAndUpdateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Update User";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddAndUpdateUser_FormClosed);
            this.Load += new System.EventHandler(this.frmAddAndUpdateUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.gbUserDetails.ResumeLayout(false);
            this.gbUserDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnNextTab;
        private People.ctrlShowPersonDetails ctrlShowPersonDetails1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.GroupBox gbUserDetails;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chxIsActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.MaskedTextBox mtxbSearch;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}