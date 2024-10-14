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
    public partial class train_seats : Form
    {
        public train_seats()
        {
            InitializeComponent();
        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel39_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Create a rectangle that matches the form's client area
            Rectangle rect = this.ClientRectangle;

            // Define colors for the gradient
            Color startColor = Color.FromArgb(0xAF, 0xCE, 0xEB); // Light blue
            Color middleColor = Color.FromArgb(0x00, 0x70, 0xC0); // Blue
            Color endColor = Color.FromArgb(0x00, 0x00, 0x00);    // Black

            // Create a LinearGradientBrush
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, startColor, endColor, LinearGradientMode.Vertical))
            {
                // Define blend factors for a 3-color gradient
                ColorBlend colorBlend = new ColorBlend(3);
                colorBlend.Colors = new Color[] { startColor, middleColor, endColor };
                colorBlend.Positions = new float[] { 0.0f, 0.5f, 1.0f }; // Start, Middle, End

                // Apply the color blend to the brush
                brush.InterpolationColors = colorBlend;

                // Paint the form background
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel32_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel33_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel34_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel35_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel36_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel38_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel40_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel41_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel43_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel44_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel45_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel46_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel47_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel48_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel49_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel50_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel51_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel52_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel53_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel54_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel55_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel56_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel57_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel58_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel59_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel60_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel61_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel62_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel63_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel65_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel66_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel67_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel68_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel69_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel70_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel64_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel42_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            // Get the panel's graphics object
            Graphics g = e.Graphics;

            // Define the border color and width
            Color borderColor = Color.Black;  // You can change this to any color
            int borderWidth = 2;  // You can change the thickness

            // Create a rectangle for the panel's bounds
            Rectangle rect = new Rectangle(0, 0, panel1.Width - borderWidth, panel1.Height - borderWidth);

            // Draw the border using the specified color and width
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                g.DrawRectangle(pen, rect);
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {
            // Define the border color and width
            Color borderColor = Color.White;
            int borderWidth = 5;
            int cornerRadius = 20; // Adjust for larger/smaller corners

            // Get the table layout panel's graphics object
            Graphics g = e.Graphics;

            // Enable anti-aliasing for smoother edges
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Create the rectangle where the border will be drawn
            Rectangle rect = this.tableLayoutPanel5.ClientRectangle;
            rect.Width -= borderWidth; // Adjust the width to account for the border width
            rect.Height -= borderWidth; // Adjust the height to account for the border width
            rect.X += borderWidth / 2; // Slightly adjust the position to center the border
            rect.Y += borderWidth / 2; // Slightly adjust the position to center the border

            // Create a path for the rounded rectangle
            using (GraphicsPath path = new GraphicsPath())
            {
                // Add rounded rectangle to the path (starting from the top-left corner)
                path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90); // Top-left corner
                path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90); // Top-right corner
                path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Bottom-right corner
                path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Bottom-left corner
                path.CloseFigure(); // Close the path

                // Draw the black border with the rounded corners
                using (Pen pen = new Pen(borderColor, borderWidth))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Get the panel's graphics object
            Graphics g = e.Graphics;

            // Define the border color and width
            Color borderColor = Color.White;  // You can change this to any color
            int borderWidth = 2;  // You can change the thickness

            // Create a rectangle for the panel's bounds
            Rectangle rect = new Rectangle(0, 0, panel1.Width - borderWidth, panel1.Height - borderWidth);

            // Draw the border using the specified color and width
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                g.DrawRectangle(pen, rect);
            }
        }
    }
}
