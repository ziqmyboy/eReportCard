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

            lblSchool_Name.Text = Login.schoolID + " School";

            // getting school year
            if (date == "9" || date == "10" || date == "11" || date == "12")
            {
                lblSchool_Year.Text = DateTime.Now.Year.ToString() + " - " + DateTime.Now.AddMonths(12).Year;
                lblTerm.Text = "1st Term";
            }
            else if (date == "1" || date == "2" || date == "3")
            {
                lblSchool_Year.Text = DateTime.Now.AddMonths(-12).Year + " - " + DateTime.Now.Year.ToString();
                lblTerm.Text = "2nd Term";
            }
            else if (date == "4" || date == "5" || date == "6")
            {
                lblSchool_Year.Text = DateTime.Now.AddMonths(-12).Year + " - " + DateTime.Now.Year.ToString();
                lblTerm.Text = "3rd Term";
            }

            lblClassID.Text = Login.classID + "\nClass Register";
            txtF_Name.Focus();
                
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            //
            
            string fn = txtF_Name.Text; string ln = txtL_Name.Text; student_FullName = fn + " " + ln;

            if (!string.IsNullOrWhiteSpace(txtF_Name.Text) || !string.IsNullOrWhiteSpace(txtL_Name.Text) || !string.IsNullOrWhiteSpace(cbAge.Text))
            {
                if (rbMale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                var register = new Register_Data
                {
                    FName = txtF_Name.Text,
                    LName = txtL_Name.Text,
                    Age = cbAge.Text,
                    Gender = gender,
                    StudentID = lblStudent_ID.Text
                };
                SetResponse response = await client.SetTaskAsync("REGISTER/" + lblSchool_Name.Text + "/" + Login.classID + "/" + lblSchool_Year.Text + "/" + student_FullName, register);
                Register_Data result = response.ResultAs<Register_Data>();


                var counter_class = new Counter_Class
                {
                    cnt = "0"
                };

                SetResponse response1 = await client.SetTaskAsync("COUNTER/" + lblSchool_Name.Text + "/" + Login.classID + "/" + lblSchool_Year.Text + "/" + lblTerm.Text + "/" + student_FullName, counter_class);
                Counter_Class result1 = response.ResultAs<Counter_Class>();

                //adding data from textboxes to datagridview
                int n = dgvClass_Register.Rows.Add();
                dgvClass_Register.Rows[n].Cells[0].Value = student_FullName;
                if (rbMale.Checked)
                {
                    dgvClass_Register.Rows[n].Cells[1].Value = "Male";
                    gender = "Male";
                }
                else if (rbFemale.Checked)
                {
                    dgvClass_Register.Rows[n].Cells[1].Value = "Female";
                    gender = "Female";
                }
                else
                {
                    MessageBox.Show("Student gender was not chosen.", "Gender");
                }

                dgvClass_Register.Rows[n].Cells[2].Value = cbAge.Text;

                txtF_Name.Text = "";
                txtL_Name.Text = "";
                rbMale.Checked = false;
                rbFemale.Checked = false;
                cbAge.Text = "";

                

            }
            else
            {
                MessageBox.Show("Please ensure all fields are entered properly.", "E R R O R");
            }
        }

        private void btnSave_Class_Register_Click(object sender, EventArgs e)
        {
            //saving the class register to local database xml file
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "ClassRegister";
            dt.Columns.Add("StudentName");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Age");
            ds.Tables.Add(dt);
            foreach (DataGridViewRow r in dgvClass_Register.Rows)
            {
                DataRow row = ds.Tables["ClassRegister"].NewRow();
                row["StudentName"] = r.Cells[0].Value;
                row["Gender"] = r.Cells[1].Value;
                row["Age"] = r.Cells[2].Value;
                ds.Tables["ClassRegister"].Rows.Add(row);
            }
            ds.WriteXml(Environment.CurrentDirectory + "\\XMLFILE.xml");

        }

        private void btnShow_Class_Register_Click(object sender, EventArgs e)
        {

            //populating dgvClass Register.

            DataSet ds = new DataSet();
            ds.ReadXml(Environment.CurrentDirectory + "\\XMLFILE.xml");
            dgvClass_Register.Rows.Clear();
            foreach (DataRow item in ds.Tables["ClassRegister"].Rows)
            {
                int n = dgvClass_Register.Rows.Add();
                dgvClass_Register.Rows[n].Cells[0].Value = item[0];
                dgvClass_Register.Rows[n].Cells[1].Value = item[1];
                dgvClass_Register.Rows[n].Cells[2].Value = item[2];
            }

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


        private void Class_Register_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            /*
            //populating dgvClass Register.

            DataSet ds = new DataSet();
            ds.ReadXml(Environment.CurrentDirectory + "\\XMLFILE.xml");
            dgvClass_Register.Rows.Clear();
            foreach (DataRow item in ds.Tables["ClassRegister"].Rows)
            {
                int n = dgvClass_Register.Rows.Add();
                dgvClass_Register.Rows[n].Cells[0].Value = item[0];
                dgvClass_Register.Rows[n].Cells[1].Value = item[1];
                dgvClass_Register.Rows[n].Cells[2].Value = item[2];
            }
            */
        }

    }
}
