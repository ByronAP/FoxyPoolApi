using FoxyPoolApi;

namespace FoxyPoolApiTests
{
    public static class EnvironmentConfig
    {
        public const string LauncherId = "Update-With-Your-Own";
        /// <summary>
        /// The simplest way to retraeive your auth token is to open your browser dev tools
        /// ans look in the applications local storage for a key named "authToken"
        /// </summary>
        public const string AuthToken = "Update-With-Your-Own";
        public const Pools SelectedPool = Pools.Chia_OG;
    }
}
