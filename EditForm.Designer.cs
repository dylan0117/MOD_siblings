namespace Studentsiblings
{
    partial class EditForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbHelp1 = new System.Windows.Forms.Label();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.lbHelp2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbHelp3 = new System.Windows.Forms.Label();
            this.cbTitle = new System.Windows.Forms.ComboBox();
            this.tbClassName = new System.Windows.Forms.TextBox();
            this.lbHelp6 = new System.Windows.Forms.Label();
            this.tbSchoolName = new System.Windows.Forms.TextBox();
            this.lbHelp5 = new System.Windows.Forms.Label();
            this.lbHelp4 = new System.Windows.Forms.Label();
            this.tbBirthday = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(124, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(205, 230);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbHelp1
            // 
            this.lbHelp1.AutoSize = true;
            this.lbHelp1.Location = new System.Drawing.Point(40, 24);
            this.lbHelp1.Name = "lbHelp1";
            this.lbHelp1.Size = new System.Drawing.Size(29, 12);
            this.lbHelp1.TabIndex = 2;
            this.lbHelp1.Text = "稱謂";
            // 
            // tbRemark
            // 
            this.tbRemark.Location = new System.Drawing.Point(92, 193);
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(188, 22);
            this.tbRemark.TabIndex = 3;
            // 
            // lbHelp2
            // 
            this.lbHelp2.AutoSize = true;
            this.lbHelp2.Location = new System.Drawing.Point(42, 58);
            this.lbHelp2.Name = "lbHelp2";
            this.lbHelp2.Size = new System.Drawing.Size(29, 12);
            this.lbHelp2.TabIndex = 4;
            this.lbHelp2.Text = "姓名";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(92, 53);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(188, 22);
            this.tbName.TabIndex = 5;
            // 
            // lbHelp3
            // 
            this.lbHelp3.AutoSize = true;
            this.lbHelp3.Location = new System.Drawing.Point(42, 93);
            this.lbHelp3.Name = "lbHelp3";
            this.lbHelp3.Size = new System.Drawing.Size(29, 12);
            this.lbHelp3.TabIndex = 6;
            this.lbHelp3.Text = "生日";
            // 
            // cbTitle
            // 
            this.cbTitle.FormattingEnabled = true;
            this.cbTitle.Items.AddRange(new object[] {
            "哥哥",
            "姊姊",
            "弟弟",
            "妹妹"});
            this.cbTitle.Location = new System.Drawing.Point(92, 20);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Size = new System.Drawing.Size(188, 20);
            this.cbTitle.TabIndex = 8;
            // 
            // tbClassName
            // 
            this.tbClassName.Location = new System.Drawing.Point(92, 158);
            this.tbClassName.Name = "tbClassName";
            this.tbClassName.Size = new System.Drawing.Size(188, 22);
            this.tbClassName.TabIndex = 12;
            // 
            // lbHelp6
            // 
            this.lbHelp6.AutoSize = true;
            this.lbHelp6.Location = new System.Drawing.Point(42, 198);
            this.lbHelp6.Name = "lbHelp6";
            this.lbHelp6.Size = new System.Drawing.Size(29, 12);
            this.lbHelp6.TabIndex = 11;
            this.lbHelp6.Text = "備註";
            // 
            // tbSchoolName
            // 
            this.tbSchoolName.Location = new System.Drawing.Point(92, 123);
            this.tbSchoolName.Name = "tbSchoolName";
            this.tbSchoolName.Size = new System.Drawing.Size(188, 22);
            this.tbSchoolName.TabIndex = 10;
            // 
            // lbHelp5
            // 
            this.lbHelp5.AutoSize = true;
            this.lbHelp5.Location = new System.Drawing.Point(42, 163);
            this.lbHelp5.Name = "lbHelp5";
            this.lbHelp5.Size = new System.Drawing.Size(29, 12);
            this.lbHelp5.TabIndex = 9;
            this.lbHelp5.Text = "班級";
            // 
            // lbHelp4
            // 
            this.lbHelp4.AutoSize = true;
            this.lbHelp4.Location = new System.Drawing.Point(42, 128);
            this.lbHelp4.Name = "lbHelp4";
            this.lbHelp4.Size = new System.Drawing.Size(29, 12);
            this.lbHelp4.TabIndex = 13;
            this.lbHelp4.Text = "學校";
            // 
            // tbBirthday
            // 
            this.tbBirthday.Location = new System.Drawing.Point(92, 88);
            this.tbBirthday.Name = "tbBirthday";
            this.tbBirthday.Size = new System.Drawing.Size(188, 22);
            this.tbBirthday.TabIndex = 7;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 273);
            this.Controls.Add(this.lbHelp4);
            this.Controls.Add(this.tbClassName);
            this.Controls.Add(this.lbHelp6);
            this.Controls.Add(this.tbSchoolName);
            this.Controls.Add(this.lbHelp5);
            this.Controls.Add(this.cbTitle);
            this.Controls.Add(this.tbBirthday);
            this.Controls.Add(this.lbHelp3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbHelp2);
            this.Controls.Add(this.tbRemark);
            this.Controls.Add(this.lbHelp1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "編輯";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lbHelp1;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.Label lbHelp2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbHelp3;
        private System.Windows.Forms.ComboBox cbTitle;
        private System.Windows.Forms.TextBox tbClassName;
        private System.Windows.Forms.Label lbHelp6;
        private System.Windows.Forms.TextBox tbSchoolName;
        private System.Windows.Forms.Label lbHelp5;
        private System.Windows.Forms.Label lbHelp4;
        private System.Windows.Forms.TextBox tbBirthday;
    }
}