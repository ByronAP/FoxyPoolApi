// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocConfigResponse.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocConfigResponse.
    /// </summary>
    public class PocConfigResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether [binding closed].
        /// </summary>
        /// <value><c>true</c> if [binding closed]; otherwise, <c>false</c>.</value>
        [JsonProperty("bindingClosed")]
        public bool BindingClosed { get; set; }

        /// <summary>
        /// Gets or sets the binding cost.
        /// </summary>
        /// <value>The binding cost.</value>
        [JsonProperty("bindingCost")]
        public decimal BindingCost { get; set; }

        /// <summary>
        /// Gets or sets the bind to function.
        /// </summary>
        /// <value>The bind to function.</value>
        [JsonProperty("bindToFunction")]
        public string? BindToFunction { get; set; }

        /// <summary>
        /// Gets or sets the block explorer block URL template.
        /// </summary>
        /// <value>The block explorer block URL template.</value>
        [JsonProperty("blockExplorerBlockUrlTemplate")]
        public string? BlockExplorerBlockUrlTemplate { get; set; }

        /// <summary>
        /// Gets or sets the block explorer tx URL template.
        /// </summary>
        /// <value>The block explorer tx URL template.</value>
        [JsonProperty("blockExplorerTxUrlTemplate")]
        public string? BlockExplorerTxUrlTemplate { get; set; }

        /// <summary>
        /// Gets or sets the block reward distribution delay.
        /// </summary>
        /// <value>The block reward distribution delay.</value>
        [JsonProperty("blockRewardDistributionDelay")]
        public uint BlockRewardDistributionDelay { get; set; }

        /// <summary>
        /// Gets or sets the blocks per day.
        /// </summary>
        /// <value>The blocks per day.</value>
        [JsonProperty("blocksPerDay")]
        public uint BlocksPerDay { get; set; }

        /// <summary>
        /// Gets or sets the default distribution ratio.
        /// </summary>
        /// <value>The default distribution ratio.</value>
        [JsonProperty("defaultDistributionRatio")]
        public string? DefaultDistributionRatio { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [disable pledge instructions].
        /// </summary>
        /// <value><c>true</c> if [disable pledge instructions]; otherwise, <c>false</c>.</value>
        [JsonProperty("disablePledgeInstructions")]
        public bool DisablePledgeInstructions { get; set; }

        /// <summary>
        /// Gets or sets the faucet input.
        /// </summary>
        /// <value>The faucet input.</value>
        [JsonProperty("faucetInput")]
        public string? FaucetInput { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [free bindings].
        /// </summary>
        /// <value><c>true</c> if [free bindings]; otherwise, <c>false</c>.</value>
        [JsonProperty("freeBindings")]
        public bool FreeBindings { get; set; }

        /// <summary>
        /// Gets or sets the historical count.
        /// </summary>
        /// <value>The historical count.</value>
        [JsonProperty("historicalCount")]
        public uint HistoricalCount { get; set; }

        /// <summary>
        /// Gets or sets the low share.
        /// </summary>
        /// <value>The low share.</value>
        [JsonProperty("lowShare")]
        public decimal LowShare { get; set; }

        /// <summary>
        /// Gets or sets the lucky block reward minimum.
        /// </summary>
        /// <value>The lucky block reward minimum.</value>
        [JsonProperty("luckyBlockRewardMin")]
        public decimal LuckyBlockRewardMin { get; set; }

        /// <summary>
        /// Gets or sets the minimum payout.
        /// </summary>
        /// <value>The minimum payout.</value>
        [JsonProperty("minimumPayout")]
        public decimal MinimumPayout { get; set; }

        /// <summary>
        /// Gets or sets the mining URL.
        /// </summary>
        /// <value>The mining URL.</value>
        [JsonProperty("miningUrl")]
        public string? MiningUrl { get; set; }

        //TODO: notices type
        /// <summary>
        /// Gets or sets the notices.
        /// </summary>
        /// <value>The notices.</value>
        [JsonProperty("notices")]
        public List<object>? Notices { get; set; }

        /// <summary>
        /// Gets or sets the on demand payout fee.
        /// </summary>
        /// <value>The on demand payout fee.</value>
        [JsonProperty("onDemandPayoutFee")]
        public decimal OnDemandPayoutFee { get; set; }

        /// <summary>
        /// Gets or sets the pledge function.
        /// </summary>
        /// <value>The pledge function.</value>
        [JsonProperty("pledgeFunction")]
        public string? PledgeFunction { get; set; }

        /// <summary>
        /// Gets or sets the pledge precision.
        /// </summary>
        /// <value>The pledge precision.</value>
        [JsonProperty("pledgePrecision")]
        public uint PledgePrecision { get; set; }

        /// <summary>
        /// Gets or sets the pledge unit.
        /// </summary>
        /// <value>The pledge unit.</value>
        [JsonProperty("pledgeUnit")]
        public string? PledgeUnit { get; set; }

        /// <summary>
        /// Gets or sets the pool address.
        /// </summary>
        /// <value>The pool address.</value>
        [JsonProperty("poolAddress")]
        public string? PoolAddress { get; set; }

        /// <summary>
        /// Gets or sets the name of the pool.
        /// </summary>
        /// <value>The name of the pool.</value>
        [JsonProperty("poolName")]
        public string? PoolName { get; set; }

        /// <summary>
        /// Gets or sets the pool share.
        /// </summary>
        /// <value>The pool share.</value>
        [JsonProperty("poolShare")]
        public uint PoolShare { get; set; }

        /// <summary>
        /// Gets or sets the pool URL.
        /// </summary>
        /// <value>The pool URL.</value>
        [JsonProperty("poolUrl")]
        public string? PoolUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [requires full pledge].
        /// </summary>
        /// <value><c>true</c> if [requires full pledge]; otherwise, <c>false</c>.</value>
        [JsonProperty("requiresFullPledge")]
        public bool RequiresFullPledge { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [supports binding].
        /// </summary>
        /// <value><c>true</c> if [supports binding]; otherwise, <c>false</c>.</value>
        [JsonProperty("supportsBinding")]
        public bool SupportsBinding { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [supports dynamic rewards].
        /// </summary>
        /// <value><c>true</c> if [supports dynamic rewards]; otherwise, <c>false</c>.</value>
        [JsonProperty("supportsDynamicRewards")]
        public bool SupportsDynamicRewards { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [supports faucet].
        /// </summary>
        /// <value><c>true</c> if [supports faucet]; otherwise, <c>false</c>.</value>
        [JsonProperty("supportsFaucet")]
        public bool SupportsFaucet { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [supports message verification].
        /// </summary>
        /// <value><c>true</c> if [supports message verification]; otherwise, <c>false</c>.</value>
        [JsonProperty("supportsMessageVerification")]
        public bool SupportsMessageVerification { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [supports pledge].
        /// </summary>
        /// <value><c>true</c> if [supports pledge]; otherwise, <c>false</c>.</value>
        [JsonProperty("supportsPledge")]
        public bool SupportsPledge { get; set; }

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        [JsonProperty("symbol")]
        public string? Symbol { get; set; }

        /// <summary>
        /// Gets or sets the target dl.
        /// </summary>
        /// <value>The target dl.</value>
        [JsonProperty("targetDL")]
        public ulong TargetDl { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [JsonProperty("version")]
        public string? Version { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is testnet.
        /// </summary>
        /// <value><c>true</c> if this instance is testnet; otherwise, <c>false</c>.</value>
        [JsonProperty("isTestnet")]
        public bool IsTestnet { get; set; }
    }
}
