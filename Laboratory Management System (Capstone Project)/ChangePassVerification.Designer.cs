﻿namespace Laboratory_Management_System__Capstone_Project_
{
    partial class ChangePassVerification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassVerification));
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbPin = new System.Windows.Forms.TextBox();
            this.btnSendPIN = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lnklblBack = new System.Windows.Forms.LinkLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbEmail
            // 
            this.tbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEmail.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.tbEmail.Location = new System.Drawing.Point(174, 248);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(321, 27);
            this.tbEmail.TabIndex = 0;
            // 
            // tbPin
            // 
            this.tbPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPin.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.tbPin.Location = new System.Drawing.Point(355, 311);
            this.tbPin.Name = "tbPin";
            this.tbPin.Size = new System.Drawing.Size(140, 27);
            this.tbPin.TabIndex = 1;
            // 
            // btnSendPIN
            // 
            this.btnSendPIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(21)))));
            this.btnSendPIN.FlatAppearance.BorderSize = 0;
            this.btnSendPIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendPIN.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
            this.btnSendPIN.ForeColor = System.Drawing.Color.White;
            this.btnSendPIN.Location = new System.Drawing.Point(519, 241);
            this.btnSendPIN.Name = "btnSendPIN";
            this.btnSendPIN.Size = new System.Drawing.Size(155, 40);
            this.btnSendPIN.TabIndex = 2;
            this.btnSendPIN.Text = "SEND PIN";
            this.btnSendPIN.UseVisualStyleBackColor = false;
            this.btnSendPIN.Click += new System.EventHandler(this.btnSendPIN_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(151)))), ((int)(((byte)(47)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(519, 305);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(155, 40);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label1.Location = new System.Drawing.Point(142, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "PASSWORD VERIFICATION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label2.Location = new System.Drawing.Point(112, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(472, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Please enter your registered EMAIL ADDRESS to receive a PIN CODE.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label3.Location = new System.Drawing.Point(302, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "PIN:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(171, 375);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(356, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "NOTE: If not found, please check your spam messages)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label5.Location = new System.Drawing.Point(40, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Email Address:";
            // 
            // lnklblBack
            // 
            this.lnklblBack.AutoSize = true;
            this.lnklblBack.BackColor = System.Drawing.Color.Transparent;
            this.lnklblBack.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.lnklblBack.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnklblBack.LinkColor = System.Drawing.Color.White;
            this.lnklblBack.Location = new System.Drawing.Point(493, 734);
            this.lnklblBack.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnklblBack.Name = "lnklblBack";
            this.lnklblBack.Size = new System.Drawing.Size(107, 17);
            this.lnklblBack.TabIndex = 9;
            this.lnklblBack.TabStop = true;
            this.lnklblBack.Text = "BACK TO LOGIN";
            this.lnklblBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblBack_LinkClicked);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(460, 154);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(169, 169);
            this.pictureBox3.TabIndex = 28;
            this.pictureBox3.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(155, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 25);
            this.label10.TabIndex = 29;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(334, 309);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 25);
            this.label11.TabIndex = 29;
            this.label11.Text = "*";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.email_pic1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbEmail);
            this.panel1.Controls.Add(this.tbPin);
            this.panel1.Controls.Add(this.btnSendPIN);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(190, 248);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 422);
            this.panel1.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(325, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 33);
            this.label6.TabIndex = 31;
            this.label6.Text = "LABORATORY";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Bahnschrift SemiLight", 12F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(441, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 19);
            this.label7.TabIndex = 32;
            this.label7.Text = "COLLEGE OF ENGINEERING";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(21)))));
            this.label8.Location = new System.Drawing.Point(420, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(339, 33);
            this.label8.TabIndex = 33;
            this.label8.Text = "           INVENTORY SYSTEM";
            // 
            // ChangePassVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.bg_main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1053, 790);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lnklblBack);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePassVerification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Verification";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbPin;
        private System.Windows.Forms.Button btnSendPIN;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lnklblBack;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}