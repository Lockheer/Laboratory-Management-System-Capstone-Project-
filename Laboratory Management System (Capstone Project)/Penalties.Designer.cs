﻿namespace Laboratory_Management_System__Capstone_Project_
{
    partial class PenaltiesRecords
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
            this.PanelCRUD = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.panelPayment = new System.Windows.Forms.Panel();
            this.lblRemainingBalance = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.tbAmtPayed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAmtToBe = new System.Windows.Forms.TextBox();
            this.lblAmntPayed = new System.Windows.Forms.Label();
            this.cbCondition = new System.Windows.Forms.ComboBox();
            this.cbTransact = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpPenaltyDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbViolation = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbContact = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbStudentName = new System.Windows.Forms.TextBox();
            this.tbIDnum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvPenalties = new System.Windows.Forms.DataGridView();
            this.tbSearchPenalty = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.PanelCRUD.SuspendLayout();
            this.panelPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenalties)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelCRUD
            // 
            this.PanelCRUD.Controls.Add(this.label9);
            this.PanelCRUD.Controls.Add(this.cbStatus);
            this.PanelCRUD.Controls.Add(this.panelPayment);
            this.PanelCRUD.Controls.Add(this.cbCondition);
            this.PanelCRUD.Controls.Add(this.cbTransact);
            this.PanelCRUD.Controls.Add(this.label11);
            this.PanelCRUD.Controls.Add(this.dtpPenaltyDate);
            this.PanelCRUD.Controls.Add(this.label1);
            this.PanelCRUD.Controls.Add(this.btnSendEmail);
            this.PanelCRUD.Controls.Add(this.btnDetails);
            this.PanelCRUD.Controls.Add(this.label7);
            this.PanelCRUD.Controls.Add(this.tbViolation);
            this.PanelCRUD.Controls.Add(this.label10);
            this.PanelCRUD.Controls.Add(this.tbContact);
            this.PanelCRUD.Controls.Add(this.tbEmail);
            this.PanelCRUD.Controls.Add(this.tbStudentName);
            this.PanelCRUD.Controls.Add(this.tbIDnum);
            this.PanelCRUD.Controls.Add(this.label8);
            this.PanelCRUD.Controls.Add(this.label6);
            this.PanelCRUD.Controls.Add(this.label5);
            this.PanelCRUD.Controls.Add(this.label4);
            this.PanelCRUD.Controls.Add(this.label3);
            this.PanelCRUD.Controls.Add(this.btnDelete);
            this.PanelCRUD.Controls.Add(this.btnUpdate);
            this.PanelCRUD.Controls.Add(this.btnAdd);
            this.PanelCRUD.Location = new System.Drawing.Point(21, 498);
            this.PanelCRUD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PanelCRUD.Name = "PanelCRUD";
            this.PanelCRUD.Size = new System.Drawing.Size(980, 396);
            this.PanelCRUD.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(310, 15);
            this.label9.TabIndex = 37;
            this.label9.Text = "Please select an existing Laboratory Transaction first";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Ongoing Penalty",
            "Cleared"});
            this.cbStatus.Location = new System.Drawing.Point(155, 296);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(114, 21);
            this.cbStatus.TabIndex = 36;
            // 
            // panelPayment
            // 
            this.panelPayment.Controls.Add(this.lblRemainingBalance);
            this.panelPayment.Controls.Add(this.lblBalance);
            this.panelPayment.Controls.Add(this.tbAmtPayed);
            this.panelPayment.Controls.Add(this.label2);
            this.panelPayment.Controls.Add(this.tbAmtToBe);
            this.panelPayment.Controls.Add(this.lblAmntPayed);
            this.panelPayment.Location = new System.Drawing.Point(686, 93);
            this.panelPayment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelPayment.Name = "panelPayment";
            this.panelPayment.Size = new System.Drawing.Size(270, 161);
            this.panelPayment.TabIndex = 35;
            // 
            // lblRemainingBalance
            // 
            this.lblRemainingBalance.AutoSize = true;
            this.lblRemainingBalance.Location = new System.Drawing.Point(116, 100);
            this.lblRemainingBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemainingBalance.Name = "lblRemainingBalance";
            this.lblRemainingBalance.Size = new System.Drawing.Size(16, 13);
            this.lblRemainingBalance.TabIndex = 32;
            this.lblRemainingBalance.Text = "...";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(12, 100);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(102, 13);
            this.lblBalance.TabIndex = 31;
            this.lblBalance.Text = "Remaining Balance:";
            // 
            // tbAmtPayed
            // 
            this.tbAmtPayed.Location = new System.Drawing.Point(115, 67);
            this.tbAmtPayed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAmtPayed.Name = "tbAmtPayed";
            this.tbAmtPayed.Size = new System.Drawing.Size(141, 20);
            this.tbAmtPayed.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Amount to be Payed:";
            // 
            // tbAmtToBe
            // 
            this.tbAmtToBe.Location = new System.Drawing.Point(115, 36);
            this.tbAmtToBe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAmtToBe.Name = "tbAmtToBe";
            this.tbAmtToBe.Size = new System.Drawing.Size(141, 20);
            this.tbAmtToBe.TabIndex = 28;
            // 
            // lblAmntPayed
            // 
            this.lblAmntPayed.AutoSize = true;
            this.lblAmntPayed.Location = new System.Drawing.Point(44, 67);
            this.lblAmntPayed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAmntPayed.Name = "lblAmntPayed";
            this.lblAmntPayed.Size = new System.Drawing.Size(70, 13);
            this.lblAmntPayed.TabIndex = 29;
            this.lblAmntPayed.Text = "Amount Paid:";
            // 
            // cbCondition
            // 
            this.cbCondition.FormattingEnabled = true;
            this.cbCondition.Items.AddRange(new object[] {
            "Payment",
            "Item Replacement",
            "Borrowing Restriction"});
            this.cbCondition.Location = new System.Drawing.Point(155, 266);
            this.cbCondition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbCondition.Name = "cbCondition";
            this.cbCondition.Size = new System.Drawing.Size(133, 21);
            this.cbCondition.TabIndex = 34;
            this.cbCondition.SelectedIndexChanged += new System.EventHandler(this.cbCondition_SelectedIndexChanged);
            // 
            // cbTransact
            // 
            this.cbTransact.FormattingEnabled = true;
            this.cbTransact.Location = new System.Drawing.Point(158, 60);
            this.cbTransact.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTransact.Name = "cbTransact";
            this.cbTransact.Size = new System.Drawing.Size(114, 21);
            this.cbTransact.TabIndex = 33;
            this.cbTransact.SelectedIndexChanged += new System.EventHandler(this.cbTransact_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(71, 299);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Violation Status:";
            // 
            // dtpPenaltyDate
            // 
            this.dtpPenaltyDate.Location = new System.Drawing.Point(577, 27);
            this.dtpPenaltyDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpPenaltyDate.Name = "dtpPenaltyDate";
            this.dtpPenaltyDate.Size = new System.Drawing.Size(192, 20);
            this.dtpPenaltyDate.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Penalty Issue Date:";
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(746, 296);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(152, 32);
            this.btnSendEmail.TabIndex = 24;
            this.btnSendEmail.Text = "SEND EMAIL";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(290, 53);
            this.btnDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(131, 32);
            this.btnDetails.TabIndex = 23;
            this.btnDetails.Text = "CHECK DETAILS";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 62);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Lab Transaction Number:";
            // 
            // tbViolation
            // 
            this.tbViolation.Location = new System.Drawing.Point(158, 232);
            this.tbViolation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbViolation.Name = "tbViolation";
            this.tbViolation.Size = new System.Drawing.Size(244, 20);
            this.tbViolation.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(95, 232);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Violation:";
            // 
            // tbContact
            // 
            this.tbContact.Location = new System.Drawing.Point(160, 196);
            this.tbContact.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbContact.Name = "tbContact";
            this.tbContact.ReadOnly = true;
            this.tbContact.Size = new System.Drawing.Size(242, 20);
            this.tbContact.TabIndex = 16;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(160, 162);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.ReadOnly = true;
            this.tbEmail.Size = new System.Drawing.Size(242, 20);
            this.tbEmail.TabIndex = 15;
            // 
            // tbStudentName
            // 
            this.tbStudentName.Location = new System.Drawing.Point(160, 129);
            this.tbStudentName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbStudentName.Name = "tbStudentName";
            this.tbStudentName.ReadOnly = true;
            this.tbStudentName.Size = new System.Drawing.Size(242, 20);
            this.tbStudentName.TabIndex = 14;
            // 
            // tbIDnum
            // 
            this.tbIDnum.Location = new System.Drawing.Point(160, 98);
            this.tbIDnum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbIDnum.Name = "tbIDnum";
            this.tbIDnum.ReadOnly = true;
            this.tbIDnum.Size = new System.Drawing.Size(242, 20);
            this.tbIDnum.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 268);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Penalty Condition:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 198);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Contact Number:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 164);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Email Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Student Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "ID Number:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(139, 336);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 32);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "REMOVE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(248, 336);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 32);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(23, 336);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 32);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvPenalties
            // 
            this.dgvPenalties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPenalties.Location = new System.Drawing.Point(59, 136);
            this.dgvPenalties.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPenalties.Name = "dgvPenalties";
            this.dgvPenalties.RowHeadersWidth = 51;
            this.dgvPenalties.RowTemplate.Height = 24;
            this.dgvPenalties.Size = new System.Drawing.Size(918, 344);
            this.dgvPenalties.TabIndex = 0;
            this.dgvPenalties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPenalties_CellClick);
            // 
            // tbSearchPenalty
            // 
            this.tbSearchPenalty.Location = new System.Drawing.Point(418, 99);
            this.tbSearchPenalty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSearchPenalty.Name = "tbSearchPenalty";
            this.tbSearchPenalty.Size = new System.Drawing.Size(242, 20);
            this.tbSearchPenalty.TabIndex = 14;
            this.tbSearchPenalty.TextChanged += new System.EventHandler(this.tbSearchPenalty_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(374, 102);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Search:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(416, 54);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(237, 18);
            this.label13.TabIndex = 34;
            this.label13.Text = "PENALTIES AND VIOLATIONS";
            // 
            // PenaltiesRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1021, 894);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbSearchPenalty);
            this.Controls.Add(this.dgvPenalties);
            this.Controls.Add(this.PanelCRUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PenaltiesRecords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Violations and Penalties";
            this.Load += new System.EventHandler(this.PenaltiesRecords_Load);
            this.PanelCRUD.ResumeLayout(false);
            this.PanelCRUD.PerformLayout();
            this.panelPayment.ResumeLayout(false);
            this.panelPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenalties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelCRUD;
        private System.Windows.Forms.DataGridView dgvPenalties;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbContact;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbStudentName;
        private System.Windows.Forms.TextBox tbIDnum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbViolation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpPenaltyDate;
        private System.Windows.Forms.TextBox tbAmtPayed;
        private System.Windows.Forms.Label lblAmntPayed;
        private System.Windows.Forms.TextBox tbAmtToBe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbSearchPenalty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbTransact;
        private System.Windows.Forms.ComboBox cbCondition;
        private System.Windows.Forms.Panel panelPayment;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblRemainingBalance;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label9;
    }
}