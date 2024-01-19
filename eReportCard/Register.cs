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
    public partial class Register : Form
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


        //declaring global variables.
        public static string newUsername;
        public static string newPassword;
        public static string name;
        public static string school;
        public static string grade;

        public string institutions;
        public string uID;
        public string pass;


        public Register()
        {
            InitializeComponent();

            //code to make rounded corners for screen, changing numbers after the height will increase or decrease the corner radius
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            //code to create button corner radius
            btnRegister.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnRegister.Width, btnRegister.Height, 25, 25));

            lblTeacher_Principal.Text = Profession_Institution.profession;

            institutions = Profession_Institution.institution;
            

            if (lblTeacher_Principal.Text == "Principal")
            {
                lblClassID_Label.Visible = false;
                cbClassID.Visible = false;
                plClassID.Visible = false;
            }
            if (institutions == "Primary School")
            {
                //adding names of intitutions based on level selected
                txtSchoolName.Items.AddRange(new object[] { "Dublanc Bioche Primary School"/*add more schools here*/ });
                txtSchoolName.AutoCompleteCustomSource.AddRange(new string[] { "Dublanc Bioche Primary School"/*add more schools here*/ });

                //adding class level
                cbClassID.Items.AddRange(new object[] { "Grade K", "Grade 1", "Grade 2", "Grade 3", "Grade 4", "Grade 5", "Grade 6" });
                cbClassID.AutoCompleteCustomSource.AddRange(new string[] { "Grade K", "Grade 1", "Grade 2", "Grade 3", "Grade 4", "Grade 5", "Grade 6" });
            }
            else if (institutions == "Secondary School")
            {
                txtSchoolName.Items.AddRange(new object[] { "Castle Bruce Secondary"/*add more schools here*/ });
                txtSchoolName.AutoCompleteCustomSource.AddRange(new string[] { "Castle Bruce Secondary"/*add more schools here*/ });
            }
            
        }

        private void Register_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            //opening the Profession_Institution page
            Profession_Institution profession_Institution = new Profession_Institution();
            profession_Institution.Show();

            //closing login page
            this.Hide();
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

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            btnRegister.Text = "Registering....";
            btnRegister.ForeColor = Color.LightSeaGreen;

            //error checking
            if (string.IsNullOrWhiteSpace(txtNewUsername.Text))
            {
                pTxtNewUser.BackColor = Color.Red;
                MessageBox.Show("Username field required.", "ERROR!!!");
                txtNewUsername.Focus();
                btnRegister.Text = "REGISTER";
                btnRegister.ForeColor = Color.FromArgb(0, 117, 214);
            }
            else if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                pTxtNewPassword.BackColor = Color.Red;
                MessageBox.Show("Password field required.", "ERROR!!!");
                txtNewPassword.Focus();
                btnRegister.Text = "REGISTER";
                btnRegister.ForeColor = Color.FromArgb(0, 117, 214);
            }
            else if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text) || txtNewPassword.Text != txtConfirmPassword.Text)
            {
                pTxtConfirmPassword.BackColor = Color.Red;
                MessageBox.Show("Password fields are not the same.", "ERROR!!!");
                btnRegister.Text = "REGISTER";
                btnRegister.ForeColor = Color.FromArgb(0, 117, 214);
            }
            else if (string.IsNullOrWhiteSpace(txtTeacher_Principal_Name.Text))
            {
                pTxtPrincipal_Teacher.BackColor = Color.Red;
                MessageBox.Show("Name field required.", "ERROR!!!");
                txtTeacher_Principal_Name.Focus();
                btnRegister.Text = "REGISTER";
                btnRegister.ForeColor = Color.FromArgb(0, 117, 214);
            }
            else if (string.IsNullOrWhiteSpace(txtSchoolName.Text))
            {
                pTxtSchoolName.BackColor = Color.Red;
                MessageBox.Show("School name field required.", "ERROR!!!");
                txtSchoolName.Focus();
                btnRegister.Text = "REGISTER";
                btnRegister.ForeColor = Color.FromArgb(0, 117, 214);
            }
            else if (Profession_Institution.profession == "Teacher" && cbClassID.Text == string.Empty)
            {
                plClassID.BackColor = Color.Red;
                MessageBox.Show("Class ID is required.", "ERROR!!!");
                cbClassID.Focus();
                btnRegister.Text = "REGISTER";
                btnRegister.ForeColor = Color.FromArgb(0, 117, 214);
            }
            else if (Profession_Institution.profession == "Teacher")
            {

                //getting the count of current registered users
                FirebaseResponse resp = await client.GetAsync("UserCOUNTER");
                Counter_Class get = resp.ResultAs<Counter_Class>();

                //converting the count into an integer and placing it into the variable "Counter"
                int Counter = int.Parse(get.cnt);

                //database draws the data in the form of an object class
                //creating an object

                var user = new Users
                {
                    id = (Convert.ToInt32(get.cnt) + 1).ToString(),
                    UserID = txtNewUsername.Text,
                    PassID = Encrypt(txtNewPassword.Text),
                    ClassID = cbClassID.Text,
                    NameID = txtTeacher_Principal_Name.Text,
                    ProfessionID = Profession_Institution.profession,
                    SchoolID = txtSchoolName.Text,

                    //identification to know if reportcard data has been enter under teacher class
                    rcData = "NO DATA"
                };

                // forloop to catch if username already exist.
                for (int i = 1; i <= Counter; i++)
                {
                    FirebaseResponse resp1 = await client.GetAsync("UserCounterList/" + i);
                    Users UID = resp1.ResultAs<Users>();

                    string compUID = UID.UserID;

                    if (compUID == txtNewUsername.Text)
                    {
                        pTxtNewUser.BackColor = Color.Red;
                        MessageBox.Show("Username already Taken. Please enter a different name", "E X I S T S");
                        btnRegister.Text = "REGISTER";
                        btnRegister.ForeColor = Color.FromArgb(0, 117, 214);
                        return;
                    }
                }

                //incrementing the count variable
                var obj = new Counter_Class
                {
                    cnt = user.id
                };

                UserCounter uID = new UserCounter()
                {
                    UserID = txtNewUsername.Text,
                };

                //saving data of registered user to database
                SetResponse response = await client.SetAsync("USERS/" + txtNewUsername.Text, user);
                Users result = response.ResultAs<Users>();

                //saving the total count of the registered users
                SetResponse response1 = await client.SetAsync("UserCOUNTER/", obj);
                Counter_Class result1 = response1.ResultAs<Counter_Class>();

                //saving current user count along with their username ID
                SetResponse response2 = await client.SetAsync("UserCounterList/" + user.id, uID);
                Users result2 = response2.ResultAs<Users>();

             
                //setting global variables to respective fields
                newUsername = txtNewUsername.Text.Trim();
                newPassword = txtNewPassword.Text.Trim();
                name = txtTeacher_Principal_Name.Text.Trim();
                school = txtSchoolName.Text.Trim();
                grade = cbClassID.Text.Trim();

                //opening the login page
                Login login = new Login();
                login.Show();

                //closing the splash screen
                this.Hide();

            }
            else if (Profession_Institution.profession == "Principal")
            {
                //getting the count of current registered users
                FirebaseResponse resp = await client.GetAsync("UserCOUNTER");
                Counter_Class get = resp.ResultAs<Counter_Class>();

                //converting the count into an integer and placing it into the variable "Counter"
                int Counter = int.Parse(get.cnt);

                //database draws the data in the form of an object class
                //creating an object

                var user = new Users
                {
                    id = (Convert.ToInt32(get.cnt) + 1).ToString(),
                    UserID = txtNewUsername.Text,
                    PassID = Encrypt(txtNewPassword.Text),
                    NameID = txtTeacher_Principal_Name.Text,
                    ProfessionID = Profession_Institution.profession,
                    SchoolID = txtSchoolName.Text
                };

                // forloop to catch if username already exist.
                for (int i = 1; i <= Counter; i++)
                {
                    FirebaseResponse resp1 = await client.GetAsync("UserCounterList/" + i);
                    Users UID = resp1.ResultAs<Users>();

                    string compUID = UID.UserID;

                    if (compUID == txtNewUsername.Text)
                    {
                        pTxtNewUser.BackColor = Color.Red;
                        MessageBox.Show("Username already Taken. Please enter a different name", "E X I S T S");
                        return;
                    }
                }

                //incrementing the count variable
                var obj = new Counter_Class
                {
                    cnt = user.id
                };

                UserCounter uID = new UserCounter()
                {
                    UserID = txtNewUsername.Text
                };

                //saving data of registered user to database
                SetResponse response = await client.SetAsync("USERS/" + txtNewUsername.Text, user);
                Users result = response.ResultAs<Users>();

                //saving the total count of the registered users                //
                SetResponse response1 = await client.SetAsync("UserCOUNTER/", obj);
                Counter_Class result1 = response1.ResultAs<Counter_Class>();

                //saving current user count along with their username ID
                SetResponse response2 = await client.SetAsync("UserCounterList/" + user.id, uID);
                Users result2 = response2.ResultAs<Users>();


                //setting global variables to respective fields
                newUsername = txtNewUsername.Text.Trim();
                newPassword = txtNewPassword.Text.Trim();
                name = txtTeacher_Principal_Name.Text.Trim();
                school = txtSchoolName.Text.Trim();
                grade = cbClassID.Text.Trim();

                //opening the login page
                Login login = new Login();
                login.Show();

                //closing the splash screen
                this.Hide();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //opening the login page
            Login login = new Login();
            login.Show();

            //closing the splash screen
            this.Hide();
        }
    }
}
