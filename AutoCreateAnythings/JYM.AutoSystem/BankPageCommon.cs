using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using JYM.Lib;
using JYM.Model;
using JYM.Service;

namespace JYM.AutoSystem
{
    public class BankPageCommon
    {
        private readonly JymService jymService = new JymService();

        /// <summary>
        ///     获取用户流水的东西 哈哈哈
        /// </summary>
        /// <returns></returns>
        public async Task GetUserTransactoin(string userId, string urlB, WebBrowser webBrowser = null, Action action = null)
        {
            SetWebbrowser.SumitForm(12);

            if (webBrowser == null)
            {
                webBrowser = new WebBrowser();
            }
            webBrowser.ScriptErrorsSuppressed = true;
            //InvestmentReqeust investmentRequest = new InvestmentReqeust { Amount = 10000, CellPhone = registerSuccessInfo.CellPhone, ClientType = 900, ProductIdentifier = "33B97C6537564B3FB349B35C949A930F", ReturnUrl = "http://www.dev.ad.jinyinmao.com.cn/redirect/Home/?request=http://www.baidu.com", Pwd = registerSuccessInfo.Pwd };
            BankSercrityInfo bankSercrityInfo = await this.jymService.GetInformationData(userId); //http://fsgw.hkmdev.firstpay.com/
            if (bankSercrityInfo.MerchantId == null)
            {
                //标识
                if (action != null)
                {
                    action();
                }
                return;
            }
            string url = $"{urlB}phoenixFS-fsgw/gateway?data={HttpUtility.UrlEncode(bankSercrityInfo.Data)}&tm={HttpUtility.UrlEncode(bankSercrityInfo.Tm)}&merchantId={bankSercrityInfo.MerchantId}";
            //添加一个
            string transgerUrl = ConfigurationManager.AppSettings["TransferUrl"];
            webBrowser.Navigate(new Uri(url, UriKind.Absolute));
            int index = 0;
            webBrowser.DocumentCompleted += (obj, e) =>
            {
                if (webBrowser.ReadyState < WebBrowserReadyState.Complete) return;
                HtmlDocument htmlDocument = webBrowser.Document;
                if (index == 0)
                {
                    if (htmlDocument != null)
                    {
                        Thread th = new Thread(() =>
                            {
                                try
                                {
                                    //先获取余额
                                    HtmlElement elementsBySpan = htmlDocument.GetElementsByTagName("span")[3];
                                    string leftAmount = elementsBySpan.InnerText.Replace(",", "");
                                    Logger.LoadData(@"TransactionText\UserLeftAmount.txt", $"{userId},{leftAmount}");
                                    bool isRedirect = false;
                                    do
                                    {
                                        webBrowser.Navigate("javascript:var domList = $('a.underline');$.each($(domList), function (index, dom) { dom = $(dom); if (dom.text().trim() === '查看') { window.location.href = window.location.origin + dom.attr('href')}})");
                                        Thread.Sleep(2000);
                                        //判断
                                        string htmlText = htmlDocument.Body?.InnerText;
                                        if (htmlText != null && htmlText.Contains("账户流水查询"))
                                        {
                                            isRedirect = true;
                                        }
                                    } while (!isRedirect);
                                    //执行第二页
                                    string url32 = webBrowser.Url.AbsoluteUri;
                                    string htmlRqid = htmlDocument.GetElementsByTagName("input")[4].GetAttribute("value");
                                    if (string.IsNullOrEmpty(htmlRqid))
                                    {
                                        if (action != null)
                                        {
                                            action();
                                        }
                                        return;
                                    }

                                    string urlBase = $"{transgerUrl}phoenixFS-web/manage/showAccountQueryforJson?reqId={htmlRqid}&timeCode=4&timeType=1&pageSize=1000";
                                    WebClient webClient = new WebClient();
                                    List<BankDataModel> listBankDataModels = new List<BankDataModel>();
                                    //先获取page
                                    byte[] allData1 = webClient.DownloadData(urlBase);
                                    string jsonData1 = Encoding.UTF8.GetString(allData1);
                                    BankDataModel bankDataModel1 = StringExtensions.FromJson<BankDataModel>(jsonData1);
                                    int totalPage = bankDataModel1.totalPage;
                                    int totalNums = bankDataModel1.pageNum;
                                    if (totalPage == 0)
                                    {
                                        if (action != null)
                                        {
                                            action();
                                        }
                                        return;
                                    }
                                    for (int j = 0; j <= totalNums; j++)
                                    {
                                        urlBase = $"{transgerUrl}phoenixFS-web/manage/showAccountQueryforJson?reqId={htmlRqid}&timeCode=4&timeType=1&pageSize=1000" + "&page=" + (j + 1);
                                        byte[] allData = webClient.DownloadData(urlBase);
                                        string jsonData = Encoding.UTF8.GetString(allData);
                                        BankDataModel bankDataModel = StringExtensions.FromJson<BankDataModel>(jsonData);
                                        listBankDataModels.Add(bankDataModel);
                                    }
                                    //保存
                                    foreach (BankDataModel bankDataModel in listBankDataModels)
                                    {
                                        foreach (userTrades userTrade in bankDataModel.userTrades)
                                        {
                                            string dateType = userTrade.transType;
                                            string amount = userTrade.amount.Replace(",", "");
                                            string dateTime = userTrade.gmtCreate;
                                            switch (dateType)
                                            {
                                                case "返利":
                                                    Logger.LoadData(@"TransactionText\Rebate.txt", $"{userId},{amount},{dateTime}");
                                                    break;

                                                case "债转放款":
                                                    Logger.LoadData(@"TransactionText\DebtGrant.txt", $"{userId},{amount},{dateTime}");
                                                    break;

                                                case "网银充值":
                                                    Logger.LoadData(@"TransactionText\Recharge.txt", $"{userId},{amount},{dateTime}");
                                                    break;

                                                case "提现":
                                                    Logger.LoadData(@"TransactionText\Withdraw.txt", $"{userId},{amount},{dateTime}");
                                                    break;

                                                case "资金迁移":
                                                    Logger.LoadData(@"TransactionText\TransferFunds.txt", $"{userId},{amount},{dateTime}");
                                                    break;

                                                case "放款":
                                                    Logger.LoadData(@"TransactionText\Grant.txt", $"{userId},{amount},{dateTime}");
                                                    break;

                                                case "收费":
                                                    Logger.LoadData(@"TransactionText\FeeInfo.txt", $"{userId},{amount},{dateTime}");
                                                    break;

                                                case "快捷充值":
                                                    Logger.LoadData(@"TransactionText\Recharge.txt", $"{userId},{amount},{dateTime}");
                                                    break;

                                                case "还款-利息":
                                                    Logger.LoadData(@"TransactionText\RepaymentWithInterest.txt", $"{userId},{amount},{dateTime}");
                                                    break;

                                                case "还款-本金":
                                                    Logger.LoadData(@"TransactionText\RepaymentWithCapital.txt", $"{userId},{amount},{dateTime}");
                                                    break;

                                                case "还款-分润": break;
                                                case "预约投资红包": break;
                                                case "放款分润": break;
                                            }
                                        }
                                    }
                                    //string jsStr = "var dataList=[];var count=0;var maxlen=1;$(\"ul.cgb-query-filter  .pt15 .mr25:last-child\").click();$(\"#submit\").click();function getCurrentListData(){$.each($(\"#table_data tr\"),function(index,item){var td=$(item).find(\"td\");dataList.push({date:$(td[0]).text(),type:$(td[1]).text(),amount:$(td[2]).text()})})}function getCurrentStatus(){maxlen=$(\"#page_footer\")[0].childNodes[0].nodeValue.replace(/^\\d+\\-(\\d+)条.+/,\"$1\");if($(\"#table_data tr\").length>0&&maxlen>dataList.length){getCurrentListData();return 1}if(maxlen==dataList.length){return 2}return 0}function main(){var timer=setInterval(function(){if(count>30){count=0;clearInterval(timer);window.location.reload();return}var status=getCurrentStatus();if(status==1){count=0;$(\"#next_page\").click()}else{if(status==2){var str=\"\";for(var i=0,len=dataList.length;i<len;i++){str+=\'<li><a class=\"date\">\'+dataList[i].date+\'</a><a class=\"type\">\'+dataList[i].type+\'</a><a class=\"amount\">\'+dataList[i].amount+\"</a></li>\"}$(document.body).append(\'<div class=\"jinyinmao\"></div>\');$(\".jinyinmao\").ready(function(){$(\".jinyinmao\").html(\"<ul>\"+str+\"</ul>\");$(\".jinyinmao\").ready(function(){$(\".jinyinmao > ul\").attr(\"id\",\"jinyinmao\")})});clearInterval(timer);return}else{count++}}},1000)}main();";
                                    //webBrowser.Navigate("javascript:" + jsStr);
                                    ////string htmlText = webBrowser.DocumentText;
                                    //HtmlElement setPwd;
                                    //Thread.Sleep(2000);
                                    //do
                                    //{
                                    //    setPwd = htmlDocument.GetElementById("jinyinmao");
                                    //    Thread.Sleep(500);
                                    //} while (setPwd == null);
                                    ////获取所有的li
                                    //HtmlElementCollection liElementCollection = setPwd.GetElementsByTagName("li");
                                    //string htmlText = setPwd.InnerText;
                                    //foreach (HtmlElement liElement in liElementCollection)
                                    //{
                                    //    //再获取a标签
                                    //    HtmlElementCollection aElementCollection = liElement.GetElementsByTagName("a");
                                    //    //查找
                                    //    string dateTime = aElementCollection[0].InnerText;
                                    //    string dateType = aElementCollection[1].InnerText;
                                    //    string amount = aElementCollection[2].InnerText;
                                    //    //保存到文本文件中 放款，收费，快捷充值，还款本金，还款利息

                                    //}
                                    //获取一下
                                    if (action != null)
                                    {
                                        action();
                                    }
                                }
                                catch (Exception exception)
                                {
                                    if (action != null)
                                    {
                                        action();
                                    }
                                    Logger.LoadData(@"TransactionText\Error.txt", $"{userId}----{exception.Message},{exception.StackTrace}");
                                }
                            })
                        { IsBackground = true };
                        th.Start();
                    }
                }
                ++index;
                //MessageBox.Show(index.ToString());
            };
        }

