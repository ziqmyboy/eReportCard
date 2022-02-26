using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace eReportCard
{
    public partial class SplashScreen : Form
    {
        //initialize integer variable for timer
        private int _start;

        //code to make rounded corners for screen
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int RightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse

            );

        public SplashScreen()
        {
            InitializeComponent();

            //code to make rounded corners for screen, changing numbers after the height will increase or decrease the corner radius
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //incrementing timer by one on every tick
            _start++;

            if (_start == 7)
            {
                //stopping the timer
                timer1.Enabled = false;

                //opening the login page
                Login login = new Login();
                login.Show();

                //closing the splash screen
                this.Hide();
            }
        }
    }
}
