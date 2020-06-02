using FISCA.Presentation.Controls;
using K12.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class Program
    {
        [FISCA.MainMethod()]
        public static void main()
        {
            //第一個 RibbonBar 功能
            FISCA.Presentation.RibbonBarItem item = FISCA.Presentation.MotherForm.RibbonBarItems["學生", "康橋"];
            item["第一個程式"].Click += delegate
             {
                 MessageBox.Show("Hello FISCA!");

                 //if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 0)
                 //{
                 //    StudentRecord stud = Student.SelectByID(K12.Presentation.NLDPanels.Student.SelectedSource[0]);
                 //    EditForm edit = new EditForm(stud);
                 //    edit.ShowDialog();
                 //}

             };

            //Sync UDT Schema
            FISCA.UDT.SchemaManager sch = new FISCA.UDT.SchemaManager(FISCA.Authentication.DSAServices.DefaultConnection);
            sch.SyncSchema(new SiblingRecord());

            //ADD資料項目
            K12.Presentation.NLDPanels.Student.AddDetailBulider(new FISCA.Presentation.DetailBulider<UCSiblingItem>());

        }
    }
}
