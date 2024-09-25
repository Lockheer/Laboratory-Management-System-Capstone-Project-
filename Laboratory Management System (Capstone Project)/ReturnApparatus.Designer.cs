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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearchID = new System.Windows.Forms.TextBox();
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
            this.btnExitUpper = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnInformation)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityReturned)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRefresh.FlatAppearance.BorderSize = 2;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(84, 656);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(124, 50);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(21)))));
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(70, 357);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(124, 35);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearchID
            // 
            this.tbSearchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchID.Location = new System.Drawing.Point(37, 317);
            this.tbSearchID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSearchID.Name = "tbSearchID";
            this.tbSearchID.Size = new System.Drawing.Size(194, 21);
            this.tbSearchID.TabIndex = 6;
            this.tbSearchID.TextChanged += new System.EventHandler(this.tbSearchID_TextChanged);
            this.tbSearchID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearchID_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(84, 99);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dgvReturnInformation
            // 
            this.dgvReturnInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnInformation.Location = new System.Drawing.Point(292, 74);
            this.dgvReturnInformation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvReturnInformation.Name = "dgvReturnInformation";
            this.dgvReturnInformation.RowHeadersWidth = 51;
            this.dgvReturnInformation.RowTemplate.Height = 24;
            this.dgvReturnInformation.Size = new System.Drawing.Size(772, 667);
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
            this.panel2.Location = new System.Drawing.Point(292, 418);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 323);
            this.panel2.TabIndex = 0;
            // 
            // numQuantityReturned
            // 
            this.numQuantityReturned.Location = new System.Drawing.Point(418, 82);
            this.numQuantityReturned.Name = "numQuantityReturned";
            this.numQuantityReturned.Size = new System.Drawing.Size(38, 20);
            this.numQuantityReturned.TabIndex = 15;
            // 
            // tbRemarks
            // 
            this.tbRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemarks.Location = new System.Drawing.Point(500, 107);
            this.tbRemarks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(245, 98);
            this.tbRemarks.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(496, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "Remarks:";
            // 
            // tbDue
            // 
            this.tbDue.Location = new System.Drawing.Point(207, 155);
            this.tbDue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbDue.Name = "tbDue";
            this.tbDue.Size = new System.Drawing.Size(182, 20);
            this.tbDue.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(110, 155);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Due Date:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(723, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(31, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "X";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnIssueReturn
            // 
            this.btnIssueReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(21)))));
            this.btnIssueReturn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIssueReturn.FlatAppearance.BorderSize = 0;
            this.btnIssueReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueReturn.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.btnIssueReturn.ForeColor = System.Drawing.Color.White;
            this.btnIssueReturn.Location = new System.Drawing.Point(523, 244);
            this.btnIssueReturn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIssueReturn.Name = "btnIssueReturn";
            this.btnIssueReturn.Size = new System.Drawing.Size(164, 38);
            this.btnIssueReturn.TabIndex = 10;
            this.btnIssueReturn.Text = "CONFIRM";
            this.btnIssueReturn.UseVisualStyleBackColor = false;
            this.btnIssueReturn.Click += new System.EventHandler(this.btnIssueReturn_Click);
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReturnDate.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.dtpReturnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReturnDate.Location = new System.Drawing.Point(191, 200);
            this.dtpReturnDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(168, 21);
            this.dtpReturnDate.TabIndex = 7;
            // 
            // tbBorrowedDate
            // 
            this.tbBorrowedDate.Location = new System.Drawing.Point(207, 123);
            this.tbBorrowedDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbBorrowedDate.Name = "tbBorrowedDate";
            this.tbBorrowedDate.Size = new System.Drawing.Size(182, 20);
            this.tbBorrowedDate.TabIndex = 6;
            // 
            // tbApparatusName
            // 
            this.tbApparatusName.Location = new System.Drawing.Point(207, 82);
            this.tbApparatusName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbApparatusName.Name = "tbApparatusName";
            this.tbApparatusName.Size = new System.Drawing.Size(182, 20);
            this.tbApparatusName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(73, 203);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Date Returned:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(79, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Borrowed Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(70, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apparatus Name:";
            // 
            // btnExitUpper
            // 
            this.btnExitUpper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExitUpper.FlatAppearance.BorderSize = 0;
            this.btnExitUpper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitUpper.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitUpper.ForeColor = System.Drawing.Color.White;
            this.btnExitUpper.Location = new System.Drawing.Point(1058, 26);
            this.btnExitUpper.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExitUpper.Name = "btnExitUpper";
            this.btnExitUpper.Size = new System.Drawing.Size(47, 49);
            this.btnExitUpper.TabIndex = 38;
            this.btnExitUpper.Text = "X";
            this.btnExitUpper.UseVisualStyleBackColor = false;
            this.btnExitUpper.Click += new System.EventHandler(this.btnExitUpper_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(494, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(407, 29);
            this.label6.TabIndex = 9;
            this.label6.Text = "RETURN APPARATUS TRANSACTION";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(35, 276);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(196, 29);
            this.label8.TabIndex = 39;
            this.label8.Text = "Enter ID Number:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(77, 243);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student List";
            // 
            // ReturnApparatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1127, 792);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnExitUpper);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearchID);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvReturnInformation);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReturnApparatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Return Transaction";
            this.Load += new System.EventHandler(this.ReturnApparatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnInformation)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityReturned)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvReturnInformation;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearchID;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExitUpper;
        private System.Windows.Forms.TextBox tbRemarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numQuantityReturned;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
    }
}