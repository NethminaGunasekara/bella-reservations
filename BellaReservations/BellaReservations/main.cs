using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BellaReservations
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login1 fm = new login1();

            // Step 4: The "this" keyword stores the current state of the form
            login1 fm2 = new login1(this);

            // Close the application when destination form closes
            fm.FormClosing += delegate { Application.Exit(); };

            fm.Show();
            this.Hide();
        }
    }
}
