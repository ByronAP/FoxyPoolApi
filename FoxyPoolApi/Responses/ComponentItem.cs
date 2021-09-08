using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class ComponentItem
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("status")]
        public ComponentStatus Status { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("position")]
        public uint Position { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("showcase")]
        public bool Showcase { get; set; }

        [JsonProperty("start_date")]
        public DateTimeOffset? StartDate { get; set; }

        [JsonProperty("group_id")]
        public string? GroupId { get; set; }

        [JsonProperty("page_id")]
        public string? PageId { get; set; }

        [JsonProperty("group")]
        public bool Group { get; set; }

        [JsonProperty("only_show_if_degraded")]
        public bool OnlyShowIfDegraded { get; set; }

        [JsonProperty("components", NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? Components { get; set; }
    }
}
