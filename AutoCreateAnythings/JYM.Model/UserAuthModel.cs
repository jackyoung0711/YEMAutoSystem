using Newtonsoft.Json;

namespace JYM.Model
{
    public class UserAuthModel
    {
        [JsonProperty("clientType")]
        public int ClientType { get; set; } = 900;

        [JsonProperty("grantList")]
        public string GrantList { get; set; }

        [JsonProperty("returnUrl")]
        public string ReturnUrl { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}