
namespace eReportCard
{
    partial class Profession_Institution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profession_Institution));
            this.rbPrincipal = new System.Windows.Forms.RadioButton();
            this.rbTeacher = new System.Windows.Forms.RadioButton();
            this.rbPrimarySchool = new System.Windows.Forms.RadioButton();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblBack = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWelcome_Message = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblTxt_Institution = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSecondarySchool = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbPrincipal
            // 
            this.rbPrincipal.AutoSize = true;
            this.rbPrincipal.Location = new System.Drawing.Point(19, 37);
            this.rbPrincipal.Name = "rbPrincipal";
            this.rbPrincipal.Size = new System.Drawing.Size(66, 19);
            this.rbPrincipal.TabIndex = 0;
            this.rbPrincipal.Text = "Princial";
            this.rbPrincipal.UseVisualStyleBackColor = true;
            this.rbPrincipal.CheckedChanged += new System.EventHandler(this.rbPrincipal_CheckedChanged);
            // 
            // rbTeacher
            // 
            this.rbTeacher.AutoSize = true;
            this.rbTeacher.Location = new System.Drawing.Point(112, 37);
            this.rbTeacher.Name = "rbTeacher";
            this.rbTeacher.Size = new System.Drawing.Size(70, 19);
            this.rbTeacher.TabIndex = 0;
            this.rbTeacher.Text = "Teacher";
            this.rbTeacher.UseVisualStyleBackColor = true;
            this.rbTeacher.CheckedChanged += new System.EventHandler(this.rbTeacher_CheckedChanged);
            // 
            // rbPrimarySchool
            // 
            this.rbPrimarySchool.AutoSize = true;
            this.rbPrimarySchool.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.rbPrimarySchool.Location = new System.Drawing.Point(206, 184);
            this.rbPrimarySchool.Name = "rbPrimarySchool";
            this.rbPrimarySchool.Size = new System.Drawing.Size(108, 19);
            this.rbPrimarySchool.TabIndex = 0;
            this.rbPrimarySchool.TabStop = true;
            this.rbPrimarySchool.Text = "Primary School";
            this.rbPrimarySchool.UseVisualStyleBackColor = true;
            this.rbPrimarySchool.Visible = false;
            this.rbPrimarySchool.CheckedChanged += new System.EventHandler(this.rbPrimarySchool_CheckedChanged);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.White;
            this.btnContinue.Enabled = false;
            this.btnContinue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnContinue.FlatAppearance.BorderSize = 2;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnContinue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnContinue.Location = new System.Drawing.Point(342, 213);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(88, 29);
            this.btnContinue.TabIndex = 13;
            this.btnContinue.Text = "continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblBack.ForeColor = System.Drawing.Color.White;
            this.lblBack.Location = new System.Drawing.Point(16, 10);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(25, 26);
            this.lblBack.TabIndex = 14;
            this.lblBack.Text = "<";
            this.lblBack.Click += new System.EventHandler(this.lblBack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.panel1.Controls.Add(this.lblWelcome_Message);
            this.panel1.Controls.Add(this.lblClose);
            this.panel1.Controls.Add(this.lblBack);
            this.panel1.Location = new System.Drawing.Point(-4, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 51);
            this.panel1.TabIndex = 15;
            // 
            // lblWelcome_Message
            // 
            this.lblWelcome_Message.AutoSize = true;
            this.lblWelcome_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome_Message.ForeColor = System.Drawing.Color.White;
            this.lblWelcome_Message.Location = new System.Drawing.Point(88, 17);
            this.lblWelcome_Message.Name = "lblWelcome_Message";
            this.lblWelcome_Message.Size = new System.Drawing.Size(105, 16);
            this.lblWelcome_Message.TabIndex = 15;
            this.lblWelcome_Message.Text = "Good Morning";
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(414, 14);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(20, 20);
            this.lblClose.TabIndex = 14;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblTxt_Institution
            // 
            this.lblTxt_Institution.AutoSize = true;
            this.lblTxt_Institution.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTxt_Institution.Location = new System.Drawing.Point(30, 156);
            this.lblTxt_Institution.Name = "lblTxt_Institution";
            this.lblTxt_Institution.Size = new System.Drawing.Size(334, 15);
            this.lblTxt_Institution.TabIndex = 14;
            this.lblTxt_Institution.Text = "What institution of learning are you a Teacher / Principal of ...";
            this.lblTxt_Institution.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTeacher);
            this.groupBox1.Controls.Add(this.rbPrincipal);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox1.Location = new System.Drawing.Point(24, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 72);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Are you a Principal or a Teacher?";
            // 
            // rbSecondarySchool
            // 
            this.rbSecondarySchool.AutoSize = true;
            this.rbSecondarySchool.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.rbSecondarySchool.Location = new System.Drawing.Point(44, 212);
            this.rbSecondarySchool.Name = "rbSecondarySchool";
            this.rbSecondarySchool.Size = new System.Drawing.Size(124, 19);
            this.rbSecondarySchool.TabIndex = 17;
            this.rbSecondarySchool.TabStop = true;
            this.rbSecondarySchool.Text = "Secondary School";
            this.rbSecondarySchool.UseVisualStyleBackColor = true;
            this.rbSecondarySchool.Visible = false;
            this.rbSecondarySchool.CheckedChanged += new System.EventHandler(this.rbSecondarySchool_CheckedChanged);
            // 
            // Profession_Institution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(442, 258);
            this.ControlBox = false;
            this.Controls.Add(this.rbSecondarySchool);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTxt_Institution);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.rbPrimarySchool);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Profession_Institution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbPrincipal;
        private System.Windows.Forms.RadioButton rbTeacher;
        private System.Windows.Forms.RadioButton rbPrimarySchool;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTxt_Institution;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblWelcome_Message;
        private System.Windows.Forms.RadioButton rbSecondarySchool;
    }
}