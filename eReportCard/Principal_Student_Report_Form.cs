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
using Newtonsoft.Json;

namespace eReportCard
{
    public partial class Principal_Student_Report_Form : Form
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
        string full_Date = DateTime.Now.ToShortDateString();

        public static string promote_Status;
        public Principal_Student_Report_Form()
        {
            InitializeComponent();

            lblSchool_Name.Text = Login.schoolID;
            lblPrincipal_Signature.Text = Login.nameID;
            lblGradeRC.Text = Principal_Home_Form.selected_ClassID + "\nStudent\n Report Card";
            lblClassID.Text = Principal_Home_Form.selected_ClassID;
            lblPrincipal_Signature.Text = Principal_Home_Form.principal_Name;


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
            else if (date == "5" || date == "6" || date == "7")
            {
                lblSchool_Year.Text = DateTime.Now.AddMonths(-12).Year + " - " + DateTime.Now.Year.ToString();
                lblTerm.Text = "3rd Term";
                gb_PromoteStatus.Visible = true;
            }


            // Principal's signature date
            lblPrincipal_Signature_Date.Text = DateTime.Now.ToShortDateString();

        }

        private void Principal_Student_Report_Form_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            //getting students name registered in the class from database 
            FirebaseResponse res = client.Get(@"REGISTER/" + lblSchool_Name.Text + "/" + lblClassID.Text + "/" + lblSchool_Year.Text);
            Dictionary<string, Register_Data> data = JsonConvert.DeserializeObject<Dictionary<string, Register_Data>>(res.Body.ToString());
            populateCB(data);

            //adding columns to datagridview on startup.
            dt.Columns.Add("Course");
            dt.Columns.Add("Teacher");
            dt.Columns.Add("Term");
            dt.Columns.Add("Exam");
            dt.Columns.Add("Comments");

            dgvPrincipal_Form.DataSource = dt;
        }

