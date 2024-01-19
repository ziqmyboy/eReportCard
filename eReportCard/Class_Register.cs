using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace eReportCard
{
    public partial class Class_Register : Form
    {
        DataTable dt = new DataTable();

        //connection to database
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "jr3Tt5PfFktmLn3JjSWf6Wl0fW3xj22b00TywSk4",
            BasePath = "https://ereportcard767-1f7ba-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;
        //date variable
        string date = DateTime.Now.Month.ToString();

        string gender;

        //
        public static string student_FullName;

        public Class_Register()
        {
            InitializeComponent();



            lblSchool_Name.Text = Login.schoolID;

            // getting school year
            if (date == "9" || date == "10" || date == "11" || date == "12")
            {
                lblSchool_Year.Text = DateTime.Now.Year.ToString() + " - " + DateTime.Now.AddMonths(12).Year;
                lblTerm.Text = "1st Term";
            }
            else if (date == "1" || date == "2" || date == "3" || date == "4")
            {
                lblSchool_Year.Text = DateTime.Now.AddMonths(-12).Year + " - " + DateTime.Now.Year.ToString();
                lblTerm.Text = "2nd Term";
            }
            else if (date == "5" || date == "6" || date == "7" || date == "8")
            {
                lblSchool_Year.Text = DateTime.Now.AddMonths(-12).Year + " - " + DateTime.Now.Year.ToString();
                lblTerm.Text = "3rd Term";
            }

            lblClassID.Text = Login.classID + "\nClass Register";
            txtF_Name.Focus();

        }

        private async void Class_Register_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            //adding columns to datagridview on startup.
            dt.Columns.Add("Student Name");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Age");

            dgvClass_Register.DataSource = dt;

            dt.Rows.Clear();

            FirebaseResponse resp = await client.GetAsync("USERS/" + Login.uID);
            Users get = resp.ResultAs<Users>();

            if (get.rcData == "NO DATA")
            {
                var rCnt = new Counter_Class
                {
                    cnt = "0"
                };

                SetResponse re = await client.SetAsync("RegisterCOUNTER/" + lblSchool_Name.Text + "/" + Login.classID + "/" + lblSchool_Year.Text + "/Students/", rCnt);
                Counter_Class r = re.ResultAs<Counter_Class>();
                return;
            }
            


            //getting list of registered students from db
            int i = 0;
            FirebaseResponse fresp = client.Get(@"RegisterCOUNTER/" + lblSchool_Name.Text + "/" + Login.classID + "/" + lblSchool_Year.Text + "/Students/");
            Counter_Class result1 = fresp.ResultAs<Counter_Class>();
            int cnt = Convert.ToInt32(result1.cnt);

            while (true)
            {

                if (i == cnt)
                {
                    break;
                }
                i++;

                try
                {
                    FirebaseResponse res = client.Get(@"REGISTER/" + lblSchool_Name.Text + "/" + Login.classID + "/" + lblSchool_Year.Text + "/Students/" + i);
                    Register_Data name = res.ResultAs<Register_Data>();

                    DataRow row = dt.NewRow();
                    row["Student Name"] = name.FullName;
                    row["Gender"] = name.Gender;
                    row["Age"] = name.Age;

                    dt.Rows.Add(row);

                }
                catch
                {
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            btnAdd.Text = "Adding...";

            string fn = txtF_Name.Text; string ln = txtL_Name.Text; student_FullName = fn + " " + ln;

            if (!string.IsNullOrWhiteSpace(txtF_Name.Text))
            {
                if (!string.IsNullOrWhiteSpace(txtL_Name.Text))
                {
                    if (!string.IsNullOrWhiteSpace(cbAge.Text))
                    {
                        if (rbMale.Checked)
                        {
                            gender = "Male";
                            addChildToDatabaseAndDataGrideView();
                        }
                        else if (rbFemale.Checked)
                        {
                            gender = "Female";
                            addChildToDatabaseAndDataGrideView();
                        }
                        else
                        {
                            MessageBox.Show("Student gender was not chosen.", "Gender");
                            btnAdd.Text = "Add Student";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please ensure all fields are entered properly.", "E R R O R");
                        btnAdd.Text = "Add Student";
                    }
                }
                else
                {
                    MessageBox.Show("Please ensure all fields are entered properly.", "E R R O R");
                    btnAdd.Text = "Add Student";
                }
            }
            else
            {
                MessageBox.Show("Please ensure all fields are entered properly.", "E R R O R");
                btnAdd.Text = "Add Student";
            }
        
    }

        private async void addChildToDatabaseAndDataGrideView()
        {
            btnAdd.Text = "Adding...";

            FirebaseResponse resp1 = await client.GetAsync("RegisterCOUNTER/" + lblSchool_Name.Text + "/" + Login.classID + "/" + lblSchool_Year.Text + "/Students/");
            Counter_Class get = resp1.ResultAs<Counter_Class>();

            var register = new Register_Data
            {
                id = (Convert.ToInt32(get.cnt) + 1).ToString(),
                FullName = student_FullName.ToUpper(),
                Age = cbAge.Text,
                Gender = gender,
                StudentID = lblStudent_ID.Text
            };

            SetResponse response = await client.SetAsync("REGISTER/" + lblSchool_Name.Text + "/" + Login.classID + "/" + lblSchool_Year.Text + "/" + "Students" + "/" + register.id, register);
            Register_Data result = response.ResultAs<Register_Data>();

            var obj = new Counter_Class
            {
                cnt = register.id
            };

            SetResponse resp2 = await client.SetAsync("RegisterCOUNTER/" + lblSchool_Name.Text + "/" + Login.classID + "/" + lblSchool_Year.Text + "/Students/", obj);
            Counter_Class results = resp2.ResultAs<Counter_Class>();


            var counter_class = new Counter_Class
            {
                cnt = "0"
            };

            SetResponse response1 = await client.SetAsync("COUNTER/" + lblSchool_Name.Text + "/" + Login.classID + "/" + lblSchool_Year.Text + "/" + lblTerm.Text + "/" + student_FullName.ToUpper(), counter_class);
            Counter_Class result1 = response.ResultAs<Counter_Class>();

            var users = new Users
            {
                ClassID = Login.classID,
                NameID = Login.nameID,
                PassID = Login.pass,
                ProfessionID = Login.professionID,
                SchoolID = Login.schoolID,
                UserID = Login.uID,
                rcData = "DATA"
            };

            //resaving data of registered user with rcDATA to database
            SetResponse response3 = await client.SetAsync("USERS/" + Login.uID, users);
            Users result3 = response3.ResultAs<Users>();


            //getting list of registered students from db
            int i = 0;
            FirebaseResponse fresp = client.Get(@"RegisterCOUNTER/" + lblSchool_Name.Text + "/" + Login.classID + "/" + lblSchool_Year.Text + "/Students/");
            Counter_Class result2 = fresp.ResultAs<Counter_Class>();
            int cnt = Convert.ToInt32(result2.cnt);
            dt.Rows.Clear();

            while (true)
            {

                if (i == cnt)
                {
                    break;
                }
                i++;

                try
                {
                    FirebaseResponse res = client.Get(@"REGISTER/" + lblSchool_Name.Text + "/" + Login.classID + "/" + lblSchool_Year.Text + "/Students/" + i);
                    Register_Data name = res.ResultAs<Register_Data>();

                    DataRow row = dt.NewRow();
                    row["Student Name"] = name.FullName;
                    row["Gender"] = name.Gender;
                    row["Age"] = name.Age;

                    dt.Rows.Add(row);

                }
                catch
                {
                }
            }
            
            txtF_Name.Text = "";
            txtL_Name.Text = "";
            lblStudent_ID.Text = "------------";
            rbMale.Checked = false;
            rbFemale.Checked = false;
            cbAge.Text = " ";
            btnAdd.Text = "Add Student";

        }


        private void txtF_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ensures only letter values into textbox
            char ch = e.KeyChar;

            if (!char.IsLetter(ch) && ch != 8 && ch != 46 && ch != 32)
            {
                e.Handled = true;

            }
        }

        private void txtL_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ensures only letter values into textbox
            char ch = e.KeyChar;

            if (!char.IsLetter(ch) && ch != 8 && ch != 46 && ch != 32)
            {
                e.Handled = true;

            }
        }

        //creating student unique identification
        private void txtL_Name_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtF_Name.Text) && !string.IsNullOrEmpty(txtL_Name.Text))
            {
                //setting unique identification for student
                txtF_Name.SelectionStart = 0;
                txtF_Name.SelectionLength = 1;
                txtL_Name.SelectionStart = 0;
                txtL_Name.SelectionLength = 3;

                lblStudent_ID.Text = (txtF_Name.SelectedText + txtL_Name.SelectedText).ToUpper() + DateTime.Now.Month.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
            }
        }


        private void lblEdit_StudentID_Click(object sender, EventArgs e)
        {
            if (lblEdit_StudentID.Text == "done")
            {
                if (string.IsNullOrEmpty(txtTransfered_StudentID.Text))
                {
                    if (MessageBox.Show("Please Enter Student I.D.", "MISSING!!!", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        lblEdit_StudentID.Focus();
                        txtTransfered_StudentID.Visible = false;
                        lblEdit_StudentID.Text = "edit";
                        lblStudent_ID.Text = "------------";
                        lblStudent_ID.Visible = true;
                    }
                }
                else
                {
                    rbMale.Focus();
                    lblStudent_ID.Text = txtTransfered_StudentID.Text;
                    txtTransfered_StudentID.Visible = false;
                    lblEdit_StudentID.Text = "edit";
                    lblStudent_ID.Visible = true;
                }
            }
            else
            {
                rbMale.Focus();
                txtTransfered_StudentID.Visible = true;
                txtTransfered_StudentID.Focus();
                lblEdit_StudentID.Text = "done";
                lblStudent_ID.Visible = false;
            }
        }
    }
}
