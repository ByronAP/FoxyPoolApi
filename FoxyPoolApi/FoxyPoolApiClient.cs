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
    public class FoxyPoolApiClient : IDisposable
    {
        public Pools Pool { get; }
        public bool IgnoreCertErrors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private readonly RestClient _restClient;
        private readonly IMemoryCache _memCache;
        private readonly ILogger<FoxyPoolApiClient>? _logger;
        private bool _disposedValue;

        public FoxyPoolApiClient(Pools pool, IMemoryCache memCache, ILogger<FoxyPoolApiClient> logger)
        {
            Pool = pool;
            _logger = logger;
            _memCache = memCache;

            _restClient = new RestClient($"{Constants.PoolBaseUrl}/{Constants.PoolApiVersion}/{pool.ToString().Replace("_", "-").ToLowerInvariant()}");

            _logger.LogDebug("Created new FoxyPoolApi instance");
        }

        public FoxyPoolApiClient(Pools pool)
        {
            var memCacheOptions = new MemoryCacheOptions
            {
                ExpirationScanFrequency = TimeSpan.FromSeconds(2)
            };

            Pool = pool;
            _logger = null;

            _memCache = new MemoryCache(memCacheOptions);
            _restClient = new RestClient($"{Constants.PoolBaseUrl}/{Constants.PoolApiVersion}/{pool.ToString().Replace("_", "-").ToLowerInvariant()}");

#if DEBUG
            Console.WriteLine($"{DateTime.UtcNow}: Created new FoxyPoolApi instance.");
#endif
        }

        public Task<ConfigResponse> GetConfigAsync()
        {
            return GetTAsync<ConfigResponse>(Endpoint.Config, Constants.ConfigResponseCacheSeconds);
        }

        public Task<PoolResponse> GetPoolAsync()
        {
            return GetTAsync<PoolResponse>(Endpoint.Pool, Constants.PoolResponseCacheSeconds);
        }

        public Task<AccountsResponse> GetAccountsAsync()
        {
            return GetTAsync<AccountsResponse>(Endpoint.Accounts, Constants.AccountsResponseCacheSeconds);
        }

        public Task<RewardsResponse> GetRewardsAsync()
        {
            return GetTAsync<RewardsResponse>(Endpoint.Rewards, Constants.RewardsResponseCacheSeconds);
        }

        public Task<List<PayoutsResponse>> GetPayoutsAsync()
        {
            return GetTAsync<List<PayoutsResponse>>(Endpoint.Payouts, Constants.PayoutsResponseCacheSeconds);
        }

        public Task<RatesResponse> GetRatesAsync()
        {
            return GetTAsync<RatesResponse>(Endpoint.Rates, Constants.RatesResponseCacheSeconds);
        }

        public Task<AccountResponse> GetAccountAsync(string launcherId)
        {
            return GetTAsync<AccountResponse>(Endpoint.Account, Constants.AccountResponseCacheSeconds, launcherId);
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

        #region UNOFFICIAL METHODS

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Task<IRestResponse> UpdateAccountNameAsync(string newName, string launcherId, string authToken)
        {
            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = $"{{\"newName\":\"{newName}\"}}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "name");
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Task<IRestResponse> UpdateAccountMinPayoutAmountAsync(decimal newMinPayoutAmount, string launcherId, string authToken)
        {
            if (newMinPayoutAmount < 0.01m)
                throw new ArgumentOutOfRangeException(nameof(newMinPayoutAmount), new Exception("Minimum payout amount must be 0.001 or greater"));

            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = $"{{\"minimumPayout\":\"{newMinPayoutAmount}\"}}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "minimum-payout");
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Task<IRestResponse> UpdateAccountDistributionRatioAmountAsync(string newDistributionRatio, string launcherId, string authToken)
        {
            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = $"{{\"newDistributionRatio\":\"{newDistributionRatio}\"}}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "distribution-ratio");
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Task<IRestResponse> UpdateAccountLeavePoolAsync(bool leaveForever, string launcherId, string authToken)
        {
            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = $"{{\"leaveForEver\":{leaveForever.ToString().ToLowerInvariant()}}}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "leave-pool");
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Task<IRestResponse> UpdateAccountRejoinPoolAsync(string launcherId, string authToken)
        {
            var headers = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("Authorization", $"Bearer {authToken}") };
            // since this is so simple don't bother doing anything other than just manually building the json string
            var body = "{}";

            return PostAsync(Endpoint.Account, headers, body, launcherId, "rejoin-pool");
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
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
