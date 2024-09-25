namespace Laboratory_Management_System__Capstone_Project_
{
    partial class Form1
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
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.CbShowPass = new System.Windows.Forms.CheckBox();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lnklblChangePass = new System.Windows.Forms.LinkLabel();
            this.lnkLblRegister = new System.Windows.Forms.LinkLabel();
            this.lblErrorHandler = new System.Windows.Forms.Label();
            this.lblUsernameHandler = new System.Windows.Forms.Label();
            this.lblPasswordHandler = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.SystemColors.Window;
            this.tbUsername.ForeColor = System.Drawing.Color.Gray;
            this.tbUsername.Location = new System.Drawing.Point(151, 226);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(2);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(141, 20);
            this.tbUsername.TabIndex = 1;
            this.tbUsername.Text = "Username";
            this.tbUsername.Enter += new System.EventHandler(this.tbUsername_Enter);
            this.tbUsername.Leave += new System.EventHandler(this.tbUsername_Leave);
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.SystemColors.Window;
            this.tbPassword.ForeColor = System.Drawing.Color.Gray;
            this.tbPassword.Location = new System.Drawing.Point(135, 316);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(255, 20);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.Text = "Password";
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            this.tbPassword.Enter += new System.EventHandler(this.tbPassword_Enter);
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            this.tbPassword.Leave += new System.EventHandler(this.tbPassword_Leave);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(21)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(146, 493);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(146, 34);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // CbShowPass
            // 
            this.CbShowPass.AutoSize = true;
            this.CbShowPass.BackColor = System.Drawing.Color.Transparent;
            this.CbShowPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.CbShowPass.Location = new System.Drawing.Point(69, 404);
            this.CbShowPass.Margin = new System.Windows.Forms.Padding(2);
            this.CbShowPass.Name = "CbShowPass";
            this.CbShowPass.Size = new System.Drawing.Size(102, 17);
            this.CbShowPass.TabIndex = 10;
            this.CbShowPass.Text = "Show Password";
            this.CbShowPass.UseVisualStyleBackColor = false;
            this.CbShowPass.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.ForeColor = System.Drawing.Color.White;
            this.btnCloseForm.Location = new System.Drawing.Point(1100, 26);
            this.btnCloseForm.Margin = new System.Windows.Forms.Padding(2);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(32, 32);
            this.btnCloseForm.TabIndex = 11;
            this.btnCloseForm.Text = "X";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.button3_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Bahnschrift Condensed", 15F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1054, 26);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 31);
            this.button3.TabIndex = 14;
            this.button3.Text = "___";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.bcc_logo_circle;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(148, -72);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lnklblChangePass
            // 
            this.lnklblChangePass.AutoSize = true;
            this.lnklblChangePass.BackColor = System.Drawing.Color.Transparent;
            this.lnklblChangePass.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.lnklblChangePass.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnklblChangePass.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.lnklblChangePass.Location = new System.Drawing.Point(221, 404);
            this.lnklblChangePass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnklblChangePass.Name = "lnklblChangePass";
            this.lnklblChangePass.Size = new System.Drawing.Size(140, 19);
            this.lnklblChangePass.TabIndex = 14;
            this.lnklblChangePass.TabStop = true;
            this.lnklblChangePass.Text = "Forgot Password?";
            this.lnklblChangePass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblChangePass_LinkClicked);
            // 
            // lnkLblRegister
            // 
            this.lnkLblRegister.AutoSize = true;
            this.lnkLblRegister.BackColor = System.Drawing.Color.Transparent;
            this.lnkLblRegister.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.lnkLblRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkLblRegister.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(21)))));
            this.lnkLblRegister.Location = new System.Drawing.Point(645, 811);
            this.lnkLblRegister.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkLblRegister.Name = "lnkLblRegister";
            this.lnkLblRegister.Size = new System.Drawing.Size(70, 19);
            this.lnkLblRegister.TabIndex = 15;
            this.lnkLblRegister.TabStop = true;
            this.lnkLblRegister.Text = "Register";
            this.lnkLblRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblRegister_LinkClicked);
            // 
            // lblErrorHandler
            // 
            this.lblErrorHandler.AutoSize = true;
            this.lblErrorHandler.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorHandler.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.lblErrorHandler.ForeColor = System.Drawing.Color.Red;
            this.lblErrorHandler.Location = new System.Drawing.Point(147, 114);
            this.lblErrorHandler.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorHandler.Name = "lblErrorHandler";
            this.lblErrorHandler.Size = new System.Drawing.Size(366, 19);
            this.lblErrorHandler.TabIndex = 16;
            this.lblErrorHandler.Text = "The username or password provided is incorrect.";
            // 
            // lblUsernameHandler
            // 
            this.lblUsernameHandler.AutoSize = true;
            this.lblUsernameHandler.BackColor = System.Drawing.Color.Transparent;
            this.lblUsernameHandler.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.lblUsernameHandler.ForeColor = System.Drawing.Color.Red;
            this.lblUsernameHandler.Location = new System.Drawing.Point(169, 258);
            this.lblUsernameHandler.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsernameHandler.Name = "lblUsernameHandler";
            this.lblUsernameHandler.Size = new System.Drawing.Size(221, 19);
            this.lblUsernameHandler.TabIndex = 17;
            this.lblUsernameHandler.Text = "Please enter your username:";
            // 
            // lblPasswordHandler
            // 
            this.lblPasswordHandler.AutoSize = true;
            this.lblPasswordHandler.BackColor = System.Drawing.Color.Transparent;
            this.lblPasswordHandler.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.lblPasswordHandler.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordHandler.Location = new System.Drawing.Point(184, 352);
            this.lblPasswordHandler.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPasswordHandler.Name = "lblPasswordHandler";
            this.lblPasswordHandler.Size = new System.Drawing.Size(206, 19);
            this.lblPasswordHandler.TabIndex = 18;
            this.lblPasswordHandler.Text = "Please enter your pasword";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(376, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 33);
            this.label3.TabIndex = 19;
            this.label3.Text = "LABORATORY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiLight", 12F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(513, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "COLLEGE OF ENGINEERING";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(21)))));
            this.label5.Location = new System.Drawing.Point(471, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(339, 33);
            this.label5.TabIndex = 21;
            this.label5.Text = "           INVENTORY SYSTEM";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblPasswordHandler);
            this.panel1.Controls.Add(this.lblUsernameHandler);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblErrorHandler);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.CbShowPass);
            this.panel1.Controls.Add(this.lnklblChangePass);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.tbUsername);
            this.panel1.Location = new System.Drawing.Point(382, 209);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 566);
            this.panel1.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(119, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label7.Location = new System.Drawing.Point(47, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(352, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "Welcome, please enter your details to proceed.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Bahnschrift", 25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label9.Location = new System.Drawing.Point(163, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 41);
            this.label9.TabIndex = 19;
            this.label9.Text = "LOGIN";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.bcc_logo_circle;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(530, 137);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(144, 144);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(456, 811);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = "Don\'t have an account?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label2.Location = new System.Drawing.Point(26, 214);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label1.Location = new System.Drawing.Point(26, 317);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "Password:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(109, 292);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 25);
            this.label10.TabIndex = 19;
            this.label10.Text = "*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.bg_main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1153, 865);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lnkLblRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox CbShowPass;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel lnklblChangePass;
        private System.Windows.Forms.LinkLabel lnkLblRegister;
        private System.Windows.Forms.Label lblErrorHandler;
        private System.Windows.Forms.Label lblUsernameHandler;
        private System.Windows.Forms.Label lblPasswordHandler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
    }
}

