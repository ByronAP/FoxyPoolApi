using FoxyPoolApi;

namespace FoxyPoolApiTests
{
    public static class EnvironmentConfig
    {
        public const string DEFAULT = "Update-With-Your-Own";

        // POST
        public const string PostLauncherId = "Update-With-Your-Own";
        /// <summary>
        /// The simplest way to retraeive your auth token is to open your browser dev tools
        /// ans look in the applications local storage for a key named "authToken"
        /// </summary>
        public const string PostAuthToken = "Update-With-Your-Own";
        public const PostPool PostSelectedPool = PostPool.Chia_OG;

        // POC
        public const PocPool PocSelectedPool = PocPool.BHD;
    }
}
