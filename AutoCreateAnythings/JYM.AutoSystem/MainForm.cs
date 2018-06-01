using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HuaidingSoft.DAL;
using JYM.Lib;
using JYM.Model;
using JYM.Service;
using MigrationData.DAL;

namespace JYM.AutoSystem
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public partial class AutoSystemForm : Form
    {
        private readonly BankPageCommon bankPageCommon = new BankPageCommon();
        private readonly TsourceDal<AccountUsers> dal = new TsourceDal<AccountUsers>();
        private readonly Dictionary<string, string> dicbankInfo = AutoCreateAnyCode.GetDicBankNameAndCodes;
        private readonly JymService jymService = new JymService();
        private readonly object obj = new object();
        private readonly StringBuilder rechargeResults = new StringBuilder();
        private int count;
        private int failNums;
        private bool isFlag; //限定只能串行
        private bool isFlagByOpenAccount; //限定只能串行开户
        private bool IsOpen;
        private bool IsRecharge;
        private int secondsOpenAccount;

        private int secondsRecharge; //每次充值的时间限定
        //每次开户时间限定

        private int successNums;

        //private WebBrowser webBrowser;
        public AutoSystemForm()
        {
            this.InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public static DataTable ToDataTable<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            IEnumerable<T> enumerable = collection as T[] ?? collection.ToArray();
            if (enumerable.Any())
            {
                for (int i = 0; i < enumerable.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(enumerable.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }

        public static List<T> ToList<T>(DataTable dt) where T : class, new()
        {
            //创建一个属性的列表
            List<PropertyInfo> prlist = new List<PropertyInfo>();
            //获取TResult的类型实例  反射的入口

            Type t = typeof(T);

            //获得TResult 的所有的Public 属性 并找出TResult属性和DataTable的列名称相同的属性(PropertyInfo) 并加入到属性列表
            Array.ForEach(t.GetProperties(), p =>
            {
                if (dt.Columns.IndexOf(p.Name) != -1) prlist.Add(p);
            });

            //创建返回的集合

            List<T> oblist = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                //创建TResult的实例
                T ob = new T();
                //找到对应的数据  并赋值
                prlist.ForEach(p =>
                {
                    if (row[p.Name] != DBNull.Value) p.SetValue(ob, row[p.Name], null);
                });
                //放入到返回的集合中.
                oblist.Add(ob);
            }
            return oblist;
        }

        private void AddNumber(int index)
        {
            lock (this.obj)
            {
                SqlHelper.ExecuteNoneQuery(index == 0 ? "insert into TestAc(UserIdentifier,Count) values('aaa',1)" : "insert into TestAc(UserIdentifier,Count) values('bbb',1)");
            }
        }

        private async void AutoSystemForm_Load(object sender, EventArgs e)
        {
            //1.此项目加到了github上面了 谢谢！ 秋燕军和谁
            //1. 加载银行卡信息
            this.cb_BankcardNos.Items.Add("请选择银行卡");
            List<string> bankNames = this.dicbankInfo.Keys.ToList();
            foreach (string t in bankNames)
            {
                this.cb_BankcardNos.Items.Add(t);
            }
            this.cb_BankcardNos.SelectedIndex = 0;
            StringBuilder sb = new StringBuilder();
            //2. 加入数据 测试数据
            //Parallel.For(0, 2000, i =>
            //{
            //    //update
            //    int result = SqlHelper.ExecuteNoneQuery("update TestAc set Count=Count-1 where Count-1>=0 and Id=1");
            //    this.AddNumber(result > 0 ? 0 : 1);
            //});
        }

        /// <summary>
        ///     开户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_opne_Click(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;
            string bankName = this.cb_BankcardNos.Text;
            if (bankName == "请选择银行卡")
            {
                MessageBox.Show("请先选择银行卡");
                return;
            }
            string bankCardNo = AutoCreateAnyCode.GetBankCardNo(this.dicbankInfo[bankName]);
            AccountUsers user = new AccountUsers
            {
                CellPhone = this.txb_CellPhone.Text.Trim(),
                InviteBy = this.txb_inviteBy.Text.Trim(),
                Pwd = this.txb_Pwd.Text.Trim(),
                RealName = this.txb_UserName.Text.Trim(),
                BankCardNo = bankCardNo,
                CredentialNo = AutoCreateAnyCode.GetCredentialNo(),
                UserMac = AutoCreateAnyCode.GetMacAddressByNetworkInformation(),
                CgCellPhone = this.txb_BankCardCellPhone.Text.Trim(),
                RigisterTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss")
            };
            Regex regex = new Regex("^\\d{11}$");
            if (!regex.IsMatch(user.CellPhone))
            {
                MessageBox.Show("手机号格式有误");
                return;
            }
            if (!await this.jymService.CheckCellPhone(user.CellPhone))
            {
                MessageBox.Show("手机号已经使用");
                return;
            }
            if (string.IsNullOrEmpty(user.Pwd))
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            this.btn_opne.Enabled = false;
            this.lbl_showOpen.Text = "正在开户,请耐心等待................";
            user.RealName = user.RealName == "" ? AutoCreateAnyCode.GetUserName() : user.RealName;
            user.InviteBy = user.InviteBy == "" ? "22222" : user.InviteBy;
            user.CgCellPhone = user.CgCellPhone == "" ? AutoCreateAnyCode.GetCellPhone() : user.CgCellPhone;
            //注册认证
            AccountUsers successAccountUsers = await this.Register(user);
            if (successAccountUsers != null)
            {
                //存管开户
                await this.bankPageCommon.OpenBankAccount(successAccountUsers, this.webBrowser_OpenAccount, () =>
                {
                    this.lbl_showOpen.Text = "开户成功";
                    this.btn_opne.Enabled = true;
                });
            }
            else
            {
                this.lbl_showOpen.Text = "auth系统报错导致开户失败,请找交易系统开发人员";
            }
        }

        /// <summary>
        ///     批量充值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_recharge_Click(object sender, EventArgs e)
        {
            //批量充值
            string userIdentifiers = this.txb_userIndentifiers.Text.Trim();
            string amountTxt = this.txb_amount.Text.Trim();
            if (string.IsNullOrEmpty(amountTxt) || string.IsNullOrEmpty(userIdentifiers))
            {
                MessageBox.Show("信息不能为空");
                return;
            }
            Regex regex = new Regex("^[1-9]{1}[0-9]{0,14}$");
            if (!regex.IsMatch(amountTxt))
            {
                MessageBox.Show("金额格式不对");
                return;
            }
            long amount = Convert.ToInt64(amountTxt);
            string[] userInfoList = Regex.Split(userIdentifiers, "\r\n", RegexOptions.IgnoreCase);
            Thread thBtRechar = new Thread(async () =>
                {
                    this.btn_recharge.Enabled = false;
                    this.button1.Enabled = false;
                    foreach (string useridentifier in userInfoList)
                    {
                        this.lbl_showRecharge.Text = $"{useridentifier}: 正在进行充值操作.......";
                        this.isFlag = false;
                        this.secondsRecharge = 0;
                        //判断该用户是否在银行开户
                        //List<string> userInfos = user.GetListByStr();
                        Regex regexuserIdentifier = new Regex("^[0-9a-zA-Z]{32}$");
                        if (!regexuserIdentifier.IsMatch(useridentifier))
                        {
                            //格式不正确
                            this.lbl_showRecharge.Text = $"{useridentifier}: 格式错误，充值失败.....";
                            Thread.Sleep(1500);
                            continue;
                        }
                        BankUserInfo bankUser = await this.jymService.GetBankUserInfoAsync(useridentifier.ToUpper());
                        if (bankUser == null)
                        {
                            this.lbl_showRecharge.Text = $"{useridentifier}: 该用户还未开户";
                            //this.txb_RechargeResults.Text = this.rechargeResults.ToString();
                            //提示
                            Thread.Sleep(1500);
                            continue;
                        }
                        //充值
                        RechargeReqeust rechargeReqeust = new RechargeReqeust { Amount = amount, ChannelType = 10, ClientType = 900, ReturnUrl = "http://www.dev.ad.jinyinmao.com.cn/redirect/Home/?request=http://www.baidu.com", UserIdentifier = useridentifier };
                        await this.bankPageCommon.Recharge(rechargeReqeust, () =>
                        {
                            this.lbl_showRecharge.Text = $"{useridentifier}: 该用户充值成功";
                            //记录充值
                            SqlHelper.ExecuteNoneQuery($"update AccountUsers set RechargeNums=RechargeNums+1,RechargeAmount=RechargeAmount+{amount} where UserIdentifier='{useridentifier}'");
                            this.isFlag = true;
                        }, this.webBrowser_recharge);
                        while (!this.isFlag)
                        {
                            //secondsRecharge
                            Thread.Sleep(4000);
                            this.secondsRecharge += this.secondsRecharge + 4000;
                            if (this.secondsRecharge >= 120000)
                            {
                                break;
                            }
                        }
                    }
                    //充值操作结束
                    this.btn_recharge.Enabled = true;
                    this.button1.Enabled = true;
                    this.lbl_showRecharge.Text = "充值操作结束";
                })
            { IsBackground = true };
            thBtRechar.Start();
        }

        /// <summary>
        ///     开户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //this.IsOpen = false;
            ////await this.jymService.Login(new LoginRequest { LoginName = "17808598964", Password = "111111" });
            //RegisterSuccessInfo d = await this.Register();
            //if (d.IsSuccess)
            //{
            //    //开通存管账户
            //    await this.OpenBankAccount(d, this.webBrowser1);
            //}
            //
        }

        /// <summary>
        ///     清空信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.txb_userIndentifiers.Text = "";
            this.txb_amount.Text = "";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.btn_recharge.Enabled = false;
            this.lbl_showRecharge.Text = "正在进行充值操作.......";
            string userIdentifiers = this.txb_userIndentifiers.Text.Trim();
            string[] userInfoList = Regex.Split(userIdentifiers, "\r\n", RegexOptions.IgnoreCase);
            if (userInfoList.Length == 0)
            {
                MessageBox.Show("数据格式不对");
                return;
            }
            foreach (string user in userInfoList)
            {
                //判断该用户是否在银行开户
                List<string> userInfos = user.GetListByStr();
                if (userInfos == null || userInfos.Count == 0)
                {
                    //格式不正确
                    this.rechargeResults.Append($"{user}：格式不正确");
                    this.rechargeResults.Append("\r\n");
                    //this.txb_RechargeResults.Text = this.rechargeResults.ToString();
                    //提示
                    continue;
                }
                BankUserInfo bankUser = await this.jymService.GetBankUserInfoAsync(userInfos[0]);
                if (bankUser == null)
                {
                    this.rechargeResults.Append($"{user}：该用户还未开户");
                    this.rechargeResults.Append("\r\n");
                    //this.txb_RechargeResults.Text = this.rechargeResults.ToString();
                    //提示
                    continue;
                }
                //充值
                RechargeReqeust rechargeReqeust = new RechargeReqeust { Amount = Convert.ToInt64(userInfos[1]), ChannelType = 10, ClientType = 900, ReturnUrl = "http://www.dev.ad.jinyinmao.com.cn/redirect/Home/?request=http://www.baidu.com", UserIdentifier = userInfos[0] };
                await this.bankPageCommon.Recharge(rechargeReqeust, () =>
                {
                    this.rechargeResults.Append($"{user}：充值成功");
                    this.isFlag = true;
                    this.rechargeResults.Append("\r\n");
                    //this.txb_RechargeResults.Text = this.rechargeResults.ToString();
                    //提示成功
                });
                while (!this.isFlag)
                {
                    Thread.Sleep(5000);
                }
            }
            //充值操作结束
            this.btn_recharge.Enabled = true;
            this.lbl_showRecharge.Text = "充值操作结束";
            //this.button2.Enabled = false;
            //int nums = Convert.ToInt16(this.txb_num.Text.Trim());
            //this.count = nums;
            //for (int i = 0; i < nums; i++)
            //{
            //    RegisterSuccessInfo d = await this.Register();
            //    if (d.IsSuccess)
            //    {
            //        //开通存管账户
            //        await this.OpenBankAccount(d, this.webBrowser1);
            //    }
            //}
            //this.button2.Enabled = true;
            //MessageBox.Show("成功");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.button3.Enabled = false;
            //for (int i = 0; i < 1; i++)
            //{
            //    Thread th = new Thread(() =>
            //    {
            //        RegisterSuccessInfo d = this.Register().Result;
            //        if (d.IsSuccess)
            //        {
            //            //开通存管账户
            //            bool result = this.OpenBankAccount(d, this.webBrowser1).Result;
            //        }
            //    })
            //    { IsBackground = true };
            //    th.Start();
            //}
            //this.button3.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            //this.button4.Enabled = false;
            //await this.Recharge(new RegisterSuccessInfo { CellPhone = this.textBox1.Text, IsSuccess = true, Pwd = "111111" }, this.webBrowser1);
            //this.button4.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //执行sql语句
            HtmlDocument htmlDocument = this.webBrowser_OpenAccount.Document;
            HtmlElement setPwd = htmlDocument.GetElementById("payPassword"); //输入密码
            HtmlElement Parent = setPwd.Parent.GetElementsByTagName("button")[0];
            Parent.InvokeMember("click");
            //this.webBrowser_OpenAccount.Navigate("javascript:$(\'#payPassword\').next().click()");
            //获取到键值为1的id
            HtmlElement key1 = htmlDocument.GetElementById("key11");
            key1?.InvokeMember("click");
            key1?.InvokeMember("click");
            key1?.InvokeMember("click");
            key1?.InvokeMember("click");
            key1?.InvokeMember("click");
            key1?.InvokeMember("click");
            //调试
            MessageBox.Show("执行完毕");
        }

        /// <summary>
        ///     注册
        /// </summary>
        /// <returns></returns>
        private async Task<AccountUsers> Register(AccountUsers user)
        {
            //注册一个用户
            string cellphone = user.CellPhone;
            //RegisterSuccessInfo responseRegisterSuccessInfo = new RegisterSuccessInfo { IsSuccess = false };
            //发送验证码 并且验证该手机号是否存在
            //发送验证码
            SmsCodeInfo smsCodeInfo = await this.jymService.GetSmsCodeInfo(new SendVeriCodeRequest { Cellphone = cellphone });
            //验证
            if (await this.jymService.VerifyCellPhone(new VerifyRequest { Cellphone = cellphone, Code = smsCodeInfo.Code.Split('|')[0], Type = 10 }))
            {
                //成功后注册
                RegisterInfo info = new RegisterInfo { Token = smsCodeInfo.Token, InviteBy = user.InviteBy, ContractId = "300020150820103000", Password = user.Pwd };
                if (await this.jymService.Register(info))
                {
                    //认证
                    string realName = user.RealName;
                    string credentialNo = user.CredentialNo;
                    IdentityAuthenticationResponse registerSuccess = await this.jymService.IdentityAuthentication(new IdentityAuthenticationRequest { Credential = "10", CredentialNo = credentialNo, RealName = realName }, cellphone, user.Pwd);
                    if (registerSuccess.IsSuccess)
                    {
                        user.UserIdentifier = registerSuccess.UserIdentifier;
                        user.IsVerifed = 1;
                        //将数据存入数据库中
                        bool addSuccess = SqlHelper.ExecuteNoneQuery($"insert into AccountUsers(BankCardNo,CellPhone,CgCellPhone,CredentialNo,InviteBy,InviteFor,IsActivity,IsAuthInvest,IsAuthWithdraw,IsVerifed,Pwd,RealName,RechargeAmount,RechargeNums,RigisterTime,UserIdentifier,UserMac,IsBankAuth)values('{user.BankCardNo}','{user.CellPhone}','{user.CgCellPhone}','{user.CredentialNo}','{user.InviteBy}','{user.InviteFor}',{user.IsActivity},{user.IsAuthInvest},{user.IsAuthWithdraw},{user.IsVerifed},'{user.Pwd}','{user.RealName}',{user.RechargeAmount},{user.RechargeNums},'{user.RigisterTime}','{user.UserIdentifier}','{user.UserMac}',0)") > 0;
                        if (addSuccess)
                        {
                            return user;
                        }
                    }
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        ///     批量开户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BatchOpenAccount batchOpenAccount = BatchOpenAccount.GetBatchOpenAccount(async nums => await Task.Run(() =>
            {
                this.lbl_showOpen.Text = "正在批量开户,请耐心等待.......";
                this.btn_opne.Enabled = false;
                this.toolStripButton1.Enabled = false;
                for (int i = 0; i < nums; i++)
                {
                    this.isFlagByOpenAccount = false;
                    this.secondsOpenAccount = 0;
                    Tuple<string, string> infos = AutoCreateAnyCode.GetUserName1();
                    AccountUsers user = new AccountUsers
                    {
                        CellPhone = infos.Item2,
                        Pwd = "111111",
                        RealName = infos.Item1,
                        BankCardNo = AutoCreateAnyCode.GetBankCardNo(),
                        CredentialNo = AutoCreateAnyCode.GetCredentialNo(),
                        UserMac = AutoCreateAnyCode.GetMacAddressByNetworkInformation(),
                        CgCellPhone = AutoCreateAnyCode.GetCellPhone(),
                        RigisterTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss")
                    };
                    if (!this.jymService.CheckCellPhone(user.CellPhone).Result)
                    {
                        continue;
                    }
                    this.btn_opne.Enabled = false;
                    user.RealName = user.RealName == "" ? AutoCreateAnyCode.GetUserName() : user.RealName;
                    user.InviteBy = user.InviteBy == "" ? "22222" : user.InviteBy;
                    user.CgCellPhone = user.CgCellPhone == "" ? AutoCreateAnyCode.GetCellPhone() : user.CgCellPhone;
                    //注册认证
                    int i1 = i + 1;
                    AccountUsers successAccountUsers = this.Register(user).Result;
                    if (successAccountUsers != null)
                    {
                        //存管开户
                        bool result = this.bankPageCommon.OpenBankAccount(successAccountUsers, this.webBrowser_OpenAccount, () =>
                        {
                            this.lbl_showOpen.Text = $"正在批量开户,请耐心等待.......   已经开户数量{i1}";
                            this.isFlagByOpenAccount = true;
                        }).Result;
                    }
                    else
                    {
                        this.lbl_showOpen.Text = $"第{i1}个用户开户失败";
                    }
                    while (!this.isFlagByOpenAccount)
                    {
                        Thread.Sleep(2000);
                        this.secondsOpenAccount += 2000;
                        if (this.secondsOpenAccount >= 35000)
                        {
                            this.lbl_showOpen.Text = $"第{i1}个用户开户失败";
                            break;
                        }
                    }
                }
                this.lbl_showOpen.Text = "批量开户结束";
                this.btn_opne.Enabled = true;
                this.toolStripButton1.Enabled = true;
            }));
            batchOpenAccount.ShowDialog();
        }

        /// <summary>
        ///     查询开户用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            UserInfoManage userInfoManage = new UserInfoManage();
            userInfoManage.Show();
        }

        /// <summary>
        ///     批量充值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     激活用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            //执行数据
            int count = 700;
            DataTable dt = SqlHelper.ExecuteDataTable("select * from AccountUsers where Id>397");
            //直接转list
            List<AccountUsers> listUsers = ToList<AccountUsers>(dt);
            for (int i = 0; i < listUsers.Count; i++)
            {
                count++;
                AccountUsers accountUsers = listUsers[i];
                accountUsers.Id = count + 1;
            }
            string msg;
            SqlHelper.SqlBulkCopyByDatatable("", ToDataTable(listUsers), out msg);
        }

        /// <summary>
        ///     获取用户流水
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            UserTransactionFrom userTransactionFrom = new UserTransactionFrom();
            userTransactionFrom.ShowDialog();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            RedeemCheck redeemCheckForm = new RedeemCheck();
            redeemCheckForm.ShowDialog();
        }
    }
}