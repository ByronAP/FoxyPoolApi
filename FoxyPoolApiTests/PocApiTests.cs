using FoxyPoolApi;
using System.Threading.Tasks;
using Xunit;

namespace FoxyPoolApiTests
{
    public class PocApiTests
    {
        private readonly PocApiClient _apiClient;

        public PocApiTests()
        {
            _apiClient = new PocApiClient(EnvironmentConfig.PocSelectedPool);
        }

        [Fact]
        public async Task ConfigTestTest()
        {
            var config = await _apiClient.GetConfigAsync();

            Assert.NotNull(config);

            Assert.True(config.BlockRewardDistributionDelay == 101);
        }

        [Fact]
        public async Task PoolTest()
        {
            var pool = await _apiClient.GetPoolAsync();

            Assert.NotNull(pool);

            Assert.NotEmpty(pool.Accounts);
        }

        [Fact]
        public async Task RoundTest()
        {
            var round = await _apiClient.GetRoundAsync();

            Assert.NotNull(round);

            Assert.True(round.BestDeadline > 0);
        }

        [Fact]
        public async Task LiveTest()
        {
            var live = await _apiClient.GetLiveAsync();

            Assert.NotNull(live);

            Assert.NotEmpty(live.CurrentSubmissions);
        }
    }
}
