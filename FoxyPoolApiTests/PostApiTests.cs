using FoxyPoolApi;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FoxyPoolApiTests
{
    public class PostApiTests
    {
        private readonly PostApiClient _apiClient;

        public PostApiTests()
        {
            _apiClient = new PostApiClient(EnvironmentConfig.PostSelectedPool);
        }

        [Fact]
        public async Task AccountTest()
        {
            if(EnvironmentConfig.PostLauncherId.Equals(EnvironmentConfig.DEFAULT))
            {
                // test can not be run wiothout a valid config value
                throw new Exception("Environment config not set.");
            }

            var account = await _apiClient.GetAccountAsync(EnvironmentConfig.PostLauncherId);

            Assert.NotNull(account);

            Assert.Equal(account.PoolPublicKey, EnvironmentConfig.PostLauncherId);
        }

        [Fact]
        public async Task AccountsTest()
        {
            var accounts = await _apiClient.GetAccountsAsync();

            Assert.NotNull(accounts);

            Assert.InRange<uint>(accounts.AccountsWithShares, 1, 50000);

            Assert.NotEmpty(accounts.TopAccounts);
        }

        [Fact]
        public async Task ConfigTestTest()
        {
            var config = await _apiClient.GetConfigAsync();

            Assert.NotNull(config);

            Assert.True(config.BlockRewardDistributionDelay == 100);
        }

        [Fact]
        public async Task PayoutsTest()
        {
            var payouts = await _apiClient.GetPayoutsAsync();

            Assert.NotNull(payouts);

            Assert.NotEmpty(payouts);

            Assert.NotEmpty(payouts[0].Transactions);
        }

        [Fact]
        public async Task PoolTest()
        {
            var pool = await _apiClient.GetPoolAsync();

            Assert.NotNull(pool);

            Assert.InRange<ulong>(pool.Height, 1, 9111000);

            Assert.InRange<uint>(pool.Difficulty, 1, 918240);
        }

        [Fact]
        public async Task RatesTest()
        {
            var rates = await _apiClient.GetRatesAsync();

            Assert.NotNull(rates);

            Assert.NotEmpty(rates.Rates);

            Assert.NotEmpty(rates.Currencies);
        }

        [Fact]
        public async Task RewardsTest()
        {
            var rewards = await _apiClient.GetRewardsAsync();

            Assert.NotNull(rewards);

            Assert.NotEmpty(rewards.RecentlyWonBlocks);

            Assert.True(rewards.DailyRewardPerPiB > 0);
        }

        [Fact]
        public async Task PoolHistoricalTest()
        {
            var historical = await _apiClient.GetPoolHistoricalAsync();

            Assert.NotNull(historical);

            Assert.True(historical.Count > 1);
        }
    }
}
