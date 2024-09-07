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
        // Method to set rounded corners on control (can be used for panels, datagridviews, etc.)
        public static void SetRoundedCorners(Control control, int radius)
        {
            control.Paint += (sender, e) =>
            {
                // Create a GraphicsPath for rounded corners
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.StartFigure();
                path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
                path.AddArc(new Rectangle(control.Width - radius, 0, radius, radius), 270, 90);
                path.AddArc(new Rectangle(control.Width - radius, control.Height - radius, radius, radius), 0, 90);
                path.AddArc(new Rectangle(0, control.Height - radius, radius, radius), 90, 90);
                path.CloseFigure();

                // Set the region for the control to the rounded rectangle
                control.Region = new Region(path);
            };
        }



        public static void SetGradientBackground(Panel panel, Color color1, Color color2, LinearGradientMode gradientMode)
        {
            // Attach the paint event to draw the gradient
            panel.Paint += (sender, e) =>
            {
                // Create a LinearGradientBrush with the specified colors and gradient mode
                using (LinearGradientBrush brush = new LinearGradientBrush(panel.ClientRectangle, color1, color2, gradientMode))
                {
                    // Fill the panel's background with the gradient
                    e.Graphics.FillRectangle(brush, panel.ClientRectangle);
                }
            };

            // Force the panel to repaint so the gradient is applied
            panel.Invalidate();
        }

        public static void SetRoundedButton(Button button, int borderRadius)
        {
            // Define the rounded button style
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90);
            path.AddArc(new Rectangle(button.Width - borderRadius, 0, borderRadius, borderRadius), 270, 90);
            path.AddArc(new Rectangle(button.Width - borderRadius, button.Height - borderRadius, borderRadius, borderRadius), 0, 90);
            path.AddArc(new Rectangle(0, button.Height - borderRadius, borderRadius, borderRadius), 90, 90);
            path.CloseFigure();

            // Set the region to the button (applies rounded corners)
            button.Region = new Region(path);

            // Ensure there is no border drawn if the user doesn't want it
            button.Paint += (sender, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            };
        }
    }
}
