using System;
using System.Windows.Forms;

namespace BellaReservations
{
    public partial class main : Form
    {
        // Application's connection string
        public static string ConnectionString = "Data Source=NETHMINA\\SQLEXPRESS;Initial Catalog=bellareservations;Integrated Security=True;Encrypt=False";
        
        // Id of the currently logged in user
        public static int UserId;

        // Role of the currently logged in user
        public static string UserRole;

        public main()
        {
            InitializeComponent();
        }

        // Show the login form
        private void button1_Click(object sender, EventArgs e)
        {
            login fm = new login();

            // Step 4: The "this" keyword stores the current state of the form
            login fm2 = new login(this);

            // Close the application when destination form closes
            fm.FormClosing += delegate { Application.Exit(); };

            fm.Show();
            Hide();
        }

        // When the user has clicked the login button
        private void login_button_Click(object sender, EventArgs e)
        {
            // Pass "this" form as a parameter, so that we can return to this form
            // from the login form when the previous form button is clicked
            login loginFrm = new login(this);

            // Close the application when destination form closes
            loginFrm.FormClosing += delegate { Application.Exit(); };

            // Show the login form
            loginFrm.Show();

            // Hide the current form
            Hide();
        }

        // When the user has clicked the register button
        private void register_button_Click(object sender, EventArgs e)
        {
            register registerFrm = new register(this);
            
            registerFrm.FormClosing += delegate { Application.Exit(); };
            registerFrm.Show();

            Hide();
        }
    }
}
