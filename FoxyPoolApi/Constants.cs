namespace FoxyPoolApi
{
    public static class Constants
    {
        public const string PoolDisplayName = "Foxy Pool";
        public const string PoolHomeUrl = "https://foxypool.io";
        public const string PoolBaseUrl = "https://api2.foxypool.io/api";
        public const string PoolApiVersion = "v2";
        // For rate limiting we are using half of the api server cache time
        // so we have a max lag of half the server cache time.
        public const uint ConfigResponseCacheSeconds = 300;
        public const uint PoolResponseCacheSeconds = 15;
        public const uint AccountsResponseCacheSeconds = 30;
        public const uint AccountResponseCacheSeconds = 8;
        public const uint RewardsResponseCacheSeconds = 30;
        public const uint PayoutsResponseCacheSeconds = 150;
        public const uint RatesResponseCacheSeconds = 150;
    }
}
