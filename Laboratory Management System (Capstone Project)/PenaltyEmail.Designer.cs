namespace Laboratory_Management_System__Capstone_Project_
{
    partial class PenaltyEmail
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
            this.btnTransactDetails = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.tbMessageContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEmailRecipient = new System.Windows.Forms.TextBox();
            this.dgvViewPenaltyRecords = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPenaltyRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTransactDetails
            // 
            this.btnTransactDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTransactDetails.FlatAppearance.BorderSize = 0;
            this.btnTransactDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactDetails.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.btnTransactDetails.ForeColor = System.Drawing.Color.White;
            this.btnTransactDetails.Location = new System.Drawing.Point(35, 125);
            this.btnTransactDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTransactDetails.Name = "btnTransactDetails";
            this.btnTransactDetails.Size = new System.Drawing.Size(271, 32);
            this.btnTransactDetails.TabIndex = 14;
            this.btnTransactDetails.Text = "TRANSACTION DETAILS";
            this.btnTransactDetails.UseVisualStyleBackColor = false;
            this.btnTransactDetails.Click += new System.EventHandler(this.btnTransactDetails_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSendEmail.FlatAppearance.BorderSize = 0;
            this.btnSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendEmail.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.btnSendEmail.ForeColor = System.Drawing.Color.White;
            this.btnSendEmail.Location = new System.Drawing.Point(85, 437);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(245, 39);
            this.btnSendEmail.TabIndex = 13;
            this.btnSendEmail.Text = "SEND";
            this.btnSendEmail.UseVisualStyleBackColor = false;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // tbMessageContent
            // 
            this.tbMessageContent.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.tbMessageContent.Location = new System.Drawing.Point(64, 286);
            this.tbMessageContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbMessageContent.Multiline = true;
            this.tbMessageContent.Name = "tbMessageContent";
            this.tbMessageContent.Size = new System.Drawing.Size(242, 123);
            this.tbMessageContent.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label2.Location = new System.Drawing.Point(59, 265);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Message:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label1.Location = new System.Drawing.Point(59, 195);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Email Address:";
            // 
            // tbEmailRecipient
            // 
            this.tbEmailRecipient.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.tbEmailRecipient.Location = new System.Drawing.Point(63, 216);
            this.tbEmailRecipient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbEmailRecipient.Name = "tbEmailRecipient";
            this.tbEmailRecipient.Size = new System.Drawing.Size(242, 27);
            this.tbEmailRecipient.TabIndex = 9;
            // 
            // dgvViewPenaltyRecords
            // 
            this.dgvViewPenaltyRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewPenaltyRecords.Location = new System.Drawing.Point(412, 125);
            this.dgvViewPenaltyRecords.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvViewPenaltyRecords.Name = "dgvViewPenaltyRecords";
            this.dgvViewPenaltyRecords.RowHeadersWidth = 51;
            this.dgvViewPenaltyRecords.RowTemplate.Height = 24;
            this.dgvViewPenaltyRecords.Size = new System.Drawing.Size(598, 351);
            this.dgvViewPenaltyRecords.TabIndex = 16;
            this.dgvViewPenaltyRecords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewPenaltyRecords_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label3.Location = new System.Drawing.Point(195, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(649, 41);
            this.label3.TabIndex = 17;
            this.label3.Text = "Send a Violation or Penalty Update Notice";
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMinimize.FlatAppearance.BorderSize = 2;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.Black;
            this.btnMinimize.Location = new System.Drawing.Point(911, 12);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(38, 37);
            this.btnMinimize.TabIndex = 19;
            this.btnMinimize.Text = "___";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExit.FlatAppearance.BorderSize = 2;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(970, 11);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(38, 37);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(182, 176);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(140, 265);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "*";
            // 
            // PenaltyEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 494);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvViewPenaltyRecords);
            this.Controls.Add(this.btnTransactDetails);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.tbMessageContent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEmailRecipient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PenaltyEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send an Email";
            this.Load += new System.EventHandler(this.PenaltyEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPenaltyRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTransactDetails;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.TextBox tbMessageContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEmailRecipient;
        private System.Windows.Forms.DataGridView dgvViewPenaltyRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}