using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class startup : Form
    {
        int seconds = 0;

        public startup()
        {
            InitializeComponent();

            UIHelper.SetRoundedCorners(this, 270);
        }

        private void startup_Load(object sender, EventArgs e)
        {
            seconds = 2;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCountDown.Text = seconds--.ToString();
            if (seconds < 0)
            {
                timer1.Stop();
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
            }
        }
    }
}
