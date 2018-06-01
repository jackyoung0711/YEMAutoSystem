using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using JYM.Model;
using JYM.Service;

namespace JYM.AutoSystem
{
    public partial class BatchInvestForm : Form
    {
        private readonly JymService jymService = new JymService();
        private readonly List<string> userIdentifiers;

        public BatchInvestForm(List<string> userIdentifiers)
        {
            this.userIdentifiers = userIdentifiers;
            this.InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void HidePic()
        {
            if (this.picShow.InvokeRequired)
            {
                //在执行此对象的主线程上执行委托。
                //System.IAsyncResult BeginInvoke(System.Delegate method, object[] args) args: 作为给定方法的参数传递的 System.Object 类型数组。如果不需要参数，则可以为 null。
                //method: 对方法的 System.Delegate，采用 args 中包含的相同数字和类型的参数。
                this.picShow.BeginInvoke(new UpdatePic(this.HidePic), null);
                return;
            }
            //执行完毕后图片消失
            this.picShow.Hide();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatchInvestForm_Load(object sender, EventArgs e)
        {
            this.picShow.Show();
            Thread thStart = new Thread(() =>
                {
                    Thread.Sleep(1000);
                    this.LoadData();
                    this.picShow.Hide();
                })
                { IsBackground = true };
            thStart.Start();
            CreateContextMenuStripInstance cst = new CreateContextMenuStripInstance();
            cst.AddToolStripMenuItems(new List<ToolStripMenuItem>
            {
                new ToolStripMenuItem("批量投资(当前行)", null, (obj1, ex1) =>
                {
                    if (this.dgv_Data.SelectedRows.Count > 0)
                    {
                        //判断数据是否整个
                        long count = 1;
                        try
                        {
                            count = Convert.ToInt64(this.txb_InvestCount.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("输入的投资笔数格式不正确");
                            return;
                        }
                        //判断是否超了
                        long leftCount = Convert.ToInt64(this.dgv_Data.SelectedRows[0].Cells[7].Value);
                        if (leftCount < this.userIdentifiers.Count * count)
                        {
                            MessageBox.Show("投资总笔数大于该产品的剩余份数");
                            return;
                        }
                        InvestForm investForm = new InvestForm(this.userIdentifiers, this.dgv_Data.SelectedRows[0].Cells[1].Value.ToString(), Convert.ToInt64(this.dgv_Data.SelectedRows[0].Cells[4].Value), count);
                        investForm.Show();
                    }
                }, "")
            });
            DataGridViewHelper.AddCellMouseDownClick(this.dgv_Data, cst.GetContexMenuStrip());
        }

        //loadData
        private void LoadData()
        {
            try
            {
                List<RegularProductInfo> productInfos = this.jymService.GetAllProductInfo().Result;
                //100000010 100000020
                DataTable dtDgv = new DataTable();
                dtDgv.Columns.Add(new DataColumn("productCatorgary", Type.GetType("System.String")));
                dtDgv.Columns.Add(new DataColumn("ProductId", Type.GetType("System.String")));
                dtDgv.Columns.Add(new DataColumn("FinancingSumAmount", Type.GetType("System.String")));
                dtDgv.Columns.Add(new DataColumn("paidAmount", Type.GetType("System.String")));
                dtDgv.Columns.Add(new DataColumn("UnitPrise", Type.GetType("System.String")));
                dtDgv.Columns.Add(new DataColumn("yield", Type.GetType("System.String")));
                dtDgv.Columns.Add(new DataColumn("period", Type.GetType("System.String")));
                dtDgv.Columns.Add(new DataColumn("leftCount", Type.GetType("System.String")));
                foreach (RegularProductInfo t in productInfos)
                {
                    DataRow dr = dtDgv.NewRow();
                    dr[0] = t.ProductCategory == 100000010 ? "商票" : "银票";
                    dr[1] = t.ProductId.ToString().Replace("-", "").ToUpper();
                    dr[2] = t.FinancingSumAmount.ToString();
                    dr[3] = t.PaidAmount;
                    dr[4] = t.UnitPrice;
                    dr[5] = (t.Yield * 1.0 / 100).ToString(CultureInfo.InvariantCulture);
                    dr[6] = t.Period.ToString();
                    dr[7] = (t.FinancingSumAmount - t.PaidAmount) / t.UnitPrice;
                    //int index = this.dgv_Data.Rows.Add()
                    //DataGridViewRow dr = this.dgv_Data.Rows[index];
                    dtDgv.Rows.Add(dr);
                }
                DataGridViewHelper.InsertDataToDgv(dtDgv, this.dgv_Data, new List<int> { 2, 3, 4, 5 });
            }
            catch (Exception e)
            {
                MessageBox.Show("没有可以投资的标的,请让夏敏上一下");
            }
        }

        #region Nested type: UpdatePic

        private delegate void UpdatePic();

        #endregion
    }
}