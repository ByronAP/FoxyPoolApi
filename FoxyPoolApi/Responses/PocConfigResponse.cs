using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    public class PocConfigResponse
    {
        [JsonProperty("bindingClosed")]
        public bool BindingClosed { get; set; }

        [JsonProperty("bindingCost")]
        public decimal BindingCost { get; set; }

        [JsonProperty("bindToFunction")]
        public string BindToFunction { get; set; }

        [JsonProperty("blockExplorerBlockUrlTemplate")]
        public string BlockExplorerBlockUrlTemplate { get; set; }

        [JsonProperty("blockExplorerTxUrlTemplate")]
        public string BlockExplorerTxUrlTemplate { get; set; }

        [JsonProperty("blockRewardDistributionDelay")]
        public uint BlockRewardDistributionDelay { get; set; }

        [JsonProperty("blocksPerDay")]
        public uint BlocksPerDay { get; set; }

        [JsonProperty("defaultDistributionRatio")]
        public string DefaultDistributionRatio { get; set; }

        [JsonProperty("disablePledgeInstructions")]
        public bool DisablePledgeInstructions { get; set; }

        [JsonProperty("faucetInput")]
        public string FaucetInput { get; set; }

        [JsonProperty("freeBindings")]
        public bool FreeBindings { get; set; }

        [JsonProperty("historicalCount")]
        public uint HistoricalCount { get; set; }

        [JsonProperty("lowShare")]
        public decimal LowShare { get; set; }

        [JsonProperty("luckyBlockRewardMin")]
        public decimal LuckyBlockRewardMin { get; set; }

        [JsonProperty("minimumPayout")]
        public decimal MinimumPayout { get; set; }

        [JsonProperty("miningUrl")]
        public string MiningUrl { get; set; }

        //TODO: notices type
        [JsonProperty("notices")]
        public List<object> Notices { get; set; }

        [JsonProperty("onDemandPayoutFee")]
        public decimal OnDemandPayoutFee { get; set; }

        [JsonProperty("pledgeFunction")]
        public string PledgeFunction { get; set; }

        [JsonProperty("pledgePrecision")]
        public uint PledgePrecision { get; set; }

        [JsonProperty("pledgeUnit")]
        public string PledgeUnit { get; set; }

        [JsonProperty("poolAddress")]
        public string PoolAddress { get; set; }

        [JsonProperty("poolName")]
        public string PoolName { get; set; }

        [JsonProperty("poolShare")]
        public uint PoolShare { get; set; }

        [JsonProperty("poolUrl")]
        public string PoolUrl { get; set; }

        [JsonProperty("requiresFullPledge")]
        public bool RequiresFullPledge { get; set; }

        [JsonProperty("supportsBinding")]
        public bool SupportsBinding { get; set; }

        [JsonProperty("supportsDynamicRewards")]
        public bool SupportsDynamicRewards { get; set; }

        [JsonProperty("supportsFaucet")]
        public bool SupportsFaucet { get; set; }

        [JsonProperty("supportsMessageVerification")]
        public bool SupportsMessageVerification { get; set; }

        [JsonProperty("supportsPledge")]
        public bool SupportsPledge { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("targetDL")]
        public ulong TargetDl { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("isTestnet")]
        public bool IsTestnet { get; set; }

        public static PocConfigResponse FromJson(string json) => JsonConvert.DeserializeObject<PocConfigResponse>(json);
    }
}
