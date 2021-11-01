// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PoolIncidentsResponse.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PoolIncidentsResponse.
    /// </summary>
    public class PoolIncidentsResponse
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>The page.</value>
        [JsonProperty("page")]
        public PageItem? Page { get; set; }

        /// <summary>
        /// Gets or sets the incidents.
        /// </summary>
        /// <value>The incidents.</value>
        [JsonProperty("incidents")]
        public List<IncidentItem>? Incidents { get; set; }
    }
}
