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
    public partial class main_bus : Form
    {
        public main_bus()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
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
            Rectangle rect = this.tableLayoutPanel3.ClientRectangle;
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
    }
}
