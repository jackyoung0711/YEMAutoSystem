using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using MigrationData.DAL;

namespace JYM.Lib
{
    /// <summary>
    ///     自动生成各类数据对方的
    /// </summary>
    public static class AutoCreateAnyCode
    {
        /// <summary>
        ///     银行卡
        /// </summary>
        private static readonly List<string> BankBinCodes = new List<string> { "622260", "622202", "621661", "545431", "621034", "524094", "622999", "621568" };

        /// <summary>
        ///     手机号前缀数组
        /// </summary>
        private static readonly string[] cellphonePrefixs = ConfigurationManager.AppSettings["cellphonePrefix"].Split(',');

        /// <summary>
        ///     身份证号码前缀数组
        /// </summary>
        private static readonly string[] credentialNoPrefixs = ConfigurationManager.AppSettings["credentialNoPrefix"].Split(',');

        /// <summary>
        ///     首姓名
        /// </summary>
        private static readonly List<string> FirstName = new List<string> { "赵", "钱", "孙", "李", "周", "吴", "郑", "王", "冯", "陈", "楮", "卫", "蒋", "沈", "韩", "杨", "朱", "秦", "尤", "许", "何", "吕", "施", "张", "孔", "曹", "严", "华", "金", "魏", "陶", "姜", "戚", "谢", "邹", "喻", "柏", "水", "窦", "章", "云", "苏", "潘", "葛", "奚", "范", "彭", "郎", "鲁", "韦", "昌", "马", "苗", "凤", "花", "方", "俞", "任", "袁", "柳", "酆", "鲍", "史", "唐", "费", "廉", "岑", "薛", "雷", "贺", "倪", "汤", "滕", "殷", "罗", "毕", "郝", "邬", "安", "常" };

        /// <summary>
        /// </summary>
        private static readonly string LastNameMan = "刚伟勇毅俊峰强军平保东文辉力明永健世广志义兴良海山仁波宁贵福生龙元全国胜学祥才发武新利清飞彬富顺信子杰涛昌成康星光天达安岩中茂进林有坚和彪博诚先敬震振壮会思群豪心邦承乐绍功松善厚庆磊民友裕河哲江超浩亮政谦亨奇固之轮翰朗伯宏言若鸣朋斌梁栋维启克伦翔旭鹏泽晨辰士以建家致树炎德行时泰盛雄琛钧冠策腾楠榕风航弘";

        /// <summary>
        ///     获取
        /// </summary>
        public static Dictionary<string, string> GetDicBankNameAndCodes { get; } = new Dictionary<string, string> { { "中国工商银行", "621226" }, { "中国银行", "621661" }, { "中国建设银行", "621700" }, { "中国农业银行", "622848" }, { "交通银行", "622260" } }; //, { "上海银行", "621005" }, { "光大银行", "622666" }, { "民生银行", "377152" }, { "浦发银行", "456418" }, { "兴业银行", "552398" }, { "招商银行", "356887" },

        /// <summary>
        ///     生成cellphone
        /// </summary>
        /// <returns></returns>
        public static string BuildCellPhone(string cellPhone, string number)
        {
            if (number.Length > 6 || number.Length <= 0)
            {
                return null;
            }
            int len = 6 - number.Length;
            StringBuilder sb = new StringBuilder();
            sb.Append(cellPhone);
            for (int i = 0; i < len - 1; i++)
            {
                sb.Append("0");
            }
            sb.Append(number);
            return sb.ToString();
        }

        /// <summary>
        ///     随机生成银行卡号
        /// </summary>
        /// <returns></returns>
        public static string GetBankCardNo(string binCode = null)
        {
            //生成bincodes
            List<string> bankBinCode = GetDicBankNameAndCodes.Values.ToList();
            Random rand = new Random();
            if (binCode == null)
            {
                binCode = bankBinCode[rand.Next(0, bankBinCode.Count - 1)];
            }
            return $"{binCode}{rand.Next(100000000, 999999999)}{rand.Next(1000, 9999)}";
        }

        /// <summary>
        ///     随机生成手机号
        /// </summary>
        /// <returns></returns>
        public static string GetCellPhone()
        {
            Random ran = new Random();
            int index = ran.Next(0, cellphonePrefixs.Length - 1);
            string first = cellphonePrefixs[index];
            string second = (ran.Next(100, 888) + 10000).ToString().Substring(1);
            string thrid = (ran.Next(1, 9100) + 10000).ToString().Substring(1);
            return first + second + thrid;
        }

        /// <summary>
        ///     随机生成身份证号
        /// </summary>
        /// <returns></returns>
        public static string GetCredentialNo()
        {
            return $"{credentialNoPrefixs[new Random().Next(0, credentialNoPrefixs.Length - 1)]}{DateTime.Now.AddYears(-new Random().Next(0, 70)).ToString("yyyyMMdd")}{new Random().Next(1000, 9999)}";
        }

        public static string GetLocalIp()
        {
            string hostName = Dns.GetHostName(); //获取本机名
            IPHostEntry localhost = Dns.GetHostEntry(hostName); //获取IPv6地址
            IPAddress localaddr = localhost.AddressList[0];

            return localaddr.ToString();
        }

        /// <summary>
        ///     通过网络适配器获取MAC地址
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddressByNetworkInformation()
        {
            string macAddress = "";
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in nics)
                {
                    if (!adapter.GetPhysicalAddress().ToString().Equals(""))
                    {
                        macAddress = adapter.GetPhysicalAddress().ToString();
                        for (int i = 1; i < 6; i++)
                        {
                            macAddress = macAddress.Insert(3 * i - 1, ":");
                        }
                        break;
                    }
                }
            }
            catch
            {
            }
            return macAddress.Replace(":", "");
        }

        public static string GetUserName()
        {
            return $"{FirstName[new Random().Next(0, FirstName.Count - 1)]}{LastNameMan.ToCharArray()[new Random().Next(0, LastNameMan.ToCharArray().Length - 1)]}";
        }

        /// <summary>
        ///     随机生成用户姓名和手机号
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, string> GetUserName1()
        {
            //1359990
            //获取东西
            try
            {
                DataTable dtInfos = SqlHelper.ExecuteDataTable("select * from UserInfo where IsUsed=1");
                if (dtInfos == null)
                {
                    return Tuple.Create(GetUserName(), GetCellPhone());
                }
                Random random = new Random();
                int count = dtInfos.Rows.Count;
                int index = random.Next(0, count);
                DataRow dr = dtInfos.Rows[index];
                string userName = dr["UserName"] + "D" + dr["MaxId"];
                string cellPhone = BuildCellPhone(dr["CellPhone"].ToString(), dr["MaxId"].ToString());
                int maxId = Convert.ToInt16(dr["MaxId"]);
                //更新数据库
                SqlHelper.ExecuteNoneQuery($"update UserInfo set MaxId={maxId}+1 where Id={dr["Id"]}");
                return Tuple.Create(userName, cellPhone);
            }
            catch (Exception)
            {
                return Tuple.Create(GetUserName(), GetCellPhone());
            }
        }
    }
}