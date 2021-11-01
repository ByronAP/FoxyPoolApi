// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PostRewardsResponse.cs" company="ByronAP">
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
    /// Class PostRewardsResponse.
    /// </summary>
    public class PostRewardsResponse
    {
        /// <summary>
        /// Gets or sets the recently won blocks.
        /// </summary>
        /// <value>The recently won blocks.</value>
        [JsonProperty("recentlyWonBlocks")]
        public List<RecentlyWonBlock>? RecentlyWonBlocks { get; set; }

        /// <summary>
        /// Gets or sets the daily reward per pi b.
        /// </summary>
        /// <value>The daily reward per pi b.</value>
        [JsonProperty("dailyRewardPerPiB")]
        public decimal DailyRewardPerPiB { get; set; }

        /// <summary>
        /// Gets or sets the average effort.
        /// </summary>
        /// <value>The average effort.</value>
        [JsonProperty("averageEffort")]
        public decimal AverageEffort { get; set; }
    }

    /// <summary>
    /// Class RecentlyWonBlock.
    /// </summary>
    public class RecentlyWonBlock
    {
        /// <summary>
        /// Gets or sets the winner.
        /// </summary>
        /// <value>The winner.</value>
        [JsonProperty("winner")]
        public BlockWinner? Winner { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is reward claimed.
        /// </summary>
        /// <value><c>true</c> if this instance is reward claimed; otherwise, <c>false</c>.</value>
        [JsonProperty("isRewardClaimed")]
        public bool IsRewardClaimed { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        [JsonProperty("height")]
        public ulong Height { get; set; }

        /// <summary>
        /// Gets or sets the hash.
        /// </summary>
        /// <value>The hash.</value>
        [JsonProperty("hash")]
        public string? Hash { get; set; }

        /// <summary>
        /// Gets or sets the reward.
        /// </summary>
        /// <value>The reward.</value>
        [JsonProperty("reward")]
        public decimal Reward { get; set; }

        /// <summary>
        /// Gets or sets the network space in tib.
        /// </summary>
        /// <value>The network space in tib.</value>
        [JsonProperty("networkSpaceInTib")]
        public string? NetworkSpaceInTib { get; set; }

        /// <summary>
        /// Gets or sets the effort.
        /// </summary>
        /// <value>The effort.</value>
        [JsonProperty("effort")]
        public decimal Effort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="RecentlyWonBlock"/> is distributed.
        /// </summary>
        /// <value><c>true</c> if distributed; otherwise, <c>false</c>.</value>
        [JsonProperty("distributed")]
        public bool Distributed { get; set; }

        /// <summary>
        /// Gets or sets the distribution ratio.
        /// </summary>
        /// <value>The distribution ratio.</value>
        [JsonProperty("distributionRatio")]
        public string? DistributionRatio { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }

    /// <summary>
    /// Class BlockWinner.
    /// </summary>
    public class BlockWinner
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the payout address.
        /// </summary>
        /// <value>The payout address.</value>
        [JsonProperty("payoutAddress")]
        public string? PayoutAddress { get; set; }
    }
}
