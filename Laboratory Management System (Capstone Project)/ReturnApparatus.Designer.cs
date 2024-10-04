namespace Laboratory_Management_System__Capstone_Project_
{
    partial class ReturnApparatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnApparatus));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearchID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvReturnInformation = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numQuantityReturned = new System.Windows.Forms.NumericUpDown();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnIssueReturn = new System.Windows.Forms.Button();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.tbBorrowedDate = new System.Windows.Forms.TextBox();
            this.tbApparatusName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExitUpper = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnInformation)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityReturned)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.tbSearchID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(4, 91);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 820);
            this.panel1.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRefresh.FlatAppearance.BorderSize = 2;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(88, 303);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(165, 43);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSearch.FlatAppearance.BorderSize = 2;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(88, 246);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(165, 43);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearchID
            // 
            this.tbSearchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchID.Location = new System.Drawing.Point(48, 217);
            this.tbSearchID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSearchID.Name = "tbSearchID";
            this.tbSearchID.Size = new System.Drawing.Size(257, 24);
            this.tbSearchID.TabIndex = 6;
            this.tbSearchID.TextChanged += new System.EventHandler(this.tbSearchID_TextChanged);
            this.tbSearchID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearchID_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter ID Number";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(103, 39);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dgvReturnInformation
            // 
            this.dgvReturnInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnInformation.Location = new System.Drawing.Point(389, 91);
            this.dgvReturnInformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvReturnInformation.Name = "dgvReturnInformation";
            this.dgvReturnInformation.RowHeadersWidth = 51;
            this.dgvReturnInformation.RowTemplate.Height = 24;
            this.dgvReturnInformation.Size = new System.Drawing.Size(1019, 418);
            this.dgvReturnInformation.TabIndex = 0;
            this.dgvReturnInformation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReturnInformation_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.numQuantityReturned);
            this.panel2.Controls.Add(this.tbRemarks);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tbDue);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnIssueReturn);
            this.panel2.Controls.Add(this.dtpReturnDate);
            this.panel2.Controls.Add(this.tbBorrowedDate);
            this.panel2.Controls.Add(this.tbApparatusName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(389, 514);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1029, 398);
            this.panel2.TabIndex = 0;
            // 
            // numQuantityReturned
            // 
            this.numQuantityReturned.Location = new System.Drawing.Point(513, 46);
            this.numQuantityReturned.Margin = new System.Windows.Forms.Padding(4);
            this.numQuantityReturned.Name = "numQuantityReturned";
            this.numQuantityReturned.Size = new System.Drawing.Size(51, 22);
            this.numQuantityReturned.TabIndex = 15;
            // 
            // tbRemarks
            // 
            this.tbRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemarks.Location = new System.Drawing.Point(227, 231);
            this.tbRemarks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(459, 150);
            this.tbRemarks.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(112, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Remarks:";
            // 
            // tbDue
            // 
            this.tbDue.Location = new System.Drawing.Point(248, 135);
            this.tbDue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDue.Name = "tbDue";
            this.tbDue.ReadOnly = true;
            this.tbDue.Size = new System.Drawing.Size(241, 22);
            this.tbDue.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(119, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Due Date:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(987, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(41, 34);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "X";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnIssueReturn
            // 
            this.btnIssueReturn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIssueReturn.FlatAppearance.BorderSize = 2;
            this.btnIssueReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReturn.Location = new System.Drawing.Point(775, 343);
            this.btnIssueReturn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIssueReturn.Name = "btnIssueReturn";
            this.btnIssueReturn.Size = new System.Drawing.Size(219, 47);
            this.btnIssueReturn.TabIndex = 10;
            this.btnIssueReturn.Text = "CONFIRM";
            this.btnIssueReturn.UseVisualStyleBackColor = true;
            this.btnIssueReturn.Click += new System.EventHandler(this.btnIssueReturn_Click);
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReturnDate.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.dtpReturnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReturnDate.Location = new System.Drawing.Point(227, 191);
            this.dtpReturnDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(223, 24);
            this.dtpReturnDate.TabIndex = 7;
            // 
            // tbBorrowedDate
            // 
            this.tbBorrowedDate.Location = new System.Drawing.Point(248, 96);
            this.tbBorrowedDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbBorrowedDate.Name = "tbBorrowedDate";
            this.tbBorrowedDate.ReadOnly = true;
            this.tbBorrowedDate.Size = new System.Drawing.Size(241, 22);
            this.tbBorrowedDate.TabIndex = 6;
            // 
            // tbApparatusName
            // 
            this.tbApparatusName.Location = new System.Drawing.Point(248, 46);
            this.tbApparatusName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbApparatusName.Name = "tbApparatusName";
            this.tbApparatusName.ReadOnly = true;
            this.tbApparatusName.Size = new System.Drawing.Size(241, 22);
            this.tbApparatusName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Date Returned:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Borrowed Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apparatus Name:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.Controls.Add(this.btnExitUpper);
            this.panel3.Location = new System.Drawing.Point(-5, -10);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1424, 48);
            this.panel3.TabIndex = 9;
            // 
            // btnExitUpper
            // 
            this.btnExitUpper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExitUpper.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExitUpper.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitUpper.ForeColor = System.Drawing.Color.White;
            this.btnExitUpper.Location = new System.Drawing.Point(1325, 12);
            this.btnExitUpper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExitUpper.Name = "btnExitUpper";
            this.btnExitUpper.Size = new System.Drawing.Size(63, 34);
            this.btnExitUpper.TabIndex = 38;
            this.btnExitUpper.Text = "X";
            this.btnExitUpper.UseVisualStyleBackColor = false;
            this.btnExitUpper.Click += new System.EventHandler(this.btnExitUpper_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(460, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(470, 29);
            this.label6.TabIndex = 9;
            this.label6.Text = "RETURN APPARATUS TRANSACTION";
            // 
            // ReturnApparatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1420, 884);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvReturnInformation);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReturnApparatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Return Transaction";
            this.Load += new System.EventHandler(this.ReturnApparatus_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnInformation)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityReturned)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvReturnInformation;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearchID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnIssueReturn;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.TextBox tbBorrowedDate;
        private System.Windows.Forms.TextBox tbApparatusName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExitUpper;
        private System.Windows.Forms.TextBox tbRemarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numQuantityReturned;
    }
}