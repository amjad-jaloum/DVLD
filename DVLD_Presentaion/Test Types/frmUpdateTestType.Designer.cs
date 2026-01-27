namespace _19___Project___DVLD.Test_Types
{
    partial class frmUpdateTestType
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbTestFees = new System.Windows.Forms.TextBox();
            this.tbTestTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTestID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTestDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancel.Location = new System.Drawing.Point(408, 416);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 59);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.Location = new System.Drawing.Point(547, 416);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 59);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbTestFees
            // 
            this.tbTestFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbTestFees.Location = new System.Drawing.Point(12, 363);
            this.tbTestFees.Name = "tbTestFees";
            this.tbTestFees.Size = new System.Drawing.Size(668, 35);
            this.tbTestFees.TabIndex = 2;
            this.tbTestFees.Leave += new System.EventHandler(this.tbTestFees_Leave);
            // 
            // tbTestTitle
            // 
            this.tbTestTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbTestTitle.Location = new System.Drawing.Point(12, 49);
            this.tbTestTitle.Name = "tbTestTitle";
            this.tbTestTitle.Size = new System.Drawing.Size(668, 35);
            this.tbTestTitle.TabIndex = 0;
            this.tbTestTitle.Leave += new System.EventHandler(this.tbTestTitle_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(12, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fees:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(12, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Title:";
            // 
            // lblTestID
            // 
            this.lblTestID.AutoSize = true;
            this.lblTestID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTestID.Location = new System.Drawing.Point(628, 17);
            this.lblTestID.Name = "lblTestID";
            this.lblTestID.Size = new System.Drawing.Size(52, 29);
            this.lblTestID.TabIndex = 9;
            this.lblTestID.Text = "###";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(580, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "ID:";
            // 
            // tbTestDesc
            // 
            this.tbTestDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbTestDesc.Location = new System.Drawing.Point(12, 132);
            this.tbTestDesc.Multiline = true;
            this.tbTestDesc.Name = "tbTestDesc";
            this.tbTestDesc.Size = new System.Drawing.Size(668, 181);
            this.tbTestDesc.TabIndex = 1;
            this.tbTestDesc.Leave += new System.EventHandler(this.tbTestDesc_Leave);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDesc.Location = new System.Drawing.Point(12, 100);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(74, 29);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Desc:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmUpdateTestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 487);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.tbTestDesc);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbTestFees);
            this.Controls.Add(this.tbTestTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTestID);
            this.Controls.Add(this.label1);
            this.Name = "frmUpdateTestType";
            this.Text = "frmUpdateTestType";
            this.Load += new System.EventHandler(this.frmUpdateTestType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbTestFees;
        private System.Windows.Forms.TextBox tbTestTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTestID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTestDesc;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}