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
    public partial class Transcript : Form
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
        public Transcript()
        {
            InitializeComponent();

            lblSchool_Name.Text = Login.schoolID;
            lblTeacher_Signature.Text = Login.nameID;
            lblGradeRC.Text = Login.classID + "\nStudent\n Report Card";
            lblClassID.Text = Login.classID;

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


        }

        private void Transcript_Load(object sender, EventArgs e)
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

            dgvTranscript.DataSource = dt;
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
            lblPrincipals_Comments.Text = get2.principalComments;
            lblPrincipal_Signature_Date.Text = get2.principal_SignatureDate;
            lblPrincipal_Signature.Text = get2.principal_Name;
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

                if (i == cnt)
                {
                    break;
                }
                i++;

                try
                {
                    FirebaseResponse fresp2 = await client.GetTaskAsync("REPORTCARD/" + lblSchool_Name.Text + "/" + lblClassID.Text + "/" + lblSchool_Year.Text + "/" + lblTerm.Text + "/" + cbStudent_Name.Text + "/COURSES/" + i);
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
    }
}

