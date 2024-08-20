namespace Laboratory_Management_System__Capstone_Project_
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
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbPin = new System.Windows.Forms.TextBox();
            this.btnSendPIN = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(208, 150);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(218, 20);
            this.tbEmail.TabIndex = 0;
            // 
            // tbPin
            // 
            this.tbPin.Location = new System.Drawing.Point(208, 246);
            this.tbPin.Name = "tbPin";
            this.tbPin.Size = new System.Drawing.Size(218, 20);
            this.tbPin.TabIndex = 1;
            // 
            // btnSendPIN
            // 
            this.btnSendPIN.Location = new System.Drawing.Point(450, 147);
            this.btnSendPIN.Name = "btnSendPIN";
            this.btnSendPIN.Size = new System.Drawing.Size(75, 23);
            this.btnSendPIN.TabIndex = 2;
            this.btnSendPIN.Text = "Send PIN";
            this.btnSendPIN.UseVisualStyleBackColor = true;
            this.btnSendPIN.Click += new System.EventHandler(this.btnSendPIN_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(450, 244);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ChangePassVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnSendPIN);
            this.Controls.Add(this.tbPin);
            this.Controls.Add(this.tbEmail);
            this.Name = "ChangePassVerification";
            this.Text = "ChangePassVerification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbPin;
        private System.Windows.Forms.Button btnSendPIN;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Timer timer1;
    }
}