        /// <summary>
        ///     存管投资
        /// </summary>
        /// <returns></returns>
        public async Task InvestAction(InvestmentReqeust investmentRequest, Action action, WebBrowser webBrowser = null)
        {
            SetWebbrowser.SumitForm(12);
            if (webBrowser == null)
            {
                webBrowser = new WebBrowser();
            }
            webBrowser.ScriptErrorsSuppressed = true;
            //InvestmentReqeust investmentRequest = new InvestmentReqeust { Amount = 10000, CellPhone = registerSuccessInfo.CellPhone, ClientType = 900, ProductIdentifier = "33B97C6537564B3FB349B35C949A930F", ReturnUrl = "http://www.dev.ad.jinyinmao.com.cn/redirect/Home/?request=http://www.baidu.com", Pwd = registerSuccessInfo.Pwd };
            InvestmentResponse investmentResponse = await this.jymService.InvestByService(investmentRequest);
            if (investmentResponse != null)
            {
                BankSercrityInfo bankSercrityInfo = investmentResponse.GatewayResponse;
                string url = $"http://fsgw.hkmdev.firstpay.com/phoenixFS-fsgw/gateway?data={HttpUtility.UrlEncode(bankSercrityInfo.Data)}&tm={HttpUtility.UrlEncode(bankSercrityInfo.Tm)}&merchantId=M20000002130";
                //添加一个
                webBrowser.Navigate(new Uri(url, UriKind.Absolute));
                int index = 0;
                webBrowser.DocumentCompleted += (obj, e) =>
                {
                    if (webBrowser.ReadyState < WebBrowserReadyState.Complete) return;
                    HtmlDocument htmlDocument = webBrowser.Document;
                    if (index == 0)
                    {
                        if (htmlDocument != null)
                        {
                            Thread th = new Thread(() =>
                                {
                                    Thread.Sleep(1000);
                                    HtmlElement setPwd = htmlDocument.GetElementById("payPassword");
                                    setPwd?.SetAttribute("value", "111111");
                                    setPwd?.SetAttribute("data-status", "true");
                                    HtmlElement submitBtn = htmlDocument.GetElementById("submitBtn");
                                    submitBtn?.InvokeMember("click");
                                })
                            { IsBackground = true };
                            th.Start();
                        }
                    }
                    if (index == 2)
                    {
                        action();
                    }
                    ++index;
                };
            }
        }

