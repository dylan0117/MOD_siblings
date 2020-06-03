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
            StringBuilder sb_log = new StringBuilder();

            if (_sibling == null)
            {
                sb_log.AppendLine(string.Format("新增學生「{0}」兄弟姊妹資料：", _student.Name));
                sb_log.AppendLine(string.Format("稱謂「{0}」", cbTitle.Text));
                sb_log.AppendLine(string.Format("姓名「{0}」", tbName.Text));
                sb_log.AppendLine(string.Format("生日「{0}」", tbBirthday.Text));
                sb_log.AppendLine(string.Format("學校「{0}」", tbSchoolName.Text));
                sb_log.AppendLine(string.Format("班級「{0}」", tbClassName.Text));
                sb_log.AppendLine(string.Format("備註「{0}」", tbRemark.Text));

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
                try
                {
                    tool._a.InsertValues(new List<SiblingRecord>() { _sibling });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("新增失敗:" + ex.Message);
                    return;
                }

                FISCA.LogAgent.ApplicationLog.Log("兄弟姊妹模組", "新增", sb_log.ToString());
                this.DialogResult = DialogResult.OK;

            }
            else
            {
                sb_log.AppendLine(string.Format("更新學生「 {0} 」兄弟姊妹資料：", _student.Name));
                sb_log.AppendLine(string.Format("稱謂由「{0}」變更為「{1}」", _sibling.SiblingTitle, cbTitle.Text));
                sb_log.AppendLine(string.Format("姓名由「{0}」變更為「{1}」", _sibling.SiblingName, tbName.Text));
                sb_log.AppendLine(string.Format("生日由「{0}」變更為「{1}」", _sibling.Birthday.ToString("yyyy/MM/dd"), tbBirthday.Text));
                sb_log.AppendLine(string.Format("學校由「{0}」變更為「{1}」", _sibling.SchoolName, tbSchoolName.Text));
                sb_log.AppendLine(string.Format("班級由「{0}」變更為「{1}」", _sibling.ClassName, tbClassName.Text));
                sb_log.AppendLine(string.Format("備註由「{0}」變更為「{1}」", _sibling.Remark, tbRemark.Text));
                sb_log.AppendLine("");

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
                try
                {
                    tool._a.UpdateValues(new List<SiblingRecord>() { _sibling });
                }
                catch(Exception ex)
                {
                    MessageBox.Show("更新失敗:" + ex.Message);
                    return;
                }


                FISCA.LogAgent.ApplicationLog.Log("兄弟姊妹模組", "更新", sb_log.ToString());
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
