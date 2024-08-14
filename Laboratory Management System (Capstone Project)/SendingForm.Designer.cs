namespace Laboratory_Management_System__Capstone_Project_
{
    partial class SendingForm
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
            this.pgbSending = new System.Windows.Forms.ProgressBar();
            this.lblSending = new System.Windows.Forms.Label();
            this.tmrSending = new System.Windows.Forms.Timer(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pgbSending
            // 
            this.pgbSending.ForeColor = System.Drawing.Color.Lime;
            this.pgbSending.Location = new System.Drawing.Point(58, 52);
            this.pgbSending.Margin = new System.Windows.Forms.Padding(2);
            this.pgbSending.Name = "pgbSending";
            this.pgbSending.Size = new System.Drawing.Size(284, 35);
            this.pgbSending.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbSending.TabIndex = 0;
            // 
            // lblSending
            // 
            this.lblSending.AutoSize = true;
            this.lblSending.Location = new System.Drawing.Point(169, 20);
            this.lblSending.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSending.Name = "lblSending";
            this.lblSending.Size = new System.Drawing.Size(69, 16);
            this.lblSending.TabIndex = 1;
            this.lblSending.Text = "Sending....";
            // 
            // tmrSending
            // 
            this.tmrSending.Enabled = true;
            this.tmrSending.Interval = 16;
            this.tmrSending.Tick += new System.EventHandler(this.tmrSending_Tick);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(154, 52);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(91, 35);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // SendingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(408, 129);
            this.ControlBox = false;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblSending);
            this.Controls.Add(this.pgbSending);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendingForm";
    
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbSending;
        private System.Windows.Forms.Label lblSending;
        private System.Windows.Forms.Timer tmrSending;
        private System.Windows.Forms.Button btnOk;
    }
}