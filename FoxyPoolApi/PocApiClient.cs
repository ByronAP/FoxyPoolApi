// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-05-2021
// ***********************************************************************
// <copyright file="PocApiClient.cs" company="ByronAP">
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
    /// Class PocApiClient.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class PocApiClient : IDisposable
    {
        /// <summary>
        /// Gets the pool.
        /// </summary>
        /// <value>The pool.</value>
        public PocPool Pool { get; }

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
        private readonly ILogger<PocApiClient>? _logger;
        /// <summary>
        /// The disposed value
        /// </summary>
        private bool _disposedValue;


        /// <summary>
        /// Initializes a new instance of the <see cref="PocApiClient"/> class.
        /// </summary>
        /// <param name="pool">The pool.</param>
        /// <param name="logger">The logger.</param>
        public PocApiClient(PocPool pool, ILogger<PocApiClient> logger)
        {
            Pool = pool;
            _logger = logger;

            _memCache = BuildNewMemoryCacheInstance();

            _restClient = BuildNewRestClient();

            _logger.LogDebug("Created new FoxyPool POC API instance");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PocApiClient"/> class.
        /// </summary>
        /// <param name="pool">The pool.</param>
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
            return new RestClient($"{Constants.PocPoolBaseUrl}/{Constants.PocPoolStats}/{Pool.ToString().ToLowerInvariant()}");
        }

        /// <summary>
        /// Gets the configuration asynchronous.
        /// </summary>
        /// <returns>Task&lt;PocConfigResponse&gt;.</returns>
        public Task<PocConfigResponse> GetConfigAsync()
        {
            return GetTAsync<PocConfigResponse>(Endpoint.Config, Constants.PocConfigResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the pool asynchronous.
        /// </summary>
        /// <returns>Task&lt;PocPoolResponse&gt;.</returns>
        public Task<PocPoolResponse> GetPoolAsync()
        {
            return GetTAsync<PocPoolResponse>(Endpoint.Pool, Constants.PocPoolResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the round asynchronous.
        /// </summary>
        /// <returns>Task&lt;PocRoundResponse&gt;.</returns>
        public Task<PocRoundResponse> GetRoundAsync()
        {
            return GetTAsync<PocRoundResponse>(Endpoint.Round, Constants.PocRoundResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the live asynchronous.
        /// </summary>
        /// <returns>Task&lt;PocLiveResponse&gt;.</returns>
        public Task<PocLiveResponse> GetLiveAsync()
        {
            return GetTAsync<PocLiveResponse>(Endpoint.Live, Constants.PocLiveResponseCacheSeconds);
        }

        /// <summary>
        /// Get t as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="cacheSeconds">The cache seconds.</param>
        /// <param name="segments">The segments.</param>
        /// <returns>A Task&lt;T&gt; representing the asynchronous operation.</returns>
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

        /// <summary>
        /// Gets the response asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="segments">The segments.</param>
        /// <returns>Task&lt;T&gt;.</returns>
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
