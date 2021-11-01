// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocTransactionItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocTransactionItem.
    /// </summary>
    public class PocTransactionItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("_id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the tx identifier.
        /// </summary>
        /// <value>The tx identifier.</value>
        [JsonProperty("txId")]
        public string? TxId { get; set; }

        /// <summary>
        /// Gets or sets the payout amounts.
        /// </summary>
        /// <value>The payout amounts.</value>
        [JsonProperty("payoutAmounts")]
        public Dictionary<string, string>? PayoutAmounts { get; set; }
    }
}
