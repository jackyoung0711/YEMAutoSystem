using Newtonsoft.Json;

namespace JYM.Model
{
    public class InvestmentReqeust
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("clientType")]
        public int ClientType { get; set; }

        [JsonIgnore]
        [JsonProperty("couponIdentifier")]
        public string CouponIdentifier { get; set; }

        [JsonIgnore]
        [JsonProperty("couponType")]
        public int CouponType { get; set; }

        [JsonProperty("productIdentifier")]
        public string ProductIdentifier { get; set; }

        [JsonProperty("returnUrl")]
        public string ReturnUrl { get; set; }

        [JsonIgnore]
        public string UserIdentifier { get; set; }
    }

    public class InvestmentResponse
    {
        [JsonProperty("gatewayResponse")]
        public BankSercrityInfo GatewayResponse { get; set; }

        [JsonProperty("orderIdentifier")]
        public string OrderIdentifier { get; set; }
    }
}