using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_Management_System__Capstone_Project_
{
    public partial class TransparentForm : Form
    {
        public TransparentForm()
        {
            InitializeComponent();

            //this.ShowInTaskbar = false;
            //this.Opacity = 0.6;

            //this.Load += TransparentForm_Load;
        }
        private void TransparentForm_Load(object sender, EventArgs e)
        {      
            //this.Enabled = false; 
        }
    }
}