#region method used to populate combobox with list of students registered in the class
        private void populateCB(Dictionary<string, Register_Data> record)
        {
            cbStudent_Name.Items.Clear();
            foreach (var item in record)
            {
                cbStudent_Name.Items.Add(item.Key.ToString());
            }
        }
        #endregion

        private async void cbStudent_Name_SelectedIndexChanged(object sender, EventArgs e)
        {

            FirebaseResponse resp1 = await client.GetTaskAsync("REGISTER/" + lblSchool_Name.Text + "/" + lblClassID.Text + "/" + lblSchool_Year.Text + "/" + cbStudent_Name.Text);
            Register_Data get1 = resp1.ResultAs<Register_Data>();

            lblStudent_ID.Text = get1.StudentID;


            export();



            FirebaseResponse resp2 = await client.GetTaskAsync("REPORTCARD/" + lblSchool_Name.Text + "/" + lblClassID.Text + "/" + lblSchool_Year.Text + "/" + lblTerm.Text + "/" + cbStudent_Name.Text + "/" + lblStudent_ID.Text);
            Course_Data_cont get2 = resp2.ResultAs<Course_Data_cont>();

            lblTerm_Avg.Text = get2.termAverage;
            lblExam_Avg.Text = get2.examAverage;
            lblRegularity.Text = get2.regularity;
            lblPunctuality.Text = get2.punctuality;
            lblIndustry.Text = get2.industry;
            lblPersonal_Appearance.Text = get2.personalAppearance;
            lblSocial_Relationship.Text = get2.socialRelationship;
            lblConduct.Text = get2.conduct;
            lblReliability.Text = get2.reliability;
            lblSportsmanship.Text = get2.sportsmanship;
            lblCo_operation.Text = get2.co_operation;
            lblTeacher_Comments.Text = get2.generalComments;
            lblTeacher_Signature_Date.Text = get2.teacher_SignatureDate;
            lblTerm.Text = get2.schoolTerm;
            lblTeacher_Signature.Text = get2.teacher_Name;
        }

        private async void export()
        {
            dt.Rows.Clear();

            int i = 0;
            FirebaseResponse fresp = await client.GetTaskAsync("COUNTER/" + lblSchool_Name.Text + "/" + lblClassID.Text + "/" + lblSchool_Year.Text + "/" + lblTerm.Text + "/" + cbStudent_Name.Text);
            Counter_Class result1 = fresp.ResultAs<Counter_Class>();
            int cnt = Convert.ToInt32(result1.cnt);

            while (true)
            {

                if (i==cnt)
                {
                    break;
                }
                i++;

                try
                {
                    FirebaseResponse fresp2 = await client.GetTaskAsync("REPORTCARD/" + lblSchool_Name.Text + "/" + lblClassID.Text + "/" + lblSchool_Year.Text + "/" + lblTerm.Text + "/" + cbStudent_Name.Text + "/COURSES/" +i);
                    Course_Data result2 = fresp2.ResultAs<Course_Data>();

                    DataRow row = dt.NewRow();
                    row["Course"] = result2.courseName;
                    row["Teacher"] = result2.courseTeacher;
                    row["Term"] = result2.courseTermGrade;
                    row["Exam"] = result2.courseExamGrade;
                    row["Comments"] = result2.courseComments;

                    dt.Rows.Add(row);

                }
                catch
                {
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtPrincipal_Comments.Text))
            {
                MessageBox.Show("Principal's comments can't be empty!", "M I S S I N G!");
            }
            else
            {
                //checking student promoted status is selected to update Reportcard
                if (lblTerm.Text == "3rd Term" && rb_Promoted.Checked == true)
                {
                    promote_Status = "Promoted";
                    update_ReportCard();
                }
                else if (lblTerm.Text == "3rd Term" && rb_Repeated.Checked == true)
                {
                    promote_Status = "Repeated";
                    update_ReportCard();
                }
                else
                {
                    promote_Status = " ";
                    update_ReportCard();
                }
            }
        }

        private async void update_ReportCard()
        {
            //database draws the data in the form of an object class
            //creating an object
            var course_data_cont = new Course_Data_cont
            {
                childID = lblStudent_ID.Text,
                childName = cbStudent_Name.Text,
                classID = lblClassID.Text,
                co_operation = lblCo_operation.Text,
                conduct = lblConduct.Text,
                examAverage = lblExam_Avg.Text,
                generalComments = lblTeacher_Comments.Text,
                industry = lblIndustry.Text,
                personalAppearance = lblPersonal_Appearance.Text,
                principalComments = txtPrincipal_Comments.Text,
                principal_SignatureDate = lblPrincipal_Signature_Date.Text,
                principal_Name = lblPrincipal_Signature.Text,
                punctuality = lblPunctuality.Text,
                regularity = lblRegularity.Text,
                reliability = lblReliability.Text,
                schoolTerm = lblTerm.Text,
                schoolYear = lblSchool_Year.Text,
                socialRelationship = lblSocial_Relationship.Text,
                sportsmanship = lblSportsmanship.Text,
                teacher_Name = lblTeacher_Signature.Text,
                teacher_SignatureDate = lblTeacher_Signature_Date.Text,
                termAverage = lblTerm_Avg.Text,
                promote_Status = promote_Status
                

            };

            FirebaseResponse response = await client.UpdateTaskAsync("REPORTCARD/" + lblSchool_Name.Text + "/" + lblClassID.Text + "/" + lblSchool_Year.Text + "/" + lblTerm.Text + "/" + cbStudent_Name.Text + "/" + lblStudent_ID.Text, course_data_cont);
            Course_Data_cont result = response.ResultAs<Course_Data_cont>();
            MessageBox.Show("Inserted successfully");

            //clearing out student's info

            lblStudent_ID.Text = "------";
            lblSchool_Name.Focus();
            cbStudent_Name.Text = "Select Student";
            lblCo_operation.Text = "------";
            lblConduct.Text = "------";
            lblExam_Avg.Text = "------";
            lblTeacher_Comments.Text = "------";
            lblIndustry.Text = "------";
            lblPersonal_Appearance.Text = "------";
            txtPrincipal_Comments.Text = "";
            lblPunctuality.Text = "------";
            lblRegularity.Text = "------";
            lblReliability.Text = "------";
            lblSocial_Relationship.Text = "------";
            lblSportsmanship.Text = "------";
            lblTeacher_Signature.Text = "------";
            lblTeacher_Signature_Date.Text = "------";
            lblTerm_Avg.Text = "------";
            rb_Promoted.Checked = false;
            rb_Repeated.Checked = false;

            dt.Rows.Clear();
        }

        private void cbStudent_Name_Click(object sender, EventArgs e)
        {
            cbStudent_Name.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStudent_Name.DroppedDown = true;
        }
    }

}
