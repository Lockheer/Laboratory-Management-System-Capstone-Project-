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
            Panel shadow = new Panel
            {
                Size = control.Size,
                Location = new Point(control.Left, control.Top + 6),
                BackColor = Color.FromArgb(50, 0, 0, 0)
            };

            int radius = 30;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // Top-left corner
            path.AddArc(shadow.Width - radius, 0, radius, radius, 270, 90); // Top-right corner
            path.AddArc(shadow.Width - radius, shadow.Height - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(0, shadow.Height - radius, radius, radius, 90, 90); // Bottom-left corner
            path.CloseFigure();

            shadow.Region = new Region(path);

            control.Parent.Controls.Add(shadow);
            shadow.SendToBack();

            control.SizeChanged += (sender, e) =>
            {
                shadow.Size = control.Size;
                shadow.Location = new Point(control.Left + 5, control.Top + 5);

                path.Reset();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(shadow.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(shadow.Width - radius, shadow.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, shadow.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                shadow.Region = new Region(path);
            };
        }

        public static void SetRoundedComboBox(ComboBox comboBox, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);  // Top-left corner
            path.AddArc(comboBox.Width - radius, 0, radius, radius, 270, 90);  // Top-right corner
            path.AddArc(comboBox.Width - radius, comboBox.Height - radius, radius, radius, 0, 90);  // Bottom-right corner
            path.AddArc(0, comboBox.Height - radius, radius, radius, 90, 90);  // Bottom-left corner
            path.CloseFigure();

            comboBox.Region = new Region(path);
        }

        public static void MakeRoundedTextBox(TextBox textBox, int borderRadius)
        {
            int numSpaces = 2;
            string leadingSpaces = new string(' ', numSpaces);
            textBox.Text = leadingSpaces + textBox.Text.TrimStart();

            textBox.TextChanged += (sender, e) =>
            {
                if (!textBox.Text.StartsWith(leadingSpaces))
                {
                    textBox.Text = leadingSpaces + textBox.Text.TrimStart(); 
                    textBox.SelectionStart = textBox.Text.Length;
                }
            };

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.SelectionStart < leadingSpaces.Length)
                {
                    textBox.SelectionStart = leadingSpaces.Length;
                }
            };

            textBox.Region = new Region(MakeRectangleRounded(new Rectangle(0, 0, textBox.Width, textBox.Height), borderRadius));
        }

        private static GraphicsPath MakeRectangleRounded(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Top-left corner
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Top-right corner
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Bottom-left corner
            path.CloseFigure();
            return path;
        }

        public static void SetRoundedNumericUpDown(NumericUpDown numericUpDown, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // Top-left corner
            path.AddArc(numericUpDown.Width - radius, 0, radius, radius, 270, 90); // Top-right corner
            path.AddArc(numericUpDown.Width - radius, numericUpDown.Height - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(0, numericUpDown.Height - radius, radius, radius, 90, 90); // Bottom-left corner
            path.CloseFigure();

            numericUpDown.Region = new Region(path);

            numericUpDown.Paint += (sender, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.Gray, 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };

            numericUpDown.SizeChanged += (sender, e) =>
            {
                path.Reset();
                path.AddArc(0, 0, radius, radius, 180, 90); // Top-left corner
                path.AddArc(numericUpDown.Width - radius, 0, radius, radius, 270, 90); // Top-right corner
                path.AddArc(numericUpDown.Width - radius, numericUpDown.Height - radius, radius, radius, 0, 90); // Bottom-right corner
                path.AddArc(0, numericUpDown.Height - radius, radius, radius, 90, 90); // Bottom-left corner
                path.CloseFigure();

                numericUpDown.Region = new Region(path);
                numericUpDown.Invalidate();
            };
        }

    }
}
