using System;
using System.Collections.Generic;

namespace JYM.Model
{
    public class RegularProductInfo
    {
        /// <summary>
        ///     Gets or sets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public Dictionary<string, object> Args { get; set; }

        /// <summary>
        ///     Gets or sets the AssetInfoDesc
        /// </summary>
        /// <value>The AssetInfoDesc</value>
        public string AssetInfoDesc { get; set; }

        /// <summary>
        ///     Gets or sets the name of the bank.
        /// </summary>
        /// <value>The name of the bank.</value>
        public string BankName { get; set; }

        /// <summary>
        ///     Gets or sets the drawee.
        /// </summary>
        /// <value>The drawee.</value>
        public string Drawee { get; set; }

        /// <summary>
        ///     Gets or sets the drawee information.
        /// </summary>
        /// <value>The drawee information.</value>
        public string DraweeInfo { get; set; }

        /// <summary>
        ///     Gets or sets the endorse image link.
        /// </summary>
        /// <value>The endorse image link.</value>
        public string EndorseImageLink { get; set; }

        /// <summary>
        ///     Gets or sets the endorse images link.
        /// </summary>
        /// <value>The endorse images link.</value>
        public List<string> EndorseImagesLink { get; set; }

        /// <summary>
        ///     Gets or sets the end sell time.
        /// </summary>
        /// <value>The end sell time.</value>
        public DateTime EndSellTime { get; set; }

        /// <summary>
        ///     Gets or sets the enterprise information.
        /// </summary>
        /// <value>The enterprise information.</value>
        public string EnterpriseInfo { get; set; }

        /// <summary>
        ///     Gets or sets the enterprise license.
        /// </summary>
        /// <value>The enterprise license.</value>
        public string EnterpriseLicense { get; set; }

        /// <summary>
        ///     Gets or sets the name of the enterprise.
        /// </summary>
        /// <value>The name of the enterprise.</value>
        public string EnterpriseName { get; set; }

        /// <summary>
        ///     Gets or sets the financing sum amount.
        /// </summary>
        /// <value>The financing sum amount.</value>
        public long FinancingSumAmount { get; set; }

        /// <summary>
        ///     是否放款
        /// </summary>
        /// <value><c>true</c> if this instance is loans; otherwise, <c>false</c>.</value>
        public bool IsLoans { get; set; }

        /// <summary>
        ///     Gets or sets the Is PuHuiZhongYin.
        /// </summary>
        /// <value>The Is PuHuiZhongYin.</value>
        public bool IsPuHuiZhongYin { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is signature.
        /// </summary>
        /// <value><c>true</c> if this instance is signature; otherwise, <c>false</c>.</value>
        public bool IsSignature { get; set; }

        /// <summary>
        ///     Gets or sets the issue no.
        /// </summary>
        /// <value>The issue no.</value>
        public int IssueNo { get; set; }

        /// <summary>
        ///     Gets or sets the issue time.
        /// </summary>
        /// <value>The issue time.</value>
        public DateTime IssueTime { get; set; }

        /// <summary>
        ///     Gets or sets the paid amount.
        /// </summary>
        /// <value>The paid amount.</value>
        public long PaidAmount { get; set; }

        /// <summary>
        ///     pdf模板信息
        /// </summary>
        /// <value>The PDF agreement.</value>
        public Dictionary<int, string> PdfAgreement { get; set; }

        /// <summary>
        ///     Gets or sets the period.
        /// </summary>
        /// <value>The period.</value>
        public int Period { get; set; }

        //        /// <summary>
        //        ///     Gets or sets the PHZYInfo arguments.
        //        /// </summary>
        //        /// <value>The arguments.</value>
        //        public Dictionary<string, object> PHZYInfoArgs { get; set; }

        /// <summary>
        ///     Gets or sets the pledge no.
        /// </summary>
        /// <value>The pledge no.</value>
        public string PledgeNo { get; set; }

        /// <summary>
        ///     Gets or sets the product category.
        /// </summary>
        /// <value>The product category.</value>
        public long ProductCategory { get; set; }

        /// <summary>
        ///     Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public Guid ProductId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the product.
        /// </summary>
        /// <value>The name of the product.</value>
        public string ProductName { get; set; }

        /// <summary>
        ///     Gets or sets the product no.
        /// </summary>
        /// <value>The product no.</value>
        public string ProductNo { get; set; }

        /// <summary>
        /// </summary>
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="RegularProductInfo" /> is repaid.
        /// </summary>
        /// <value><c>true</c> if repaid; otherwise, <c>false</c>.</value>
        public bool Repaid { get; set; }

        /// <summary>
        ///     Gets or sets the repaid time.
        /// </summary>
        /// <value>The repaid time.</value>
        public DateTime? RepaidTime { get; set; }

        /// <summary>
        ///     Gets or sets the repayment deadline.
        /// </summary>
        /// <value>The repayment deadline.</value>
        public DateTime RepaymentDeadline { get; set; }

        /// <summary>
        ///     Gets or sets the ReturnMoneyMethod.
        /// </summary>
        /// <value>The pledge no.</value>
        public string ReturnMoneyMethod { get; set; }

        /// <summary>
        ///     Gets or sets the risk management.
        /// </summary>
        /// <value>The risk management.</value>
        public string RiskManagement { get; set; }

        /// <summary>
        ///     Gets or sets the risk management information.
        /// </summary>
        /// <value>The risk management information.</value>
        public string RiskManagementInfo { get; set; }

        /// <summary>
        ///     Gets or sets the risk management mode.
        /// </summary>
        /// <value>The risk management mode.</value>
        public string RiskManagementMode { get; set; }

        /// <summary>
        ///     Gets or sets the settle date.
        /// </summary>
        /// <value>The settle date.</value>
        public DateTime SettleDate { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [sold out].
        /// </summary>
        /// <value><c>true</c> if [sold out]; otherwise, <c>false</c>.</value>
        public bool SoldOut { get; set; }

        /// <summary>
        ///     Gets or sets the sold out time.
        /// </summary>
        /// <value>The sold out time.</value>
        public DateTime? SoldOutTime { get; set; }

        /// <summary>
        ///     Gets or sets the start sell time.
        /// </summary>
        /// <value>The start sell time.</value>
        public DateTime StartSellTime { get; set; }

        /// <summary>
        ///     Gets or sets the TagNames.
        /// </summary>
        /// <value>The yield.</value>
        public string TagNames { get; set; }

        /// <summary>
        ///     Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public long UnitPrice { get; set; }

        /// <summary>
        ///     Gets or sets the usage.
        /// </summary>
        /// <value>The usage.</value>
        public string Usage { get; set; }

        /// <summary>
        ///     Gets or sets the value date.
        /// </summary>
        /// <value>The value date.</value>
        public DateTime? ValueDate { get; set; }

        /// <summary>
        ///     Gets or sets the value date mode.
        /// </summary>
        /// <value>The value date mode.</value>
        public int? ValueDateMode { get; set; }

        /// <summary>
        ///     Gets or sets the value date.
        /// </summary>
        /// <value>The value date.</value>
        public int? ValueDays { get; set; }

        /// <summary>
        ///     Gets or sets the yield.
        /// </summary>
        /// <value>The yield.</value>
        public int Yield { get; set; }
    }
}