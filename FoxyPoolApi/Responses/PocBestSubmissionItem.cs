// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocBestSubmissionItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocBestSubmissionItem.
    /// </summary>
    public class PocBestSubmissionItem
    {
        /// <summary>
        /// Gets or sets the plotter identifier.
        /// </summary>
        /// <value>The plotter identifier.</value>
        [JsonProperty("plotterId")]
        public string? PlotterId { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        [JsonProperty("height")]
        public ulong Height { get; set; }

        /// <summary>
        /// Gets or sets the nonce.
        /// </summary>
        /// <value>The nonce.</value>
        [JsonProperty("nonce")]
        public string? Nonce { get; set; }

        /// <summary>
        /// Gets or sets the deadline.
        /// </summary>
        /// <value>The deadline.</value>
        [JsonProperty("deadline")]
        public string? Deadline { get; set; }
    }
}
