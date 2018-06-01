using System;
using System.Data;
using System.Windows.Forms;
using MigrationData.DAL;

namespace JYM.AutoSystem
{
    public partial class RedeemCheck : Form
    {
        public RedeemCheck()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql1 = "(SELECT UserAssetRatioId FROM Core.RedeemOrderDetail WHERE Status=0 AND AssetRatioType = 1)";
            string sql2 = "SELECT * FROM Core.RequestBatchDetails WHERE Info LIKE '%@Id@%' AND TypeId=50  ";
            DataTable dt = SqlHelperByYem.ExecuteDataTable(sql1);

            foreach (DataRow dtRow in dt.Rows)
            {
                //SqlHelperByYem.ExecuteDataTable(sql2.Replace("@Id@",dtRow.));
            }
        }

        //债权检查
        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Core.DeptAssignRelations WHERE OldUserAssetRatioId IN (SELECT UserAssetRatioId FROM Core.RedeemOrderDetail WHERE Status=0 AND AssetRatioType = 2)";
            DataTable dt = SqlHelperByYem.ExecuteDataTable(sql);
        }
    }
}