
namespace eReportCard
{
    partial class Teacher_Home_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTranscript = new System.Windows.Forms.Button();
            this.btnClass_Register = new System.Windows.Forms.Button();
            this.btnReport_Card = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTeacher_Name = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pMain_Display = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pMain_Display.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTranscript);
            this.panel1.Controls.Add(this.btnClass_Register);
            this.panel1.Controls.Add(this.btnReport_Card);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 635);
            this.panel1.TabIndex = 0;
            // 
            // btnTranscript
            // 
            this.btnTranscript.FlatAppearance.BorderSize = 0;
            this.btnTranscript.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTranscript.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTranscript.Location = new System.Drawing.Point(3, 236);
            this.btnTranscript.Name = "btnTranscript";
            this.btnTranscript.Size = new System.Drawing.Size(176, 41);
            this.btnTranscript.TabIndex = 0;
            this.btnTranscript.Text = "eTranscript";
            this.btnTranscript.UseVisualStyleBackColor = true;
            this.btnTranscript.Click += new System.EventHandler(this.btnTranscript_Click);
            // 
            // btnClass_Register
            // 
            this.btnClass_Register.FlatAppearance.BorderSize = 0;
            this.btnClass_Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClass_Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClass_Register.Location = new System.Drawing.Point(3, 189);
            this.btnClass_Register.Name = "btnClass_Register";
            this.btnClass_Register.Size = new System.Drawing.Size(176, 41);
            this.btnClass_Register.TabIndex = 0;
            this.btnClass_Register.Text = "eClass Register";
            this.btnClass_Register.UseVisualStyleBackColor = true;
            this.btnClass_Register.Click += new System.EventHandler(this.btnClass_Register_Click);
            // 
            // btnReport_Card
            // 
            this.btnReport_Card.FlatAppearance.BorderSize = 0;
            this.btnReport_Card.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport_Card.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport_Card.Location = new System.Drawing.Point(3, 142);
            this.btnReport_Card.Name = "btnReport_Card";
            this.btnReport_Card.Size = new System.Drawing.Size(176, 41);
            this.btnReport_Card.TabIndex = 0;
            this.btnReport_Card.Text = "eReport Card";
            this.btnReport_Card.UseVisualStyleBackColor = true;
            this.btnReport_Card.Click += new System.EventHandler(this.btnReport_Card_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.lblTeacher_Name);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(179, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1053, 41);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClose.Location = new System.Drawing.Point(1022, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(31, 41);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTeacher_Name
            // 
            this.lblTeacher_Name.AutoSize = true;
            this.lblTeacher_Name.Location = new System.Drawing.Point(411, 15);
            this.lblTeacher_Name.Name = "lblTeacher_Name";
            this.lblTeacher_Name.Size = new System.Drawing.Size(85, 13);
            this.lblTeacher_Name.TabIndex = 0;
            this.lblTeacher_Name.Text = "Teacher\'s Name";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(50, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Home";
            // 
            // pMain_Display
            // 
            this.pMain_Display.Controls.Add(this.label3);
            this.pMain_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain_Display.Location = new System.Drawing.Point(179, 41);
            this.pMain_Display.Name = "pMain_Display";
            this.pMain_Display.Size = new System.Drawing.Size(1053, 594);
            this.pMain_Display.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Pristina", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(410, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 63);
            this.label3.TabIndex = 1;
            this.label3.Text = "eReportCard";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Teacher_Home_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 635);
            this.Controls.Add(this.pMain_Display);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Teacher_Home_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teacher_Home_Form";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pMain_Display.ResumeLayout(false);
            this.pMain_Display.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReport_Card;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pMain_Display;
        private System.Windows.Forms.Button btnTranscript;
        private System.Windows.Forms.Button btnClass_Register;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTeacher_Name;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label3;
    }
}