using Newtonsoft.Json;

namespace JYM.Model
{
    /// <summary>
    ///     充值
    /// </summary>
    public class RechargeReqeust
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        public string CellPhone { get; set; }

        [JsonProperty("channelType")]
        public int ChannelType { get; set; }

        [JsonProperty("clientType")]
        public int ClientType { get; set; }

        public string Password { get; set; }

        [JsonProperty("returnUrl")]
        public string ReturnUrl { get; set; }

        [JsonIgnore]
        public string UserIdentifier { get; set; }
    }
}