// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-04-2021
//
// Last Modified By : bapen
// Last Modified On : 10-01-2021
// ***********************************************************************
// <copyright file="PostApiClient.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using FoxyPoolApi.Responses;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoxyPoolApi
{
    /// <summary>
    /// Class PostApiClient.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class PostApiClient : IDisposable
    {
        /// <summary>
        /// Gets the pool.
        /// </summary>
        /// <value>The pool.</value>
        public PostPool Pool { get; }

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
        private readonly ILogger<PostApiClient>? _logger;
        /// <summary>
        /// The disposed value
        /// </summary>
        private bool _disposedValue;


        /// <summary>
        /// Initializes a new instance of the <see cref="PostApiClient"/> class.
        /// </summary>
        /// <param name="pool">The pool.</param>
        /// <param name="logger">The logger.</param>
        public PostApiClient(PostPool pool, ILogger<PostApiClient> logger)
        {
            Pool = pool;
            _logger = logger;

            _memCache = BuildNewMemoryCacheInstance();

            _restClient = BuildNewRestClient();

            _logger.LogDebug("Created new FoxyPool POST API instance");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostApiClient"/> class.
        /// </summary>
        /// <param name="pool">The pool.</param>
        public PostApiClient(PostPool pool)
        {
            Pool = pool;
            _logger = null;

            _memCache = BuildNewMemoryCacheInstance();
            _restClient = BuildNewRestClient();

#if DEBUG
            Console.WriteLine($"{DateTime.UtcNow}: Created new FoxyPool POST API instance.");
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
            return new RestClient($"{Constants.PostPoolBaseUrl}/{Constants.PostPoolApiVersion}/{Pool.ToString().Replace("_", "-").ToLowerInvariant()}");
        }

        /// <summary>
        /// Gets the configuration asynchronous.
        /// </summary>
        /// <returns>Task&lt;PostConfigResponse&gt;.</returns>
        public Task<PostConfigResponse> GetConfigAsync()
        {
            return GetTAsync<PostConfigResponse>(Endpoint.Config, Constants.PostConfigResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the pool asynchronous.
        /// </summary>
        /// <returns>Task&lt;PostPoolResponse&gt;.</returns>
        public Task<PostPoolResponse> GetPoolAsync()
        {
            return GetTAsync<PostPoolResponse>(Endpoint.Pool, Constants.PostPoolResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the accounts asynchronous.
        /// </summary>
        /// <returns>Task&lt;PostAccountsResponse&gt;.</returns>
        public Task<PostAccountsResponse> GetAccountsAsync()
        {
            return GetTAsync<PostAccountsResponse>(Endpoint.Accounts, Constants.PostAccountsResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the rewards asynchronous.
        /// </summary>
        /// <returns>Task&lt;PostRewardsResponse&gt;.</returns>
        public Task<PostRewardsResponse> GetRewardsAsync()
        {
            return GetTAsync<PostRewardsResponse>(Endpoint.Rewards, Constants.PostRewardsResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the payouts asynchronous.
        /// </summary>
        /// <returns>Task&lt;List&lt;PostPayoutsResponse&gt;&gt;.</returns>
        public Task<List<PostPayoutsResponse>> GetPayoutsAsync()
        {
            return GetTAsync<List<PostPayoutsResponse>>(Endpoint.Payouts, Constants.PostPayoutsResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the rates asynchronous.
        /// </summary>
        /// <returns>Task&lt;PostRatesResponse&gt;.</returns>
        public Task<PostRatesResponse> GetRatesAsync()
        {
            return GetTAsync<PostRatesResponse>(Endpoint.Rates, Constants.PostRatesResponseCacheSeconds);
        }

        /// <summary>
        /// Gets the account asynchronous.
        /// </summary>
        /// <param name="launcherId">The launcher identifier.</param>
        /// <returns>Task&lt;PostAccountResponse&gt;.</returns>
        public Task<PostAccountResponse> GetAccountAsync(string launcherId)
        {
            return GetTAsync<PostAccountResponse>(Endpoint.Account, Constants.PostAccountResponseCacheSeconds, launcherId);
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

        #region UDOCUMENTED METHODS

        /// <summary>
        /// Updates the account name asynchronous.
        /// </summary>
        /// <param name="newName">The new name.</param>
        /// <param name="launcherId">The launcher identifier.</param>
        /// <param name="authToken">The authentication token.</param>
        /// <returns>Task&lt;IRestResponse&gt;.</returns>
        public Task<IRestResponse> UpdateAccountNameAsync(string newName, string launcherId, string authToken)
        {
            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = $"{{\"newName\":\"{newName}\"}}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "name");
        }

        /// <summary>
        /// Updates the account minimum payout amount asynchronous.
        /// </summary>
        /// <param name="newMinPayoutAmount">The new minimum payout amount.</param>
        /// <param name="launcherId">The launcher identifier.</param>
        /// <param name="authToken">The authentication token.</param>
        /// <returns>Task&lt;IRestResponse&gt;.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">newMinPayoutAmount - new Exception("Minimum payout amount must be 0.001 or greater")</exception>
        /// <exception cref="System.Exception">Minimum payout amount must be 0.001 or greater</exception>
        public Task<IRestResponse> UpdateAccountMinPayoutAmountAsync(decimal newMinPayoutAmount, string launcherId, string authToken)
        {
            if (newMinPayoutAmount < 0.01m)
                throw new ArgumentOutOfRangeException(nameof(newMinPayoutAmount), new Exception("Minimum payout amount must be 0.001 or greater"));

            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = $"{{\"minimumPayout\":\"{newMinPayoutAmount}\"}}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "minimum-payout");
        }

        /// <summary>
        /// Updates the account distribution ratio amount asynchronous.
        /// </summary>
        /// <param name="newDistributionRatio">The new distribution ratio.</param>
        /// <param name="launcherId">The launcher identifier.</param>
        /// <param name="authToken">The authentication token.</param>
        /// <returns>Task&lt;IRestResponse&gt;.</returns>
        public Task<IRestResponse> UpdateAccountDistributionRatioAmountAsync(string newDistributionRatio, string launcherId, string authToken)
        {
            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = $"{{\"newDistributionRatio\":\"{newDistributionRatio}\"}}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "distribution-ratio");
        }

        /// <summary>
        /// Updates the account leave pool asynchronous.
        /// </summary>
        /// <param name="leaveForever">if set to <c>true</c> [leave forever].</param>
        /// <param name="launcherId">The launcher identifier.</param>
        /// <param name="authToken">The authentication token.</param>
        /// <returns>Task&lt;IRestResponse&gt;.</returns>
        public Task<IRestResponse> UpdateAccountLeavePoolAsync(bool leaveForever, string launcherId, string authToken)
        {
            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = $"{{\"leaveForEver\":{leaveForever.ToString().ToLowerInvariant()}}}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "leave-pool");
        }

        /// <summary>
        /// Updates the account rejoin pool asynchronous.
        /// </summary>
        /// <param name="launcherId">The launcher identifier.</param>
        /// <param name="authToken">The authentication token.</param>
        /// <returns>Task&lt;IRestResponse&gt;.</returns>
        public Task<IRestResponse> UpdateAccountRejoinPoolAsync(string launcherId, string authToken)
        {
            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = "{}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "rejoin-pool");
        }

        /// <summary>
        /// Gets the account historical asynchronous.
        /// </summary>
        /// <param name="launcherId">The launcher identifier.</param>
        /// <returns>Task&lt;List&lt;PostAccountHistoricalItem&gt;&gt;.</returns>
        public Task<List<PostAccountHistoricalItem>> GetAccountHistoricalAsync(string launcherId)
        {
            return GetTAsync<List<PostAccountHistoricalItem>>(Endpoint.Account, Constants.PostAccountHistoricalResponseCacheSeconds, launcherId, "historical");
        }

        /// <summary>
        /// Gets the pool historical asynchronous.
        /// </summary>
        /// <returns>Task&lt;List&lt;PostPoolHistoricalItem&gt;&gt;.</returns>
        public Task<List<PostPoolHistoricalItem>> GetPoolHistoricalAsync()
        {
            return GetTAsync<List<PostPoolHistoricalItem>>(Endpoint.Pool, Constants.PostPoolHistoricalResponseCacheSeconds, "historical");
        }

        /// <summary>
        /// Posts the asynchronous.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="body">The body.</param>
        /// <param name="segments">The segments.</param>
        /// <returns>Task&lt;IRestResponse&gt;.</returns>
        private Task<IRestResponse> PostAsync(Endpoint endpoint, KeyValuePair<string, string>[] headers, string body, params string[] segments)
        {
            var url = endpoint.ToString().ToLowerInvariant();
            switch (segments.Length)
            {
                case 0:
                    break;
                case 1:
                    url += segments[0];
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

            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddHeaders(headers);
            request.AddJsonBody(body);

            return _restClient.ExecuteAsync(request);
        }
        #endregion

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
