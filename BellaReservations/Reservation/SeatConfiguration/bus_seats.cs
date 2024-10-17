using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace BellaReservations
{
    /*
     
                    customerName: "",
                    transportMode: "Bus",
                    startPoint: "",
                    endPoint: "",
                    dateTime: "",
     */

    public partial class bus_seats : Form
    {
        // Property to store the previous form, which we later refer to switch back
        Form PreviousForm;

        // Property to store the bus id selected on the previous page
        private int BusId;

        // Properties to store receipt data
        string StartPoint, EndPoint, DateTime;

        // List to store the numbers of all occupied seats
        List<int> SelectedSeats = new List<int>();

        public bus_seats(int busId, Form previousForm, string startingPoint, string endPoint, string dateTime)
        {
            InitializeComponent();

            // Assign the parameter values we took to the class properties
            PreviousForm = previousForm;
            BusId = busId;
            StartPoint = startingPoint;
            EndPoint = endPoint;
            DateTime = dateTime;
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

        // Method to check if the given seat number for the given bus id is reserved
        private bool CheckSeatAvailability(short seatNumber)
        {
            string query = $"SELECT * FROM bus_seats WHERE bus_id = {BusId} AND seat_number = {seatNumber}";

            try
            {
                using (SqlConnection conn = new SqlConnection(main.ConnectionString))
                {
                    conn.Open(); // Open the database connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Execute the command and retrieve the first result
                        object result = cmd.ExecuteScalar();

                        // If any row satisfies the query is found
                        if (result != null)
                        {
                            // Return false, indicating that the given seat is already selected
                            return false;
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show("There was an error retrieving the bus data!");
            }

            // Return true if no row satisfies the query is found
            return true;
        }

        // Method attached to the form to run when the form is loaded
        private void bus_seats_Load(object sender, EventArgs e)
        {
            // Enable or disable each seat selection checkbox, so that the users can't select already occupied seats
            seat_1.Enabled = CheckSeatAvailability(1);
            seat_2.Enabled = CheckSeatAvailability(2);
            seat_3.Enabled = CheckSeatAvailability(3);
            seat_4.Enabled = CheckSeatAvailability(4);
            seat_5.Enabled = CheckSeatAvailability(5);
            seat_6.Enabled = CheckSeatAvailability(6);
            seat_7.Enabled = CheckSeatAvailability(7);
            seat_8.Enabled = CheckSeatAvailability(8);
            seat_9.Enabled = CheckSeatAvailability(9);
            seat_10.Enabled = CheckSeatAvailability(10);
            seat_11.Enabled = CheckSeatAvailability(11);
            seat_12.Enabled = CheckSeatAvailability(12);
            seat_13.Enabled = CheckSeatAvailability(13);
            seat_14.Enabled = CheckSeatAvailability(14);
            seat_15.Enabled = CheckSeatAvailability(15);
            seat_16.Enabled = CheckSeatAvailability(16);
            seat_17.Enabled = CheckSeatAvailability(17);
            seat_18.Enabled = CheckSeatAvailability(18);
            seat_19.Enabled = CheckSeatAvailability(19);
            seat_20.Enabled = CheckSeatAvailability(20);
            seat_21.Enabled = CheckSeatAvailability(21);
            seat_22.Enabled = CheckSeatAvailability(22);
            seat_23.Enabled = CheckSeatAvailability(23);
            seat_24.Enabled = CheckSeatAvailability(24);
            seat_25.Enabled = CheckSeatAvailability(25);
            seat_26.Enabled = CheckSeatAvailability(26);
            seat_27.Enabled = CheckSeatAvailability(27);
            seat_28.Enabled = CheckSeatAvailability(28);
            seat_29.Enabled = CheckSeatAvailability(29);
            seat_30.Enabled = CheckSeatAvailability(30);
            seat_31.Enabled = CheckSeatAvailability(31);
            seat_32.Enabled = CheckSeatAvailability(32);
            seat_33.Enabled = CheckSeatAvailability(33);
            seat_34.Enabled = CheckSeatAvailability(34);
            seat_35.Enabled = CheckSeatAvailability(35);
            seat_36.Enabled = CheckSeatAvailability(36);
            seat_37.Enabled = CheckSeatAvailability(37);
            seat_38.Enabled = CheckSeatAvailability(38);
            seat_39.Enabled = CheckSeatAvailability(39);
            seat_40.Enabled = CheckSeatAvailability(40);
            seat_41.Enabled = CheckSeatAvailability(41);
            seat_42.Enabled = CheckSeatAvailability(42);
            seat_43.Enabled = CheckSeatAvailability(43);
            seat_44.Enabled = CheckSeatAvailability(44);
            seat_45.Enabled = CheckSeatAvailability(45);
            seat_46.Enabled = CheckSeatAvailability(46);
            panel54.Enabled = CheckSeatAvailability(47);
            seat_48.Enabled = CheckSeatAvailability(48);
            seat_49.Enabled = CheckSeatAvailability(49);
            seat_50.Enabled = CheckSeatAvailability(50);
            seat_51.Enabled = CheckSeatAvailability(51);
            seat_52.Enabled = CheckSeatAvailability(52);
            seat_53.Enabled = CheckSeatAvailability(53);
            seat_54.Enabled = CheckSeatAvailability(54);
            seat_55.Enabled = CheckSeatAvailability(55);
            seat_56.Enabled = CheckSeatAvailability(56);
        }

        // Method attached to all 56 checkboxes to run when either they're being checked or unchecked
        private void CheckChanged(object sender, EventArgs e)
        {
            // Get the checkbox
            CheckBox checkBox = sender as CheckBox;

            // Get the seat number of the current checkbox by retrieving its name an converting it to an integer
            // We also remove the "seat_" part from the checkbox name before the conversion
            int SeatNo = Convert.ToInt16(checkBox.Name.Replace("seat_", ""));

            // If the checkbox is being checked
            if (checkBox.Checked)
            {
                // Add it to the list of selected seats
                SelectedSeats.Add(SeatNo);
            }

            // If the checkbox is being unchecked
            else
            {
                // Remove it from the list of selected seats
                SelectedSeats.Remove(SeatNo);
            }
        }

        // Method attached to the form to run when the previous form button is clicked
        private void PreviousFormButton_Click(object sender, EventArgs e)
        {
            // Return the user to previous form
            PreviousForm.Show();
            PreviousForm.FormClosing += delegate { Application.Exit(); };
            this.Hide();
        }

        // Helper method to store selected seats in the bus_seats table
        private void StoreSelectedSeats(int reservationId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(main.ConnectionString))
                {
                    conn.Open(); // Open the connection

                    // Insert each selected seat along with the reservation_id and bus_id
                    foreach (int seatNumber in SelectedSeats)
                    {
                        string query = "INSERT INTO bus_seats (bus_id, seat_number, reservation_id) " +
                                       $"VALUES ({BusId}, {seatNumber}, {reservationId})";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.ExecuteNonQuery(); // Execute the insert command
                        }
                    }
                }
            }

            catch (SqlException)
            {
                MessageBox.Show("Error storing seat data!");
            }
        }

        // Method attached to the form to run when the confirm reservation button is clicked
        private void ConfirmReservation_Click(object sender, EventArgs e)
        {
            // Initialize variables 
            int CustomerId = main.UserId; // Use the logged-in user's ID
            int ReservationId;
            string CustomerName = "Not Found!";
            string ReservationPrice = "Fair";

            try
            {
                using (SqlConnection conn = new SqlConnection(main.ConnectionString))
                {
                    conn.Open(); // Open the connection

                    // Insert the reservation into the bus_reservation table
                    string query = "INSERT INTO bus_reservation (customer_id, bus_id) " +
                                   $"VALUES ({CustomerId}, {BusId}); " +
                                   "SELECT SCOPE_IDENTITY();"; // Retrieve the reservation_id

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        ReservationId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Store the selected seats
                    StoreSelectedSeats(ReservationId);

                    // Retrieve the customer name from the customer table
                    string customerQuery = $"SELECT name FROM customer WHERE customer_id = {CustomerId}";
                    using (SqlCommand cmd = new SqlCommand(customerQuery, conn))
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            CustomerName = result.ToString();
                        }
                    }

                    // Retrieve the price for the bus id bus_data table
                    string priceQuery = $"SELECT price FROM bus_data WHERE bus_id = {BusId}";

                    using (SqlCommand cmd = new SqlCommand(priceQuery, conn))
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            ReservationPrice = $"LKR {result.ToString()}";
                        }
                    }
                }

                // Show a success message
                MessageBox.Show("Reservation successful!");

                // Display the receipt form
                receipt receipt = new receipt(
                    reservationId: ReservationId.ToString(),
                    customerName: CustomerName,
                    transportMode: "Bus",
                    startPoint: StartPoint,
                    endPoint: EndPoint,
                    dateTime: DateTime,
                    seatNumbers: string.Join(",", SelectedSeats),
                    price: ReservationPrice);

                receipt.FormClosing += delegate { Application.Exit(); };
                receipt.Show();

                // Hide the current form after showing the receipt
                Hide();
            }
            catch (SqlException)
            {
                MessageBox.Show("There was an error while making the reservation!");
            }
        }

    }
}
