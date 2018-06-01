using Newtonsoft.Json;

namespace JYM.Model
{
    public class AuthUserInfo
    {
        [JsonProperty("inviteBy")]
        public string InviteBy { get; set; }

        [JsonProperty("inviteFor")]
        public string InviteFor { get; set; }

        [JsonProperty("registerTime")]
        public string RegisterTime { get; set; }

        [JsonProperty("userIdentifier")]
        public string UserIdentifier { get; set; }
    }

    public class BankUserBalance
    {
        [JsonProperty("availableBalance")]
        public long AvailableBalance { get; set; }

        [JsonProperty("respCode")]
        public int RespCode { get; set; }
    }

    /// <summary>
    ///     银行用户信息
    /// </summary>
    public class BankUserInfo
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public class UserInfo
    {
        [JsonProperty("isActivation")]
        public bool IsActivation { get; set; }

        [JsonProperty("userIdentifier")]
        public string UserIdentifier { get; set; }
    }
}