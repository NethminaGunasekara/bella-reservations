using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BellaReservations
{
    public partial class bus_data : Form
    {
        Form PreviousForm;

        public bus_data(Form previousForm)
        {
            InitializeComponent();

            PreviousForm = previousForm;
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            
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

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            DateTime date;
            DateTime time;
            double price;

            try
            {
                date = DateTime.Parse(reservation_date.Text);
                time = DateTime.Parse(reservation_time.Text);

                // Try to parse the price into a double value
                price = Double.Parse(textBox_price.Text);
            } 

            // Handle any errors during retrieving and parsing the inputs
            catch (Exception)
            {
                MessageBox.Show("Error inserting data! Please check your inputs.");

                return; // Prevent the next code from executing when an error has occured
            }

            // If all inputs are provided
            if(textBox_from.Text.Length >= 1 && textBox_to.Text.Length >=1)
            {
                // Query to insert all values into bus_data table
                string query = @"INSERT INTO bus_data (departing_station, destination_station, date, time, price) 
                                    VALUES (@From, @To, @Date, @Time, @Price)";

                try
                {
                    using (SqlConnection conn = new SqlConnection(main.ConnectionString))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Set the parameter values
                            cmd.Parameters.AddWithValue("@From", textBox_from.Text);
                            cmd.Parameters.AddWithValue("@To", textBox_to.Text);
                            cmd.Parameters.AddWithValue("@Date", date.Date);
                            cmd.Parameters.AddWithValue("@Time", time);
                            cmd.Parameters.AddWithValue("@Price", price);

                            // Execute the query
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // If there's an error, display an error message
                catch (Exception)
                {
                    MessageBox.Show("An error has occurred while saving data.");
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            DateTime date;
            DateTime time;
            double price;

            try
            {
                // Parse inputs into appropriate types
                date = DateTime.Parse(reservation_date.Text);
                time = DateTime.Parse(reservation_time.Text);
                price = Double.Parse(textBox_price.Text);
            }

            // If there's an error while parsing input data, display an error message
            catch (Exception)
            {
                MessageBox.Show("Error processing data! Please check your inputs.");
                return; // Prevent the next code from executing when an error has occured
            }

            // Check if from and to stations have been provided
            if (textBox_from.Text.Length >= 1 && textBox_to.Text.Length >= 1)
            {
                // SQL query to delete the first matching row from bus_data
                string query = @"DELETE TOP (1) FROM bus_data 
                                WHERE departing_station = @From 
                                AND destination_station = @To 
                                AND date = @Date 
                                AND time = @Time 
                                AND price = @Price";

                using (SqlConnection conn = new SqlConnection(main.ConnectionString))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Assign values to the parameters
                            cmd.Parameters.AddWithValue("@From", textBox_from.Text);
                            cmd.Parameters.AddWithValue("@To", textBox_to.Text);
                            cmd.Parameters.AddWithValue("@Date", date.Date);
                            cmd.Parameters.AddWithValue("@Time", time.TimeOfDay);
                            cmd.Parameters.AddWithValue("@Price", price);

                            // Execute the DELETE query
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Notify the user if no rows were affected
                            if (rowsAffected == 0)
                            {
                                MessageBox.Show("No matching reservation found.");
                            }

                            else
                            {
                                MessageBox.Show("Reservation deleted successfully.");
                            }
                        }
                    }

                    // If there's an error, display an error message
                    catch (Exception)
                    {
                        MessageBox.Show("An error has occurred while deleting the record.");
                    }
                }
            }

            else
            {
                MessageBox.Show("Please fill in both the 'From' and 'To' stations.");
            }
        }

        private void UpdatePrice_Click(object sender, EventArgs e)
        {
            DateTime date;
            DateTime time;
            double price;

            try
            {
                // Parse date, time, and price inputs
                date = DateTime.Parse(reservation_date.Text);
                time = DateTime.Parse(reservation_time.Text);
                price = Double.Parse(textBox_price.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error processing data! Please check your inputs.");

                return; // Prevent the next code from executing if inputs are invalid
            }

            // Ensure that 'From' and 'To' stations are not empty
            if (textBox_from.Text.Length >= 1 && textBox_to.Text.Length >= 1)
            {
                // SQL query to update the price where all other details match
                string query = @"UPDATE bus_data 
                                SET price = @Price 
                                WHERE departing_station = @From 
                                AND destination_station = @To 
                                AND date = @Date 
                                AND time = @Time";

                using (SqlConnection conn = new SqlConnection(main.ConnectionString))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Assign values to the parameters
                            cmd.Parameters.AddWithValue("@From", textBox_from.Text);
                            cmd.Parameters.AddWithValue("@To", textBox_to.Text);
                            cmd.Parameters.AddWithValue("@Date", date.Date);
                            cmd.Parameters.AddWithValue("@Time", time.TimeOfDay);
                            cmd.Parameters.AddWithValue("@Price", price);

                            // Execute the UPDATE query
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Notify the user about the result
                            if (rowsAffected == 0)
                            {
                                MessageBox.Show("No matching reservation found to update.");
                            }
                            else
                            {
                                MessageBox.Show("Price updated successfully.");
                            }
                        }
                    }

                    // If there's an error, display an error message
                    catch (Exception)
                    {
                        MessageBox.Show("An error has occurred while updating the record.");
                    }
                }
            }

            else
            {
                MessageBox.Show("Please fill in both the 'From' and 'To' stations.");
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DateTime date;
            DateTime time;

            try
            {
                // Parse date and time inputs
                date = DateTime.Parse(reservation_date.Text);
                time = DateTime.Parse(reservation_time.Text);
            }
            catch (Exception)
            {
                // Handle input parsing errors
                MessageBox.Show("Error processing data! Please check your inputs.");

                return; // Prevent the next code from executing if inputs are invalid
            }

            // Check if both 'From' and 'To' stations are provided
            if (textBox_from.Text.Length >= 1 && textBox_to.Text.Length >= 1)
            {
                // SQL query to search for a matching bus record (ignoring price)
                string query = @"SELECT price 
                                FROM bus_data 
                                WHERE departing_station = @From 
                                AND destination_station = @To 
                                AND date = @Date 
                                AND time = @Time";

                using (SqlConnection conn = new SqlConnection(main.ConnectionString))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Assign values to the parameters
                            cmd.Parameters.AddWithValue("@From", textBox_from.Text);
                            cmd.Parameters.AddWithValue("@To", textBox_to.Text);
                            cmd.Parameters.AddWithValue("@Date", date.Date);
                            cmd.Parameters.AddWithValue("@Time", time.TimeOfDay);

                            // Execute the query and read the result
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                // If a record is found
                                if (reader.Read())
                                {
                                    // Retrieve the price
                                    decimal price = reader.GetDecimal(0);

                                    // Display the price
                                    MessageBox.Show($"Record found! Price: LKR {price}");
                                }

                                // If no record matches the search criteria
                                else
                                {
                                    MessageBox.Show("No matching bus record found.");
                                }
                            }
                        }
                    }

                    // If there's an error, display an error message
                    catch (Exception)
                    {
                        MessageBox.Show("An error has occurred while searching for the record.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill in both the 'From' and 'To' stations.");
            }
        }
    }
}
