using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using JYM.Model;

namespace JYM.AutoSystem
{
    public partial class InvestForm : Form
    {
        private readonly BankPageCommon bankPageCommon = new BankPageCommon();
        private readonly long investCount;
        private readonly List<WebBrowser> listweBrowsers;
        private readonly object obj = new object();
        private readonly string productIdentifier;
        private readonly long unitPrise;
        private readonly List<string> userIdentifiers;
        private int hasOverCount;

        public InvestForm(List<string> userIdentifiers, string productIdentifier, long unitPrise, long investCount)
        {
            this.InitializeComponent();
            this.userIdentifiers = userIdentifiers;
            this.unitPrise = unitPrise;
            this.productIdentifier = productIdentifier;
            this.listweBrowsers = this.Getwebbrowsers();
            this.investCount = investCount;
            CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private WebBrowser GetNextWebbrowser(int i)
        {
            lock (this.obj)
            {
                List<WebBrowser> webBrowsers = this.listweBrowsers.Where(x => x.Name == "web_" + i).ToList();
                if (webBrowsers.Count > 0)
                {
                    return webBrowsers[0];
                }
                return null;
            }
        }

        private List<WebBrowser> Getwebbrowsers()
        {
            List<WebBrowser> list = new List<WebBrowser>();
            for (int i = 0; i < this.Controls.Count; i++)
            {
                Control control = this.Controls[i];
                if (control is WebBrowser)
                {
                    list.Add(control as WebBrowser);
                }
            }
            return list;
        }

        private async void InvestForm_Load(object sender, EventArgs e)
        {
            //批量投资
            //Parallel.For(0, this.userIdentifiers.Count, async i =>
            //{
            //});
            for (int i = 0; i < this.userIdentifiers.Count; i++)
            {
                //并行执行
                InvestmentReqeust investmentRequest = new InvestmentReqeust { Amount = this.unitPrise * this.investCount, ClientType = 900, ProductIdentifier = this.productIdentifier, ReturnUrl = "http://www.dev.ad.jinyinmao.com.cn/redirect/Home/?request=http://www.baidu.com", UserIdentifier = this.userIdentifiers[i] };
                await this.bankPageCommon.InvestAction(investmentRequest, () => this.hasOverCount += 1, this.GetNextWebbrowser(i + 1));
            }
            Thread thClosed = new Thread(() =>
                {
                    while (this.hasOverCount < this.userIdentifiers.Count)
                    {
                        Thread.Sleep(3000);
                    }
                    this.Close();
                })
            { IsBackground = true };
            thClosed.Start();
        }
    }
}