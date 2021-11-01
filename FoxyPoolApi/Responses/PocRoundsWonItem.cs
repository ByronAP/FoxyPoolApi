// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocRoundsWonItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocRoundsWonItem.
    /// </summary>
    public class PocRoundsWonItem
    {
        /// <summary>
        /// Gets or sets the block.
        /// </summary>
        /// <value>The block.</value>
        [JsonProperty("block")]
        public PocBlockItem? Block { get; set; }

        /// <summary>
        /// Gets or sets the best account.
        /// </summary>
        /// <value>The best account.</value>
        [JsonProperty("bestAccount")]
        public PocBestAccountItem? BestAccount { get; set; }

        /// <summary>
        /// Gets or sets the winner.
        /// </summary>
        /// <value>The winner.</value>
        [JsonProperty("winner")]
        public PocWinnerItem? Winner { get; set; }

        /// <summary>
        /// Gets or sets the pool capacity.
        /// </summary>
        /// <value>The pool capacity.</value>
        [JsonProperty("poolCapacity")]
        public PocPoolCapacityItem? PoolCapacity { get; set; }

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
        /// Gets or sets a value indicating whether this <see cref="PocRoundsWonItem"/> is distributed.
        /// </summary>
        /// <value><c>true</c> if distributed; otherwise, <c>false</c>.</value>
        [JsonProperty("distributed")]
        public bool Distributed { get; set; }

        /// <summary>
        /// Gets or sets the distribution ratio.
        /// </summary>
        /// <value>The distribution ratio.</value>
        [JsonProperty("distributionRatio", NullValueHandling = NullValueHandling.Ignore)]
        public string? DistributionRatio { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PocRoundsWonItem"/> is won.
        /// </summary>
        /// <value><c>true</c> if won; otherwise, <c>false</c>.</value>
        [JsonProperty("won")]
        public bool Won { get; set; }
    }
}
