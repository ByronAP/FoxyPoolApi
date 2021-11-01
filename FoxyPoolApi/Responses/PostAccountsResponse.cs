// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PostAccountsResponse.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PostAccountsResponse.
    /// </summary>
    public class PostAccountsResponse
    {
        /// <summary>
        /// Gets or sets the top accounts.
        /// </summary>
        /// <value>The top accounts.</value>
        [JsonProperty("topAccounts")]
        public List<TopAccount>? TopAccounts { get; set; }

        /// <summary>
        /// Gets or sets the accounts with shares.
        /// </summary>
        /// <value>The accounts with shares.</value>
        [JsonProperty("accountsWithShares")]
        public uint AccountsWithShares { get; set; }

        /// <summary>
        /// Gets or sets the ec sum.
        /// </summary>
        /// <value>The ec sum.</value>
        [JsonProperty("ecSum")]
        public decimal EcSum { get; set; }
    }

    /// <summary>
    /// Class TopAccount.
    /// </summary>
    public class TopAccount
    {
        /// <summary>
        /// Gets or sets the pending.
        /// </summary>
        /// <value>The pending.</value>
        [JsonProperty("pending")]
        public string? Pending { get; set; }

        /// <summary>
        /// Gets or sets the ec.
        /// </summary>
        /// <value>The ec.</value>
        [JsonProperty("ec")]
        public decimal Ec { get; set; }

        /// <summary>
        /// Gets or sets the payout address.
        /// </summary>
        /// <value>The payout address.</value>
        [JsonProperty("payoutAddress")]
        public string? PayoutAddress { get; set; }

        /// <summary>
        /// Gets or sets the distribution ratio.
        /// </summary>
        /// <value>The distribution ratio.</value>
        [JsonProperty("distributionRatio")]
        public string? DistributionRatio { get; set; }

        /// <summary>
        /// Gets or sets the collateral.
        /// </summary>
        /// <value>The collateral.</value>
        [JsonProperty("collateral", NullValueHandling = NullValueHandling.Ignore)]
        public string? Collateral { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }
    }
}
