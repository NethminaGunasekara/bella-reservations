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
    public partial class login : Form
    {
        // Step 01: First create a variable for storing the current form
        Form PreviousForm;

        // Step 2: Add the variable we created as a parameter
        public login(Form previousForm)
        {
            InitializeComponent();

            // Step 3: Store the previous form within the variable we created
            PreviousForm = previousForm;
        }

        private const string CorrectUsername = "admin";
        private const string CorrectPassword = "123";

        public login()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void set_background(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(0, 0, 0), Color.FromArgb(57, 128, 227), 65f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login(object sender, EventArgs e)
        {
            string username = username_field.Text;
            string password = password_field.Text;

            // Display an error message if no username or password is entered
            if (username.Length == 0 && password.Length == 0)
            {
                // Display an error message indicating that no password is entered
                MessageBox.Show("Please enter a username and password to continue!");

                return; // Terminate the method as we can't proceed to login without a username and password
            }

            // If both username and password are present, continue to login

            // Check credentials in admin table
            using (SqlConnection conn = new SqlConnection(main.ConnectionString))
            {
                conn.Open();

                string query = "SELECT admin_id, name FROM admin WHERE username = @username AND password = @password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Assign parameters to command
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Admin login successful
                            main.UserId = reader.GetInt32(0); // admin_id
                            string adminName = reader.GetString(1); // name
                            main.UserRole = "ADMIN";
                            MessageBox.Show($"Login successful! Welcome, {adminName} (Admin).");

                            // Initialize the transport mode selection form
                            selection selection = new selection(this);

                            // Show the transport mode selection form
                            selection.Show();

                            // Hide the current form
                            this.Hide();

                            return;
                        }
                    }
                }

                // Check credentials in customer table
                query = "SELECT customer_id, name FROM customer WHERE username = @username AND password = @password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Assign parameters to command
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Customer login successful
                            main.UserId = reader.GetInt32(0); // customer_id
                            string customerName = reader.GetString(1); // name
                            main.UserRole = "CUSTOMER";
                            MessageBox.Show($"Login successful! Welcome, {customerName} (Customer).");

                            // Initialize the transport mode selection form
                            selection selection = new selection(this);

                            // Show the transport mode selection form
                            selection.Show();

                            // Hide the current form
                            this.Hide();

                            return;
                        }
                    }
                }
            }

            // If no login was successful
            MessageBox.Show("Login failed! Incorrect username or password.");
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