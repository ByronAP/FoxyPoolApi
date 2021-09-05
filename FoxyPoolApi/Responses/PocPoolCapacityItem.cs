using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    public class PocPoolCapacityItem
    {
        [JsonProperty("ec")]
        public decimal Ec { get; set; }

        [JsonProperty("accountEcSum")]
        public decimal AccountEcSum { get; set; }
    }
}
