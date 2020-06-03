using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studentsiblings
{
    /// <summary>
    /// 權限代碼定義與顯示名稱
    /// </summary>
    [FISCA.Permission.FeatureCode("kcbs_detail_item_sibling", "兄弟姊妹")]
    internal partial class UCSiblingItem : FISCA.Presentation.DetailContent
    {
        //背景取得資料
        BackgroundWorker _bgw = new BackgroundWorker();

        //目前資料是哪一位學生
        K12.Data.StudentRecord _student { get; set; }

        //資料切換旗標
        bool _bgwFlag = false;

        public UCSiblingItem()
        {
            InitializeComponent();

            this.Group = "兄弟姊妹";

            _bgw.DoWork += Bgw_DoWork;
            _bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
        }

        /// <summary>
        /// 當使用者切換選擇對象時
        /// </summary>
        protected override void OnPrimaryKeyChanged(EventArgs e)
        {
            //轉圈圈開始轉動
            this.Loading = true;

            //對象的系統編號
            if (this.PrimaryKey != "")
            {
                //當系統忙碌時,資料再一次切換
                if (_bgw.IsBusy)
                {       //資料更新旗標
                    _bgwFlag = true;
                }
                else
                {
                    //開始非同步作業
                    _bgw.RunWorkerAsync();
                }
            }
        }

        /// <summary>
        /// 資料取得
        /// </summary>
        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            //取得目前資料是哪一位學生
            _student = K12.Data.Student.SelectByID(this.PrimaryKey);

            //取得該名學生的UDT資料
            List<SiblingRecord> siblingsList = tool._a.Select<SiblingRecord>
                (string.Format("ref_student_id={0}", _student.ID));

            //將作業結果傳遞至 Completed
            e.Result = siblingsList;
        }

        /// <summary>
        /// 畫面建置
        /// </summary>
        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //如果 , 有新的更新需求傳入
            if (_bgwFlag)
            {
                //進行最後一次背景作業
                _bgwFlag = false;
                _bgw.RunWorkerAsync();
                return;
            }
            //沒有更新需求,則建置畫面
            List<SiblingRecord> siblingsList = (List<SiblingRecord>)e.Result;
            //將資料設定到畫面上
            BindData(siblingsList);

            //轉圈圈停止
            this.Loading = false;

        }

        /// <summary>
        /// 畫面建置
        /// </summary>
        private void BindData(List<SiblingRecord> siblingsList)
        {
            //先清除舊有資料
            this.listView1.Items.Clear();

            //建立每一筆資料
            foreach (SiblingRecord each in siblingsList)
            {
                ListViewItem item = new ListViewItem(each.SiblingTitle); //稱謂
                item.SubItems.Add(each.SiblingName); //姓名
                item.SubItems.Add(each.Birthday.ToString("yyyy/MM/dd")); //生日
                item.SubItems.Add(each.SchoolName); //學校
                item.SubItems.Add(each.ClassName); //班級
                item.SubItems.Add(each.Remark); //備註

                //把原本的UDT資料儲存在TAG
                item.Tag = each;
                //加入畫面上
                listView1.Items.Add(item);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(_student);
            DialogResult dr = editForm.ShowDialog();

            //如果確認,就更新系統
            if (dr == DialogResult.OK)
            {
                _bgw.RunWorkerAsync();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                SiblingRecord record = (SiblingRecord)listView1.SelectedItems[0].Tag;
                EditForm editForm = new EditForm(_student, record);
                DialogResult dr = editForm.ShowDialog();
                //如果確認,就更新系統
                if (dr == DialogResult.OK)
                {
                    _bgw.RunWorkerAsync();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //使用者確定有選取資料
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult dr = MessageBox.Show("是否刪除資料?", "警告", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    StringBuilder sb_log = new StringBuilder();
                    sb_log.AppendLine(string.Format("刪除「{0}」兄弟姊妹資料:", _student.Name));

                    List<SiblingRecord> SiblingList = new List<SiblingRecord>();
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        SiblingRecord sibling = (SiblingRecord)item.Tag;
                        SiblingList.Add(sibling);

                        sb_log.AppendLine(string.Format("稱謂「{0}」", sibling.SiblingTitle));
                        sb_log.AppendLine(string.Format("姓名「{0}」", sibling.SiblingName));
                        sb_log.AppendLine(string.Format("生日「{0}」", sibling.Birthday.ToString("yyyy/MM/dd")));
                        sb_log.AppendLine(string.Format("學校「{0}」", sibling.SchoolName));
                        sb_log.AppendLine(string.Format("班級「{0}」", sibling.ClassName));
                        sb_log.AppendLine(string.Format("備註「{0}」", sibling.Remark));
                        sb_log.AppendLine("");
                    }

                    //開始刪除資料
                    try
                    {
                        tool._a.DeletedValues(SiblingList);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("刪除失敗:" + ex.Message);
                        return;
                    }

                    FISCA.LogAgent.ApplicationLog.Log("兄弟姊妹模組", "刪除", sb_log.ToString());

                    //刪除後更新畫面
                    _bgw.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("已取消");
                }
            }
            else
            {
                MessageBox.Show("未選擇資料");
            }
        }
    }
}
