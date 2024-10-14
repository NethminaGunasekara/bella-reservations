using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BellaReservations
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            TableLayoutPanel tableLayoutPanel = sender as TableLayoutPanel;

            // Set the background color to transparent or match your gradient
            tableLayoutPanel.BackColor = Color.Transparent; // or set to match your gradient colors

            // Set padding and margin to zero
            tableLayoutPanel.Padding = new Padding(0);
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.BorderStyle = BorderStyle.None; // Remove default border

            // Define the radius for the rounded corners
            int radius = 30;

            // Create a rectangle for the TableLayoutPanel's bounds
            Rectangle rect = new Rectangle(0, 0, tableLayoutPanel.Width, tableLayoutPanel.Height);

            // Create a GraphicsPath to define the rounded rectangle
            GraphicsPath path = new GraphicsPath();

            // Define the rounded rectangle shape
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Top-left corner
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Top-right corner
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Bottom-left corner
            path.CloseFigure(); // Complete the path

            // Set the smoothing mode for better drawing quality
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Clip the graphics to the rounded rectangle
            e.Graphics.SetClip(path);

            // Define the colors for the gradient
            Color startColor = Color.FromArgb(0xAF, 0xCE, 0xEB); // Light blue (Top)
            Color middleColor = Color.FromArgb(0x00, 0x70, 0xC0); // Blue (Middle)
            Color endColor = Color.FromArgb(0x00, 0x00, 0x00);    // Black (Bottom)

            // Create a LinearGradientBrush for the background
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, startColor, endColor, LinearGradientMode.Vertical))
            {
                // Define a color blend to transition between the three colors
                ColorBlend colorBlend = new ColorBlend(3);
                colorBlend.Colors = new Color[] { startColor, middleColor, endColor };
                colorBlend.Positions = new float[] { 0.0f, 0.5f, 1.0f }; // Gradient stops

                // Apply the color blend to the brush
                brush.InterpolationColors = colorBlend;

                // Paint the gradient background on the TableLayoutPanel
                e.Graphics.FillRectangle(brush, rect);
            }

            // Set the region of the TableLayoutPanel to the rounded rectangle to clip its corners
            tableLayoutPanel.Region = new Region(path);

            // Add the white border after the gradient is painted
            using (Pen whitePen = new Pen(Color.White, 5)) // 5 is the border width; adjust as needed
            {
                // Draw the white border around the path
                e.Graphics.DrawPath(whitePen, path);
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            TableLayoutPanel tableLayoutPanel = sender as TableLayoutPanel;

            // Set the background color to transparent or match your gradient
            tableLayoutPanel.BackColor = Color.Transparent; // or set to match your gradient colors

            // Set padding and margin to zero
            tableLayoutPanel.Padding = new Padding(0);
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.BorderStyle = BorderStyle.None; // Remove default border

            // Define the radius for the rounded corners
            int radius = 30;

            // Create a rectangle for the TableLayoutPanel's bounds
            Rectangle rect = new Rectangle(0, 0, tableLayoutPanel.Width, tableLayoutPanel.Height);

            // Create a GraphicsPath to define the rounded rectangle
            GraphicsPath path = new GraphicsPath();

            // Define the rounded rectangle shape
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Top-left corner
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Top-right corner
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Bottom-left corner
            path.CloseFigure(); // Complete the path

            // Set the smoothing mode for better drawing quality
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Clip the graphics to the rounded rectangle
            e.Graphics.SetClip(path);

            // Define the colors for the gradient
            Color startColor = Color.FromArgb(0xAF, 0xCE, 0xEB); // Light blue (Top)
            Color middleColor = Color.FromArgb(0x00, 0x70, 0xC0); // Blue (Middle)
            Color endColor = Color.FromArgb(0x00, 0x00, 0x00);    // Black (Bottom)

            // Create a LinearGradientBrush for the background
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, startColor, endColor, LinearGradientMode.Vertical))
            {
                // Define a color blend to transition between the three colors
                ColorBlend colorBlend = new ColorBlend(3);
                colorBlend.Colors = new Color[] { startColor, middleColor, endColor };
                colorBlend.Positions = new float[] { 0.0f, 0.5f, 1.0f }; // Gradient stops

                // Apply the color blend to the brush
                brush.InterpolationColors = colorBlend;

                // Paint the gradient background on the TableLayoutPanel
                e.Graphics.FillRectangle(brush, rect);
            }

            // Set the region of the TableLayoutPanel to the rounded rectangle to clip its corners
            tableLayoutPanel.Region = new Region(path);

            // Add the white border after the gradient is painted
            using (Pen whitePen = new Pen(Color.White, 5)) // 5 is the border width; adjust as needed
            {
                // Draw the white border around the path
                e.Graphics.DrawPath(whitePen, path);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Get the panel's graphics object
            Graphics g = e.Graphics;

            // Define the border color (white) and width
            Color borderColor = Color.White;
            int borderWidth = 2; // Set border width as needed

            // Create a rectangle for the panel's bounds, considering the border width
            Rectangle rect = new Rectangle(0, 0, panel1.Width - borderWidth, panel1.Height - borderWidth);

            // Draw the white border around the panel
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                g.DrawRectangle(pen, rect);
            }
        }
    }
}