        /// <summary>
        ///     开通存管账户
        /// </summary>
        /// <returns></returns>
        public async Task<bool> OpenBankAccount(AccountUsers user, WebBrowser webBrowser, Action action)
        {
            SetWebbrowser.SumitForm(12);
            webBrowser.ScriptErrorsSuppressed = true;
            OpenAccountRequest request = new OpenAccountRequest { BankCardNo = user.BankCardNo, BankCardPhone = user.CgCellPhone, BizType = "01", CertNo = user.CredentialNo, RealName = user.RealName, RegisteredCell = user.CellPhone, ReturnUrl = "http://www.baidu.com/", UserId = user.UserIdentifier, ClientType = 900, OrderId = Guid.NewGuid().ToString("N").ToUpper() };
            BankSercrityInfo openAcountResponse = await this.jymService.OpenAccountAsync(request);
            if (openAcountResponse == null)
            {
                return false;
            }
            string url = $"http://fsgw.hkmdev.firstpay.com/phoenixFS-fsgw/gateway?data={HttpUtility.UrlEncode(openAcountResponse.Data)}&tm={HttpUtility.UrlEncode(openAcountResponse.Tm)}&merchantId=M20000002130";
            //添加一个
            //WebBrowser webBrowser = new WebBrowser { Name = "wb" + Guid.NewGuid().ToString("N").ToUpper() };
            webBrowser.Navigate(new Uri(url, UriKind.Absolute));
            int first = 0;
            webBrowser.DocumentCompleted += (obj, e) =>
            {
                //赋值
                HtmlDocument htmlDocument = webBrowser.Document;
                if (first == 0)
                {
                    if (htmlDocument != null)
                    {
                        try
                        {
                            Thread.Sleep(650);
                            string html1 = htmlDocument.Body?.InnerHtml;
                            string dkfk = html1;
                            //webBrowser.Navigate("jajavascript:window.alert($)");
                            //webBrowser.Navigate("javascript:$('#payPassword').next().click();$('#confirmPayPassword').next().click();$('#payPassword').val('111111');$('#confirmPayPassword').val('111111');$('#sendSmsCode').click();$('#smsCode').val('123456');$(':submit').click()");
                            int a = 0;
                            Thread th = new Thread(() =>
                                {
                                    try
                                    {
                                        Thread.Sleep(650);
                                        string html = htmlDocument.Body?.InnerHtml;
                                        HtmlElement setPwd = htmlDocument.GetElementById("payPassword"); //输入密码
                                        HtmlElement parent = setPwd?.Parent?.GetElementsByTagName("button")[0];
                                        parent?.InvokeMember("click");
                                        //获取到键值为1的id
                                        HtmlElement key1 = htmlDocument.GetElementById("key11");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");

                                        HtmlElement confirmSetPwd = htmlDocument.GetElementById("confirmPayPassword"); //确认密码
                                        HtmlElement parent1 = confirmSetPwd?.Parent?.GetElementsByTagName("button")[0];
                                        parent1?.InvokeMember("click");
                                        //获取到键值为1的id
                                        HtmlElement key2 = htmlDocument.GetElementById("key11");
                                        key2?.InvokeMember("click");
                                        key2?.InvokeMember("click");
                                        key2?.InvokeMember("click");
                                        key2?.InvokeMember("click");
                                        key2?.InvokeMember("click");
                                        key2?.InvokeMember("click");

                                        List<HtmlElement> listElements = new List<HtmlElement> { htmlDocument.GetElementById("payPassword"), htmlDocument.GetElementById("payPasswordConfirm"), htmlDocument.GetElementById("bankCode"), htmlDocument.GetElementById("bankCardNoInput"), htmlDocument.GetElementById("bankCardPhone"), htmlDocument.GetElementById("smsCode") };
                                        foreach (HtmlElement t in listElements)
                                        {
                                            t?.SetAttribute("data-status", "true");
                                        }
                                        HtmlElementCollection input = htmlDocument.GetElementsByTagName("input");
                                        input[10]?.SetAttribute("data-status", "true");

                                        //var pas = document.getElementById('confirmPayPassword'); pas.nextElementSibling.onclick(); var ke1 = document.getElementById('key11'); ke1.onclick(); ke1.onclick(); ke1.onclick(); ke1.onclick(); ke1.onclick(); ke1.onclick();
                                        //undefined
                                        //var pas = document.getElementById('payPassword'); pas.nextElementSibling.onclick(); var ke1 = document.getElementById('key11'); ke1.onclick(); ke1.onclick(); ke1.onclick(); ke1.onclick(); ke1.onclick(); ke1.onclick();

                                        //$('#payPassword').next().click();$('#confirmPayPassword').next().click();$('#payPassword').val('111111');$('#confirmPayPassword').val('111111');$('#sendSmsCode').click();$('#smsCode').val('123456');$(':submit').click()
                                        //webBrowser.Navigate("javascript:$(\'#payPassword\').next().click()");
                                        //webBrowser.Navigate("javascript:$('#payPassword').next().click();$('#confirmPayPassword').next().click();$('#payPassword').val('111111');$('#confirmPayPassword').val('111111');$('#sendSmsCode').click();$('#smsCode').val('123456');"); //$(':submit').click()
                                        //setPwd?.SetAttribute("value", "111111");
                                        //htmlDocument.GetElementById("payPasswordConfirm")?.SetAttribute("value", "111111");
                                        htmlDocument.GetElementById("smsCode")?.SetAttribute("value", "123456");
                                        //点击按钮
                                        for (int ii = 0; ii < input.Count; ii++)
                                        {
                                            if (input[ii].GetAttribute("type").ToLower().Equals("submit"))
                                            {
                                                input[ii].InvokeMember("click");
                                            }
                                        }
                                    }
                                    catch (Exception exception)
                                    {
                                        Console.WriteLine(exception);
                                        throw;
                                    }
                                })
                            { IsBackground = true };
                            th.Start();
                        }
                        catch (Exception ex)
                        {
                            //是失败
                        }
                    }
                }
                first = first + 1;
                bool? contains = htmlDocument?.Body?.OuterHtml.Contains("成功开通");
                if (contains != null && (bool)contains)
                {
                    action();
                }
            };
            return false;
        }

