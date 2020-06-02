using FISCA.Permission;
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
            item["第一個程式"].Enable = FISCA.Permission.UserAcl.Current["09613d9c-56b6-4511-b046-5b40689d5955"].Executable;
            item["第一個程式"].Click += delegate
             {
                 MessageBox.Show("Hello FISCA!");
             };

            //權限控管
            Catalog ribbon = RoleAclSource.Instance["學生"]["功能按鈕"];
            ribbon.Add(new RibbonFeature("09613d9c-56b6-4511-b046-5b40689d5955", "是否執行Hello"));

            //Sync UDT Schema
            FISCA.UDT.SchemaManager sch = new FISCA.UDT.SchemaManager(FISCA.Authentication.DSAServices.DefaultConnection);
            sch.SyncSchema(new SiblingRecord());

            //ADD資料項目
            K12.Presentation.NLDPanels.Student.AddDetailBulider(
                new FISCA.Presentation.DetailBulider<UCSiblingItem>());

        }
    }
}
