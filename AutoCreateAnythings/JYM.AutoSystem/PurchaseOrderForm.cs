using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using JYM.Service;

namespace JYM.AutoSystem
{
    public partial class PurchaseOrderForm : Form
    {
        private readonly JymService jymService = new JymService();
        private readonly string userId;

        public PurchaseOrderForm(string userId)
        {
            this.userId = userId;
            this.InitializeComponent();
        }

        /// <summary>
        ///     购买
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_purchase_Click(object sender, EventArgs e)
        {
            try
            {
                string txtNums = this.txb_Nums.Text.Trim();
                if (string.IsNullOrEmpty(txtNums))
                {
                    MessageBox.Show("请输入购买份数");
                    return;
                }
                //判断金额
                int nums = Convert.ToInt16(txtNums);
                if (nums > 10000 || nums <= 0)
                {
                    MessageBox.Show("输入购买份数数据不在范围内");
                    return;
                }
                long amount = nums * 10000;
                this.btn_purchase.Enabled = false;
                //购买
                Task taskPurchase = Task.Run(async () =>
                {
                    bool result = await this.jymService.PurchaseOrders(amount, this.userId);
                    MessageBox.Show("执行完毕,执行结果:" + (result ? "TRUE" : "FALSE"));
                });
                Task.WhenAll(taskPurchase);
                this.btn_purchase.Enabled = true;
            }
            catch (Exception exception)
            {
                this.btn_purchase.Enabled = true;
                MessageBox.Show(exception.Message);
            }
        }

        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            this.txb_userid.Text = this.userId;
        }
    }
}