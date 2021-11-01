// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocPlotterItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocPlotterItem.
    /// </summary>
    public class PocPlotterItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("_id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the plotter identifier.
        /// </summary>
        /// <value>The plotter identifier.</value>
        [JsonProperty("id")]
        public string? PlotterId { get; set; }

        /// <summary>
        /// Gets or sets the last height of the submission.
        /// </summary>
        /// <value>The last height of the submission.</value>
        [JsonProperty("lastSubmissionHeight")]
        public ulong LastSubmissionHeight { get; set; } = 0;
    }
}
