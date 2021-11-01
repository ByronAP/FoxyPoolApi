// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocBestAccountItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocBestAccountItem.
    /// </summary>
    public class PocBestAccountItem
    {
        /// <summary>
        /// Gets or sets the best deadline.
        /// </summary>
        /// <value>The best deadline.</value>
        [JsonProperty("bestDeadline")]
        public string? BestDeadline { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public string? Id { get; set; }
    }
}
