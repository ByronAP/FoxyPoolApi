namespace FoxyPoolApi
{
    public static class Constants
    {
        // General Info
        public const string PoolDisplayName = "Foxy Pool";
        public const string PoolHomeUrl = "https://foxypool.io";

        // POST Pools
        public const string PostPoolBaseUrl = "https://api2.foxypool.io/api";
        public const string PostPoolApiVersion = "v2";
        // For rate limiting we are using half of the api server cache time
        // so we have a max lag of half the server cache time.
        public const uint PostConfigResponseCacheSeconds = 300;
        public const uint PostPoolResponseCacheSeconds = 15;
        public const uint PostAccountsResponseCacheSeconds = 30;
        public const uint PostAccountResponseCacheSeconds = 8;
        public const uint PostRewardsResponseCacheSeconds = 30;
        public const uint PostPayoutsResponseCacheSeconds = 150;
        public const uint PostRatesResponseCacheSeconds = 150;

        // POC Pools
        public const string PocPoolBaseUrl = "https://api.foxypool.io/api";
        public const string PocPoolStats = "stats";
        public const uint PocConfigResponseCacheSeconds = 300;
        public const uint PocPoolResponseCacheSeconds = 30;
        public const uint PocRoundResponseCacheSeconds = 8;
        public const uint PocLiveResponseCacheSeconds = 2;

        // POC socket.io
        public const string PocSocketIOWebUiUrl = "https://api.foxypool.io/web-ui";
        public const string PocSocketIOMiningUrl = "http://miner.foxypool.io/mining";
    }
}
