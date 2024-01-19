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
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Security.Cryptography;

namespace eReportCard
{
    public partial class Login : Form
    {
        //connection to database
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "jr3Tt5PfFktmLn3JjSWf6Wl0fW3xj22b00TywSk4",
            BasePath = "https://ereportcard767-1f7ba-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

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


        public static string uID;
        public static string pass;
        public static string nameID;
        public static string professionID;
        public static string classID;
        public static string schoolID;
        public static string rcDATA;


        public Login()
        {
            InitializeComponent();

            //code to make rounded corners for screen, changing numbers after the height will increase or decrease the corner radius
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            //code to create button corner radius
            btnLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 25, 25));

            txtUsername.Text = Register.newUsername;
        }

        //method for encrypting user password.
        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginUser();
        }

        //login user method
        private async void loginUser()
        {
            btnLogin.Text = "Loading....";
            btnLogin.ForeColor = Color.LightSeaGreen;

            //error checking
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                MessageBox.Show("Username and Password fields required.", "ERROR!!!");
                txtUsername.Focus();
                btnLogin.Text = "LOG IN";
                btnLogin.ForeColor = Color.FromArgb(0, 117, 214);
            }
            else
            {
                //querry the firebase
                FirebaseResponse response = await client.GetAsync("USERS/" + txtUsername.Text);
                if (response.Body.ToString() != "null") {
                    Users users = response.ResultAs<Users>();
                    uID = users.UserID;
                    pass = users.PassID;
                    professionID = users.ProfessionID;
                    nameID = users.NameID;
                    classID = users.ClassID;
                    schoolID = users.SchoolID;
                    rcDATA = users.rcData;

                    if (users.UserID == txtUsername.Text && users.PassID == Encrypt(txtPassword.Text) && professionID == "Teacher")
                    {
                        //opening the Teacher's Home page
                        Teacher_Home_Form teacher_Home_Form = new Teacher_Home_Form();
                        teacher_Home_Form.Show();


                        //closing login page
                        this.Hide();

                    }
                    else if (users.UserID == txtUsername.Text && users.PassID == Encrypt(txtPassword.Text) && professionID == "Principal")
                    {

                        //opening the Teacher's Home page
                        Principal_Home_Form principal_Home_Form = new Principal_Home_Form();
                        principal_Home_Form.Show();

                        //closing login page
                        this.Hide();
                    }
                }
                else
                {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    MessageBox.Show("Your username or password is incorrect.", "Invalid User!");
                    txtUsername.Focus();
                    btnLogin.Text = "LOG IN";
                    btnLogin.ForeColor = Color.FromArgb(0, 117, 214);
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //opening the Register page
            Profession_Institution profession_Institution = new Profession_Institution();
            profession_Institution.Show();

            //closing login page
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
        }

        private void pb_Show_Hide_Password_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void pb_Show_Hide_Password_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginUser();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginUser();
            }
        }
    }
}
