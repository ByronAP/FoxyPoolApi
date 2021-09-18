using FoxyPoolApi;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FoxyPoolApiTests
{
    public class PostUnofficialApiTests
    {
        private readonly PostApiClient _apiClient;

        public PostUnofficialApiTests()
        {
            _apiClient = new PostApiClient(EnvironmentConfig.PostSelectedPool);
        }

        [Fact]
        public async Task UpdateAccountNameTest()
        {
            if (EnvironmentConfig.PostLauncherId.Equals(EnvironmentConfig.DEFAULT) ||
                EnvironmentConfig.PostAuthToken.Equals(EnvironmentConfig.DEFAULT))
            {
                // test can not be run wiothout a valid config value
                throw new Exception("Environment config not set.");
            }

            string newName = $"ByronAP 🦊 {new Random().Next()}";
            var updateResult = await _apiClient.UpdateAccountNameAsync(newName, EnvironmentConfig.PostLauncherId, EnvironmentConfig.PostAuthToken);

            Assert.NotNull(updateResult);

            Assert.True(updateResult.IsSuccessful);

            // ensure the local and server caches have timed out
            await Task.Delay(TimeSpan.FromSeconds(Constants.PostAccountResponseCacheSeconds * 2));

            var accountInfo = await _apiClient.GetAccountAsync(EnvironmentConfig.PostLauncherId);

            Assert.Equal(accountInfo.Name, newName);
        }

        [Fact]
        public async Task UpdateAccountMinPayoutAmountTest()
        {
            if (EnvironmentConfig.PostLauncherId.Equals(EnvironmentConfig.DEFAULT) ||
                EnvironmentConfig.PostAuthToken.Equals(EnvironmentConfig.DEFAULT))
            {
                // test can not be run wiothout a valid config value
                throw new Exception("Environment config not set.");
            }

            decimal newMinPayoutAmount = Convert.ToDecimal(0.01 + new Random().NextDouble());

            var updateResult = await _apiClient.UpdateAccountMinPayoutAmountAsync(newMinPayoutAmount, EnvironmentConfig.PostLauncherId, EnvironmentConfig.PostAuthToken);

            Assert.NotNull(updateResult);

            Assert.True(updateResult.IsSuccessful);

            // ensure the local and server caches have timed out
            await Task.Delay(TimeSpan.FromSeconds(Constants.PostAccountResponseCacheSeconds * 2));

            var accountInfo = await _apiClient.GetAccountAsync(EnvironmentConfig.PostLauncherId);

            Assert.Equal(accountInfo.MinimumPayout, newMinPayoutAmount);
        }

        [Fact]
        public async Task GetAccountHistoricalTest()
        {
            if (EnvironmentConfig.PostLauncherId.Equals(EnvironmentConfig.DEFAULT))
            {
                // test can not be run wiothout a valid config value
                throw new Exception("Environment config not set.");
            }

            var historicalResult = await _apiClient.GetAccountHistorical(EnvironmentConfig.PostLauncherId);

            Assert.NotNull(historicalResult);

            Assert.NotEmpty(historicalResult);
        }

        //TODO: add tests for other unofficial/undocumented methods
    }
}
