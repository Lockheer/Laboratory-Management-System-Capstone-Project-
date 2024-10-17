using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OfficeOpenXml.FormulaParsing;
using System.IO.Ports;

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


        public static void RemoveGroupBoxBorder(GroupBox groupBox)
        {
            groupBox.Paint += (sender, e) =>
            {
                e.Graphics.Clear(groupBox.BackColor);
                TextRenderer.DrawText(e.Graphics, groupBox.Text, groupBox.Font, new Point(10, 0), groupBox.ForeColor);
            };
        }

        public static void SetShadow(Control control)
        {
            Panel shadow = new Panel
            {
                Size = control.Size,
                Location = new Point(control.Left + 5, control.Top + 5), // Slight offset to give shadow effect  Location = new Point(control.Left, control.Top + 6),(control.Left + 5, control.Top + 5)
                BackColor = Color.DimGray // Solid gray shadow, no transparency Color.FromArgb(50, 0, 0, 0)
            };

            int radius = 50; // Smaller radius for a simpler look
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
                shadow.Location = new Point(control.Left + 5, control.Top + 5); // Keep the offset

                path.Reset();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(shadow.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(shadow.Width - radius, shadow.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, shadow.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                shadow.Region = new Region(path);
            };
        }


        public static void SetShadowBtn(Control control)
        {
            // Create the shadow panel
            Panel shadow = new Panel
            {
                Size = control.Size,
                Location = new Point(control.Left, control.Top + 5), 
                BackColor = Color.DarkGray
            };

            int radius = 10; 
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
                shadow.Location = new Point(control.Left + 5, control.Top + 5); // Keep the offset

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
            GraphicsPath path = new GraphicsPath();
            int diameter = borderRadius * 2;
            path.AddArc(0, 0, diameter, diameter, 180, 90); // Top-left corner
            path.AddArc(textBox.Width - diameter, 0, diameter, diameter, 270, 90); // Top-right corner
            path.AddArc(textBox.Width - diameter, textBox.Height - diameter, diameter, diameter, 0, 90); // Bottom-right corner
            path.AddArc(0, textBox.Height - diameter, diameter, diameter, 90, 90); // Bottom-left corner
            path.CloseFigure();

            textBox.Region = new Region(path);
            textBox.SizeChanged += (sender, e) => textBox.Invalidate();
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

        public static void SetRoundedDateTimePicker(DateTimePicker dateTimePicker, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // Top-left corner
            path.AddArc(dateTimePicker.Width - radius, 0, radius, radius, 270, 90); // Top-right corner
            path.AddArc(dateTimePicker.Width - radius, dateTimePicker.Height - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(0, dateTimePicker.Height - radius, radius, radius, 90, 90); // Bottom-left corner
            path.CloseFigure();

            dateTimePicker.Region = new Region(path);
        }
        public static void ApplyHoverEffectToMenuStrip(MenuStrip menuStrip)
        {
            // Apply hover effect to main menu items and their sub-items recursively
            foreach (ToolStripMenuItem menuItem in menuStrip.Items)
            {
                ApplyHoverEffectToMenuItem(menuItem);
            }
        }

        private static void ApplyHoverEffectToMenuItem(ToolStripMenuItem menuItem)
        {
            // Apply hover effect to the main menu item
            menuItem.MouseEnter += (sender, e) =>
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                item.Font = new Font(item.Font.FontFamily, item.Font.Size + 2, FontStyle.Bold);
            };

            menuItem.MouseLeave += (sender, e) =>
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                item.Font = new Font(item.Font.FontFamily, item.Font.Size - 2, FontStyle.Regular);
            };

            // Apply the same hover effect to sub-items recursively
            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem dropDownItem)
                {
                    ApplyHoverEffectToMenuItem(dropDownItem);  // Recursive call
                }
            }
        }


        public static void SetFormStartLocation(Form form, int x, int y)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(x, y);
        }
    }
}
