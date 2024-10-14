using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BellaReservations
{
    public partial class register : Form
    {
        Form PreviousForm;

        public register(Form previousForm)
        {
            InitializeComponent();
            PreviousForm = previousForm;
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
        }

        // When the user has clicked the previous form button
        private void previous_form_btn_Click(object sender, EventArgs e)
        {
            PreviousForm.FormClosing += delegate { Application.Exit(); };

            // Show the previous form
            PreviousForm.Show();

            // Hide the current form
            this.Hide();
        }

        private void account_creation_button_Click(object sender, EventArgs e)
        {
            // Retrieve values from input fields
            string name = name_field.Text.Trim();
            string nic = nic_field.Text.Trim();
            string username = username_field.Text.Trim();
            string password = password_field.Text.Trim();
            string mobile = mobile_field.Text.Trim();
            string address = address_field.Text.Trim();
            string email = email_field.Text.Trim();
            string nationality = nationality_selection.Text.Trim();

            // If any of the fields contain whitespaces or no characters
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(nic) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(mobile) || string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(nationality))
            {
                // Display an error message
                MessageBox.Show("Please fill out all the fields!");
                
                return; // This "return" keyword prevents the rest of the code from running if one or more fields are empty
            }

            // If the password has less than 16 characters
            // This condition checks if the password's length is less than 16 characters
            else if (password.Length < 16)
            {
                // Display an error message
                MessageBox.Show("The password must contain 16 - 24 characters!");

                return;
            }

            // If the username has less than 7 characters
            else if (username.Length < 7)
            {
                // Display an error message
                MessageBox.Show("The username must be 7 characters in length!");

                return;
            }

            // Query to INSERT retrieved data to the database
            string query = @"INSERT INTO customer (name, nic, username, password, mobile, address, email, nationality) 
                             VALUES (@name, @nic, @username, @password, @mobile, @address, @email, @nationality)";

            try
            {
                using (SqlConnection conn = new SqlConnection(main.ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to the command
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@nic", nic);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@mobile", mobile);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@nationality", nationality);

                        // Execute the query and get the number of rows affected
                        int rowsAffected = cmd.ExecuteNonQuery();
                        
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account created successfully!");
                        }

                        // If no rows are affected, it could've happened because of our unique key "username"
                        // A column with a unique key constraint allows no duplicate values, so it'll generate
                        // an error if the username is repeated.
                        else
                        {
                            // Display the error message
                            MessageBox.Show("The username you entered is already in use.");
                        }
                    }
                }
            }

            // If there's an error, display an error message
            catch (Exception error)
            {
                MessageBox.Show("An error has occurred during the registration!");
                Console.WriteLine($"Error: {error.Message}");
            }
        }
    }
}
