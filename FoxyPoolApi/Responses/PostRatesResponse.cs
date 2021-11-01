// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PostRatesResponse.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PostRatesResponse.
    /// </summary>
    public class PostRatesResponse
    {
        /// <summary>
        /// Gets or sets the rates.
        /// </summary>
        /// <value>The rates.</value>
        [JsonProperty("rates")]
        public Dictionary<string, decimal>? Rates { get; set; }

        /// <summary>
        /// Gets or sets the currencies.
        /// </summary>
        /// <value>The currencies.</value>
        [JsonProperty("currencies")]
        public List<string>? Currencies { get; set; }
    }
}
