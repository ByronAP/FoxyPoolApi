using FoxyPoolApi;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FoxyPoolApiTests
{
    public class PocSocketIOWebUITests
    {
        private readonly PocSocketIOApiClient _apiClient;

        public PocSocketIOWebUITests()
        {
            _apiClient = new PocSocketIOApiClient(SocketIOApi.Web_UI);
        }

        [Fact]
        [TestPriority(0)]
        public async Task ConnectTest()
        {
            await _apiClient.ConnectAsync();

            var checkConnectTask = CheckConnectAsync();
            var timeoutTask = Task.Delay(TimeSpan.FromSeconds(30));
            var taskIndex = Task.WaitAny(checkConnectTask, timeoutTask);
            
            Assert.Equal(0, taskIndex);
        }

        internal async Task CheckConnectAsync()
        {
            do
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            } while (!_apiClient.IsConnected);
        }
    }
}
