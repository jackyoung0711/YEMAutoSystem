using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using JYM.Model;
using JYM.Service;
using MigrationData.DAL;

namespace JYM.AutoSystem
{
    public partial class UserBankAuthForm : Form
    {
        private readonly Action action;

        private readonly BankPageCommon bankPageCommon = new BankPageCommon();

        //需要充值的userids
        private readonly List<DataGridViewModel> datas;

        private readonly JymService jymService = new JymService();

        private readonly ToolStripButton toolStripButton;
        private bool isFlag; //串行充值
        private int secondsRecharge; //超时

        public UserBankAuthForm(List<DataGridViewModel> datas, ToolStripButton toolStripButton, Action action)
        {
            this.action = action;
            this.datas = datas;
            this.toolStripButton = toolStripButton;
            this.InitializeComponent();
        }

        /// <summary>
        ///     用户授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserBankAuthForm_Load(object sender, EventArgs e)
        {
            //批量充值
            Thread thBtRechar = new Thread(async () =>
                {
                    this.toolStripButton.Enabled = false;
                    foreach (DataGridViewModel data in this.datas)
                    {
                        string useridentifier = data.UserIdentifer;
                        this.lbl_showRechrge.Text = $"{useridentifier}: 正在进行授权操作.......";
                        this.isFlag = false;
                        this.secondsRecharge = 0;
                        BankUserInfo bankUser = await this.jymService.GetBankUserInfoAsync(data.UserIdentifer);
                        if (bankUser == null)
                        {
                            this.lbl_showRechrge.Text = $"{useridentifier}: 该用户还未开户";
                            Thread.Sleep(1500);
                            continue;
                        }
                        //充值
                        string useridentifier1 = useridentifier;
                        await this.bankPageCommon.UserAuth(useridentifier, () =>
                        {
                            this.lbl_showRechrge.Text = $"{useridentifier1}: 该用户授权成功";
                            //记录充值
                            SqlHelper.ExecuteNoneQuery($"update AccountUsers set IsBankAuth=1 where UserIdentifier='{useridentifier1}'");
                            this.isFlag = true;
                        }, this.webBrowser_batchAuth);
                        while (!this.isFlag)
                        {
                            //secondsRecharge
                            Thread.Sleep(4000);
                            this.secondsRecharge += this.secondsRecharge + 4000;
                            if (this.secondsRecharge >= 60000)
                            {
                                this.lbl_showRechrge.Text = $"{useridentifier}: 授权超时";
                                break;
                            }
                        }
                    }
                    this.toolStripButton.Enabled = true;
                    this.action();
                    this.Close();
                })
                { IsBackground = true };
            thBtRechar.Start();
        }
    }
}