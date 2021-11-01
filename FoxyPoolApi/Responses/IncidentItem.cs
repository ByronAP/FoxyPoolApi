// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="IncidentItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class IncidentItem.
    /// </summary>
    public class IncidentItem
    {
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the impact.
        /// </summary>
        /// <value>The impact.</value>
        [JsonProperty("impact")]
        public IncidentImpact Impact { get; set; }

        /// <summary>
        /// Gets or sets the incident updates.
        /// </summary>
        /// <value>The incident updates.</value>
        [JsonProperty("incident_updates")]
        public List<IncidentUpdateItem>? IncidentUpdates { get; set; }

        /// <summary>
        /// Gets or sets the monitoring at.
        /// </summary>
        /// <value>The monitoring at.</value>
        [JsonProperty("monitoring_at")]
        public DateTimeOffset? MonitoringAt { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the page identifier.
        /// </summary>
        /// <value>The page identifier.</value>
        [JsonProperty("page_id")]
        public string? PageId { get; set; }

        /// <summary>
        /// Gets or sets the resolved at.
        /// </summary>
        /// <value>The resolved at.</value>
        [JsonProperty("resolved_at")]
        public DateTimeOffset? ResolvedAt { get; set; }

        /// <summary>
        /// Gets or sets the shortlink.
        /// </summary>
        /// <value>The shortlink.</value>
        [JsonProperty("shortlink")]
        public string? Shortlink { get; set; }

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

        /// <summary>
        /// Gets or sets the scheduled for.
        /// </summary>
        /// <value>The scheduled for.</value>
        [JsonProperty("scheduled_for", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ScheduledFor { get; set; }

        /// <summary>
        /// Gets or sets the scheduled until.
        /// </summary>
        /// <value>The scheduled until.</value>
        [JsonProperty("scheduled_until", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ScheduledUntil { get; set; }
    }
}
