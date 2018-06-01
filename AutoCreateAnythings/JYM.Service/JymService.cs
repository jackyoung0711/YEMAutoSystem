using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using JYM.Lib;
using JYM.Model;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace JYM.Service
{
    /// <summary>
    ///     金银猫系统调用服务
    /// </summary>
    public class JymService
    {
        private static readonly string authBaseUrl = ConfigurationManager.AppSettings["AuthUrl"];

        /// <summary>
        ///     网关baseUrl
        /// </summary>
        private static readonly string bankGetwayBaseUrl = ConfigurationManager.AppSettings["BankGateWayUrl"];

        /// <summary>
        ///     bizbaseUrl
        /// </summary>
        private static readonly string BizeBaseUrl = ConfigurationManager.AppSettings["BizUrl"];

        /// <summary>
        ///     验证接口baseUrl
        /// </summary>
        private static readonly string vailcodeBaseUrl = ConfigurationManager.AppSettings["VailcodeUrl"];

        /// <summary>
        ///     The yem biz URL
        /// </summary>
        private static readonly string YemBizUrl = ConfigurationManager.AppSettings["YemBizUrl"];

        private static HttpClient Client => HttpClientHelper.Client.Value;

        /// <summary>
        ///     检查手机号是否可用
        /// </summary>
        /// <param name="cellphone">The cellphone.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> CheckCellPhone(string cellphone)
        {
            try
            {
                string url = $"{authBaseUrl}api/User/Auth/CheckCellphone";
                HttpResponseMessage responseMessage = await Client.GetAsync($"{url}?cellphone={cellphone}");
                ResultInfo result = await responseMessage.Content.ReadAsAsync<ResultInfo>();
                return responseMessage.StatusCode != HttpStatusCode.OK || !result.Result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        ///     获取所有在售产品信息
        /// </summary>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<List<RegularProductInfo>> GetAllProductInfo()
        {
            try
            {
                string url = $"{BizeBaseUrl}Product/Regular/IndexAllOnSale";
                Client.DefaultRequestHeaders.Remove("X-JYM-Authorization");
                HttpResponseMessage responseMessage = await Client.GetAsync(url);
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    return await responseMessage.Content.ReadAsAsync<List<RegularProductInfo>>();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     获取auth
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAuth(string cellPhone, string pwd)
        {
            try
            {
                //先根据userIdentifer获取电话号码密码
                LoginResponse response = await this.Login(new LoginRequest { LoginName = cellPhone, Password = pwd });
                return response.AccessToken;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        ///     用户auth
        /// </summary>
        /// <param name="userIdentifer"></param>
        /// <returns></returns>
        public async Task<BankSercrityInfo> GetAuthBankSercrityInfo(string userIdentifer)
        {
            try
            {
                string url = $"{bankGetwayBaseUrl}api/auth/authorizationcreate";
                HttpResponseMessage responseMessage = await Client.PostAsJsonAsync(url, new { GrantList = "100", ReturnUrl = "http://www.baidu.com", UserId = userIdentifer, ClientType = 900 });
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    return await responseMessage.Content.ReadAsAsync<BankSercrityInfo>();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     根据useid获取银行的余额信息
        /// </summary>
        /// <param name="userIdentifier">The userid.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<BankUserBalance> GetBankUserBalance(string userIdentifier)
        {
            try
            {
                string url = $"{bankGetwayBaseUrl}api/users/balancequery";
                HttpResponseMessage responseMessage = await Client.PostAsJsonAsync(url, new { UserId = userIdentifier });
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    return await responseMessage.Content.ReadAsAsync<BankUserBalance>();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     获取银行版本的用户信息
        /// </summary>
        /// <param name="userIdentifier"></param>
        /// <returns></returns>
        public async Task<BankUserInfo> GetBankUserInfoAsync(string userIdentifier)
        {
            try
            {
                //HttpClient httpClient=new HttpClient {BaseAddress = new Uri("http://api.dev.ad.jinyinmao.com.cn/") };
                string url = $"{bankGetwayBaseUrl}api/users/accountsearch";
                HttpResponseMessage responseMessage = await Client.PostAsJsonAsync(url, new { UserId = userIdentifier });
                string userInfoStr = await responseMessage.Content.ReadAsStringAsync();
                BankUserInfo userInfo = JsonConvert.DeserializeObject<BankUserInfo>(userInfoStr);
                return userInfo.UserId.IsNullOrEmpty() ? null : userInfo;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     获取当前资产信息
        /// </summary>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<CurrentProductInfo> GetCurrentProductInfo()
        {
            try
            {
                string url = $"{BizeBaseUrl}Product/Current/CurrentYemId";
                HttpResponseMessage responseMessage = await new HttpClient().GetAsync(url);
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    return await responseMessage.Content.ReadAsAsync<CurrentProductInfo>();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //http://jym-dev-sf.jinyinmao.com.cn/gateway/api/users/infomanage
        /// <summary>
        ///     获取网关数据
        /// </summary>
        /// <returns></returns>
        public async Task<BankSercrityInfo> GetInformationData(string userId)
        {
            HttpResponseMessage httpResponseMesage = new HttpResponseMessage();
            try
            {
                //记录下需要插入的资产ids
                httpResponseMesage = await Client.PostAsJsonAsync($"{bankGetwayBaseUrl}api/users/infomanage", new { returnUrl = "http://www.baidu.com", userId, clientType = 900 });
                BankSercrityInfo response = await httpResponseMesage.Content.ReadAsAsync<BankSercrityInfo>();
                return response;
            }
            catch (Exception ex)
            {
                //log记录日志
                //Logger.LoadData(@"DebtInfo\Error.txt", ex.Message + "---------" + await httpResponseMesage.Content.ReadAsStringAsync());
                return null;
            }
        }

        /// <summary>
        ///     发送验证码
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns>Task&lt;SmsCodeInfo&gt;.</returns>
        public async Task<SmsCodeInfo> GetSmsCodeInfo(SendVeriCodeRequest info)
        {
            try
            {
                string url = $"{vailcodeBaseUrl}api/ValidateCodes/Send";
                HttpResponseMessage responseMessage = await Client.PostAsJsonAsync(url, info);
                SendVeriCodeResponse response = await responseMessage.Content.ReadAsAsync<SendVeriCodeResponse>();
                if (responseMessage.StatusCode == HttpStatusCode.OK && response.Success)
                {
                    HashEntry[] redisResult = await RedisHelper.GetBizRedisClient().HashGetAllAsync($"VeriCodes{DateTime.Now.Date.ToString("yyyyMMdd")}:{info.Cellphone}");
                    return JsonConvert.DeserializeObject<SmsCodeInfo>(redisResult.FirstOrDefault(hash => hash.Name == info.Type).Value);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     根据手机号获取useridentiifer
        /// </summary>
        /// <param name="cellPhone"></param>
        /// <returns></returns>
        public async Task<AuthUserInfo> GetUserIdentifierByCellPhone(string cellPhone)
        {
            try
            {
                string url = $"{authBaseUrl}api/User/Auth/UserAuthInfo/{cellPhone}";
                HttpResponseMessage responseMessage = await Client.GetAsync(url);
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    return await responseMessage.Content.ReadAsAsync<AuthUserInfo>();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     获取开户认证信息
        /// </summary>
        /// <param name="userIdentifier"></param>
        /// <returns></returns>
        public async Task<UserInfo> GetUserInfoAsync(string userIdentifier)
        {
            try
            {
                //HttpClient httpClient=new HttpClient {BaseAddress = new Uri("http://api.dev.ad.jinyinmao.com.cn/") };
                string url = $"{BizeBaseUrl}/BackOffice/UserInfo/{userIdentifier}";
                HttpResponseMessage response = await Client.GetAsync(url);
                string userInfoStr = await response.Content.ReadAsStringAsync();
                UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(userInfoStr);
                return userInfo.UserIdentifier.IsNullOrEmpty() ? null : userInfo;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     用户认证接口
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cellphone"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public async Task<IdentityAuthenticationResponse> IdentityAuthentication(IdentityAuthenticationRequest request, string cellphone, string pwd)
        {
            IdentityAuthenticationResponse response = new IdentityAuthenticationResponse { IsSuccess = false };
            try
            {
                string url = $"{BizeBaseUrl}User/Auth/CGAuthenticate";
                //登录后去token
                LoginResponse loginResponse = await this.Login(new LoginRequest { LoginName = cellphone, Password = pwd });
                if (loginResponse == null)
                {
                    return response;
                }
                Client.DefaultRequestHeaders.Remove("X-JYM-Authorization");
                Client.DefaultRequestHeaders.Add("X-JYM-Authorization", $"Bearer {loginResponse.AccessToken}");
                HttpResponseMessage responseMessage = await Client.PostAsJsonAsync(url, request);
                //IdentityAuthenticationResponse response = await responseMessage.Content.ReadAsAsync<IdentityAuthenticationResponse>();
                response.IsSuccess = responseMessage.StatusCode == HttpStatusCode.OK;
                response.UserIdentifier = loginResponse.UserId.Replace("-", "").ToUpper();
            }
            catch (Exception)
            {
                return response;
            }
            return response;
        }

        /// <summary>
        ///     存管投资
        /// </summary>
        /// <param name="reqeust"></param>
        /// <returns></returns>
        public async Task<InvestmentResponse> InvestByService(InvestmentReqeust reqeust)
        {
            try
            {
                string url = $"{BizeBaseUrl}/Investing/Regular";
                //获取token
                string token = ""; // await this.GetAuth(reqeust.UserIdentifier);;
                Client.DefaultRequestHeaders.Remove("X-JYM-Authorization");
                Client.DefaultRequestHeaders.Add("X-JYM-Authorization", token);
                HttpResponseMessage responseMessage = await Client.PostAsJsonAsync(url, reqeust);
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    return await responseMessage.Content.ReadAsAsync<InvestmentResponse>();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            try
            {
                string url = $"{authBaseUrl}api/User/Auth/SignIn";
                Client.DefaultRequestHeaders.Remove("X-JYM-Authorization");
                Client.DefaultRequestHeaders.Add("X-JYM-Authorization", "Bearer ==");
                string c = request.ToJson();
                HttpResponseMessage responseMessage = await Client.PostAsJsonAsync(url, request);
                LoginResponse response = await responseMessage.Content.ReadAsAsync<LoginResponse>();
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     开通存管账户获取tmdata
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BankSercrityInfo> OpenAccountAsync(OpenAccountRequest request)
        {
            try
            {
                string url = $"{bankGetwayBaseUrl}api/users/accountcreate";
                HttpResponseMessage responseMessage = await Client.PostAsJsonAsync(url, request);
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    return await responseMessage.Content.ReadAsAsync<BankSercrityInfo>();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        ///     预申购订单
        /// </summary>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> PurchaseOrders(long amount, string userId)
        {
            try
            {
                string url = $"{BizeBaseUrl}LessPwd/YemInvest";
                CurrentProductInfo currentProductInfo = await this.GetCurrentProductInfo();
                HttpResponseMessage responseMessage = await new HttpClient().PostAsJsonAsync(url, new { Amount = amount, UserId = userId, ProductIdentifier = currentProductInfo.ResultKey });
                return responseMessage.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     充值
        /// </summary>
        /// <param name="rechargeReqeust"></param>
        /// <returns></returns>
        public async Task<BankSercrityInfo> RechargeByService(RechargeReqeust rechargeReqeust)
        {
            try
            {
                //string url = "http://api.dev.ad.jinyinmao.com.cn/User/Payment/Recharge";
                string url = $"{BizeBaseUrl}User/Payment/Recharge";
                //获取token
                string token = await this.GetAuth(rechargeReqeust.CellPhone, rechargeReqeust.Password);
                Client.DefaultRequestHeaders.Remove("X-JYM-Authorization");
                Client.DefaultRequestHeaders.Add("X-JYM-Authorization", $"Bearer {token}");
                HttpResponseMessage responseMessage = await Client.PostAsJsonAsync(url, rechargeReqeust);
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    return await responseMessage.Content.ReadAsAsync<BankSercrityInfo>();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        ///     赎回
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> RedeemAsync(RedeemInput input)
        {
            try
            {
                string url = $"{YemBizUrl}Yem/Order/Redeem";
                Client.DefaultRequestHeaders.Add("X-JYM-Application", EncryptHelper.Base64Encode("Jinyinmao.Tirisfal.Api@" + HttpUtility.HtmlDecode(ConfigurationManager.AppSettings["BearerAuthKeys"])));
                HttpResponseMessage responseMessage = await Client.PostAsJsonAsync(url, input);
                BizSimpleResult result = await responseMessage.Content.ReadAsAsync<BizSimpleResult>();
                Client.DefaultRequestHeaders.Remove("X-JYM-Application");
                return responseMessage.StatusCode == HttpStatusCode.OK && result.IsSuccess;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        ///     注册
        /// </summary>
        /// <param name="registerInfo"></param>
        /// <returns></returns>
        public async Task<bool> Register(RegisterInfo registerInfo)
        {
            try
            {
                string url = $"{authBaseUrl}api/User/Auth/SignUp";
                Client.DefaultRequestHeaders.Remove("X-JYM-Authorization");
                Client.DefaultRequestHeaders.Add("X-JYM-Authorization", "Bearer ==");
                HttpResponseMessage responseMessage = await Client.PostAsJsonAsync(url, registerInfo);
                return responseMessage.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     手机号认证
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> VerifyCellPhone(VerifyRequest request)
        {
            try
            {
                string url = $"{vailcodeBaseUrl}api/ValidateCodes/Verify";
                HttpResponseMessage responseMessage = await Client.PostAsJsonAsync(url, request);
                VerifyResponse response = await responseMessage.Content.ReadAsAsync<VerifyResponse>();
                return responseMessage.StatusCode == HttpStatusCode.OK && response.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}