using System;
using Newtonsoft.Json;

namespace AutoRegister
{
    public class BankInfo
    {
        [JsonProperty("bankCode")]
        public string BankCode { get; set; }

        [JsonProperty("bankName")]
        public string BankName { get; set; }

        [JsonProperty("cardPreFix")]
        public int CardPreFix { get; set; }
    }

    public class DepositByXianFengRequest
    {
        [JsonProperty("smsCode")]
        public string SmsCode { get; set; }

        [JsonProperty("sn")]
        public string SN { get; set; }
    }

    public class DepositByXianFengResponse
    {
        [JsonProperty("resultCode")]
        public int ResultCode { get; set; }

        [JsonProperty("retryCount")]
        public int RetryCount { get; set; }
    }

    public class LoginRequest
    {
        [JsonProperty("loginName")]
        public string LoginName { get; set; }

        [JsonProperty("passWord")]
        public string PassWord { get; set; } = "111111";
    }

    public class LoginResponse
    {
        public string access_token { get; set; }

        public string auth { get; set; }

        public string cellphone { get; set; }

        public long expiration { get; set; }

        public bool Lock { get; set; }

        public long remainCount { get; set; }

        public bool success { get; set; }

        public bool userExist { get; set; }

        public string userId { get; set; }
    }

    public class PreDepositByXianFengRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; } = 300;

        [JsonProperty("bankCardNo")]
        public string BankCardNo { get; set; }

        [JsonProperty("bankCode")]
        public string bankCode { get; set; }

        [JsonProperty("bankName")]
        public string BankName { get; set; }

        [JsonProperty("cellphone")]
        public string Cellphone { get; set; }

        [JsonProperty("credentialNo")]
        public string CredentialNo { get; set; }

        [JsonProperty("realName")]
        public string RealName { get; set; } = "System";
    }

    public class PreDepositByXianFengResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; } //相关的提示信息

        [JsonProperty("result")]
        public bool Result { get; set; } // 预充值结果 ,

        [JsonProperty("resutlCode")]
        public string ResutlCode { get; set; } // 详细的错误码， 3000 = “验证码错误” ,

        [JsonProperty("retryCount")]
        public int RetryCount { get; set; }

        [JsonProperty("sequenceNo")]
        public string SequenceNo { get; set; } //充值的流水号 ,

        [JsonProperty("verifyState")]
        public string VerifyState { get; set; } //  认证状态

        //  重试次数
    }
}

public class BankSercrityInfo
{
    /// <summary>
    ///     加密后的业务数据
    /// </summary>
    [JsonProperty("data")]
    public string Data { get; set; }

    /// <summary>
    ///     商户编码
    /// </summary>
    [JsonProperty("merchantId")]
    public string MerchantId { get; set; }

    /// <summary>
    ///     密钥
    /// </summary>
    [JsonProperty("tm")]
    public string Tm { get; set; }
}

/// <summary>
///     Class CGAuthenticateRequest.
/// </summary>
public class CGAuthenticateRequest
{
    [JsonProperty("credential")]
    public int Credential { get; set; }

    [JsonProperty("credentialno")]
    public string CredentialNo { get; set; }

    [JsonProperty("realname")]
    public string RealName { get; set; }
}

public class CGCreateAccountRequest
{
    public string agreement { get; set; } = "1";
    public string bankCardNo { get; set; }
    public string bankCardNoInput { get; set; }
    public string bankCardPhone { get; set; }
    public string bankCode { get; set; }
    public string exponent { get; set; }
    public string modulus { get; set; }
    public string payPassword { get; set; } = "111111";
    public string payPasswordConfirm { get; set; } = "111111";
    public string reqId { get; set; } = "web.member.account.create-";
    public string smsCode { get; set; } = "123456";
    public string tradePwdMD5 { get; set; }
}

public class CGGeneralWebResponse
{
    public string Data { get; set; }

    public string MerchantId { get; set; }

    public string Tm { get; set; }
}

public class CreateAccountRequest
{
    public string BankCardNo { get; set; }
    public string BankCardPhone { get; set; }

    public string BizType
    {
        get { return "01"; }
    }

    public string CertNo { get; set; }

    public int ClientType
    {
        get { return 900; }
    }

    public string OrderId
    {
        get { return Guid.NewGuid().ToString("N"); }
    }

    public string RealName
    {
        get { return "批量开户"; }
    }

    public string RegisteredCell { get; set; }

    public string ReturnUrl
    {
        get { return "http://www.dev.ad.jinyinmao.com.cn/redirect/Home/?request=http://www.baidu.com"; }
    }

    public string UserId { get; set; }
}

/// <summary>
///     身份认证模型 request
/// </summary>
public class IdentityAuthenticationRequest
{
    [JsonProperty("credential")]
    public string Credential { get; set; } = "10";

    [JsonProperty("credentialNo")]
    public string CredentialNo { get; set; }

    [JsonProperty("realName")]
    public string RealName { get; set; }
}

/// <summary>
///     身份认证模型 response
/// </summary>
public class IdentityAuthenticationResponse
{
    [JsonProperty("isSuccess")]
    public bool IsSuccess { get; set; }

