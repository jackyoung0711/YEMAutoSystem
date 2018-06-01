using Newtonsoft.Json;

namespace JYM.Model
{
    public class BizSimpleResult
    {
        /// <summary>
        ///     错误信息
        /// </summary>
        /// <value>
        ///     The error desc.
        /// </value>
        [JsonProperty("errorDesc")]
        public string ErrorDesc { get; set; }

        /// <summary>
        ///     是否成功
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }
    }

    public class CurrentProductInfo
    {
        //"result": "03/04/2020 00:17:16",
        //"resultKey": "FE77B2EABE5E4F6DB250FA07764FC965"

        public string Result { get; set; }

        public string ResultKey { get; set; }
    }
}