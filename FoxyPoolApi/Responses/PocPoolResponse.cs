// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocPoolResponse.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocPoolResponse.
    /// </summary>
    public class PocPoolResponse
    {
        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the ec.
        /// </summary>
        /// <value>The ec.</value>
        [JsonProperty("ec")]
        public decimal Ec { get; set; }

        /// <summary>
        /// Gets or sets the estimated capacity.
        /// </summary>
        /// <value>The estimated capacity.</value>
        [JsonProperty("estimatedCapacity")]
        public uint EstimatedCapacity { get; set; }

        /// <summary>
        /// Gets or sets the account count.
        /// </summary>
        /// <value>The account count.</value>
        [JsonProperty("accountCount")]
        public uint AccountCount { get; set; }

        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        [JsonProperty("accounts")]
        public List<PocAccountItem>? Accounts { get; set; }

        /// <summary>
        /// Gets or sets the payouts.
        /// </summary>
        /// <value>The payouts.</value>
        [JsonProperty("payouts")]
        public List<PocPayoutItem>? Payouts { get; set; }

        /// <summary>
        /// Gets or sets the pledge.
        /// </summary>
        /// <value>The pledge.</value>
        [JsonProperty("pledge")]
        public decimal Pledge { get; set; }

        /// <summary>
        /// Gets or sets the required pledge.
        /// </summary>
        /// <value>The required pledge.</value>
        [JsonProperty("requiredPledge")]
        public uint RequiredPledge { get; set; }

        /// <summary>
        /// Gets or sets the available mining balance.
        /// </summary>
        /// <value>The available mining balance.</value>
        [JsonProperty("availableMiningBalance")]
        public decimal AvailableMiningBalance { get; set; }

        /// <summary>
        /// Gets or sets the rounds won.
        /// </summary>
        /// <value>The rounds won.</value>
        [JsonProperty("roundsWon")]
        public List<PocRoundsWonItem>? RoundsWon { get; set; }

        /// <summary>
        /// Gets or sets the total capacity.
        /// </summary>
        /// <value>The total capacity.</value>
        [JsonProperty("totalCapacity")]
        public ulong TotalCapacity { get; set; }

        /// <summary>
        /// Gets or sets the distribution ratios.
        /// </summary>
        /// <value>The distribution ratios.</value>
        [JsonProperty("distributionRatios")]
        public List<string>? DistributionRatios { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        // TODO: event type
        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>The events.</value>
        [JsonProperty("events")]
        public List<object>? Events { get; set; }

        /// <summary>
        /// Gets or sets the pledge sum.
        /// </summary>
        /// <value>The pledge sum.</value>
        [JsonProperty("pledgeSum")]
        public string? PledgeSum { get; set; }

        /// <summary>
        /// Gets or sets the daily reward per pi b.
        /// </summary>
        /// <value>The daily reward per pi b.</value>
        [JsonProperty("dailyRewardPerPiB")]
        public decimal DailyRewardPerPiB { get; set; }
    }
}
