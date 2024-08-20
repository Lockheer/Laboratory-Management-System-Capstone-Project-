namespace Laboratory_Management_System__Capstone_Project_
{
    partial class RegistrationForm
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
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbMiddleName = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lbFN = new System.Windows.Forms.Label();
            this.lbLN = new System.Windows.Forms.Label();
            this.lbMN = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblReminder = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbConfirmPass = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupGender = new System.Windows.Forms.GroupBox();
            this.radiobtnFemale = new System.Windows.Forms.RadioButton();
            this.radiobtnMale = new System.Windows.Forms.RadioButton();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lbIDnum = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lbContact = new System.Windows.Forms.Label();
            this.tbContactNumber = new System.Windows.Forms.TextBox();
            this.lblBirth = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.lblShowPass = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.groupGender.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(154, 92);
            this.tbFirstName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(143, 20);
            this.tbFirstName.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(154, 130);
            this.tbLastName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(143, 20);
            this.tbLastName.TabIndex = 2;
            // 
            // tbMiddleName
            // 
            this.tbMiddleName.Location = new System.Drawing.Point(154, 167);
            this.tbMiddleName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbMiddleName.Name = "tbMiddleName";
            this.tbMiddleName.Size = new System.Drawing.Size(76, 20);
            this.tbMiddleName.TabIndex = 3;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(556, 92);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(115, 20);
            this.tbUsername.TabIndex = 5;
            this.tbUsername.Enter += new System.EventHandler(this.textBox5_Enter);
            this.tbUsername.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // lbFN
            // 
            this.lbFN.AutoSize = true;
            this.lbFN.Location = new System.Drawing.Point(80, 97);
            this.lbFN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFN.Name = "lbFN";
            this.lbFN.Size = new System.Drawing.Size(60, 13);
            this.lbFN.TabIndex = 7;
            this.lbFN.Text = "First Name:";
            // 
            // lbLN
            // 
            this.lbLN.AutoSize = true;
            this.lbLN.Location = new System.Drawing.Point(80, 130);
            this.lbLN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLN.Name = "lbLN";
            this.lbLN.Size = new System.Drawing.Size(61, 13);
            this.lbLN.TabIndex = 8;
            this.lbLN.Text = "Last Name:";
            // 
            // lbMN
            // 
            this.lbMN.AutoSize = true;
            this.lbMN.Location = new System.Drawing.Point(80, 169);
            this.lbMN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMN.Name = "lbMN";
            this.lbMN.Size = new System.Drawing.Size(72, 13);
            this.lbMN.TabIndex = 9;
            this.lbMN.Text = "Middle Name:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(4, 78);
            this.lblGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 10;
            this.lblGender.Text = "Gender:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(481, 97);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 11;
            this.lblUsername.Text = "Username:";
            // 
            // lblReminder
            // 
            this.lblReminder.AutoSize = true;
            this.lblReminder.Location = new System.Drawing.Point(481, 121);
            this.lblReminder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReminder.Name = "lblReminder";
            this.lblReminder.Size = new System.Drawing.Size(259, 13);
            this.lblReminder.TabIndex = 12;
            this.lblReminder.Text = "Take Note: Your ID Number will be your USERNAME";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(501, 162);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "Password:";
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(483, 193);
            this.lblConfirm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(94, 13);
            this.lblConfirm.TabIndex = 14;
            this.lblConfirm.Text = "Confirm Password:";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(576, 162);
            this.tbPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(95, 20);
            this.tbPass.TabIndex = 15;
            this.tbPass.UseSystemPasswordChar = true;
            // 
            // tbConfirmPass
            // 
            this.tbConfirmPass.Location = new System.Drawing.Point(576, 190);
            this.tbConfirmPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbConfirmPass.Name = "tbConfirmPass";
            this.tbConfirmPass.Size = new System.Drawing.Size(95, 20);
            this.tbConfirmPass.TabIndex = 16;
            this.tbConfirmPass.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(598, 375);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(106, 37);
            this.btnRegister.TabIndex = 17;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(598, 417);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(106, 36);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(598, 457);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(106, 36);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Back to Login";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // groupGender
            // 
            this.groupGender.Controls.Add(this.radiobtnFemale);
            this.groupGender.Controls.Add(this.radiobtnMale);
            this.groupGender.Controls.Add(this.lblGender);
            this.groupGender.Location = new System.Drawing.Point(41, 348);
            this.groupGender.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupGender.Name = "groupGender";
            this.groupGender.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupGender.Size = new System.Drawing.Size(180, 102);
            this.groupGender.TabIndex = 20;
            this.groupGender.TabStop = false;
            this.groupGender.Text = "Gender:";
            // 
            // radiobtnFemale
            // 
            this.radiobtnFemale.AutoSize = true;
            this.radiobtnFemale.Location = new System.Drawing.Point(4, 38);
            this.radiobtnFemale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radiobtnFemale.Name = "radiobtnFemale";
            this.radiobtnFemale.Size = new System.Drawing.Size(59, 17);
            this.radiobtnFemale.TabIndex = 1;
            this.radiobtnFemale.TabStop = true;
            this.radiobtnFemale.Text = "Female";
            this.radiobtnFemale.UseVisualStyleBackColor = true;
            this.radiobtnFemale.CheckedChanged += new System.EventHandler(this.radiobtnFemale_CheckedChanged);
            // 
            // radiobtnMale
            // 
            this.radiobtnMale.AutoSize = true;
            this.radiobtnMale.Location = new System.Drawing.Point(4, 17);
            this.radiobtnMale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radiobtnMale.Name = "radiobtnMale";
            this.radiobtnMale.Size = new System.Drawing.Size(48, 17);
            this.radiobtnMale.TabIndex = 0;
            this.radiobtnMale.TabStop = true;
            this.radiobtnMale.Text = "Male";
            this.radiobtnMale.UseVisualStyleBackColor = true;
            this.radiobtnMale.CheckedChanged += new System.EventHandler(this.radiobtnMale_CheckedChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(115, 198);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 21;
            this.lblEmail.Text = "Email:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(152, 198);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(145, 20);
            this.tbEmail.TabIndex = 22;
            // 
            // lbIDnum
            // 
            this.lbIDnum.AutoSize = true;
            this.lbIDnum.Location = new System.Drawing.Point(92, 228);
            this.lbIDnum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbIDnum.Name = "lbIDnum";
            this.lbIDnum.Size = new System.Drawing.Size(61, 13);
            this.lbIDnum.TabIndex = 23;
            this.lbIDnum.Text = "ID Number:";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(152, 228);
            this.tbID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(76, 20);
            this.tbID.TabIndex = 24;
            // 
            // lbContact
            // 
            this.lbContact.AutoSize = true;
            this.lbContact.Location = new System.Drawing.Point(68, 263);
            this.lbContact.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbContact.Name = "lbContact";
            this.lbContact.Size = new System.Drawing.Size(87, 13);
            this.lbContact.TabIndex = 25;
            this.lbContact.Text = "Contact Number:";
            // 
            // tbContactNumber
            // 
            this.tbContactNumber.Location = new System.Drawing.Point(152, 263);
            this.tbContactNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbContactNumber.Name = "tbContactNumber";
            this.tbContactNumber.Size = new System.Drawing.Size(108, 20);
            this.tbContactNumber.TabIndex = 26;
            this.tbContactNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbContactNumber_KeyPress);
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(68, 306);
            this.lblBirth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(69, 13);
            this.lblBirth.TabIndex = 27;
            this.lblBirth.Text = "Date of Birth:";
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.Location = new System.Drawing.Point(152, 302);
            this.dtpBirthdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(186, 20);
            this.dtpBirthdate.TabIndex = 30;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(41, 457);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(106, 37);
            this.btnPrevious.TabIndex = 31;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(152, 457);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(106, 37);
            this.btnNext.TabIndex = 32;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 32);
            this.panel1.TabIndex = 33;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMinimize.FlatAppearance.BorderSize = 2;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.Black;
            this.btnMinimize.Location = new System.Drawing.Point(731, -1);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(38, 37);
            this.btnMinimize.TabIndex = 21;
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
            this.btnExit.Location = new System.Drawing.Point(775, -1);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(38, 37);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // chkShowPass
            // 
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Location = new System.Drawing.Point(674, 162);
            this.chkShowPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(15, 14);
            this.chkShowPass.TabIndex = 35;
            this.chkShowPass.UseVisualStyleBackColor = true;
            this.chkShowPass.CheckedChanged += new System.EventHandler(this.chkShowPass_CheckedChanged);
            // 
            // lblShowPass
            // 
            this.lblShowPass.AutoSize = true;
            this.lblShowPass.Location = new System.Drawing.Point(692, 162);
            this.lblShowPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShowPass.Name = "lblShowPass";
            this.lblShowPass.Size = new System.Drawing.Size(83, 13);
            this.lblShowPass.TabIndex = 36;
            this.lblShowPass.Text = "Show Password";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(576, 222);
            this.cbRole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(92, 21);
            this.cbRole.TabIndex = 37;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(521, 225);
            this.lblRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(51, 13);
            this.lblRole.TabIndex = 38;
            this.lblRole.Text = "Set Role:";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 526);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.lblShowPass);
            this.Controls.Add(this.chkShowPass);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.dtpBirthdate);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.tbContactNumber);
            this.Controls.Add(this.lbContact);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.lbIDnum);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.groupGender);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.tbConfirmPass);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblReminder);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lbMN);
            this.Controls.Add(this.lbLN);
            this.Controls.Add(this.lbFN);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.tbMiddleName);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbFirstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegistrationForm";
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.groupGender.ResumeLayout(false);
            this.groupGender.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbMiddleName;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lbFN;
        private System.Windows.Forms.Label lbLN;
        private System.Windows.Forms.Label lbMN;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblReminder;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbConfirmPass;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupGender;
        private System.Windows.Forms.RadioButton radiobtnFemale;
        private System.Windows.Forms.RadioButton radiobtnMale;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lbIDnum;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lbContact;
        private System.Windows.Forms.TextBox tbContactNumber;
        private System.Windows.Forms.Label lblBirth;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.Label lblShowPass;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label lblRole;
    }
}