using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_Management_System__Capstone_Project_
{
    public static class UIHelper
    {   
        public static void SetRoundedCorners(Control control, int radius)
        {
            control.Paint += (sender, e) =>
            {
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.StartFigure();
                path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
                path.AddArc(new Rectangle(control.Width - radius, 0, radius, radius), 270, 90);
                path.AddArc(new Rectangle(control.Width - radius, control.Height - radius, radius, radius), 0, 90);
                path.AddArc(new Rectangle(0, control.Height - radius, radius, radius), 90, 90);
                path.CloseFigure();

                control.Region = new Region(path);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            };
        }


        public static void SetGradientBackground(Control control, Color color1, Color color2, LinearGradientMode gradientMode)
        {
            control.Paint += (sender, e) =>
            {            
                using (LinearGradientBrush brush = new LinearGradientBrush(control.ClientRectangle, color1, color2, gradientMode))
                {
                    e.Graphics.FillRectangle(brush, control.ClientRectangle);
                }
            };

            control.Invalidate();
        }


        public static void SetShadow(Control control)
        {
            Panel shadowPanel = new Panel();

            shadowPanel.Size = new Size(control.Width, 10); 
            shadowPanel.Location = new Point(control.Left, control.Bottom); 
            shadowPanel.BackColor = Color.FromArgb(50, 0, 0, 0); // Semi-transparent black for shadow effect


            control.Parent.Controls.Add(shadowPanel);


            //int shadowHeight = 10; 

            //for (int i = 0; i < shadowHeight; i++)
            //{
            //    Panel shadowPanel = new Panel();
            //    shadowPanel.Size = new Size(control.Width, 1); 
            //    shadowPanel.Location = new Point(control.Left, control.Bottom + i);

            //    // Gradually reduce opacity for each panel to create a soft shadow effect
            //    int opacity = (int)(80 * (1 - (i / (float)shadowHeight)));
            //    shadowPanel.BackColor = Color.FromArgb(opacity, 0, 0, 0); // Semi-transparent black

            //    control.Parent.Controls.Add(shadowPanel);
            //}
        }
    }
}
