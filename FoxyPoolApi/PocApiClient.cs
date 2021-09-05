using FoxyPoolApi.Responses;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Text;
using System.Threading.Tasks;

namespace FoxyPoolApi
{
    public class PocApiClient : IDisposable
    {
        public PocPool Pool { get; }

        private readonly RestClient _restClient;
        private readonly IMemoryCache _memCache;
        private readonly ILogger<PocApiClient>? _logger;
        private bool _disposedValue;


        public PocApiClient(PocPool pool, ILogger<PocApiClient> logger)
        {
            Pool = pool;
            _logger = logger;

            _memCache = BuildNewMemoryCacheInstance();

            _restClient = BuildNewRestClient();

            _logger.LogDebug("Created new FoxyPool POC API instance");
        }

        public PocApiClient(PocPool pool)
        {
            Pool = pool;
            _logger = null;

            _memCache = BuildNewMemoryCacheInstance();
            _restClient = BuildNewRestClient();

#if DEBUG
            Console.WriteLine($"{DateTime.UtcNow}: Created new FoxyPool POC API instance.");
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
            return new RestClient($"{Constants.PocPoolBaseUrl}/{Constants.PocPoolStats}/{Pool.ToString().ToLowerInvariant()}");
        }

        public Task<PocConfigResponse> GetConfigAsync()
        {
            return GetTAsync<PocConfigResponse>(Endpoint.Config, Constants.PocConfigResponseCacheSeconds);
        }

        public Task<PocPoolResponse> GetPoolAsync()
        {
            return GetTAsync<PocPoolResponse>(Endpoint.Pool, Constants.PocPoolResponseCacheSeconds);
        }

        public Task<PocRoundResponse> GetRoundAsync()
        {
            return GetTAsync<PocRoundResponse>(Endpoint.Round, Constants.PocRoundResponseCacheSeconds);
        }

        public Task<PocLiveResponse> GetLiveAsync()
        {
            return GetTAsync<PocLiveResponse>(Endpoint.Live, Constants.PocLiveResponseCacheSeconds);
        }

        private async Task<T> GetTAsync<T>(Endpoint endpoint, uint cacheSeconds, params string[] segments)
        {
            var cacheKey = $"{Pool}-{endpoint}";
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

        private Task<T> GetResponseAsync<T>(Endpoint endpoint, params string[] segments)
        {
            var url = endpoint.ToString().ToLowerInvariant();
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
