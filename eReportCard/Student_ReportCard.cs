using System;
using System.Collections.Generic;
using Newtonsoft.Json;
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
    public partial class Student_ReportCard : Form
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


        public Student_ReportCard()
        {
            InitializeComponent();

            lblSchool_Name.Text = Login.schoolID;
            lblTeacher_Name.Text = Login.nameID;
            lblTeacher_Signature.Text = Login.nameID;
            lblGradeRC.Text = Login.classID + "\nStudent\n Report Card";
            lblClassID.Text = Login.classID;

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
                txtExam_Mark.Text = "0";
                label16.Enabled = false;
                txtExam_Mark.Enabled = false;
                lblExam_Grade.Text = "";
                
            }
            else if(date == "5" || date == "6" || date == "7" || date == "8")
            {
                lblSchool_Year.Text = DateTime.Now.AddMonths(-12).Year + " - " + DateTime.Now.Year.ToString();
                lblTerm.Text = "3rd Term";
            }


            // teacher's signature date
            lblTeacher_Signature_Date.Text = DateTime.Now.ToShortDateString();

        }

        private async void Student_ReportCard_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            FirebaseResponse resp = await client.GetTaskAsync("USERS/" + Login.uID);
            Users get = resp.ResultAs<Users>();

            if (get.rcData == "NO DATA")
            {
                MessageBox.Show("Students must be Registered before using this tab\n" +
                    "to Register a child, click on the 'Class Register' tab.","NO DATA");
                return;
            }

            //getting list of registered students from db
            int i = 0;
            FirebaseResponse fresp = client.Get(@"RegisterCOUNTER/" + lblSchool_Name.Text + "/" + Login.classID + "/" + lblSchool_Year.Text + "/Students/");
            Counter_Class result1 = fresp.ResultAs<Counter_Class>();
            int cnt = Convert.ToInt32(result1.cnt);

            //cbStudent_Name.Items.Clear();

            while (true)
            {

                if (i == cnt)
                {
                    break;
                }
                i++;

                try
                {
                    FirebaseResponse res = client.Get(@"REGISTER/" + lblSchool_Name.Text + "/" + lblClassID.Text + "/" + lblSchool_Year.Text + "/Students/" + i);
                    Register_Data name = res.ResultAs<Register_Data>();
                    cbStudent_Name.Items.Add(name.FullName);

                }
                catch
                {
                }
            }
        }


        private async void btnInsert_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCourse_Name.Text) || string.IsNullOrWhiteSpace(txtTerm_Mark.Text) || string.IsNullOrWhiteSpace(txtExam_Mark.Text) || string.IsNullOrWhiteSpace(txtComments.Text) || cbStudent_Name.Text == "Select Student")
            {
                MessageBox.Show("Please ensure all fields are entered properly!", "E R R O R");
            }
            else
            {
                // adding txtbox content to datagrid view
                int n = dgvReport_Card.Rows.Add();
                dgvReport_Card.Rows[n].Cells[0].Value = txtCourse_Name.Text;
                dgvReport_Card.Rows[n].Cells[1].Value = lblTeacher_Name.Text;
                dgvReport_Card.Rows[n].Cells[2].Value = txtTerm_Mark.Text;
                dgvReport_Card.Rows[n].Cells[3].Value = lblTerm_Grade.Text;
                dgvReport_Card.Rows[n].Cells[4].Value = txtExam_Mark.Text;
                dgvReport_Card.Rows[n].Cells[5].Value = lblExam_Grade.Text;
                dgvReport_Card.Rows[n].Cells[6].Value = txtComments.Text;


                //finding the total sum of marks
                int term_sum = 0;
                int exam_sum = 0;
                for (int i = 0; i < dgvReport_Card.Rows.Count; ++i)
                {
                    term_sum += Convert.ToInt32(dgvReport_Card.Rows[i].Cells[2].Value);
                    exam_sum += Convert.ToInt32(dgvReport_Card.Rows[i].Cells[4].Value);
                }
                //finding the average of marks
                int count_row = dgvReport_Card.Rows.Count;
                double term_avg = term_sum / count_row;
                double exam_avg = exam_sum / count_row;


                //printing term avg 
                if (term_avg > 0 && term_avg <= 54)
                {
                    lblTerm_Avg.Text = term_avg.ToString() + "%  F";
                }
                else if (term_avg > 54 && term_avg <= 64)
                {
                    lblTerm_Avg.Text = term_avg.ToString() + "%  D";
                }
                else if (term_avg > 64 && term_avg <= 69)
                {
                    lblTerm_Avg.Text = term_avg.ToString() + "%  C-";
                }
                else if (term_avg > 69 && term_avg <= 74)
                {
                    lblTerm_Avg.Text = term_avg.ToString() + "%  C+";
                }
                else if (term_avg > 74 && term_avg <= 79)
                {
                    lblTerm_Avg.Text = term_avg.ToString() + "%  B-";
                }
                else if (term_avg > 79 && term_avg <= 84)
                {
                    lblTerm_Avg.Text = term_avg.ToString() + "%  B+";
                }
                else if (term_avg > 84 && term_avg <= 89)
                {
                    lblTerm_Avg.Text = term_avg.ToString() + "%  A-";
                }
                else if (term_avg > 89 && term_avg <= 100)
                {
                    lblTerm_Avg.Text = term_avg.ToString() + "%  A+";
                }
                else
                {
                    lblTerm_Avg.Visible = false;
                }


                //printing exam avg 
                if (exam_avg > 0 && exam_avg <= 54)
                {
                    lblExam_Avg.Text = exam_avg.ToString() + "%  F";
                }
                else if (exam_avg > 54 && exam_avg <= 64)
                {
                    lblExam_Avg.Text = exam_avg.ToString() + "%  D";
                }
                else if (exam_avg > 64 && exam_avg <= 69)
                {
                    lblExam_Avg.Text = exam_avg.ToString() + "%  C-";
                }
                else if (exam_avg > 69 && exam_avg <= 74)
                {
                    lblExam_Avg.Text = exam_avg.ToString() + "%  C+";
                }
                else if (exam_avg > 74 && exam_avg <= 79)
                {
                    lblExam_Avg.Text = exam_avg.ToString() + "%  B-";
                }
                else if (exam_avg > 79 && exam_avg <= 84)
                {
                    lblExam_Avg.Text = exam_avg.ToString() + "%  B+";
                }
                else if (exam_avg > 84 && exam_avg <= 89)
                {
                    lblExam_Avg.Text = exam_avg.ToString() + "%  A-";
                }
                else if (exam_avg > 89 && exam_avg <= 100)
                {
                    lblExam_Avg.Text = exam_avg.ToString() + "%  A+";
                }
                else
                {
                    lblExam_Avg.Visible = false;
                }


                FirebaseResponse resp = await client.GetTaskAsync("COUNTER/" + lblSchool_Name.Text + "/" + lblClassID.Text + "/" + lblSchool_Year.Text + "/" + lblTerm.Text + "/" + cbStudent_Name.Text);
                Counter_Class get = resp.ResultAs<Counter_Class>();

                
                //database draws the data in the form of an object class
                //creating an object

                var course_data = new Course_Data
                {
                    id = (Convert.ToInt32(get.cnt) + 1).ToString(),
                    courseName = txtCourse_Name.Text,
                    courseComments = txtComments.Text,
                    courseTeacher = lblTeacher_Name.Text,
                    courseExamGrade = txtExam_Mark.Text + lblExam_Grade.Text,
                    courseTermGrade = txtTerm_Mark.Text + lblTerm_Grade.Text
                };

                //clearing out the txtboxes
                if (date == "1" || date == "2" || date == "3" || date == "4")
                {
                    txtCourse_Name.Text = "";
                    txtTerm_Mark.Text = "";
                    txtExam_Mark.Text = "0";
                    txtComments.Text = "";
                }
                else
                {
                    txtCourse_Name.Text = "";
                    txtTerm_Mark.Text = "";
                    txtExam_Mark.Text = "";
                    txtComments.Text = "";
                }
                

                SetResponse response = await client.SetTaskAsync("REPORTCARD/" + lblSchool_Name.Text + "/" + lblClassID.Text + "/" + lblSchool_Year.Text + "/" + lblTerm.Text + "/" + cbStudent_Name.Text + "/COURSES/" + course_data.id, course_data);
                Course_Data result = response.ResultAs<Course_Data>();

                //incrementing the count variable
                var obj = new Counter_Class
                {
                    cnt = course_data.id
                };
                SetResponse response1 = await client.SetTaskAsync("COUNTER/" + lblSchool_Name.Text + "/" + lblClassID.Text + "/" + lblSchool_Year.Text + "/" + lblTerm.Text + "/" + cbStudent_Name.Text, obj);
                Counter_Class result1 = response1.ResultAs<Counter_Class>();

            }
        }

        

        private void txtTerm_Mark_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ensures only numaric values into textbox
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                
            }
        }

        private void txtExam_Mark_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ensures only numaric values into textbox
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;

            }
        }

        private void txtTerm_Mark_KeyUp(object sender, KeyEventArgs e)
        {
            //grade level are determined by marks
            if (txtTerm_Mark.Text == "1" || txtTerm_Mark.Text == "2" || txtTerm_Mark.Text == "3" || txtTerm_Mark.Text == "4" || txtTerm_Mark.Text == "5" || txtTerm_Mark.Text == "6" || txtTerm_Mark.Text == "7" || txtTerm_Mark.Text == "8" || txtTerm_Mark.Text == "9"
                || txtTerm_Mark.Text == "10" || txtTerm_Mark.Text == "11" || txtTerm_Mark.Text == "12" || txtTerm_Mark.Text == "13" || txtTerm_Mark.Text == "14" || txtTerm_Mark.Text == "15" || txtTerm_Mark.Text == "16" || txtTerm_Mark.Text == "17" || txtTerm_Mark.Text == "18"
                || txtTerm_Mark.Text == "19" || txtTerm_Mark.Text == "20" || txtTerm_Mark.Text == "21" || txtTerm_Mark.Text == "22" || txtTerm_Mark.Text == "23" || txtTerm_Mark.Text == "24" || txtTerm_Mark.Text == "25" || txtTerm_Mark.Text == "26" || txtTerm_Mark.Text == "27"
                || txtTerm_Mark.Text == "28" || txtTerm_Mark.Text == "29" || txtTerm_Mark.Text == "30" || txtTerm_Mark.Text == "31" || txtTerm_Mark.Text == "32" || txtTerm_Mark.Text == "33" || txtTerm_Mark.Text == "34" || txtTerm_Mark.Text == "35" || txtTerm_Mark.Text == "36"
                || txtTerm_Mark.Text == "37" || txtTerm_Mark.Text == "38" || txtTerm_Mark.Text == "39" || txtTerm_Mark.Text == "40" || txtTerm_Mark.Text == "41" || txtTerm_Mark.Text == "42" || txtTerm_Mark.Text == "43" || txtTerm_Mark.Text == "44" || txtTerm_Mark.Text == "45"
                || txtTerm_Mark.Text == "46" || txtTerm_Mark.Text == "47" || txtTerm_Mark.Text == "48" || txtTerm_Mark.Text == "49" || txtTerm_Mark.Text == "50" || txtTerm_Mark.Text == "51" || txtTerm_Mark.Text == "52" || txtTerm_Mark.Text == "53" || txtTerm_Mark.Text == "54")
            {
                lblTerm_Grade.Text = "%   F";
                lblTerm_Grade.Visible = true;
            }
            else if (txtTerm_Mark.Text == "55" || txtTerm_Mark.Text == "56" || txtTerm_Mark.Text == "57" || txtTerm_Mark.Text == "58" || txtTerm_Mark.Text == "59" || txtTerm_Mark.Text == "60" || txtTerm_Mark.Text == "61" || txtTerm_Mark.Text == "62" || txtTerm_Mark.Text == "63" || txtTerm_Mark.Text == "64")
            {
                lblTerm_Grade.Text = "%   D";
                lblTerm_Grade.Visible = true;
            }
            else if (txtTerm_Mark.Text == "65" || txtTerm_Mark.Text == "66" || txtTerm_Mark.Text == "67" || txtTerm_Mark.Text == "68" || txtTerm_Mark.Text == "69")
            {
                lblTerm_Grade.Text = "%  C-";
                lblTerm_Grade.Visible = true;
            }
            else if (txtTerm_Mark.Text == "70" || txtTerm_Mark.Text == "71" || txtTerm_Mark.Text == "72" || txtTerm_Mark.Text == "73" || txtTerm_Mark.Text == "74")
            {
                lblTerm_Grade.Text = "%  C+";
                lblTerm_Grade.Visible = true;
            }
            else if (txtTerm_Mark.Text == "75" || txtTerm_Mark.Text == "76" || txtTerm_Mark.Text == "77" || txtTerm_Mark.Text == "78" || txtTerm_Mark.Text == "79")
            {
                lblTerm_Grade.Text = "%  B-";
                lblTerm_Grade.Visible = true;
            }
            else if (txtTerm_Mark.Text == "80" || txtTerm_Mark.Text == "81" || txtTerm_Mark.Text == "82" || txtTerm_Mark.Text == "83" || txtTerm_Mark.Text == "84")
            {
                lblTerm_Grade.Text = "%  B+";
                lblTerm_Grade.Visible = true;
            }
            else if (txtTerm_Mark.Text == "85" || txtTerm_Mark.Text == "86" || txtTerm_Mark.Text == "87" || txtTerm_Mark.Text == "88" || txtTerm_Mark.Text == "89")
            {
                lblTerm_Grade.Text = "%  A-";
                lblTerm_Grade.Visible = true;
            }
            else if (txtTerm_Mark.Text == "90" || txtTerm_Mark.Text == "91" || txtTerm_Mark.Text == "92" || txtTerm_Mark.Text == "93" || txtTerm_Mark.Text == "94" || txtTerm_Mark.Text == "95" || txtTerm_Mark.Text == "96" || txtTerm_Mark.Text == "97" || txtTerm_Mark.Text == "98" || txtTerm_Mark.Text == "99" || txtTerm_Mark.Text == "100")
            {
                lblTerm_Grade.Text = "%  A+";
                lblTerm_Grade.Visible = true;
            }
            else
            {
                lblTerm_Grade.Visible = false;
            }

        }

        private void txtExam_Mark_KeyUp(object sender, KeyEventArgs e)
        {
            //grade level are determined by marks
            if (txtExam_Mark.Text == "1" || txtExam_Mark.Text == "2" || txtExam_Mark.Text == "3" || txtExam_Mark.Text == "4" || txtExam_Mark.Text == "5" || txtExam_Mark.Text == "6" || txtExam_Mark.Text == "7" || txtExam_Mark.Text == "8" || txtExam_Mark.Text == "9"
                || txtExam_Mark.Text == "10" || txtExam_Mark.Text == "11" || txtExam_Mark.Text == "12" || txtExam_Mark.Text == "13" || txtExam_Mark.Text == "14" || txtExam_Mark.Text == "15" || txtExam_Mark.Text == "16" || txtExam_Mark.Text == "17" || txtExam_Mark.Text == "18"
                || txtExam_Mark.Text == "19" || txtExam_Mark.Text == "20" || txtExam_Mark.Text == "21" || txtExam_Mark.Text == "22" || txtExam_Mark.Text == "23" || txtExam_Mark.Text == "24" || txtExam_Mark.Text == "25" || txtExam_Mark.Text == "26" || txtExam_Mark.Text == "27"
                || txtExam_Mark.Text == "28" || txtExam_Mark.Text == "29" || txtExam_Mark.Text == "30" || txtExam_Mark.Text == "31" || txtExam_Mark.Text == "32" || txtExam_Mark.Text == "33" || txtExam_Mark.Text == "34" || txtExam_Mark.Text == "35" || txtExam_Mark.Text == "36"
                || txtExam_Mark.Text == "37" || txtExam_Mark.Text == "38" || txtExam_Mark.Text == "39" || txtExam_Mark.Text == "40" || txtExam_Mark.Text == "41" || txtExam_Mark.Text == "42" || txtExam_Mark.Text == "43" || txtExam_Mark.Text == "44" || txtExam_Mark.Text == "45"
                || txtExam_Mark.Text == "46" || txtExam_Mark.Text == "47" || txtExam_Mark.Text == "48" || txtExam_Mark.Text == "49" || txtExam_Mark.Text == "50" || txtExam_Mark.Text == "51" || txtExam_Mark.Text == "52" || txtExam_Mark.Text == "53" || txtExam_Mark.Text == "54")
            {
                lblExam_Grade.Text = "%   F";
                lblExam_Grade.Visible = true;
            }
            else if (txtExam_Mark.Text == "55" || txtExam_Mark.Text == "56" || txtExam_Mark.Text == "57" || txtExam_Mark.Text == "58" || txtExam_Mark.Text == "59" || txtExam_Mark.Text == "60" || txtExam_Mark.Text == "61" || txtExam_Mark.Text == "62" || txtExam_Mark.Text == "63" || txtExam_Mark.Text == "64")
            {
                lblExam_Grade.Text = "%   D";
                lblExam_Grade.Visible = true;
            }
            else if (txtExam_Mark.Text == "65" || txtExam_Mark.Text == "66" || txtExam_Mark.Text == "67" || txtExam_Mark.Text == "68" || txtExam_Mark.Text == "69")
            {
                lblExam_Grade.Text = "%  C-";
                lblExam_Grade.Visible = true;
            }
            else if (txtExam_Mark.Text == "70" || txtExam_Mark.Text == "71" || txtExam_Mark.Text == "72" || txtExam_Mark.Text == "73" || txtExam_Mark.Text == "74")
            {
                lblTerm_Grade.Text = "%  C+";
                lblTerm_Grade.Visible = true;
            }
            else if (txtExam_Mark.Text == "75" || txtExam_Mark.Text == "76" || txtExam_Mark.Text == "77" || txtExam_Mark.Text == "78" || txtExam_Mark.Text == "79")
            {
                lblExam_Grade.Text = "%  B-";
                lblExam_Grade.Visible = true;
            }
            else if (txtExam_Mark.Text == "80" || txtExam_Mark.Text == "81" || txtExam_Mark.Text == "82" || txtExam_Mark.Text == "83" || txtExam_Mark.Text == "84")
            {
                lblExam_Grade.Text = "%  B+";
                lblExam_Grade.Visible = true;
            }
            else if (txtExam_Mark.Text == "85" || txtExam_Mark.Text == "86" || txtExam_Mark.Text == "87" || txtExam_Mark.Text == "88" || txtExam_Mark.Text == "89")
            {
                lblExam_Grade.Text = "%  A-";
                lblExam_Grade.Visible = true;
            }
            else if (txtExam_Mark.Text == "90" || txtExam_Mark.Text == "91" || txtExam_Mark.Text == "92" || txtExam_Mark.Text == "93" || txtExam_Mark.Text == "94" || txtExam_Mark.Text == "95" || txtExam_Mark.Text == "96" || txtExam_Mark.Text == "97" || txtExam_Mark.Text == "98" || txtExam_Mark.Text == "99" || txtExam_Mark.Text == "100")
            {
                lblExam_Grade.Text = "%  A+";
                lblExam_Grade.Visible = true;
            }
            else
            {
                lblExam_Grade.Visible = false;
            }
        }



        private async void btnSave_ReportCard_Click(object sender, EventArgs e)
        {
            btnSave_ReportCard.Text = "Saving...";
            if (string.IsNullOrWhiteSpace(cbRegularity.Text) || string.IsNullOrWhiteSpace(cbPunctuality.Text) || string.IsNullOrWhiteSpace(cbIndustry.Text) || string.IsNullOrWhiteSpace(cbPersonal_Appearance.Text) || string.IsNullOrWhiteSpace(cbSocial_Relationship.Text)
                || string.IsNullOrWhiteSpace(cbConduct.Text)|| string.IsNullOrWhiteSpace(cbReliability.Text) || string.IsNullOrWhiteSpace(cbSportsmanship.Text) || string.IsNullOrWhiteSpace(cbCo_operation.Text) || string.IsNullOrWhiteSpace(txtGeneral_Comments.Text))
            {
                MessageBox.Show("Please ensure all fields are entered properly!", "M I S S I N G   F I E L D S!");

                btnSave_ReportCard.Text = "Save Report Card";
            }
            else
            {
                //database draws the data in the form of an object class
                //creating an object

                var course_data_cont = new Course_Data_cont
                {
                    childID = lblStudent_ID.Text,
                    childName = cbStudent_Name.Text,
                    classID = lblClassID.Text,
                    co_operation = cbCo_operation.Text,
                    conduct = cbConduct.Text,
                    examAverage = lblExam_Avg.Text,
                    generalComments = txtGeneral_Comments.Text,
                    industry = cbIndustry.Text,
                    personalAppearance = cbPersonal_Appearance.Text,
                    principalComments = " ",
                    principal_SignatureDate = " ",
                    principal_Name = " ",
                    promote_Status = " ",
                    punctuality = cbPunctuality.Text,
                    regularity = cbRegularity.Text,
                    reliability = cbReliability.Text,
                    schoolTerm = lblTerm.Text,
                    schoolYear = lblSchool_Year.Text,
                    socialRelationship = cbSocial_Relationship.Text,
                    sportsmanship = cbSportsmanship.Text,
                    teacher_Name = lblTeacher_Signature.Text,
                    teacher_SignatureDate = lblTeacher_Signature_Date.Text,
                    termAverage = lblTerm_Avg.Text

                };

                SetResponse response = await client.SetTaskAsync("REPORTCARD/" + lblSchool_Name.Text + "/" + lblClassID.Text + "/" + lblSchool_Year.Text + "/" + lblTerm.Text + "/" + cbStudent_Name.Text + "/" + lblStudent_ID.Text, course_data_cont);
                Course_Data_cont result = response.ResultAs<Course_Data_cont>();

                //clearing out the txtboxes
                txtCourse_Name.Text = "";
                lblStudent_ID.Text = "-----------";
                lblSchool_Name.Focus();
                cbStudent_Name.Text = "Select Student";
                cbCo_operation.Text = "";
                cbConduct.Text = "";
                lblExam_Avg.Text = "----------";
                txtGeneral_Comments.Text = "";
                cbIndustry.Text = "";
                cbPersonal_Appearance.Text = "";
                cbPunctuality.Text = "";
                cbRegularity.Text = "";
                cbReliability.Text = "";
                cbSocial_Relationship.Text = "";
                cbSportsmanship.Text = "";
                lblTerm_Avg.Text = "----------";
                dgvReport_Card.Rows.Clear();

                btnSave_ReportCard.Text = "Save Report Card";
            }
        }

        private void cbStudent_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            string name = cbStudent_Name.Text;
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
                    FirebaseResponse res = client.Get(@"REGISTER/" + lblSchool_Name.Text + "/" + lblClassID.Text + "/" + lblSchool_Year.Text + "/Students/" + i);
                    Register_Data dbStudentName = res.ResultAs<Register_Data>();

                    if (cbStudent_Name.Text == dbStudentName.FullName)
                    {
                        lblStudent_ID.Text = dbStudentName.StudentID;
                    }
                }
                catch
                {
                }
            }
        }

        private void cbStudent_Name_Click(object sender, EventArgs e)
        {
            cbStudent_Name.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStudent_Name.DroppedDown = true;
        }
    }
}
