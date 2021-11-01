// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="IncidentUpdateItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class IncidentUpdateItem.
    /// </summary>
    public class IncidentUpdateItem
    {
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        [JsonProperty("body")]
        public string? Body { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the display at.
        /// </summary>
        /// <value>The display at.</value>
        [JsonProperty("display_at")]
        public DateTimeOffset DisplayAt { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the incident identifier.
        /// </summary>
        /// <value>The incident identifier.</value>
        [JsonProperty("incident_id")]
        public string? IncidentId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public IncidentStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>The updated at.</value>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
