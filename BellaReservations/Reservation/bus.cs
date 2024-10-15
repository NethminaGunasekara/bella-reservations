using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BellaReservations
{
    public partial class bus : Form
    {
        Form PreviousForm;

        public bus(Form previousForm)
        {
            InitializeComponent();

            PreviousForm = previousForm;

            // Retrieve and apply the list of departing stations
            RetrieveDepartingStations();
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

        // When the previous form button is clicked
        private void PreviousFormButton_Click(object sender, EventArgs e)
        {
            // Return the user to previous form
            PreviousForm.Show();
            PreviousForm.FormClosing += delegate { Application.Exit(); };
            this.Hide();
        }

        // Method to execute when the confirm reservation button is clicked
        private void ConfirmReservationButton_Click(object sender, EventArgs e)
        {
            // If any of the combo-boxes still containing their initial names, display an error message
            if(DepartingStationComboBox.Text == "Departing Station" || DestinationStationComboBox.Text == "Destination Station" || DateComboBox.Text == "Date" || TimeComboBox.Text == "Time")
            {
                MessageBox.Show("Please fill out all values before continue.");
            }
        }

        // Method to retrieve the list of departing stations
        // This method is called when the form is loaded
        private void RetrieveDepartingStations()
        {
            // Clear the existing list of departing stations (if any)
            DepartingStationComboBox.Items.Clear();

            // Initialize a list to store the departing stations
            List<string> DepartingStationsList = new List<string>();

            // SQL query to retrieve all departing stations from the "bus_data" table
            string query = "SELECT departing_station FROM bus_data";

            // Use a try-catch block to handle any potential exceptions
            try
            {
                // Initialize SQL connection
                using (SqlConnection conn = new SqlConnection(main.ConnectionString))
                {
                    // Open the database connection
                    conn.Open();

                    // Prepare the SQL command to execute
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        // Execute the command and reteive the result set
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Read all rows from the result set
                            while (reader.Read())
                            {
                                string retrievedDepartingStation = reader.GetString(0);

                                // Add each departing station to the list, if it's not already present
                                if (!DepartingStationsList.Contains(retrievedDepartingStation))
                                {
                                    DepartingStationsList.Add(retrievedDepartingStation);
                                }
                            }
                        }
                    }
                }

                // Add the list of departing stations to the combo-box containing departing stations
                DepartingStationComboBox.Items.AddRange(DepartingStationsList.ToArray());
            }

            catch (SqlException error)
            {
                Console.WriteLine("Database connection error!");
            }
        }

        // Executed when the selected value of departing station combo box has changed
        private void DepartingStationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string DepartingStation = DepartingStationComboBox.Text;

            // Restore the placeholder value of the destination station combo box
            DestinationStationComboBox.Text = "Destination Station";

            // Initialize a list to store the list of destination stations for the selected departing station
            List<string> DestinationStationsList = new List<string>();

            // SQL query to retrieve all departing stations from the "bus_data" table
            string query = $"SELECT destination_station FROM bus_data WHERE departing_station='{DepartingStation}'";

            // Use a try-catch block to handle any potential exceptions
            try
            {
                // Initialize SQL connection
                using (SqlConnection conn = new SqlConnection(main.ConnectionString))
                {
                    // Open the database connection
                    conn.Open();

                    // Prepare the SQL command to execute
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        // Execute the command and reteive the result set
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Read all rows from the result set
                            while (reader.Read())
                            {
                                string retrievedDestinationStation = reader.GetString(0);

                                // Add each destination station to the list, if it's not already present
                                if (!DestinationStationsList.Contains(retrievedDestinationStation))
                                {
                                    DestinationStationsList.Add(retrievedDestinationStation);
                                }
                            }
                        }
                    }
                }

                // Clear existing items from destination station combo-box (if any)
                DestinationStationComboBox.Items.Clear();

                // Add all items of DestinationStationsList as the items of destination stations combo box
                DestinationStationComboBox.Items.AddRange(DestinationStationsList.ToArray());
            }

            catch (SqlException error)
            {
                Console.WriteLine("Database connection error!");
            }
        }

        // Executed when the selected value of destination station combo box has changed
        private void DestinationStationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string DepartingStation = DepartingStationComboBox.Text;
            string DestinationStation = DestinationStationComboBox.Text;

            // Restore the placeholder value of the date combo box
            DateComboBox.Text = "Date";

            // Initialize a list to store the list of dates for the selected destination station
            List<string> DatesList = new List<string>();

            // SQL query to retrieve all dates from the "bus_data" table
            string query = $"SELECT [date] FROM bus_data WHERE departing_station='{DepartingStation}' AND destination_station='{DestinationStation}'";

            // Use a try-catch block to handle any potential exceptions
            try
            {
                // Initialize SQL connection
                using (SqlConnection conn = new SqlConnection(main.ConnectionString))
                {
                    // Open the database connection
                    conn.Open();

                    // Prepare the SQL command to execute
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        // Execute the command and reteive the result set
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Read all rows from the result set
                            while (reader.Read())
                            {
                                DateTime retrievedDate = reader.GetDateTime(0);

                                // Format the date to "yyyy-MM-dd"
                                string formattedDate = retrievedDate.ToString("yyyy-MM-dd");

                                // Add each date to the dates list, if it's not already present
                                if (!DatesList.Contains(formattedDate))
                                {
                                    DatesList.Add(formattedDate);
                                }
                            }
                        }
                    }
                }

                // Clear existing items from dates combo-box (if any)
                DateComboBox.Items.Clear();

                // Add all items of DatesList as the items of dates combo box
                DateComboBox.Items.AddRange(DatesList.ToArray());
            }

            catch (SqlException error)
            {
                Console.WriteLine("Database connection error!");
            }
        }

        // Executed when the selected value of date combo box has changed
        private void DateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string DepartingStation = DepartingStationComboBox.Text;
            string DestinationStation = DestinationStationComboBox.Text;
            string SelectedDate = DateComboBox.Text;

            // Restore the placeholder value of the time combo box
            TimeComboBox.Text = "Time";

            // Initialize a list to store the list of time slots for the selected destination station
            List<string> TimesList = new List<string>();

            // SQL query to retrieve all available time slots from the "bus_data" table
            string query = $"SELECT [time] FROM bus_data WHERE departing_station='{DepartingStation}' AND destination_station='{DestinationStation}' AND [date]='{SelectedDate}'";

            // Use a try-catch block to handle any potential exceptions
            try
            {
                // Initialize SQL connection
                using (SqlConnection conn = new SqlConnection(main.ConnectionString))
                {
                    // Open the database connection
                    conn.Open();

                    // Prepare the SQL command to execute
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        // Execute the command and reteive the result set
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Read all rows from the result set
                            while (reader.Read())
                            {
                                // Retrieve the value from the time(7) column as TimeSpan
                                TimeSpan retrievedTime = reader.GetTimeSpan(0);

                                // Format the time to "HH:mm"
                                string formattedTime = retrievedTime.ToString(@"hh\:mm");

                                // Add each time slot to the times list, if it's not already present
                                if (!TimesList.Contains(formattedTime))
                                {
                                    TimesList.Add(formattedTime);
                                }
                            }
                        }
                    }
                }

                // Clear existing items from times combo-box (if any)
                TimeComboBox.Items.Clear();

                // Add all items of TimesList as the items of dates combo box
                TimeComboBox.Items.AddRange(TimesList.ToArray());
            }

            catch (SqlException error)
            {
                Console.WriteLine("Database connection error!");
            }
        }
    }
}
