using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BellaReservations
{
    public partial class selection : Form
    {
        // Step 01: First create a variable for storing the current form
        Form PreviousForm;

        // Step 2: Add the variable we created as a parameter
        public selection(Form previousForm)
        {
            InitializeComponent();

            // Step 3: Store the previous form within the variable we created
            PreviousForm = previousForm;

            // Edit the form title if the logged user is an admin
            if (main.UserRole == "ADMIN")
            {
                Text = "Edit Details About A Transport Mode - Bella Reservations";
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

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            // Define the radius for the rounded corners
            int radius = 40;

            // Create a rectangle for the panel's bounds
            Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);

            // Create a GraphicsPath to define the rounded rectangle
            GraphicsPath path = new GraphicsPath();

            // Top-left corner
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);

            // Top-right corner
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);

            // Bottom-right corner
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);

            // Bottom-left corner
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);

            // Close the path to complete the rounded rectangle
            path.CloseFigure();

            // Set the smoothing mode for better drawing quality
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Fill the panel with a background color (remove the border)
            using (SolidBrush brush = new SolidBrush(panel.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            // Set the panel's region to the rounded rectangle to apply rounded corners
            panel.Region = new Region(path);
        }

        // When the previous form button is clicked
        private void PreviousFormButton_Click(object sender, EventArgs e)
        {
            // Return the user to previous form
            PreviousForm.Show();
            PreviousForm.FormClosing += delegate { Application.Exit(); };
            this.Hide();
        }

        private void ButtonTransportModeBus_Click(object sender, EventArgs e)
        {
            // If the button is clicked by an admin
            if (main.UserRole == "ADMIN")
            {
                // Show the bus data editing form
                bus_data BusDataForm = new bus_data(this);
                BusDataForm.FormClosing += delegate { Application.Exit(); };

                BusDataForm.Show(); // Show the destination form

                // Hide the current form
                this.Hide();
            }
            else
            {
                // If the button is clicked by a user
                bus BusReservation = new bus(this);
                BusReservation.FormClosing += delegate { Application.Exit(); };

                BusReservation.Show(); // Show the destination form

                // Hide the current form
                this.Hide();
            }
        }

        private void ButtonTransportModeTrain_Click(object sender, EventArgs e)
        {
            // If the button is clicked by an admin
            if (main.UserRole == "ADMIN")
            {
                // Show the train data editing form
                train_data TrainDataForm = new train_data(this);
                TrainDataForm.FormClosing += delegate { Application.Exit(); };

                TrainDataForm.Show(); // Show the destination form

                // Hide the current form
                this.Hide();
            }
            else
            {
                // If the button is clicked by a user
                train TrainReservation = new train(this);
                TrainReservation.FormClosing += delegate { Application.Exit(); };

                TrainReservation.Show(); // Show the destination form

                // Hide the current form
                this.Hide();
            }
        }

        private void ButtonTransportModeShip_Click(object sender, EventArgs e)
        {
            // If the button is clicked by an admin
            if (main.UserRole == "ADMIN")
            {
                // Show the ship data editing form
                boat_data ShipDataForm = new boat_data(this);
                ShipDataForm.FormClosing += delegate { Application.Exit(); };

                ShipDataForm.Show(); // Show the destination form

                // Hide the current form
                this.Hide();
            }
            else
            {
                // If the button is clicked by a user
                boat ShipReservation = new boat(this);
                ShipReservation.FormClosing += delegate { Application.Exit(); };

                ShipReservation.Show(); // Show the destination form

                // Hide the current form
                this.Hide();
            }
        }

        private void ButtonTransportModePlane_Click(object sender, EventArgs e)
        {
            // If the button is clicked by an admin
            if (main.UserRole == "ADMIN")
            {
                // Show the plane data editing form
                plane_data PlaneDataForm = new plane_data(this);
                PlaneDataForm.FormClosing += delegate { Application.Exit(); };

                PlaneDataForm.Show(); // Show the destination form

                // Hide the current form
                this.Hide();
            }
            else
            {
                // If the button is clicked by a user
                plane PlaneReservation = new plane(this);
                PlaneReservation.FormClosing += delegate { Application.Exit(); };

                PlaneReservation.Show(); // Show the destination form

                // Hide the current form
                this.Hide();
            }
        }


    }
}