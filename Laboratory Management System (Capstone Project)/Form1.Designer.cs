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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbShowPass = new System.Windows.Forms.CheckBox();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lnklblChangePass = new System.Windows.Forms.LinkLabel();
            this.lnkLblRegister = new System.Windows.Forms.LinkLabel();
            this.lblErrorHandler = new System.Windows.Forms.Label();
            this.lblUsernameHandler = new System.Windows.Forms.Label();
            this.lblPasswordHandler = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.SystemColors.Window;
            this.tbUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUsername.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold);
            this.tbUsername.ForeColor = System.Drawing.Color.Gray;
            this.tbUsername.Location = new System.Drawing.Point(119, 225);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(2);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(238, 32);
            this.tbUsername.TabIndex = 1;
            this.tbUsername.Text = "Username";
            this.tbUsername.Enter += new System.EventHandler(this.tbUsername_Enter);
            this.tbUsername.Leave += new System.EventHandler(this.tbUsername_Leave);
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.SystemColors.Window;
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold);
            this.tbPassword.ForeColor = System.Drawing.Color.Gray;
            this.tbPassword.Location = new System.Drawing.Point(119, 311);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(238, 32);
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
            this.btnLogin.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(114, 438);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(206, 34);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label1.Location = new System.Drawing.Point(40, 139);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Welcome, please enter your details to proceed.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 30F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label2.Location = new System.Drawing.Point(151, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 48);
            this.label2.TabIndex = 8;
            this.label2.Text = "LOGIN";
            // 
            // CbShowPass
            // 
            this.CbShowPass.AutoSize = true;
            this.CbShowPass.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.CbShowPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.CbShowPass.Location = new System.Drawing.Point(75, 384);
            this.CbShowPass.Margin = new System.Windows.Forms.Padding(2);
            this.CbShowPass.Name = "CbShowPass";
            this.CbShowPass.Size = new System.Drawing.Size(144, 23);
            this.CbShowPass.TabIndex = 10;
            this.CbShowPass.Text = "Show Password";
            this.CbShowPass.UseVisualStyleBackColor = true;
            this.CbShowPass.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.Red;
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.ForeColor = System.Drawing.Color.White;
            this.btnCloseForm.Location = new System.Drawing.Point(1100, 30);
            this.btnCloseForm.Margin = new System.Windows.Forms.Padding(2);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(32, 31);
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
            this.button3.Location = new System.Drawing.Point(1064, 30);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 31);
            this.button3.TabIndex = 14;
            this.button3.Text = "___";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            // 
            // lnklblChangePass
            // 
            this.lnklblChangePass.AutoSize = true;
            this.lnklblChangePass.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11F);
            this.lnklblChangePass.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnklblChangePass.Location = new System.Drawing.Point(159, 490);
            this.lnklblChangePass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnklblChangePass.Name = "lnklblChangePass";
            this.lnklblChangePass.Size = new System.Drawing.Size(128, 18);
            this.lnklblChangePass.TabIndex = 14;
            this.lnklblChangePass.TabStop = true;
            this.lnklblChangePass.Text = "Forgot Password?";
            this.lnklblChangePass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblChangePass_LinkClicked);
            // 
            // lnkLblRegister
            // 
            this.lnkLblRegister.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(21)))));
            this.lnkLblRegister.AutoSize = true;
            this.lnkLblRegister.BackColor = System.Drawing.Color.Transparent;
            this.lnkLblRegister.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lnkLblRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkLblRegister.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(21)))));
            this.lnkLblRegister.Location = new System.Drawing.Point(635, 795);
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
            this.lblErrorHandler.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Italic);
            this.lblErrorHandler.ForeColor = System.Drawing.Color.Red;
            this.lblErrorHandler.Location = new System.Drawing.Point(41, 167);
            this.lblErrorHandler.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorHandler.Name = "lblErrorHandler";
            this.lblErrorHandler.Size = new System.Drawing.Size(334, 18);
            this.lblErrorHandler.TabIndex = 16;
            this.lblErrorHandler.Text = "The username or password provided is incorrect.";
            // 
            // lblUsernameHandler
            // 
            this.lblUsernameHandler.AutoSize = true;
            this.lblUsernameHandler.BackColor = System.Drawing.Color.Transparent;
            this.lblUsernameHandler.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Italic);
            this.lblUsernameHandler.ForeColor = System.Drawing.Color.Red;
            this.lblUsernameHandler.Location = new System.Drawing.Point(151, 259);
            this.lblUsernameHandler.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsernameHandler.Name = "lblUsernameHandler";
            this.lblUsernameHandler.Size = new System.Drawing.Size(199, 18);
            this.lblUsernameHandler.TabIndex = 17;
            this.lblUsernameHandler.Text = "Please enter your username.";
            // 
            // lblPasswordHandler
            // 
            this.lblPasswordHandler.AutoSize = true;
            this.lblPasswordHandler.BackColor = System.Drawing.Color.Transparent;
            this.lblPasswordHandler.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Italic);
            this.lblPasswordHandler.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordHandler.Location = new System.Drawing.Point(160, 345);
            this.lblPasswordHandler.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPasswordHandler.Name = "lblPasswordHandler";
            this.lblPasswordHandler.Size = new System.Drawing.Size(198, 18);
            this.lblPasswordHandler.TabIndex = 18;
            this.lblPasswordHandler.Text = "Please enter your password.\r\n";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.tbUsername);
            this.panel1.Controls.Add(this.lblPasswordHandler);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.lblUsernameHandler);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.lblErrorHandler);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.lnklblChangePass);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CbShowPass);
            this.panel1.Location = new System.Drawing.Point(362, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 538);
            this.panel1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(150, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(153, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label8.Location = new System.Drawing.Point(71, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 19);
            this.label8.TabIndex = 20;
            this.label8.Text = "Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(175)))));
            this.label9.Location = new System.Drawing.Point(71, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 19);
            this.label9.TabIndex = 19;
            this.label9.Text = "Username:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(139, -73);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.pass_lock;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(75, 311);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.admin_icon;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(75, 225);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(372, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 33);
            this.label3.TabIndex = 22;
            this.label3.Text = "LABORATORY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiLight", 12F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(478, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "COLLEGE OF ENGINEERING";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(21)))));
            this.label5.Location = new System.Drawing.Point(467, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(339, 33);
            this.label5.TabIndex = 24;
            this.label5.Text = "           INVENTORY SYSTEM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(455, 795);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(175, 19);
            this.label10.TabIndex = 19;
            this.label10.Text = "Don\'t have an account?";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(501, 140);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(144, 144);
            this.pictureBox4.TabIndex = 25;
            this.pictureBox4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::Laboratory_Management_System__Capstone_Project_.Properties.Resources.bg_main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1153, 865);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lnkLblRegister);
            this.Controls.Add(this.pictureBox4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CbShowPass;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel lnklblChangePass;
        private System.Windows.Forms.LinkLabel lnkLblRegister;
        private System.Windows.Forms.Label lblErrorHandler;
        private System.Windows.Forms.Label lblUsernameHandler;
        private System.Windows.Forms.Label lblPasswordHandler;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}

