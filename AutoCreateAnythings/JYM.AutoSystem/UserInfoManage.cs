using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using JYM.Lib;
using JYM.Model;
using JYM.Service;
using MigrationData.DAL;

namespace JYM.AutoSystem
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public partial class UserInfoManage : Form
    {
        private static readonly string userMac = AutoCreateAnyCode.GetMacAddressByNetworkInformation();
        //private static UserInfoManage userInfo;

        private readonly BankPageCommon bankPageCommon = new BankPageCommon();

        private readonly JymService jymService = new JymService();
        private bool isRecharge; //穿行充值
        private int seondsByRecharge; //充值超时时间

        public UserInfoManage()
        {
            this.InitializeComponent();
            this.LoadData = new LoadPageData(this.btn_FirstPage, this.btn_left, this.btn_right, this.btn_LastPage, this.btn_Go, this.lbl_pageinfo1
                , this.lbl_pageinfo2, this.txt_pageIndex, 30, this.dgv_Data, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            CheckForIllegalCrossThreadCalls = false;
        }

        public LoadPageData LoadData { get; }
        public string WhereExpression { get; set; } = string.Empty;

        private void btn_SearchStatistics_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            try
            {
                int a = 0;
                string userIdentifier = this.txb_UserIdentifier.Text.Trim();
                StringBuilder sbSql = new StringBuilder();
                if (!string.IsNullOrEmpty(userIdentifier))
                {
                    sbSql.Append($" and UserIdentifier='{userIdentifier}' ");
                }
                string cellPhone = this.txb_cellPhone.Text.Trim();
                if (!string.IsNullOrEmpty(cellPhone))
                {
                    sbSql.Append($" and CellPhone='{cellPhone}' ");
                }
                //姓名 like查询
                string name = this.txb_Name.Text.Trim();
                if (!string.IsNullOrEmpty(name))
                {
                    sbSql.Append($" and RealName like '%{name}%' ");
                }
                //是否授权
                int selectIndexIsAuth = this.cbx_IsAuth.SelectedIndex;
                if (selectIndexIsAuth > 0)
                {
                    sbSql.Append($" and IsBankAuth = {selectIndexIsAuth - 1} ");
                }
                //是否充值
                int selectIndexIsRecharge = this.cbx_IsRecharge.SelectedIndex;
                if (selectIndexIsRecharge > 0)
                {
                    if (selectIndexIsRecharge == 1)
                    {
                        sbSql.Append(" and RechargeAmount =0 ");
                    }
                    else
                    {
                        sbSql.Append(" and RechargeAmount >0 ");
                    }
                }
                int selectIndex = this.cb_SortType.SelectedIndex;
                string orderSql = selectIndex == 0 ? " order by Id Desc" : " order by Id asc";
                //sbSql.Append(orderSql);
                this.WhereExpression = sbSql.ToString();
                if (sbSql.Length != 0)
                {
                    sbSql.Remove(0, 4);
                }
                //string countSql = sbSql.Length == 0 ? "" : "where " + sbSql.Remove(0, 4);
                this.LoadData.PageIndex = 1;
                this.LoadPageData(this.WhereExpression, orderSql);
                this.LoadData.Lbl_infos1.Text = "每页";
            }
            catch (Exception)
            {
                //
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     选中和取消全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ck_IsSelectedAll_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewHelper.AsAndCs(this.dgv_Data, 0, this.ck_IsSelectedAll.Checked ? 0 : 1);
        }

        private void LoadPageData(string where = null, string order = null)
        {
            //select * from ( select *,ROW_NUMBER() OVER(Order by Id) as rownum from Account) as twhere t.rownum between (@pageIndex - 1) * pageSize + 1 and @pageSize * pageIndex order by t.Id asc
            this.LoadData.Func = () => SqlHelper.Query($"select * from(select *,ROW_NUMBER() OVER({order}) as rownum from AccountUsers where  IsActivity=1 {where})as t where t.rownum between {(this.LoadData.PageIndex - 1) * this.LoadData.PageSize + 1} and {this.LoadData.PageSize * this.LoadData.PageIndex}", null, false);

            this.LoadData.FuncNums = () => Convert.ToInt16(SqlHelper.ExecuteScalar($"select count(*) from AccountUsers where  IsActivity=1 {where}"));

            this.LoadData.LoadOneTablePageData();
            this.LoadData.Action = () => this.LoadData.Lbl_infos1.Text = "每页";
            this.LoadData.Atcion1 = () => { };
        }

        /// <summary>
        ///     批量充值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.dgv_Data.Rows.Count == 0)
            {
                MessageBox.Show("数据表中没有数据还不能进行此次操作", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //GetCheckdCloumnsDatasModels
            List<DataGridViewModel> models = DataGridViewHelper.GetCheckdCloumnsDatasModels(this.dgv_Data, 0, 1);
            if (models == null || models.Count == 0)
            {
                MessageBox.Show("请选择需要执行的记录", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //BatchRecharge
            BatchRechargeForm bathBatchRechargeForm = new BatchRechargeForm(models, this.toolStripButton1, () => this.LoadPageData(this.WhereExpression, this.cb_SortType.SelectedIndex == 0 ? " order by Id Desc" : " order by Id asc"));
            bathBatchRechargeForm.Show();
        }

        /// <summary>
        ///     批量投资
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            List<string> selectedUserIdentifiers = DataGridViewHelper.GetCheckdCloumnsData(this.dgv_Data, 0, 1);
            if (selectedUserIdentifiers == null || selectedUserIdentifiers.Count == 0)
            {
                MessageBox.Show("数据表中没有数据还不能进行此次操作", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //投资
            if (MessageBox.Show("批量投资选中的用户账户必须余额足够,您确定继续吗？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BatchInvestForm batchInvestForm = new BatchInvestForm(selectedUserIdentifiers);
                batchInvestForm.ShowDialog();
            }
            //this.toolStripButton3.Enabled = false;
            //List<RegularProductInfo> infos = await this.jymService.GetAllProductInfo();
        }

        /// <summary>
        ///     其它功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     批量授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (this.dgv_Data.Rows.Count == 0)
            {
                MessageBox.Show("数据表中没有数据还不能进行此次操作", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //GetCheckdCloumnsDatasModels
            List<DataGridViewModel> models = DataGridViewHelper.GetCheckdCloumnsDatasModels(this.dgv_Data, 0, 1);
            if (models == null || models.Count == 0)
            {
                MessageBox.Show("请选择需要执行的记录", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<DataGridViewModel> dataGridViewModels = models.Where(x => x.IsBankAuth == "0").ToList();
            if (dataGridViewModels.Count == 0)
            {
                MessageBox.Show("数据表中没有数据是需要授权的", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //BatchRecharge
            UserBankAuthForm form = new UserBankAuthForm(models, this.toolStripButton5, () => this.LoadPageData(this.WhereExpression, this.cb_SortType.SelectedIndex == 0 ? " order by Id Desc" : " order by Id asc"));
            //BatchRechargeForm bathBatchRechargeForm = new BatchRechargeForm(models, this.toolStripButton1, () => this.LoadPageData(this.WhereExpression, this.cb_SortType.SelectedIndex == 0 ? " order by Id Desc" : " order by Id asc"));
            form.Show();
        }

        /// <summary>
        ///     批量下订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (this.dgv_Data.Rows.Count == 0)
            {
                MessageBox.Show("数据表中没有数据还不能进行此次操作", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //GetCheckdCloumnsDatasModels
            List<DataGridViewModel> models = DataGridViewHelper.GetCheckdCloumnsDatasModels(this.dgv_Data, 0, 1);
            if (models == null || models.Count == 0 || models.Where(x => x.IsBankAuth == "1" && x.RechargeAmount > 0).ToList().Count == 0)
            {
                MessageBox.Show("请选择需要执行的记录,获取选择的用户不满足购买条件", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //BatchRecharge
            BatchPurchaseForm form = new BatchPurchaseForm(models.Select(x => x.UserIdentifer).ToList());
            form.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            BatchDebtForm form = new BatchDebtForm();
            form.ShowDialog();
        }

        private void UserInfoManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Dispose();
        }

        private void UserInfoManage_Load(object sender, EventArgs e)
        {
            this.cb_SortType.SelectedIndex = 0;
            this.cbx_IsAuth.SelectedIndex = 0;
            this.cbx_IsRecharge.SelectedIndex = 0;
            this.LoadData.PicShow = this.picShow;
            this.cbx_pageSize.SelectedIndex = 0;
            this.LoadPageData(null, " order by Id desc");
            this.LoadData.Lbl_infos1.Text = "每页";
            //为页面容量设置改变事件
            this.cbx_pageSize.SelectedValueChanged += (objP, exP) =>
            {
                //获取此时的页码
                int pageSize = Convert.ToInt32(this.cbx_pageSize.Text);
                this.LoadData.PageSize = pageSize;
                this.LoadData.PageIndex = 1;
                this.LoadPageData(this.WhereExpression, this.cb_SortType.SelectedIndex == 0 ? " order by Id Desc" : " order by Id asc");
                this.LoadData.Lbl_infos1.Text = "每页";
            };
            //右键添加点击事件
            CreateContextMenuStripInstance cst = new CreateContextMenuStripInstance();
            cst.AddToolStripMenuItems(new List<ToolStripMenuItem>
            {
                new ToolStripMenuItem("复制UserIdentifier(当前行)", null, (obj1, ex1) =>
                {
                    if (this.dgv_Data.SelectedRows.Count > 0)
                    {
                        if (this.dgv_Data.SelectedRows.Count > 0)
                        {
                            Clipboard.SetDataObject(this.dgv_Data.SelectedRows[0].Cells[1].Value.ToString());
                            MessageBox.Show("已经复制到剪贴板了");
                        }
                    }
                }, ""),
                new ToolStripMenuItem("复制CellPhone(当前行)", null, (obj1, ex1) =>
                {
                    if (this.dgv_Data.SelectedRows.Count > 0)
                    {
                        Clipboard.SetDataObject(this.dgv_Data.SelectedRows[0].Cells[2].Value.ToString());
                        MessageBox.Show("已经复制到剪贴板了");
                    }
                }),
                new ToolStripMenuItem("复制UserIdentifier(当前页 格式：每行一个)", null, (obj1, ex1) =>
                {
                    StringBuilder sbUserIndentifiers = new StringBuilder();
                    DataGridViewRowCollection drs = this.dgv_Data.Rows;
                    foreach (DataGridViewRow dr in drs)
                    {
                        sbUserIndentifiers.Append(dr.Cells[1].Value);
                        sbUserIndentifiers.Append("\r\n");
                    }
                    Clipboard.SetDataObject(sbUserIndentifiers.ToString());
                    MessageBox.Show("已经复制到剪贴板了");
                }),
                new ToolStripMenuItem("复制UserIdentifier(当前页 格式：逗号隔开)", null, (obj1, ex1) =>
                {
                    DataGridViewRowCollection drs = this.dgv_Data.Rows;
                    List<string> list = (from DataGridViewRow dr in drs select dr.Cells[1].Value.ToString()).ToList();
                    Clipboard.SetDataObject(string.Join(",", list));
                    MessageBox.Show("已经复制到剪贴板了");
                }),
                new ToolStripMenuItem("查询余额(当前选中用户)", null, (obj1, ex1) =>
                {
                    if (this.dgv_Data.SelectedRows.Count > 0)
                    {
                        Thread thBalance = new Thread(() =>
                        {
                            BankUserBalance bankUserBalance = this.jymService.GetBankUserBalance(this.dgv_Data.SelectedRows[0].Cells[1].Value.ToString()).Result;
                            if (bankUserBalance == null)
                            {
                                MessageBox.Show("该用户信息异常，请稍后重试");
                                return;
                            }
                            if (bankUserBalance.RespCode != 1)
                            {
                                MessageBox.Show("该用户信息异常，请稍后重试");
                                return;
                            }
                            MessageBox.Show($"该余额为：{bankUserBalance.AvailableBalance}");
                        }) { IsBackground = true };
                        thBalance.Start();
                    }
                }),
                new ToolStripMenuItem("预申购(当前用户)", null, (obj1, ex1) =>
                {
                    if (this.dgv_Data.SelectedRows.Count > 0)
                    {
                        //弹出页面供用户选择
                        PurchaseOrderForm purchaseOrderForm = new PurchaseOrderForm(this.dgv_Data.SelectedRows[0].Cells[1].Value.ToString());
                        purchaseOrderForm.ShowDialog();
                    }
                })
            });
            DataGridViewHelper.AddCellMouseDownClick(this.dgv_Data, cst.GetContexMenuStrip());
        }
    }
}