        /// <summary>
        ///     存管充值
        /// </summary>
        /// <param name="rechargeReqeust"></param>
        /// <param name="action"></param>
        /// <param name="webBrowser"></param>
        /// <returns></returns>
        public async Task Recharge(RechargeReqeust rechargeReqeust, Action action, WebBrowser webBrowser = null)
        {
            SetWebbrowser.SumitForm(12);
            if (webBrowser == null)
            {
                webBrowser = new WebBrowser { ScriptErrorsSuppressed = true };
            }
            BankSercrityInfo bankSercrityInfo = await this.jymService.RechargeByService(rechargeReqeust);
            if (bankSercrityInfo != null)
            {
                int index = 0;
                string url = $"http://fsgw.hkmdev.firstpay.com/phoenixFS-fsgw/gateway?data={HttpUtility.UrlEncode(bankSercrityInfo.Data)}&tm={HttpUtility.UrlEncode(bankSercrityInfo.Tm)}&merchantId=M20000002130";
                //添加一个
                //WebBrowser webBrowser = new WebBrowser { Name = "wb" + Guid.NewGuid().ToString("N").ToUpper() };
                webBrowser.Navigate(new Uri(url, UriKind.Absolute));
                webBrowser.DocumentCompleted += (obj, e) =>
                {
                    if (webBrowser.ReadyState < WebBrowserReadyState.Complete) return;
                    //this.LastUrl = this.webbrowserBg.Url.ToString();
                    HtmlDocument htmlDocument = webBrowser.Document;
                    if (index == 0)
                    {
                        if (htmlDocument != null)
                        {
                            Thread th = new Thread(() =>
                                {
                                    try
                                    {
                                        HtmlElement setPwd = htmlDocument.GetElementById("payPassword"); //输入密码
                                        HtmlElement parent = setPwd?.Parent?.GetElementsByTagName("button")[0]; //htmlDocument.GetElementById("toggle2"); //
                                        parent?.InvokeMember("click");
                                        //获取到键值为1的id
                                        HtmlElement key1 = htmlDocument.GetElementById("key11");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        //
                                        htmlDocument.GetElementById("submitBtn")?.InvokeMember("click");
                                    }
                                    catch (Exception exception)
                                    {
                                        string c = exception.Message;
                                    }
                                })
                            { IsBackground = true };
                            th.Start();
                        }
                    }
                    else if (index == 2)
                    {
                        string html = htmlDocument?.Body?.InnerText;
                        HtmlElement bankLiElement = htmlDocument?.GetElementById("list-bank1")?.GetElementsByTagName("li")[0];
                        //click
                        bankLiElement?.InvokeMember("click");
                        HtmlElementCollection collection = htmlDocument?.GetElementsByTagName("a");
                        collection?[collection.Count - 1].InvokeMember("click");
                        //webBrowser.Document?.InvokeScript("var tabList=document.getElementById('list-bank1');chooseBank(tabList.firstElementChild,1);");
                        //webBrowser.Navigate("javascript:var tabList=document.getElementById('list-bank1');chooseBank(tabList.firstElementChild,1);");
                        //webBrowser.Navigate("javascript:sub_form();");
                    }
                    if (index == 2)
                    {
                        action();
                    }
                    ++index;
                };
            }
        }

