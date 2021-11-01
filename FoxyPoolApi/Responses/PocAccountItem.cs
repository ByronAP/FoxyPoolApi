// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocAccountItem.cs" company="ByronAP">
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
    /// Class PocAccountItem.
    /// </summary>
    public class PocAccountItem
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
        /// Gets or sets the ec share.
        /// </summary>
        /// <value>The ec share.</value>
        [JsonProperty("ecShare")]
        public decimal EcShare { get; set; }

        /// <summary>
        /// Gets or sets the payout address.
        /// </summary>
        /// <value>The payout address.</value>
        [JsonProperty("payoutAddress")]
        public string? PayoutAddress { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>The updated at.</value>
        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the distribution ratio.
        /// </summary>
        /// <value>The distribution ratio.</value>
        [JsonProperty("distributionRatio")]
        public string? DistributionRatio { get; set; }

        /// <summary>
        /// Gets or sets the miner.
        /// </summary>
        /// <value>The miner.</value>
        [JsonProperty("miner")]
        public List<PocMinerItem>? Miner { get; set; }

        /// <summary>
        /// Gets or sets the plotter.
        /// </summary>
        /// <value>The plotter.</value>
        [JsonProperty("plotter")]
        public List<PocPlotterItem>? Plotter { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the deadlines.
        /// </summary>
        /// <value>The deadlines.</value>
        [JsonProperty("deadlines")]
        public ulong Deadlines { get; set; }

        /// <summary>
        /// Gets or sets the software.
        /// </summary>
        /// <value>The software.</value>
        [JsonProperty("software", NullValueHandling = NullValueHandling.Ignore)]
        public string? Software { get; set; }

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>The connection.</value>
        [JsonProperty("connection", NullValueHandling = NullValueHandling.Ignore)]
        public string? Connection { get; set; }

        /// <summary>
        /// Gets or sets the last height of the submission.
        /// </summary>
        /// <value>The last height of the submission.</value>
        [JsonProperty("lastSubmissionHeight", NullValueHandling = NullValueHandling.Ignore)]
        public ulong LastSubmissionHeight { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deprecated URL.
        /// </summary>
        /// <value><c>true</c> if this instance is deprecated URL; otherwise, <c>false</c>.</value>
        [JsonProperty("isDeprecatedUrl", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDeprecatedUrl { get; set; } = false;

        /// <summary>
        /// Gets or sets the reported capacity.
        /// </summary>
        /// <value>The reported capacity.</value>
        [JsonProperty("reportedCapacity")]
        public ulong ReportedCapacity { get; set; }

        /// <summary>
        /// Gets or sets the pledge.
        /// </summary>
        /// <value>The pledge.</value>
        [JsonProperty("pledge", NullValueHandling = NullValueHandling.Ignore)]
        public string? Pledge { get; set; }

        /// <summary>
        /// Gets or sets the pledge share.
        /// </summary>
        /// <value>The pledge share.</value>
        [JsonProperty("pledgeShare", NullValueHandling = NullValueHandling.Ignore)]
        public decimal PledgeShare { get; set; } = 0m;
    }
}
