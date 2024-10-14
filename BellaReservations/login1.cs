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
    public partial class login1 : Form
    {
        // Step 01: First create a variable for storing the current form
        Form PreviousForm;

        // Step 2: Add the variable we created as a parameter
        public login1(Form previousForm)
        {
            InitializeComponent();

            // Step 3: Store the previous form within the variable we created
            PreviousForm = previousForm;
        }

        private const string CorrectUsername = "admin";
        private const string CorrectPassword = "123";

        public login1()
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

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == CorrectUsername && password == CorrectPassword)
            {
                MessageBox.Show("Login Succesful!");

                // Step 4: The "this" keyword stores the current state of the form
                selection2 fm = new selection2(this);

                // Close the application when destination form closes
                fm.FormClosing += delegate { Application.Exit(); };

                fm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect username or password. Please try again.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PreviousForm.Show();

            // Close the application when destination form closes
            PreviousForm.FormClosing += delegate { Application.Exit(); };

            this.Hide();
        }
    }
}
