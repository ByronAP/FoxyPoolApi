// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocRoundItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocRoundItem.
    /// </summary>
    public class PocRoundItem
    {
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        [JsonProperty("height")]
        public ulong Height { get; set; }

        /// <summary>
        /// Gets or sets the base target.
        /// </summary>
        /// <value>The base target.</value>
        [JsonProperty("baseTarget")]
        public uint BaseTarget { get; set; }

        /// <summary>
        /// Gets or sets the generation signature.
        /// </summary>
        /// <value>The generation signature.</value>
        [JsonProperty("generationSignature")]
        public string? GenerationSignature { get; set; }

        /// <summary>
        /// Gets or sets the target deadline.
        /// </summary>
        /// <value>The target deadline.</value>
        [JsonProperty("targetDeadline")]
        public ulong TargetDeadline { get; set; }

        /// <summary>
        /// Gets or sets the average commitment.
        /// </summary>
        /// <value>The average commitment.</value>
        [JsonProperty("averageCommitment", NullValueHandling = NullValueHandling.Ignore)]
        public string? AverageCommitment { get; set; }
    }
}