        /// <summary>
        ///     用户授权
        /// </summary>
        /// <param name="userIdentifier"></param>
        /// <param name="action"></param>
        /// <param name="webBrowser"></param>
        /// <returns></returns>
        public async Task UserAuth(string userIdentifier, Action action, WebBrowser webBrowser = null)
        {
            SetWebbrowser.SumitForm(12);
            if (webBrowser == null)
            {
                webBrowser = new WebBrowser { ScriptErrorsSuppressed = true };
            }
            BankSercrityInfo bankSercrityInfo = await this.jymService.GetAuthBankSercrityInfo(userIdentifier);
            if (bankSercrityInfo != null)
            {
                int index = 0;
                string url = $"http://fsgw.hkmdev.firstpay.com/phoenixFS-fsgw/gateway?data={HttpUtility.UrlEncode(bankSercrityInfo.Data)}&tm={HttpUtility.UrlEncode(bankSercrityInfo.Tm)}&merchantId=M20000002130";
                //添加一个
                //WebBrowser webBrowser = new WebBrowser { Name = "wb" + Guid.NewGuid().ToString("N").ToUpper() };
                webBrowser.Navigate(new Uri(url, UriKind.Absolute));
                webBrowser.DocumentCompleted += (obj, e) =>
                {
                    if (webBrowser.ReadyState < WebBrowserReadyState.Complete) return;
                    //this.LastUrl = this.webbrowserBg.Url.ToString();
                    HtmlDocument htmlDocument = webBrowser.Document;
                    if (index == 0)
                    {
                        if (htmlDocument != null)
                        {
                            Thread th = new Thread(() =>
                                {
                                    try
                                    {
                                        HtmlElement setPwd = htmlDocument.GetElementById("payPassword"); //输入密码
                                        HtmlElement parent = setPwd?.Parent?.GetElementsByTagName("button")[0]; //htmlDocument.GetElementById("toggle2"); //
                                        parent?.InvokeMember("click");
                                        //获取到键值为1的id
                                        HtmlElement key1 = htmlDocument.GetElementById("key11");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        key1?.InvokeMember("click");
                                        //
                                        htmlDocument.GetElementById("submitBtn")?.InvokeMember("click");
                                        bool contains = false;
                                        do
                                        {
                                            bool? b = htmlDocument.Body?.OuterHtml.Contains("用户授权成功");
                                            if (b != null) contains = (bool)b;
                                            if (contains)
                                            {
                                                action();
                                            }
                                        } while (!contains);
                                    }
                                    catch (Exception exception)
                                    {
                                        string c = exception.Message;
                                    }
                                })
                            { IsBackground = true };
                            th.Start();
                        }
                    }
                    ++index;
                };
            }
        }
    }
}