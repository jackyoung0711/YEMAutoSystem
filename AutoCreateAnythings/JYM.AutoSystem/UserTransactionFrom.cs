using System;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JYM.AutoSystem
{
    public partial class UserTransactionFrom : Form
    {
        private readonly string bankUrl;
        private int secondsOpenAccount;

        public UserTransactionFrom()
        {
            this.bankUrl = ConfigurationManager.AppSettings["BankTransferUrl"];
            this.InitializeComponent();
        }

        /// <summary>
        ///     批量获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_batchGet_Click(object sender, EventArgs e)
        {
            try
            {
                this.btn_batchGet.Enabled = false;
                this.btn_Transfer.Enabled = false;
                this.lbl_showMsg.Text = "开始获取,请稍等......";
                BankPageCommon bankPageCommon = new BankPageCommon();
                Task.Run(async () =>
                {
                    string[] userInfos = File.ReadAllLines(@"TransactionText/UserIds.txt");
                    int i = 0;
                    foreach (string userId in userInfos)
                    {
                        this.secondsOpenAccount = 0;
                        i = i + 1;
                        int index = i;
                        this.lbl_showMsg.Text = $"正在获取第{i}个用户的数据.......";
                        bool isCompelete = false;
                        await bankPageCommon.GetUserTransactoin(userId, this.bankUrl, this.webBrowser1, () =>
                        {
                            isCompelete = true;
                            this.lbl_showMsg.Text = $"第{index}个用户获取完成";
                        });
                        while (!isCompelete)
                        {
                            Thread.Sleep(2000);
                            this.secondsOpenAccount += 2000;
                            if (this.secondsOpenAccount >= 600000000)
                            {
                                this.lbl_showMsg.Text = $"第{index}个用户获取失败";
                                break;
                            }
                        }
                    }
                    this.btn_batchGet.Enabled = true;
                    this.btn_Transfer.Enabled = true;
                    this.lbl_showMsg.Text = "全部获取完成";
                });
            }
            catch (Exception ex)
            {
                this.btn_batchGet.Enabled = true;
                this.btn_Transfer.Enabled = true;
                this.lbl_showMsg.Text = "发生一个错误" + ex.Message;
            }
        }

        private async void btn_Transfer_Click(object sender, EventArgs e)
        {
            string userId = this.txb_UserId.Text.Trim();
            BankPageCommon bankPageCommon = new BankPageCommon();
            await bankPageCommon.GetUserTransactoin(userId, this.bankUrl, this.webBrowser1);
        }

        /// <summary>
        ///     用户流水
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserTransactionFrom_Load(object sender, EventArgs e)
        {
        }
    }
}