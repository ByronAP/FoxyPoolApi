// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocLiveResponse.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocLiveResponse.
    /// </summary>
    public class PocLiveResponse
    {
        /// <summary>
        /// Gets or sets the current submissions.
        /// </summary>
        /// <value>The current submissions.</value>
        [JsonProperty("currentSubmissions")]
        public Dictionary<string, PocCurrentSubmissionItem>? CurrentSubmissions { get; set; }
    }
}
