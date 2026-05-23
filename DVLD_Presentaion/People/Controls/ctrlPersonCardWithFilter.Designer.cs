namespace _19___Project___DVLD.People
{
    partial class ctrlPersonCardWithFilter
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.mtxbSearch = new System.Windows.Forms.MaskedTextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.ctrlPersonCard1 = new _19___Project___DVLD.People.ctrlPersonCard();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFindPerson);
            this.gbFilter.Controls.Add(this.btnAddPerson);
            this.gbFilter.Controls.Add(this.mtxbSearch);
            this.gbFilter.Controls.Add(this.cbFilter);
            this.gbFilter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbFilter.Location = new System.Drawing.Point(7, 6);
            this.gbFilter.Margin = new System.Windows.Forms.Padding(2);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gbFilter.Size = new System.Drawing.Size(673, 69);
            this.gbFilter.TabIndex = 5;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.AutoSize = true;
            this.btnFindPerson.Location = new System.Drawing.Point(498, 29);
            this.btnFindPerson.Margin = new System.Windows.Forms.Padding(2);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(50, 31);
            this.btnFindPerson.TabIndex = 6;
            this.btnFindPerson.Text = "Find";
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.AutoSize = true;
            this.btnAddPerson.Location = new System.Drawing.Point(549, 29);
            this.btnAddPerson.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(119, 31);
            this.btnAddPerson.TabIndex = 7;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // mtxbSearch
            // 
            this.mtxbSearch.BeepOnError = true;
            this.mtxbSearch.Location = new System.Drawing.Point(273, 31);
            this.mtxbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.mtxbSearch.Name = "mtxbSearch";
            this.mtxbSearch.Size = new System.Drawing.Size(223, 29);
            this.mtxbSearch.TabIndex = 5;
            this.mtxbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            this.mtxbSearch.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "National No.",
            "Person ID"});
            this.cbFilter.Location = new System.Drawing.Point(9, 31);
            this.cbFilter.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(261, 29);
            this.cbFilter.TabIndex = 4;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(7, 80);
            this.ctrlPersonCard1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ctrlPersonCard1.Size = new System.Drawing.Size(675, 317);
            this.ctrlPersonCard1.TabIndex = 6;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.gbFilter);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ctrlPersonCardWithFilter";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Size = new System.Drawing.Size(689, 403);
            this.Load += new System.EventHandler(this.ctrlPersonDetailWithFitler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.ErrorProvider errorProvider1;

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.MaskedTextBox mtxbSearch;
        private System.Windows.Forms.ComboBox cbFilter;
    }
}
