// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-11-2021
// ***********************************************************************
// <copyright file="PoolStatusApiClient.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using FoxyPoolApi.Responses;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Text;
using System.Threading.Tasks;

namespace FoxyPoolApi
{
    /// <summary>
    /// Class PoolStatusApiClient.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class PoolStatusApiClient : IDisposable
    {
        /// <summary>
        /// The rest client
        /// </summary>
        private readonly RestClient _restClient;
        /// <summary>
        /// The memory cache
        /// </summary>
        private readonly IMemoryCache _memCache;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<PoolStatusApiClient>? _logger;
        /// <summary>
        /// The disposed value
        /// </summary>
        private bool _disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="PoolStatusApiClient"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public PoolStatusApiClient(ILogger<PoolStatusApiClient> logger)
        {
            _logger = logger;

            _memCache = BuildNewMemoryCacheInstance();

            _restClient = BuildNewRestClient();

            _logger.LogDebug("Created new FoxyPool Status API instance");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PoolStatusApiClient"/> class.
        /// </summary>
        public PoolStatusApiClient()
        {
            _logger = null;

            _memCache = BuildNewMemoryCacheInstance();
            _restClient = BuildNewRestClient();

#if DEBUG
            Console.WriteLine($"{DateTime.UtcNow}: Created new FoxyPool Status API instance.");
#endif
        }

        /// <summary>
        /// Builds the new memory cache instance.
        /// </summary>
        /// <returns>IMemoryCache.</returns>
        private static IMemoryCache BuildNewMemoryCacheInstance()
        {
            var memCacheOptions = new MemoryCacheOptions
            {
                ExpirationScanFrequency = TimeSpan.FromSeconds(2)
            };

            return new MemoryCache(memCacheOptions);
        }

        /// <summary>
        /// Builds the new rest client.
        /// </summary>
        /// <returns>RestClient.</returns>
        private RestClient BuildNewRestClient()
        {
            return new RestClient($"{Constants.PoolStatusRootUrl}/api/{Constants.PoolStatusApiVersion}");
        }

        /// <summary>
        /// Gets the status asynchronous.
        /// </summary>
        /// <returns>Task&lt;PoolStatusResponse&gt;.</returns>
        public Task<PoolStatusResponse> GetStatusAsync()
        {
            return GetTAsync<PoolStatusResponse>(StatusEndpoint.Status, Constants.PoolStatusResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the summary asynchronous.
        /// </summary>
        /// <returns>Task&lt;PoolSummaryResponse&gt;.</returns>
        public Task<PoolSummaryResponse> GetSummaryAsync()
        {
            return GetTAsync<PoolSummaryResponse>(StatusEndpoint.Summary, Constants.PoolSummaryResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the components asynchronous.
        /// </summary>
        /// <returns>Task&lt;PoolComponentsResponse&gt;.</returns>
        public Task<PoolComponentsResponse> GetComponentsAsync()
        {
            return GetTAsync<PoolComponentsResponse>(StatusEndpoint.Components, Constants.PoolComponentsResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the incidents asynchronous.
        /// </summary>
        /// <returns>Task&lt;PoolIncidentsResponse&gt;.</returns>
        public Task<PoolIncidentsResponse> GetIncidentsAsync()
        {
            return GetTAsync<PoolIncidentsResponse>(StatusEndpoint.Incidents, Constants.PoolIncidentsResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the incidents unresolved asynchronous.
        /// </summary>
        /// <returns>Task&lt;PoolIncidentsResponse&gt;.</returns>
        public Task<PoolIncidentsResponse> GetIncidentsUnresolvedAsync()
        {
            return GetTAsync<PoolIncidentsResponse>(StatusEndpoint.Incidents_Unresolved, Constants.PoolIncidentsResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the scheduled maintenances asynchronous.
        /// </summary>
        /// <returns>Task&lt;PoolScheduledMaintenanceResponse&gt;.</returns>
        public Task<PoolScheduledMaintenanceResponse> GetScheduledMaintenancesAsync()
        {
            return GetTAsync<PoolScheduledMaintenanceResponse>(StatusEndpoint.Scheduled_Maintenances, Constants.PoolScheduledMaintenancesResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the scheduled maintenances upcoming asynchronous.
        /// </summary>
        /// <returns>Task&lt;PoolScheduledMaintenanceResponse&gt;.</returns>
        public Task<PoolScheduledMaintenanceResponse> GetScheduledMaintenancesUpcomingAsync()
        {
            return GetTAsync<PoolScheduledMaintenanceResponse>(StatusEndpoint.Scheduled_Maintenances_Upcoming, Constants.PoolScheduledMaintenancesResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the scheduled maintenances active asynchronous.
        /// </summary>
        /// <returns>Task&lt;PoolScheduledMaintenanceResponse&gt;.</returns>
        public Task<PoolScheduledMaintenanceResponse> GetScheduledMaintenancesActiveAsync()
        {
            return GetTAsync<PoolScheduledMaintenanceResponse>(StatusEndpoint.Scheduled_Maintenances_Active, Constants.PoolScheduledMaintenancesResponseCacheSeconds);
        }

        /// <summary>
        /// Get t as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="cacheSeconds">The cache seconds.</param>
        /// <param name="segments">The segments.</param>
        /// <returns>A Task&lt;T&gt; representing the asynchronous operation.</returns>
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

        /// <summary>
        /// Gets the response asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="segments">The segments.</param>
        /// <returns>Task&lt;T&gt;.</returns>
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

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
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

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
