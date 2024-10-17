﻿namespace Laboratory_Management_System__Capstone_Project_
{
    partial class TransactionDetails
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
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblStudents = new System.Windows.Forms.Label();
            this.lblApparatus = new System.Windows.Forms.Label();
            this.lblViolation = new System.Windows.Forms.Label();
            this.lblReturn = new System.Windows.Forms.Label();
            this.lblBorrow = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.cmbViewOptions = new System.Windows.Forms.ComboBox();
            this.dgvViolationRecords = new System.Windows.Forms.DataGridView();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.dgvBorrowDetails = new System.Windows.Forms.DataGridView();
            this.dgvReturnDetails = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViolationRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.bg_popup_main;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.lblStudents);
            this.panel1.Controls.Add(this.lblApparatus);
            this.panel1.Controls.Add(this.lblViolation);
            this.panel1.Controls.Add(this.lblReturn);
            this.panel1.Controls.Add(this.lblBorrow);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.cmbViewOptions);
            this.panel1.Controls.Add(this.dgvViolationRecords);
            this.panel1.Controls.Add(this.dgvInventory);
            this.panel1.Controls.Add(this.dgvStudents);
            this.panel1.Controls.Add(this.dgvBorrowDetails);
            this.panel1.Controls.Add(this.dgvReturnDetails);
            this.panel1.Location = new System.Drawing.Point(35, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1540, 932);
            this.panel1.TabIndex = 51;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(1144, 102);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(164, 38);
            this.btnExport.TabIndex = 54;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(1329, 102);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(164, 38);
            this.btnPrint.TabIndex = 53;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // lblStudents
            // 
            this.lblStudents.AutoSize = true;
            this.lblStudents.BackColor = System.Drawing.Color.Transparent;
            this.lblStudents.Font = new System.Drawing.Font("Bahnschrift", 35F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblStudents.ForeColor = System.Drawing.Color.White;
            this.lblStudents.Location = new System.Drawing.Point(1218, 26);
            this.lblStudents.Name = "lblStudents";
            this.lblStudents.Size = new System.Drawing.Size(277, 57);
            this.lblStudents.TabIndex = 52;
            this.lblStudents.Text = "Student List";
            // 
            // lblApparatus
            // 
            this.lblApparatus.AutoSize = true;
            this.lblApparatus.BackColor = System.Drawing.Color.Transparent;
            this.lblApparatus.Font = new System.Drawing.Font("Bahnschrift", 35F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblApparatus.ForeColor = System.Drawing.Color.White;
            this.lblApparatus.Location = new System.Drawing.Point(1180, 26);
            this.lblApparatus.Name = "lblApparatus";
            this.lblApparatus.Size = new System.Drawing.Size(313, 57);
            this.lblApparatus.TabIndex = 52;
            this.lblApparatus.Text = "Inventory List";
            // 
            // lblViolation
            // 
            this.lblViolation.AutoSize = true;
            this.lblViolation.BackColor = System.Drawing.Color.Transparent;
            this.lblViolation.Font = new System.Drawing.Font("Bahnschrift", 35F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblViolation.ForeColor = System.Drawing.Color.White;
            this.lblViolation.Location = new System.Drawing.Point(1098, 26);
            this.lblViolation.Name = "lblViolation";
            this.lblViolation.Size = new System.Drawing.Size(395, 57);
            this.lblViolation.TabIndex = 52;
            this.lblViolation.Text = "Violation Records";
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.BackColor = System.Drawing.Color.Transparent;
            this.lblReturn.Font = new System.Drawing.Font("Bahnschrift", 35F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblReturn.ForeColor = System.Drawing.Color.White;
            this.lblReturn.Location = new System.Drawing.Point(1149, 26);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(347, 57);
            this.lblReturn.TabIndex = 52;
            this.lblReturn.Text = "Returned Items";
            // 
            // lblBorrow
            // 
            this.lblBorrow.AutoSize = true;
            this.lblBorrow.BackColor = System.Drawing.Color.Transparent;
            this.lblBorrow.Font = new System.Drawing.Font("Bahnschrift", 35F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblBorrow.ForeColor = System.Drawing.Color.White;
            this.lblBorrow.Location = new System.Drawing.Point(1134, 26);
            this.lblBorrow.Name = "lblBorrow";
            this.lblBorrow.Size = new System.Drawing.Size(362, 57);
            this.lblBorrow.TabIndex = 52;
            this.lblBorrow.Text = "Borrowed Items";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.report2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(39, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 95);
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(147, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 19);
            this.label4.TabIndex = 49;
            this.label4.Text = "Report Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(144, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 41);
            this.label2.TabIndex = 49;
            this.label2.Text = "Transaction Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(767, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 19);
            this.label1.TabIndex = 49;
            this.label1.Text = "Check Record Details:";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1567, 33);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(32, 31);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "X";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // cmbViewOptions
            // 
            this.cmbViewOptions.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.cmbViewOptions.FormattingEnabled = true;
            this.cmbViewOptions.Location = new System.Drawing.Point(948, 109);
            this.cmbViewOptions.Margin = new System.Windows.Forms.Padding(2);
            this.cmbViewOptions.Name = "cmbViewOptions";
            this.cmbViewOptions.Size = new System.Drawing.Size(177, 27);
            this.cmbViewOptions.TabIndex = 42;
            this.cmbViewOptions.SelectedIndexChanged += new System.EventHandler(this.cmbViewOptions_SelectedIndexChanged);
            // 
            // dgvViolationRecords
            // 
            this.dgvViolationRecords.AllowUserToOrderColumns = true;
            this.dgvViolationRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViolationRecords.Location = new System.Drawing.Point(39, 161);
            this.dgvViolationRecords.Margin = new System.Windows.Forms.Padding(2);
            this.dgvViolationRecords.Name = "dgvViolationRecords";
            this.dgvViolationRecords.RowHeadersWidth = 51;
            this.dgvViolationRecords.RowTemplate.Height = 24;
            this.dgvViolationRecords.Size = new System.Drawing.Size(1454, 729);
            this.dgvViolationRecords.TabIndex = 40;
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToOrderColumns = true;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(39, 161);
            this.dgvInventory.Margin = new System.Windows.Forms.Padding(2);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowHeadersWidth = 51;
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.Size = new System.Drawing.Size(1339, 729);
            this.dgvInventory.TabIndex = 45;
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToOrderColumns = true;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(39, 161);
            this.dgvStudents.Margin = new System.Windows.Forms.Padding(2);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowHeadersWidth = 51;
            this.dgvStudents.RowTemplate.Height = 24;
            this.dgvStudents.Size = new System.Drawing.Size(1339, 729);
            this.dgvStudents.TabIndex = 47;
            // 
            // dgvBorrowDetails
            // 
            this.dgvBorrowDetails.AllowUserToOrderColumns = true;
            this.dgvBorrowDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowDetails.Location = new System.Drawing.Point(39, 161);
            this.dgvBorrowDetails.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBorrowDetails.Name = "dgvBorrowDetails";
            this.dgvBorrowDetails.RowHeadersWidth = 51;
            this.dgvBorrowDetails.RowTemplate.Height = 24;
            this.dgvBorrowDetails.Size = new System.Drawing.Size(1454, 729);
            this.dgvBorrowDetails.TabIndex = 0;
            // 
            // dgvReturnDetails
            // 
            this.dgvReturnDetails.AllowUserToOrderColumns = true;
            this.dgvReturnDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnDetails.Location = new System.Drawing.Point(39, 161);
            this.dgvReturnDetails.Margin = new System.Windows.Forms.Padding(2);
            this.dgvReturnDetails.Name = "dgvReturnDetails";
            this.dgvReturnDetails.RowHeadersWidth = 51;
            this.dgvReturnDetails.RowTemplate.Height = 24;
            this.dgvReturnDetails.Size = new System.Drawing.Size(1454, 729);
            this.dgvReturnDetails.TabIndex = 1;
            // 
            // TransactionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1829, 1084);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TransactionDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Details and Report Summary of Transactions";
            this.Load += new System.EventHandler(this.TransactionDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViolationRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBorrowDetails;
        private System.Windows.Forms.DataGridView dgvReturnDetails;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvViolationRecords;
        private System.Windows.Forms.ComboBox cmbViewOptions;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Label label1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBorrow;
        private System.Windows.Forms.Label lblStudents;
        private System.Windows.Forms.Label lblApparatus;
        private System.Windows.Forms.Label lblViolation;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
    }
}