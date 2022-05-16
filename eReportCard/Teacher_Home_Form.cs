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
        //fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        public Teacher_Home_Form()
        {
            InitializeComponent();
            lblTeacher_Name.Text = Login.nameID;
            random = new Random();
        }

        //methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while(tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton !=(Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    panelTitleBar.BackColor = color;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReport_Card_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowForm(new Student_ReportCard());
        }

        private void btnClass_Register_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowForm(new Class_Register());
        }

        private void btnTranscript_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
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


        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
