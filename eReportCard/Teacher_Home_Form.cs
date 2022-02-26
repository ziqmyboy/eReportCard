using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eReportCard
{
    public partial class Teacher_Home_Form : Form
    {
        public Teacher_Home_Form()
        {
            InitializeComponent();
            lblTeacher_Name.Text = Register.name;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReport_Card_Click(object sender, EventArgs e)
        {
            ShowForm(new Student_ReportCard());
        }

        private void btnClass_Register_Click(object sender, EventArgs e)
        {
            ShowForm(new Class_Register());
        }

        private void btnTranscript_Click(object sender, EventArgs e)
        {
            ShowForm(new Transcript());
        }


        //function to show respective form when the button is clicked
        public void ShowForm(object form)
        {
            pMain_Display.Controls.Clear();
            Form frm = form as Form;
            frm.TopLevel = false;
            pMain_Display.Controls.Add(frm);
            pMain_Display.Tag = frm;
            frm.Show();
        }
        //end of function
    }
}
