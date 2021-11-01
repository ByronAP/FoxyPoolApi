// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocMinerItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocMinerItem.
    /// </summary>
    public class PocMinerItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("_id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the software.
        /// </summary>
        /// <value>The software.</value>
        [JsonProperty("software")]
        public string? Software { get; set; }

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>The connection.</value>
        [JsonProperty("connection")]
        public string? Connection { get; set; }

        /// <summary>
        /// Gets or sets the reported capacity.
        /// </summary>
        /// <value>The reported capacity.</value>
        [JsonProperty("reportedCapacity")]
        public uint ReportedCapacity { get; set; } = 0;

        /// <summary>
        /// Gets or sets the last height of the submission.
        /// </summary>
        /// <value>The last height of the submission.</value>
        [JsonProperty("lastSubmissionHeight")]
        public ulong LastSubmissionHeight { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deprecated URL.
        /// </summary>
        /// <value><c>true</c> if this instance is deprecated URL; otherwise, <c>false</c>.</value>
        [JsonProperty("isDeprecatedUrl")]
        public bool IsDeprecatedUrl { get; set; } = false;
    }
}
