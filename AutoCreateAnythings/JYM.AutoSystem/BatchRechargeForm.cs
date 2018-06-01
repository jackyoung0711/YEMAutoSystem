using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using JYM.Model;
using JYM.Service;
using MigrationData.DAL;

namespace JYM.AutoSystem
{
    public partial class BatchRechargeForm : Form
    {
        private readonly Action action;
        private readonly BankPageCommon bankPageCommon = new BankPageCommon();
        private readonly JymService jymService = new JymService();
        private readonly ToolStripButton toolStripButton;

        //需要充值的userids
        private readonly List<DataGridViewModel> userIndentifiers;

        private bool isFlag; //串行充值
        private int secondsRecharge; //超时

        public BatchRechargeForm(List<DataGridViewModel> userIndentifiers, ToolStripButton toolStripButton, Action action)
        {
            this.userIndentifiers = userIndentifiers;
            this.action = action;
            this.toolStripButton = toolStripButton;
            this.InitializeComponent();
        }

        private void BatchRechargeForm_Load(object sender, EventArgs e)
        {
            //批量充值
            Thread thBtRechar = new Thread(async () =>
                {
                    this.toolStripButton.Enabled = false;
                    foreach (DataGridViewModel data in this.userIndentifiers)
                    {
                        string useridentifier = data.UserIdentifer;
                        this.lbl_showRechrge.Text = $"{useridentifier}: 正在进行充值操作.......";
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
                        RechargeReqeust rechargeReqeust = new RechargeReqeust { Amount = 8000000000, ChannelType = 10, ClientType = 900, ReturnUrl = "http://www.dev.ad.jinyinmao.com.cn/redirect/Home/?request=http://www.baidu.com", UserIdentifier = useridentifier, Password = data.Password, CellPhone = data.CellPhone };
                        string useridentifier1 = useridentifier;
                        await this.bankPageCommon.Recharge(rechargeReqeust, () =>
                        {
                            this.lbl_showRechrge.Text = $"{useridentifier1}: 该用户充值成功";
                            //记录充值
                            SqlHelper.ExecuteNoneQuery($"update AccountUsers set RechargeNums=RechargeNums+1,RechargeAmount=RechargeAmount+{8000000000} where UserIdentifier='{useridentifier1}'");
                            this.isFlag = true;
                        }, this.webBrowser_batchRecharge);
                        while (!this.isFlag)
                        {
                            //secondsRecharge
                            Thread.Sleep(4000);
                            this.secondsRecharge += this.secondsRecharge + 4000;
                            if (this.secondsRecharge >= 60000)
                            {
                                this.lbl_showRechrge.Text = $"{useridentifier}: 充值超时";
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

        private void button1_Click(object sender, EventArgs e)
        {
            HtmlDocument htmlDocument = this.webBrowser_batchRecharge.Document;
            HtmlElement bankLiElement = htmlDocument?.GetElementById("list-bank1")?.GetElementsByTagName("li")[0];
            //click
            bankLiElement?.InvokeMember("click");
            //webBrowser.Document?.InvokeScript("var tabList=document.getElementById('list-bank1');chooseBank(tabList.firstElementChild,1);");
            //HtmlElement setPwd = htmlDocument?.GetElementById("payPassword"); //输入密码
            //HtmlElement parent = setPwd?.Parent?.GetElementsByTagName("button")[0]; //htmlDocument.GetElementById("toggle2"); //
            //parent?.InvokeMember("click");
            ////获取到键值为1的id
            //HtmlElement key1 = htmlDocument?.GetElementById("key11");
            //key1?.InvokeMember("click");
            //key1?.InvokeMember("click");
            //key1?.InvokeMember("click");
            //key1?.InvokeMember("click");
            //key1?.InvokeMember("click");
            //key1?.InvokeMember("click");
            ////
            //htmlDocument?.GetElementById("submitBtn")?.InvokeMember("click");
            //webBrowser.Navigate("javascript:var tabList=document.getElementById('list-bank1');chooseBank(tabList.firstElementChild,1);");
            //webBrowser.Navigate("javascript:sub_form();");
        }
    }
}