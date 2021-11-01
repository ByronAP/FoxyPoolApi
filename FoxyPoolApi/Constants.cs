// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-04-2021
//
// Last Modified By : bapen
// Last Modified On : 10-01-2021
// ***********************************************************************
// <copyright file="Constants.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace FoxyPoolApi
{
    /// <summary>
    /// Class Constants.
    /// </summary>
    public static class Constants
    {
        // General Info
        /// <summary>
        /// Pool display name
        /// </summary>
        public const string PoolDisplayName = "Foxy Pool";
        /// <summary>
        /// Pool home URL
        /// </summary>
        public const string PoolHomeUrl = "https://foxypool.io";

        // POST Pools
        /// <summary>
        /// POST pools API base URL
        /// </summary>
        public const string PostPoolBaseUrl = "https://api2.foxypool.io/api";
        /// <summary>
        /// POST pools API version
        /// </summary>
        public const string PostPoolApiVersion = "v2";
        // For rate limiting we are using half (or less) of the api server cache time
        // so we have a max lag of half the server cache time.
        /// <summary>
        /// POST pools configuration response cache seconds
        /// </summary>
        public const uint PostConfigResponseCacheSeconds = 300;
        /// <summary>
        /// POST pools response cache seconds
        /// </summary>
        public const uint PostPoolResponseCacheSeconds = 15;
        /// <summary>
        /// POST pools accounts response cache seconds
        /// </summary>
        public const uint PostAccountsResponseCacheSeconds = 30;
        /// <summary>
        /// POST pools account response cache seconds
        /// </summary>
        public const uint PostAccountResponseCacheSeconds = 8;
        /// <summary>
        /// POST pools rewards response cache seconds
        /// </summary>
        public const uint PostRewardsResponseCacheSeconds = 30;
        /// <summary>
        /// POST pools payouts response cache seconds
        /// </summary>
        public const uint PostPayoutsResponseCacheSeconds = 150;
        /// <summary>
        /// POST pools rates response cache seconds
        /// </summary>
        public const uint PostRatesResponseCacheSeconds = 150;
        /// <summary>
        /// POST pools account historical response cache seconds
        /// </summary>
        public const uint PostAccountHistoricalResponseCacheSeconds = 300;
        /// <summary>
        /// POST pools historical response cache seconds
        /// </summary>
        public const uint PostPoolHistoricalResponseCacheSeconds = 900;

        // POC Pools
        /// <summary>
        /// POC pools base URL
        /// </summary>
        public const string PocPoolBaseUrl = "https://api.foxypool.io/api";
        /// <summary>
        /// POC pools stats
        /// </summary>
        public const string PocPoolStats = "stats";
        /// <summary>
        /// POC pools configuration response cache seconds
        /// </summary>
        public const uint PocConfigResponseCacheSeconds = 300;
        /// <summary>
        /// POC pools response cache seconds
        /// </summary>
        public const uint PocPoolResponseCacheSeconds = 30;
        /// <summary>
        /// POC pools round response cache seconds
        /// </summary>
        public const uint PocRoundResponseCacheSeconds = 8;
        /// <summary>
        /// POC pools live response cache seconds
        /// </summary>
        public const uint PocLiveResponseCacheSeconds = 2;

        // POC socket.io
        /// <summary>
        /// POC pools socket io web UI URL
        /// </summary>
        public const string PocSocketIOWebUiUrl = "https://api.foxypool.io/web-ui";
        /// <summary>
        /// POC pools socket io mining URL
        /// </summary>
        public const string PocSocketIOMiningUrl = "http://miner.foxypool.io/mining";

        // Statuspage
        /// <summary>
        /// Pools statuspage root URL
        /// </summary>
        public const string PoolStatusRootUrl = "https://foxypool.statuspage.io";
        /// <summary>
        /// Pools statuspage API version
        /// </summary>
        public const string PoolStatusApiVersion = "v2";
        /// <summary>
        /// Pools statuspage response cache seconds
        /// </summary>
        public const uint PoolStatusResponseCacheSeconds = 90;
        /// <summary>
        /// Pools statuspage summary response cache seconds
        /// </summary>
        public const uint PoolSummaryResponseCacheSeconds = 60;
        /// <summary>
        /// Pools statuspage components response cache seconds
        /// </summary>
        public const uint PoolComponentsResponseCacheSeconds = 60;
        /// <summary>
        /// Pools statuspage incidents response cache seconds
        /// </summary>
        public const uint PoolIncidentsResponseCacheSeconds = 60;
        /// <summary>
        /// Pools statuspage scheduled maintenances response cache seconds
        /// </summary>
        public const uint PoolScheduledMaintenancesResponseCacheSeconds = 120;
    }
}
