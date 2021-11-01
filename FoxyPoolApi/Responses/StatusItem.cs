// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="StatusItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class StatusItem.
    /// </summary>
    public class StatusItem
    {
        /// <summary>
        /// Gets or sets the indicator.
        /// </summary>
        /// <value>The indicator.</value>
        [JsonProperty("indicator")]
        public IncidentImpact Indicator { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
