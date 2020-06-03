using K12.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studentsiblings
{
    public partial class EditForm : Form
    {
        StudentRecord _student { get; set; }
        SiblingRecord _sibling { get; set; }

        /// <summary>
        /// 傳入學生資料,為新增模式
        /// </summary>
        public EditForm(StudentRecord student)
        {
            InitializeComponent();

            _student = student;
        }

        /// <summary>
        /// 傳入學生資料+兄弟姊妹資料,為更新模式,
        /// </summary>
        public EditForm(StudentRecord student, SiblingRecord sibling)
        {
            InitializeComponent();
            _student = student;
            _sibling = sibling;

            //設定舊資料至畫面上
            BindData();
        }

        /// <summary>
        /// 資料設定到畫面上
        /// </summary>
        private void BindData()
        {
            tbClassName.Text = _sibling.ClassName;


            DateTime checkDateTime = _sibling.Birthday;
            tbBirthday.Text = checkDateTime.ToString("yyyy/MM/dd");

            tbSchoolName.Text = _sibling.SchoolName;
            tbName.Text = _sibling.SiblingName;
            cbTitle.Text = _sibling.SiblingTitle;
            tbRemark.Text = _sibling.Remark;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_sibling == null)
            {
                //新增模式
                _sibling = new SiblingRecord();
                _sibling.ClassName = tbClassName.Text;

                //如果生日有輸入,且是日期格式
                DateTime checkDateTime;
                DateTime.TryParse(tbBirthday.Text, out checkDateTime);
                if (!string.IsNullOrEmpty(tbBirthday.Text) && checkDateTime != null)
                    _sibling.Birthday = checkDateTime;

                _sibling.SchoolName = tbSchoolName.Text;
                _sibling.SiblingName = tbName.Text;
                _sibling.SiblingTitle = cbTitle.Text;
                _sibling.Remark = tbRemark.Text;

                //新增資料須指定學生ID
                _sibling.StudnetID = int.Parse(_student.ID); //包含學生ID

                //將資料儲存置資料庫
                tool._a.InsertValues(new List<SiblingRecord>() { _sibling });
            }
            else
            {
                //更新模式
                _sibling.ClassName = tbClassName.Text;

                //生日格式正確才儲存
                DateTime checkDateTime;
                DateTime.TryParse(tbBirthday.Text, out checkDateTime);
                if (checkDateTime != null)
                    _sibling.Birthday = checkDateTime;

                _sibling.SchoolName = tbSchoolName.Text;
                _sibling.SiblingName = tbName.Text;
                _sibling.SiblingTitle = cbTitle.Text;
                _sibling.Remark = tbRemark.Text;

                //將資料儲存置資料庫
                //更新不須指定學生ID
                tool._a.UpdateValues(new List<SiblingRecord>() { _sibling });
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
