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
            this.lblHint = new System.Windows.Forms.Label();
            this.pnelHeader = new System.Windows.Forms.Panel();
            this.pnelControlBox = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lnklblChangePass = new System.Windows.Forms.LinkLabel();
            this.lnkLblRegister = new System.Windows.Forms.LinkLabel();
            this.lblErrorHandler = new System.Windows.Forms.Label();
            this.lblUsernameHandler = new System.Windows.Forms.Label();
            this.lblPasswordHandler = new System.Windows.Forms.Label();
            this.pnelHeader.SuspendLayout();
            this.pnelControlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.SystemColors.Window;
            this.tbUsername.ForeColor = System.Drawing.Color.Gray;
            this.tbUsername.Location = new System.Drawing.Point(172, 242);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.tbPassword.Location = new System.Drawing.Point(172, 340);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(141, 20);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.Text = "Password";
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            this.tbPassword.Enter += new System.EventHandler(this.tbPassword_Enter);
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            this.tbPassword.Leave += new System.EventHandler(this.tbPassword_Leave);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(172, 437);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(146, 34);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(202, 174);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "WELCOME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(154, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "College Of Engineering";
            // 
            // CbShowPass
            // 
            this.CbShowPass.AutoSize = true;
            this.CbShowPass.ForeColor = System.Drawing.Color.White;
            this.CbShowPass.Location = new System.Drawing.Point(172, 363);
            this.CbShowPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CbShowPass.Name = "CbShowPass";
            this.CbShowPass.Size = new System.Drawing.Size(102, 17);
            this.CbShowPass.TabIndex = 10;
            this.CbShowPass.Text = "Show Password";
            this.CbShowPass.UseVisualStyleBackColor = true;
            this.CbShowPass.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.ForeColor = System.Drawing.Color.White;
            this.btnCloseForm.Location = new System.Drawing.Point(73, 0);
            this.btnCloseForm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(32, 31);
            this.btnCloseForm.TabIndex = 11;
            this.btnCloseForm.Text = "X";
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.ForeColor = System.Drawing.Color.White;
            this.lblHint.Location = new System.Drawing.Point(169, 273);
            this.lblHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(267, 15);
            this.lblHint.TabIndex = 12;
            this.lblHint.Text = "Hint: your ID number is the username.";
            // 
            // pnelHeader
            // 
            this.pnelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnelHeader.Controls.Add(this.pnelControlBox);
            this.pnelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnelHeader.Location = new System.Drawing.Point(0, 0);
            this.pnelHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnelHeader.Name = "pnelHeader";
            this.pnelHeader.Size = new System.Drawing.Size(484, 28);
            this.pnelHeader.TabIndex = 13;
            // 
            // pnelControlBox
            // 
            this.pnelControlBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pnelControlBox.Controls.Add(this.button3);
            this.pnelControlBox.Controls.Add(this.btnCloseForm);
            this.pnelControlBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnelControlBox.Location = new System.Drawing.Point(380, 0);
            this.pnelControlBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnelControlBox.Name = "pnelControlBox";
            this.pnelControlBox.Size = new System.Drawing.Size(104, 28);
            this.pnelControlBox.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gainsboro;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(37, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 31);
            this.button3.TabIndex = 14;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(142, 338);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(140, 232);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(200, 77);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lnklblChangePass
            // 
            this.lnklblChangePass.AutoSize = true;
            this.lnklblChangePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblChangePass.Location = new System.Drawing.Point(255, 496);
            this.lnklblChangePass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnklblChangePass.Name = "lnklblChangePass";
            this.lnklblChangePass.Size = new System.Drawing.Size(114, 17);
            this.lnklblChangePass.TabIndex = 14;
            this.lnklblChangePass.TabStop = true;
            this.lnklblChangePass.Text = "Forgot Password";
            this.lnklblChangePass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblChangePass_LinkClicked);
            // 
            // lnkLblRegister
            // 
            this.lnkLblRegister.AutoSize = true;
            this.lnkLblRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLblRegister.LinkColor = System.Drawing.Color.White;
            this.lnkLblRegister.Location = new System.Drawing.Point(154, 496);
            this.lnkLblRegister.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkLblRegister.Name = "lnkLblRegister";
            this.lnkLblRegister.Size = new System.Drawing.Size(63, 18);
            this.lnkLblRegister.TabIndex = 15;
            this.lnkLblRegister.TabStop = true;
            this.lnkLblRegister.Text = "Register";
            this.lnkLblRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblRegister_LinkClicked);
            // 
            // lblErrorHandler
            // 
            this.lblErrorHandler.AutoSize = true;
            this.lblErrorHandler.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorHandler.ForeColor = System.Drawing.Color.White;
            this.lblErrorHandler.Location = new System.Drawing.Point(137, 405);
            this.lblErrorHandler.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorHandler.Name = "lblErrorHandler";
            this.lblErrorHandler.Size = new System.Drawing.Size(225, 15);
            this.lblErrorHandler.TabIndex = 16;
            this.lblErrorHandler.Text = "Incorrect Username or Password";
            // 
            // lblUsernameHandler
            // 
            this.lblUsernameHandler.AutoSize = true;
            this.lblUsernameHandler.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameHandler.ForeColor = System.Drawing.Color.White;
            this.lblUsernameHandler.Location = new System.Drawing.Point(169, 216);
            this.lblUsernameHandler.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsernameHandler.Name = "lblUsernameHandler";
            this.lblUsernameHandler.Size = new System.Drawing.Size(200, 15);
            this.lblUsernameHandler.TabIndex = 17;
            this.lblUsernameHandler.Text = "Please enter your username.";
            // 
            // lblPasswordHandler
            // 
            this.lblPasswordHandler.AutoSize = true;
            this.lblPasswordHandler.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordHandler.ForeColor = System.Drawing.Color.White;
            this.lblPasswordHandler.Location = new System.Drawing.Point(169, 314);
            this.lblPasswordHandler.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPasswordHandler.Name = "lblPasswordHandler";
            this.lblPasswordHandler.Size = new System.Drawing.Size(197, 15);
            this.lblPasswordHandler.TabIndex = 18;
            this.lblPasswordHandler.Text = "Please enter your password.\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(26)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(484, 547);
            this.Controls.Add(this.lblPasswordHandler);
            this.Controls.Add(this.lblUsernameHandler);
            this.Controls.Add(this.lblErrorHandler);
            this.Controls.Add(this.lnkLblRegister);
            this.Controls.Add(this.lnklblChangePass);
            this.Controls.Add(this.pnelHeader);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.CbShowPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnelHeader.ResumeLayout(false);
            this.pnelControlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Panel pnelHeader;
        private System.Windows.Forms.Panel pnelControlBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel lnklblChangePass;
        private System.Windows.Forms.LinkLabel lnkLblRegister;
        private System.Windows.Forms.Label lblErrorHandler;
        private System.Windows.Forms.Label lblUsernameHandler;
        private System.Windows.Forms.Label lblPasswordHandler;
    }
}

