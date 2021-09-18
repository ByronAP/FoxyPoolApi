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
    public class PostApiClient : IDisposable
    {
        public PostPool Pool { get; }

        private readonly RestClient _restClient;
        private readonly IMemoryCache _memCache;
        private readonly ILogger<PostApiClient>? _logger;
        private bool _disposedValue;


        public PostApiClient(PostPool pool, ILogger<PostApiClient> logger)
        {
            Pool = pool;
            _logger = logger;

            _memCache = BuildNewMemoryCacheInstance();

            _restClient = BuildNewRestClient();

            _logger.LogDebug("Created new FoxyPool POST API instance");
        }

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
            return new RestClient($"{Constants.PostPoolBaseUrl}/{Constants.PostPoolApiVersion}/{Pool.ToString().Replace("_", "-").ToLowerInvariant()}");
        }

        public Task<PostConfigResponse> GetConfigAsync()
        {
            return GetTAsync<PostConfigResponse>(Endpoint.Config, Constants.PostConfigResponseCacheSeconds);
        }

        public Task<PostPoolResponse> GetPoolAsync()
        {
            return GetTAsync<PostPoolResponse>(Endpoint.Pool, Constants.PostPoolResponseCacheSeconds);
        }

        public Task<PostAccountsResponse> GetAccountsAsync()
        {
            return GetTAsync<PostAccountsResponse>(Endpoint.Accounts, Constants.PostAccountsResponseCacheSeconds);
        }

        public Task<PostRewardsResponse> GetRewardsAsync()
        {
            return GetTAsync<PostRewardsResponse>(Endpoint.Rewards, Constants.PostRewardsResponseCacheSeconds);
        }

        public Task<List<PostPayoutsResponse>> GetPayoutsAsync()
        {
            return GetTAsync<List<PostPayoutsResponse>>(Endpoint.Payouts, Constants.PostPayoutsResponseCacheSeconds);
        }

        public Task<PostRatesResponse> GetRatesAsync()
        {
            return GetTAsync<PostRatesResponse>(Endpoint.Rates, Constants.PostRatesResponseCacheSeconds);
        }

        public Task<PostAccountResponse> GetAccountAsync(string launcherId)
        {
            return GetTAsync<PostAccountResponse>(Endpoint.Account, Constants.PostAccountResponseCacheSeconds, launcherId);
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

        #region UDOCUMENTED METHODS

        public Task<IRestResponse> UpdateAccountNameAsync(string newName, string launcherId, string authToken)
        {
            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = $"{{\"newName\":\"{newName}\"}}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "name");
        }

        public Task<IRestResponse> UpdateAccountMinPayoutAmountAsync(decimal newMinPayoutAmount, string launcherId, string authToken)
        {
            if (newMinPayoutAmount < 0.01m)
                throw new ArgumentOutOfRangeException(nameof(newMinPayoutAmount), new Exception("Minimum payout amount must be 0.001 or greater"));

            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = $"{{\"minimumPayout\":\"{newMinPayoutAmount}\"}}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "minimum-payout");
        }

        public Task<IRestResponse> UpdateAccountDistributionRatioAmountAsync(string newDistributionRatio, string launcherId, string authToken)
        {
            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = $"{{\"newDistributionRatio\":\"{newDistributionRatio}\"}}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "distribution-ratio");
        }

        public Task<IRestResponse> UpdateAccountLeavePoolAsync(bool leaveForever, string launcherId, string authToken)
        {
            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = $"{{\"leaveForEver\":{leaveForever.ToString().ToLowerInvariant()}}}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "leave-pool");
        }

        public Task<IRestResponse> UpdateAccountRejoinPoolAsync(string launcherId, string authToken)
        {
            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = "{}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "rejoin-pool");
        }

        public Task<List<PostAccountHistoricalItem>> GetAccountHistorical(string launcherId)
        {
            return GetTAsync<List<PostAccountHistoricalItem>>(Endpoint.Account, Constants.PostAccountHistoricalResponseCacheSeconds, launcherId, "historical");
        }

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
