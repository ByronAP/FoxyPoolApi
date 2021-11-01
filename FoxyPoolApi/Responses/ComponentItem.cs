// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="ComponentItem.cs" company="ByronAP">
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
    /// Class ComponentItem.
    /// </summary>
    public class ComponentItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public ComponentStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>The updated at.</value>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [JsonProperty("position")]
        public uint Position { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ComponentItem"/> is showcase.
        /// </summary>
        /// <value><c>true</c> if showcase; otherwise, <c>false</c>.</value>
        [JsonProperty("showcase")]
        public bool Showcase { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        [JsonProperty("start_date")]
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>The group identifier.</value>
        [JsonProperty("group_id")]
        public string? GroupId { get; set; }

        /// <summary>
        /// Gets or sets the page identifier.
        /// </summary>
        /// <value>The page identifier.</value>
        [JsonProperty("page_id")]
        public string? PageId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ComponentItem"/> is group.
        /// </summary>
        /// <value><c>true</c> if group; otherwise, <c>false</c>.</value>
        [JsonProperty("group")]
        public bool Group { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [only show if degraded].
        /// </summary>
        /// <value><c>true</c> if [only show if degraded]; otherwise, <c>false</c>.</value>
        [JsonProperty("only_show_if_degraded")]
        public bool OnlyShowIfDegraded { get; set; }

        /// <summary>
        /// Gets or sets the components.
        /// </summary>
        /// <value>The components.</value>
        [JsonProperty("components", NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? Components { get; set; }
    }
}
