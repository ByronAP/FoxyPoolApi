// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocRoundResponse.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocRoundResponse.
    /// </summary>
    public class PocRoundResponse
    {
        /// <summary>
        /// Gets or sets the round.
        /// </summary>
        /// <value>The round.</value>
        [JsonProperty("round")]
        public PocRoundItem? Round { get; set; }

        /// <summary>
        /// Gets or sets the round start.
        /// </summary>
        /// <value>The round start.</value>
        [JsonProperty("roundStart")]
        public DateTimeOffset RoundStart { get; set; }

        /// <summary>
        /// Gets or sets the best deadline.
        /// </summary>
        /// <value>The best deadline.</value>
        [JsonProperty("bestDeadline")]
        public ulong BestDeadline { get; set; }

        /// <summary>
        /// Gets or sets the best deadline miner.
        /// </summary>
        /// <value>The best deadline miner.</value>
        [JsonProperty("bestDeadlineMiner")]
        public string? BestDeadlineMiner { get; set; }

        /// <summary>
        /// Gets or sets the best submission.
        /// </summary>
        /// <value>The best submission.</value>
        [JsonProperty("bestSubmission")]
        public PocBestSubmissionItem? BestSubmission { get; set; }
    }
}
