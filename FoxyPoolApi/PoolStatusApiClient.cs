using FoxyPoolApi.Responses;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Text;
using System.Threading.Tasks;

namespace FoxyPoolApi
{
    public class PoolStatusApiClient : IDisposable
    {
        private readonly RestClient _restClient;
        private readonly IMemoryCache _memCache;
        private readonly ILogger<PoolStatusApiClient>? _logger;
        private bool _disposedValue;

        public PoolStatusApiClient(ILogger<PoolStatusApiClient> logger)
        {
            _logger = logger;

            _memCache = BuildNewMemoryCacheInstance();

            _restClient = BuildNewRestClient();

            _logger.LogDebug("Created new FoxyPool Status API instance");
        }

        public PoolStatusApiClient()
        {
            _logger = null;

            _memCache = BuildNewMemoryCacheInstance();
            _restClient = BuildNewRestClient();

#if DEBUG
            Console.WriteLine($"{DateTime.UtcNow}: Created new FoxyPool Status API instance.");
#endif
        }

        private static IMemoryCache BuildNewMemoryCacheInstance()
        {
            var memCacheOptions = new MemoryCacheOptions
            {
                ExpirationScanFrequency = TimeSpan.FromSeconds(2)
            };

            return new MemoryCache(memCacheOptions);
        }

        private RestClient BuildNewRestClient()
        {
            return new RestClient($"{Constants.PoolStatusRootUrl}/api/{Constants.PoolStatusApiVersion}");
        }

        public Task<PoolStatusResponse> GetStatusAsync()
        {
            return GetTAsync<PoolStatusResponse>(StatusEndpoint.Status, 60);
        }

        public Task<PoolSummaryResponse> GetSummaryAsync()
        {
            return GetTAsync<PoolSummaryResponse>(StatusEndpoint.Summary, 60);
        }

        public Task<PoolComponentsResponse> GetComponentsAsync()
        {
            return GetTAsync<PoolComponentsResponse>(StatusEndpoint.Components, 60);
        }

        public Task<PoolIncidentsResponse> GetIncidentsAsync()
        {
            return GetTAsync<PoolIncidentsResponse>(StatusEndpoint.Incidents, 60);
        }

        public Task<PoolIncidentsResponse> GetIncidentsUnresolvedAsync()
        {
            return GetTAsync<PoolIncidentsResponse>(StatusEndpoint.Incidents_Unresolved, 60);
        }

        public Task<PoolScheduledMaintenanceResponse> GetScheduledMaintenancesAsync()
        {
            return GetTAsync<PoolScheduledMaintenanceResponse>(StatusEndpoint.Scheduled_Maintenances, 60);
        }

        public Task<PoolScheduledMaintenanceResponse> GetScheduledMaintenancesUpcomingAsync()
        {
            return GetTAsync<PoolScheduledMaintenanceResponse>(StatusEndpoint.Scheduled_Maintenances_Upcoming, 60);
        }

        public Task<PoolScheduledMaintenanceResponse> GetScheduledMaintenancesActiveAsync()
        {
            return GetTAsync<PoolScheduledMaintenanceResponse>(StatusEndpoint.Scheduled_Maintenances_Active, 60);
        }

        private async Task<T> GetTAsync<T>(StatusEndpoint endpoint, uint cacheSeconds, params string[] segments)
        {
            var cacheKey = $"status-{endpoint}";
            foreach (var segment in segments)
            {
                cacheKey += $"-{segment}";
            }

            if (_memCache.TryGetValue<T>(cacheKey, out var data))
            {
                _logger?.LogInformation("{Endpoint} returned from cache.", endpoint);
                return data;
            }
            else
            {
                try
                {
                    var apiResponse = await GetResponseAsync<T>(endpoint, segments);
                    var options = new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheSeconds)
                    };
                    _memCache.Set(cacheKey, apiResponse, options);

                    _logger?.LogInformation("{Endpoint} returned from API, set in cache.", endpoint);

                    return apiResponse;
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, "GetTAsync threw an exception.");
                    throw;
                }
            }
        }

        private Task<T> GetResponseAsync<T>(StatusEndpoint endpoint, params string[] segments)
        {
            var url = endpoint.ToString().ToLowerInvariant();
            switch (endpoint)
            {
                case StatusEndpoint.Incidents_Unresolved:
                    url = StatusEndpoint.Incidents.ToString().ToLowerInvariant() + "/unresolved";
                    break;
                case StatusEndpoint.Scheduled_Maintenances:
                    url = StatusEndpoint.Scheduled_Maintenances.ToString().ToLowerInvariant().Replace('_', '-');
                    break;
                case StatusEndpoint.Scheduled_Maintenances_Upcoming:
                    url = StatusEndpoint.Scheduled_Maintenances.ToString().ToLowerInvariant().Replace('_', '-') + "/upcoming";
                    break;
                case StatusEndpoint.Scheduled_Maintenances_Active:
                    url = StatusEndpoint.Scheduled_Maintenances.ToString().ToLowerInvariant().Replace('_', '-') + "/active";
                    break;
            }

            switch (segments.Length)
            {
                case 0:
                    break;
                case 1:
                    url += $"/{segments[0]}";
                    break;
                default:
                    var stringBuilder = new StringBuilder(url);

                    foreach (string segment in segments)
                    {
                        _ = stringBuilder.Append("/").Append(segment);
                    }

                    url = stringBuilder.ToString();
                    _ = stringBuilder.Clear();

                    break;
            }

            // append the file type
            url += ".json";

            var request = new RestRequest(url, DataFormat.Json);

            return _restClient.GetAsync<T>(request);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // cleanup the cache
                    try
                    {
                        _memCache.Dispose();
                    }
                    catch
                    {
                        // ignore
                    }
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
