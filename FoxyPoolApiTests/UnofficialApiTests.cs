using FoxyPoolApi;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FoxyPoolApiTests
{
    public class UnofficialApiTests
    {
        private readonly FoxyPoolApiClient _apiClient;

        public UnofficialApiTests()
        {
            _apiClient = new FoxyPoolApiClient(EnvironmentConfig.SelectedPool);
        }

        [Fact]
        public async Task UpdateAccountNameTest()
        {
            string newName = $"ByronAP 🦊 {new Random().Next()}";
            var updateResult = await _apiClient.UpdateAccountNameAsync(newName, EnvironmentConfig.LauncherId, EnvironmentConfig.AuthToken);

            Assert.NotNull(updateResult);

            Assert.True(updateResult.IsSuccessful);

            // ensure the local and server caches have timed out
            await Task.Delay(TimeSpan.FromSeconds(Constants.AccountResponseCacheSeconds * 2));

            var accountInfo = await _apiClient.GetAccountAsync(EnvironmentConfig.LauncherId);

            Assert.Equal(accountInfo.Name, newName);
        }

        [Fact]
        public async Task UpdateAccountMinPayoutAmountTest()
        {
            decimal newMinPayoutAmount = Convert.ToDecimal(0.01 + new Random().NextDouble());

            var updateResult = await _apiClient.UpdateAccountMinPayoutAmountAsync(newMinPayoutAmount, EnvironmentConfig.LauncherId, EnvironmentConfig.AuthToken);

            Assert.NotNull(updateResult);

            Assert.True(updateResult.IsSuccessful);

            // ensure the local and server caches have timed out
            await Task.Delay(TimeSpan.FromSeconds(Constants.AccountResponseCacheSeconds * 2));

            var accountInfo = await _apiClient.GetAccountAsync(EnvironmentConfig.LauncherId);

            Assert.Equal(accountInfo.MinimumPayout, newMinPayoutAmount);
        }

        //TODO: add tests for other unofficial/undocumented methods
    }
}
