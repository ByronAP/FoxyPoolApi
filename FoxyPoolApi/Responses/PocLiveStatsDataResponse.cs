// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocLiveStatsDataResponse.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocLiveStatsDataResponse.
    /// </summary>
    public class PocLiveStatsDataResponse
    {
        /// <summary>
        /// Gets or sets the current submissions.
        /// </summary>
        /// <value>The current submissions.</value>
        [JsonProperty("currentSubmissions")]
        public Dictionary<string, PocCurrentSubmissionItem>? CurrentSubmissions { get; set; }

        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>PocLiveStatsDataResponse.</returns>
        public static PocLiveStatsDataResponse FromJson(string json) => JsonConvert.DeserializeObject<PocLiveStatsDataResponse>(json);
    }
}
