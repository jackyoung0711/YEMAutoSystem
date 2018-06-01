using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JYM.AutoSystem
{
    public partial class BatchOpenAccount : Form
    {
        private static BatchOpenAccount instanceBatchOpenAccount;

        private BatchOpenAccount()
        {
            this.InitializeComponent();
        }

        private static Action<int> Action1 { get; set; }

        /// <summary>
        ///     单个程序是单例
        /// </summary>
        /// <returns></returns>
        public static BatchOpenAccount GetBatchOpenAccount(Action<int> action)
        {
            if (instanceBatchOpenAccount == null)
            {
                Action1 = action;
                instanceBatchOpenAccount = new BatchOpenAccount();
            }
            return instanceBatchOpenAccount;
        }

        private void BatchOpenAccount_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     批量开户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_batchOpen_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[1-9]{1}[0-9]{0,4}$");
            string nums = this.txb_BatchOpenAccounts.Text.Trim();
            if (!regex.IsMatch(nums))
            {
                MessageBox.Show("开户数量格式不对,只能是低于六位数的数字且不能为0");
                return;
            }
            Action1(Convert.ToInt16(nums));
            this.Close();
        }
    }
}