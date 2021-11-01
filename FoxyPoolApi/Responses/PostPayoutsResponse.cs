// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 10-31-2021
// ***********************************************************************
// <copyright file="PostPayoutsResponse.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PostPayoutsResponse.
    /// </summary>
    public class PostPayoutsResponse
    {
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("state")]
        public string? State { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("_id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the transactions.
        /// </summary>
        /// <value>The transactions.</value>
        [JsonProperty("transactions")]
        public List<Transaction>? Transactions { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }

    /// <summary>
    /// Class Transaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Gets or sets the coin ids.
        /// </summary>
        /// <value>The coin ids.</value>
        [JsonProperty("coinIds")]
        public List<string>? CoinIds { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("state")]
        public string? State { get; set; }

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