    [JsonProperty("userIdentifier")]
    public string UserIdentifier { get; set; }
}

/// <summary>
///     登录模型
/// </summary>
public class LoginRequest
{
    [JsonProperty("loginName")]
    public string LoginName { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }
}

/// <summary>
///     登录返回
/// </summary>
public class LoginResponse
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("cellphone")]
    public string Cellphone { get; set; }

    [JsonProperty("userId")]
    public string UserId { get; set; }
}

public class OpenAccountRequest
{
    /// <summary>
    ///     银行卡号
    /// </summary>
    [JsonProperty("bankCardNo")]
    public string BankCardNo { get; set; }

    /// <summary>
    ///     银行预留手机号
    /// </summary>
    [JsonProperty("bankCardPhone")]
    public string BankCardPhone { get; set; }

    /// <summary>
    ///     用户类型(01-投资用户,02-借款用户,06-借款/投资混合用户)
    /// </summary>
    [JsonProperty("bizType")]
    public string BizType { get; set; }

    /// <summary>
    ///     证件号码（目前仅支持身份证）
    /// </summary>
    [JsonProperty("certNo")]
    public string CertNo { get; set; }

    [JsonProperty("clientType")]
    public int ClientType { get; set; }

    /// <summary>
    ///     orderId
    /// </summary>
    [JsonProperty("orderId")]
    public string OrderId { get; set; }

    /// <summary>
    ///     姓名
    /// </summary>
    [JsonProperty("realName")]
    public string RealName { get; set; }

    /// <summary>
    ///     注册手机号
    /// </summary>
    [JsonProperty("registeredCell")]
    public string RegisteredCell { get; set; }

    /// <summary>
    ///     前台返回地址
    /// </summary>
    [JsonProperty("returnUrl")]
    public string ReturnUrl { get; set; }

    /// <summary>
    ///     用户唯一标识
    /// </summary>
    [JsonProperty("userId")]
    public string UserId { get; set; }
}

public class RegisterInfo
{
    [JsonProperty("clientType")]
    public string ClientType { get; set; } = "900";

    [JsonProperty("contractId")]
    public string ContractId { get; set; }

    [JsonProperty("info")]
    public string Info { get; set; }

    [JsonProperty("inviteBy")]
    public string InviteBy { get; set; }

    [JsonProperty("outletCode")]
    public string OutletCode { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }

    [JsonProperty("token")]
    public string Token { get; set; }
}

/// <summary>
///     注册用户成功后返回的信息
/// </summary>
public class RegisterSuccessInfo
{
    public string BankCardNo { get; set; }

    //UserIndentifier,Pwd,CellPhone,RealName,BankCardNo,InviteBy,RigisterTime,预留手机号,IsVerifed,IsActivation,IsAuthWithdraw,IsAuthInvest
    public string CellPhone { get; set; }

    public string CgBankCellPhone { get; set; }
    public string CredentialNo { get; set; }
    public string InviteBy { get; set; }
    public int IsActivation { get; set; }
    public int IsAuthInvest { get; set; }
    public int IsAuthWithdraw { get; set; }
    public bool IsSuccess { get; set; }
    public int IsVerifed { get; set; }
    public string Pwd { get; set; }
    public string RealName { get; set; }
    public string RegisterTime { get; set; }
    public string UserIdentifier { get; set; }
}

public class ResetPaymentPwdRequest
{
    [JsonProperty("password")]
    public string Password { get; set; } = "qq000000";
}

public class ResetPaymentPwdResponse
{
    [JsonProperty("result")]
    public bool Result { get; set; }

    [JsonProperty("sequenceNo")]
    public string SequenceNo { get; set; } = "qq000000";
}

public class ResetPwdInfo
{
    [JsonProperty("password")]
    public string Password { get; set; } = "111111";

    [JsonProperty("token")]
    public string Token { get; set; }
}

public class ResultInfo
{
    public bool Result { get; set; }
}

public class SendVeriCodeRequest
{
    [JsonProperty("cellphone")]
    public string Cellphone { get; set; }

    [JsonProperty("type")]
    public int Type { get; set; } = 10;
}

public class SendVeriCodeResponse
{
    [JsonProperty("remainCount")]
    public int RemainCount { get; set; } // 今天剩余发送次数，若为-1，则今天不能再次发送该类型验证码 ,

    [JsonProperty("status")]
    public int Status { get; set; } // 1--超过一天的最大发送次数 2--超过每小时的最大发送次数 3--60秒以内不能进行发送 4--系统错误 ,

    [JsonProperty("success")]
    public bool Success { get; set; } //本次发送结果
}

public class SmsCodeInfo
{
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("receiver")]
    public string Receiver { get; set; }

    [JsonProperty("token")]
    public string Token { get; set; }

    [JsonProperty("verified")]
    public bool Verified { get; set; }
}

public class UserInfoResponse
{
    [JsonProperty("userIdentifier")]
    public string UserIdentifier { get; set; }
}

public class VerifyRequest
{
    [JsonProperty("cellphone")]
    public string Cellphone { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("type")]
    public int Type { get; set; } = 10;
}

public class VerifyResponse
{
    [JsonProperty("success")]
    public bool Success { get; set; }
}