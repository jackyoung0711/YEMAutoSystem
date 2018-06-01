using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using JYM.Service;
using MigrationData.DAL;

namespace JYM.AutoSystem
{
    public partial class BatchPurchaseForm : Form
    {
        private readonly JymService jymService = new JymService();
        private readonly List<string> userIds;

        public BatchPurchaseForm(List<string> userIds)
        {
            this.userIds = userIds;
            this.InitializeComponent();
        }

        private void BatchPurchaseForm_Load(object sender, EventArgs e)
        {
            this.cbx_AmountRange.SelectedIndex = 0;
            this.cbx_Type.SelectedIndex = 0;
            this.txb_EAmount.Text = "0";
            this.txb_SAmount.Text = "0";
            this.txb_EAmount.Enabled = true;
            this.txb_SAmount.Enabled = true;
        }

        /// <summary>
        ///     批量预申购
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_purchase_Click(object sender, EventArgs e)
        {
            try
            {
                //验证数据
                //1.金额范围 100-30000元之间 1-300
                int indexAmountRange = this.cbx_AmountRange.SelectedIndex;
                int startIndex = 1;
                int endIndex = 301;
                if (indexAmountRange == 1)
                {
                    //自定义
                    int index1 = Convert.ToInt16(this.txb_SAmount.Text.Trim());
                    int index2 = Convert.ToInt16(this.txb_EAmount.Text.Trim());
                    if (index1 < startIndex || index1 >= endIndex)
                    {
                        MessageBox.Show("开始金额不对,金额范围应该是1-300的数");
                        return;
                    }
                    if (index2 <= startIndex || index2 > endIndex)
                    {
                        MessageBox.Show("结束金额不对,金额范围应该是2-301的数");
                        return;
                    }
                    startIndex = index1;
                    endIndex = index2;
                }
                //2.本次需要申购的数据
                int numsTotal = Convert.ToInt16(this.txb_NumsTotal.Text.Trim());
                if (numsTotal == 0)
                {
                    MessageBox.Show("输入的份数必须大于0");
                    return;
                }
                //3.如果是第三种方式 先将重复的数据移除
                int indexType = this.cbx_Type.SelectedIndex; //0 可重复 1. 不重复 2. 人不重复且订单不重复
                if (indexType == 2)
                {
                    //获取所有订单中的UserId 移除
                    DataTable dt = SqlHelperByYem.ExecuteDataTable("select UserId from core.orders where RemainingAmount >90");
                    if (dt != null)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            this.userIds.Remove(dt.Rows[i]["UserId"].ToString());
                        }
                        if (this.userIds.Count == 0)
                        {
                            MessageBox.Show("所选择的用户中没有满足条件的用户可以购买,请重新选择其他用户批量购买");
                            return;
                        }
                    }
                }
                this.lbl_showMSg.Text = "执行提示:正在批量下订单操作........";
                this.btn_purchase.Enabled = false;
                Random random = new Random();
                int successNums = 0;
                int failedNums = 0;
                //3.选择哪种申购方式
                for (int i = 0; i < numsTotal; i++)
                {
                    //申购
                    long amount = random.Next(startIndex, endIndex) * 10000;
                    //人数
                    string userId = this.userIds[random.Next(0, this.userIds.Count)];
                    //购买操作
                    bool result = await this.jymService.PurchaseOrders(amount, userId);
                    if (result)
                    {
                        //提示成功了多少笔
                        successNums++;
                    }
                    else
                    {
                        failedNums++;
                    }
                    if (indexType == 0) continue;
                    //都要移除 购买完一次后
                    this.userIds.Remove(userId);
                    if (this.userIds.Count == 0)
                    {
                        break;
                    }
                }
                //结束了
                this.btn_purchase.Enabled = true;
                this.lbl_showMSg.Text = $"执行提示:执行完毕,成功数量{successNums},失败数量:{failedNums}";
                this.Close();
            }
            catch (Exception exception)
            {
                this.btn_purchase.Enabled = true;
                this.lbl_showMSg.Text = $"执行提示:{exception.Message}";
            }
        }
    }
}