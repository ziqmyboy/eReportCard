
namespace eReportCard
{
    partial class Class_Register
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvClass_Register = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbAge = new System.Windows.Forms.ComboBox();
            this.lblStudent_ID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtL_Name = new System.Windows.Forms.TextBox();
            this.txtF_Name = new System.Windows.Forms.TextBox();
            this.lblClassID = new System.Windows.Forms.Label();
            this.btnSave_Class_Register = new System.Windows.Forms.Button();
            this.btnShow_Class_Register = new System.Windows.Forms.Button();
            this.lblSchool_Year = new System.Windows.Forms.Label();
            this.lblSchool_Name = new System.Windows.Forms.Label();
            this.lblTerm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass_Register)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClass_Register
            // 
            this.dgvClass_Register.AllowUserToAddRows = false;
            this.dgvClass_Register.AllowUserToDeleteRows = false;
            this.dgvClass_Register.BackgroundColor = System.Drawing.Color.White;
            this.dgvClass_Register.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClass_Register.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvClass_Register.Location = new System.Drawing.Point(23, 140);
            this.dgvClass_Register.Name = "dgvClass_Register";
            this.dgvClass_Register.ReadOnly = true;
            this.dgvClass_Register.RowHeadersVisible = false;
            this.dgvClass_Register.Size = new System.Drawing.Size(672, 400);
            this.dgvClass_Register.TabIndex = 0;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Student Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 320;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Gender";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Age";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.cbAge);
            this.groupBox1.Controls.Add(this.lblStudent_ID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtL_Name);
            this.groupBox1.Controls.Add(this.txtF_Name);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox1.Location = new System.Drawing.Point(720, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 331);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "add Child to class register";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbFemale);
            this.groupBox2.Controls.Add(this.rbMale);
            this.groupBox2.Location = new System.Drawing.Point(80, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 66);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(17, 41);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(67, 19);
            this.rbFemale.TabIndex = 4;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(17, 12);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(53, 19);
            this.rbMale.TabIndex = 3;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(152, 279);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(103, 33);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add Student";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbAge
            // 
            this.cbAge.AutoCompleteCustomSource.AddRange(new string[] {
            "3 years",
            "4 years",
            "5 years",
            "6 years",
            "7 years",
            "8 years",
            "9 years",
            "10 years",
            "11 years",
            "12 years"});
            this.cbAge.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbAge.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbAge.FormattingEnabled = true;
            this.cbAge.Items.AddRange(new object[] {
            "3 years",
            "4 years",
            "5 years",
            "6 years",
            "7 years",
            "8 years",
            "9 years",
            "10 years",
            "11 years",
            "12 years"});
            this.cbAge.Location = new System.Drawing.Point(97, 224);
            this.cbAge.Name = "cbAge";
            this.cbAge.Size = new System.Drawing.Size(121, 23);
            this.cbAge.TabIndex = 5;
            // 
            // lblStudent_ID
            // 
            this.lblStudent_ID.AutoSize = true;
            this.lblStudent_ID.Location = new System.Drawing.Point(114, 108);
            this.lblStudent_ID.Name = "lblStudent_ID";
            this.lblStudent_ID.Size = new System.Drawing.Size(19, 15);
            this.lblStudent_ID.TabIndex = 1;
            this.lblStudent_ID.Text = "....";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Student\'s ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Age";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Gender";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name";
            // 
            // txtL_Name
            // 
            this.txtL_Name.Location = new System.Drawing.Point(80, 71);
            this.txtL_Name.Name = "txtL_Name";
            this.txtL_Name.Size = new System.Drawing.Size(156, 21);
            this.txtL_Name.TabIndex = 1;
            this.txtL_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtL_Name_KeyPress);
            this.txtL_Name.Leave += new System.EventHandler(this.txtL_Name_Leave);
            // 
            // txtF_Name
            // 
            this.txtF_Name.Location = new System.Drawing.Point(79, 34);
            this.txtF_Name.Name = "txtF_Name";
            this.txtF_Name.Size = new System.Drawing.Size(157, 21);
            this.txtF_Name.TabIndex = 0;
            this.txtF_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtF_Name_KeyPress);
            // 
            // lblClassID
            // 
            this.lblClassID.AutoSize = true;
            this.lblClassID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblClassID.Location = new System.Drawing.Point(442, 32);
            this.lblClassID.Name = "lblClassID";
            this.lblClassID.Size = new System.Drawing.Size(126, 40);
            this.lblClassID.TabIndex = 1;
            this.lblClassID.Text = "Grade 4\r\nClass Register";
            this.lblClassID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave_Class_Register
            // 
            this.btnSave_Class_Register.Location = new System.Drawing.Point(761, 509);
            this.btnSave_Class_Register.Name = "btnSave_Class_Register";
            this.btnSave_Class_Register.Size = new System.Drawing.Size(195, 31);
            this.btnSave_Class_Register.TabIndex = 7;
            this.btnSave_Class_Register.Text = "Save Class Register";
            this.btnSave_Class_Register.UseVisualStyleBackColor = true;
            this.btnSave_Class_Register.Click += new System.EventHandler(this.btnSave_Class_Register_Click);
            // 
            // btnShow_Class_Register
            // 
            this.btnShow_Class_Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow_Class_Register.Location = new System.Drawing.Point(48, 94);
            this.btnShow_Class_Register.Name = "btnShow_Class_Register";
            this.btnShow_Class_Register.Size = new System.Drawing.Size(130, 37);
            this.btnShow_Class_Register.TabIndex = 8;
            this.btnShow_Class_Register.Text = "Show Class Register";
            this.btnShow_Class_Register.UseVisualStyleBackColor = true;
            this.btnShow_Class_Register.Click += new System.EventHandler(this.btnShow_Class_Register_Click);
            // 
            // lblSchool_Year
            // 
            this.lblSchool_Year.AutoSize = true;
            this.lblSchool_Year.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSchool_Year.Location = new System.Drawing.Point(120, 26);
            this.lblSchool_Year.Name = "lblSchool_Year";
            this.lblSchool_Year.Size = new System.Drawing.Size(84, 15);
            this.lblSchool_Year.TabIndex = 9;
            this.lblSchool_Year.Text = "2021 - 2022";
            // 
            // lblSchool_Name
            // 
            this.lblSchool_Name.AutoSize = true;
            this.lblSchool_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblSchool_Name.Location = new System.Drawing.Point(20, 9);
            this.lblSchool_Name.Name = "lblSchool_Name";
            this.lblSchool_Name.Size = new System.Drawing.Size(184, 17);
            this.lblSchool_Name.TabIndex = 10;
            this.lblSchool_Name.Text = "Atkinson Primary School";
            // 
            // lblTerm
            // 
            this.lblTerm.AutoSize = true;
            this.lblTerm.Location = new System.Drawing.Point(492, 94);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(52, 13);
            this.lblTerm.TabIndex = 11;
            this.lblTerm.Text = "2nd Term";
            // 
            // Class_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 583);
            this.Controls.Add(this.lblTerm);
            this.Controls.Add(this.lblSchool_Year);
            this.Controls.Add(this.lblSchool_Name);
            this.Controls.Add(this.btnShow_Class_Register);
            this.Controls.Add(this.btnSave_Class_Register);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvClass_Register);
            this.Controls.Add(this.lblClassID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Class_Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class_Register";
            this.Load += new System.EventHandler(this.Class_Register_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass_Register)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClass_Register;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtF_Name;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.ComboBox cbAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtL_Name;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblClassID;
        private System.Windows.Forms.Button btnSave_Class_Register;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnShow_Class_Register;
        private System.Windows.Forms.Label lblSchool_Year;
        private System.Windows.Forms.Label lblSchool_Name;
        private System.Windows.Forms.Label lblStudent_ID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTerm;
    }
}