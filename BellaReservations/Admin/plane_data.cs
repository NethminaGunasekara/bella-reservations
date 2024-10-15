using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BellaReservations
{
    public partial class plane_data : Form
    {
        Form PreviousForm;

        public plane_data(Form previousForm)
        {
            InitializeComponent();

            PreviousForm = previousForm;
        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            // Cast the sender to a TableLayoutPanel
            TableLayoutPanel panel = sender as TableLayoutPanel;

            // Create a white pen for drawing the rounded corners
            using (Pen whitePen = new Pen(Color.Black, 3))
            {
                // Set smoothing mode for smoother, rounded corners
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Define the radius for the rounded corners
                int radius = 20;

                // Create a rectangle for the panel's bounds, reducing the size to fit the border
                Rectangle panelRect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

                // Create a GraphicsPath to draw the rounded corners
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

                // Add rounded rectangle to the path
                path.AddArc(panelRect.X, panelRect.Y, radius, radius, 180, 90);  // Top-left corner
                path.AddArc(panelRect.Right - radius, panelRect.Y, radius, radius, 270, 90);  // Top-right corner
                path.AddArc(panelRect.Right - radius, panelRect.Bottom - radius, radius, radius, 0, 90);  // Bottom-right corner
                path.AddArc(panelRect.X, panelRect.Bottom - radius, radius, radius, 90, 90);  // Bottom-left corner
                path.CloseAllFigures();

                // Set the region of the panel to the rounded rectangle to avoid any edges outside the rounded area
                panel.Region = new Region(path);

                // Fill the entire background with black inside the rounded region
                using (SolidBrush backgroundBrush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillPath(backgroundBrush, path);
                }

                // Draw the white border around the panel
                e.Graphics.DrawPath(whitePen, path);
            }
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

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {
            // Cast the sender to a TableLayoutPanel
            TableLayoutPanel panel = sender as TableLayoutPanel;

            // Create a white pen for drawing the rounded corners
            using (Pen whitePen = new Pen(Color.Black, 3))
            {
                // Set smoothing mode for smoother, rounded corners
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Define the radius for the rounded corners
                int radius = 20;

                // Create a rectangle for the panel's bounds, reducing the size to fit the border
                Rectangle panelRect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

                // Create a GraphicsPath to draw the rounded corners
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

                // Add rounded rectangle to the path
                path.AddArc(panelRect.X, panelRect.Y, radius, radius, 180, 90);  // Top-left corner
                path.AddArc(panelRect.Right - radius, panelRect.Y, radius, radius, 270, 90);  // Top-right corner
                path.AddArc(panelRect.Right - radius, panelRect.Bottom - radius, radius, radius, 0, 90);  // Bottom-right corner
                path.AddArc(panelRect.X, panelRect.Bottom - radius, radius, radius, 90, 90);  // Bottom-left corner
                path.CloseAllFigures();

                // Set the region of the panel to the rounded rectangle to avoid any edges outside the rounded area
                panel.Region = new Region(path);

                // Fill the entire background with black inside the rounded region
                using (SolidBrush backgroundBrush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillPath(backgroundBrush, path);
                }

                // Draw the white border around the panel
                e.Graphics.DrawPath(whitePen, path);
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plane_data_Load(object sender, EventArgs e)
        {

        }

        // When the previous form button is clicked
        private void PreviousFormButton_Click(object sender, EventArgs e)
        {
            // Return the user to previous form
            PreviousForm.Show();
            PreviousForm.FormClosing += delegate { Application.Exit(); };
            this.Hide();
        }
    }
}
