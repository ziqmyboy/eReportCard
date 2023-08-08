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
    public partial class Profession_Institution : Form
    {

        public static string profession;
        public static string institution;

        

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
        public Profession_Institution()
        {
            InitializeComponent();

            //code to make rounded corners for screen, changing numbers after the height will increase or decrease the corner radius
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            //code to create button corner radius
            btnContinue.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnContinue.Width, btnContinue.Height, 25, 25));


            string time = DateTime.Now.Hour.ToString();
            if (time == "18" || time == "19" || time == "20" || time == "21" || time == "22" || time == "23")
            {
                lblWelcome_Message.Text = "Good Evening";
            }
            else if (time == "0" || time == "1" || time == "2" || time == "3" || time == "4" || time == "5" || time == "6" || time == "7" || time == "8" || time == "9")
            {
                lblWelcome_Message.Text = "Good Morning";
            }
            else if (time == "10" || time == "11")
            {
                lblWelcome_Message.Text = "Good Day";
            }
            else if ( time == "12" || time == "13" || time == "14" || time == "15" || time == "16" || time == "17")
            {
                lblWelcome_Message.Text = "Good Afternoon";
            }
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            //opening the login page
            Login login = new Login();
            login.Show();

            //closing the window
            this.Hide();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (rbPrincipal.Checked == true)
            {
                profession = "Principal";

                //opening the Register page
                Register register = new Register();
                register.Show();

                //closing the window
                this.Hide();
            }
            else if (rbTeacher.Checked == true)
            {
                profession = "Teacher";
                //opening the Register page
                Register register = new Register();
                register.Show();

                //closing the window
                this.Hide();
            }
            else if (rbPrimarySchool.Checked == true)
            {
                
                //opening the Register page
                Register register = new Register();
                register.Show();

                //closing the window
                this.Hide();
            }

            /*todo
             * create more ifies when other institutions comes on board eg: preschools, secondary etc....
             */
            else if (rbPrimarySchool.Checked == false)
            {
                MessageBox.Show("Please select Institution level.", "Required!");
            }
        }

        private void rbPrincipal_CheckedChanged(object sender, EventArgs e)
        {
            lblTxt_Institution.Text = "What institution of learning are you the Principal of?";
            lblTxt_Institution.Visible = true;
            //rbPrimarySchool.Visible = true;
            //rbSecondarySchool.Visible = true;
            rbPreSchool.Visible = true;
        }

        private void rbTeacher_CheckedChanged(object sender, EventArgs e)
        {
            lblTxt_Institution.Text = "What institution of learning are you a Teacher of?";
            lblTxt_Institution.Visible = true;
            //rbPrimarySchool.Visible = true;
            //rbSecondarySchool.Visible = true;
            rbPreSchool.Visible = true;
        }

        private void rbPrimarySchool_CheckedChanged(object sender, EventArgs e)
        {
            btnContinue.Enabled = true;
            institution = "Primary School";
        }

        private void rbSecondarySchool_CheckedChanged(object sender, EventArgs e)
        {
            /*
            btnContinue.Enabled = true;
            institution = "Secondary School";
            */
        }

        private void rbPreSchool_CheckedChanged(object sender, EventArgs e)
        {
            btnContinue.Enabled = true;
            institution = "Pre School";
        }
    }
    }
