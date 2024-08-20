namespace Laboratory_Management_System__Capstone_Project_
{
    partial class ChangePasswordForm
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
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.chckSHowPass = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Location = new System.Drawing.Point(204, 66);
            this.tbNewPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(220, 20);
            this.tbNewPassword.TabIndex = 1;
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(204, 102);
            this.tbConfirmPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(220, 20);
            this.tbConfirmPassword.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "New Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirm Password:";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChangePassword.FlatAppearance.BorderSize = 50;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.Location = new System.Drawing.Point(204, 161);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(166, 38);
            this.btnChangePassword.TabIndex = 6;
            this.btnChangePassword.Text = "CHANGE PASSWORD";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // chckSHowPass
            // 
            this.chckSHowPass.AutoSize = true;
            this.chckSHowPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckSHowPass.Location = new System.Drawing.Point(429, 69);
            this.chckSHowPass.Name = "chckSHowPass";
            this.chckSHowPass.Size = new System.Drawing.Size(115, 17);
            this.chckSHowPass.TabIndex = 7;
            this.chckSHowPass.Text = "Show Password";
            this.chckSHowPass.UseVisualStyleBackColor = true;
            this.chckSHowPass.CheckedChanged += new System.EventHandler(this.chckSHowPass_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Time to Change your Password";
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 210);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chckSHowPass);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.tbNewPassword);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.CheckBox chckSHowPass;
        private System.Windows.Forms.Label label1;
    }
}