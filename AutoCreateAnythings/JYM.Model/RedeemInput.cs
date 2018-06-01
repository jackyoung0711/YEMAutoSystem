using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace JYM.Model
{
    public class RedeemInput
    {
        /// <summary>
        ///     债权Id
        /// </summary>
        /// <value>The asset ratio identifier.</value>
        [Required]
        [JsonProperty("userAssetRatios")]
        public List<UserRedeemableAssetRatio> UserAssetRatios { get; set; }

        /// <summary>
        ///     用户Id
        /// </summary>
        /// <value>
        ///     The user identifier.
        /// </value>
        [Required]
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    /// <summary>
    ///     Class UserRedeemableAssetRatio.
    /// </summary>
    public class UserRedeemableAssetRatio
    {
        /// <summary>
        ///     债权类型 1:子订单 2:债权
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("assetRatioType")]
        public int AssetRatioType { get; set; }

        /// <summary>
        ///     债权Id
        /// </summary>
        /// <value>The user asset ratio identifier.</value>
        [JsonProperty("userAssetRatioId")]
        public string UserAssetRatioId { get; set; }
    }
}