using System.Collections.Generic;
using Newtonsoft.Json;

namespace JYM.Model
{
    public class AnalogLogin
    {
        /// <summary>
        ///     auth
        /// </summary>
        [JsonProperty("auth")]
        public string Auth { get; set; }

        [JsonProperty("userIdentifiers")]
        public string UserIdentifiers { get; set; }
    }

    public class AnalogLoginResponse
    {
        /// <summary>
        /// </summary>
        [JsonProperty("logins")]
        public List<AnalogLogin> Logins { get; set; }
    }

    public class BaseAuth
    {
        [JsonIgnore]
        [JsonProperty("CellPhone")]
        public string CellPhone { get; set; }

        [JsonIgnore]
        [JsonProperty("Pwd")]
        public string Pwd { get; set; }
    }
}