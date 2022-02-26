using System.Windows.Forms;

namespace eReportCard
{
    internal class Course_Data
    {
        public string courseName { get; set; }
        public string courseComments { get; set; }
        public string courseExamGrade { get; set; }
        public string courseExamMark { get; set; }
        public Label courseTermGrade { get; set; }
        public TextBox courseTermMark { get; set; }
    }
}