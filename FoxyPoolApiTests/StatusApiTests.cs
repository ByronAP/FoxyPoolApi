using FoxyPoolApi;
using System.Threading.Tasks;
using Xunit;

namespace FoxyPoolApiTests
{
    public class PoolStatusApiTests
    {
        private readonly PoolStatusApiClient _apiClient;

        public PoolStatusApiTests()
        {
            _apiClient = new PoolStatusApiClient();
        }

        [Fact]
        public async Task StatusTest()
        {
            var status = await _apiClient.GetStatusAsync();

            Assert.NotNull(status);

            Assert.IsType<IncidentImpact>(status.Status.Indicator);
        }
    }
}
