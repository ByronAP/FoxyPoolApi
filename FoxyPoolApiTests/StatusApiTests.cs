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

        [Fact]
        public async Task SummaryTest()
        {
            var summary = await _apiClient.GetSummaryAsync();

            Assert.NotNull(summary);

            Assert.IsType<IncidentImpact>(summary.Status.Indicator);
        }

        [Fact]
        public async Task ComponentsTest()
        {
            var components = await _apiClient.GetComponentsAsync();

            Assert.NotNull(components);

            Assert.NotEmpty(components.Components);
        }

        [Fact]
        public async Task IncidentsTest()
        {
            var incidents = await _apiClient.GetIncidentsAsync();

            Assert.NotNull(incidents);

            Assert.NotEmpty(incidents.Incidents);
        }

        [Fact]
        public async Task UnresolvedIncidentsTest()
        {
            var incidents = await _apiClient.GetIncidentsUnresolvedAsync();

            Assert.NotNull(incidents);

            Assert.Equal("foxy-pool", incidents.Page.Name.ToLowerInvariant());
        }

        [Fact]
        public async Task ScheduledMaintenanceTest()
        {
            var maintenances = await _apiClient.GetScheduledMaintenancesAsync();

            Assert.NotNull(maintenances);

            Assert.Equal("foxy-pool", maintenances.Page.Name.ToLowerInvariant());
        }

        [Fact]
        public async Task ScheduledMaintenanceUpcomingTest()
        {
            var maintenances = await _apiClient.GetScheduledMaintenancesUpcomingAsync();

            Assert.NotNull(maintenances);

            Assert.Equal("foxy-pool", maintenances.Page.Name.ToLowerInvariant());
        }

        [Fact]
        public async Task ScheduledMaintenanceActiveTest()
        {
            var maintenances = await _apiClient.GetScheduledMaintenancesActiveAsync();

            Assert.NotNull(maintenances);

            Assert.Equal("foxy-pool", maintenances.Page.Name.ToLowerInvariant());
        }
    }
}
