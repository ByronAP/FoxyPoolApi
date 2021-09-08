/*
 * TODO: The way the result waits are done is terrible, fix this junk
 */
using FoxyPoolApi;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace FoxyPoolApiTests
{
    public class PocSocketIOWebUITests
    {
        private readonly PocSocketIOApiClient _apiWebUIClient;
        private readonly PocSocketIOApiClient _apiMiningClient;

        public PocSocketIOWebUITests()
        {
            _apiWebUIClient = new PocSocketIOApiClient(SocketIOApi.Web_UI);
            _apiMiningClient = new PocSocketIOApiClient(SocketIOApi.Mining);
        }

        [Fact]
        public async Task WebUiConnectTest()
        {
            if (_apiWebUIClient.IsConnected)
            {
                Assert.True(true);
                return;
            }

            await _apiWebUIClient.ConnectAsync();

            var checkConnectTask = CheckConnectAsync(_apiWebUIClient);
            var timeoutTask = Task.Delay(TimeSpan.FromSeconds(30));
            var taskIndex = Task.WaitAny(checkConnectTask, timeoutTask);

            Assert.Equal(0, taskIndex);

            // TODO: check connect and disconnect events
        }

        [Fact]
        public async Task MiningConnectTest()
        {
            if (_apiMiningClient.IsConnected)
            {
                Assert.True(true);
                return;
            }

            await _apiMiningClient.ConnectAsync();

            var checkConnectTask = CheckConnectAsync(_apiMiningClient);
            var timeoutTask = Task.Delay(TimeSpan.FromSeconds(30));
            var taskIndex = Task.WaitAny(checkConnectTask, timeoutTask);

            Assert.Equal(0, taskIndex);

            // TODO: check connect and disconnect events
        }

        internal async Task CheckConnectAsync(PocSocketIOApiClient client)
        {
            do
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            } while (!client.IsConnected);
        }

        [Fact]
        public async Task StatsLiveTest()
        {
            if (!_apiWebUIClient.IsConnected)
            {
                await _apiWebUIClient.ConnectAsync();

                var checkConnectTask = CheckConnectAsync(_apiWebUIClient);
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(30));
                var taskIndex = Task.WaitAny(checkConnectTask, timeoutTask);

                Assert.Equal(0, taskIndex);
            }

            bool responseReceived = false;

            _apiWebUIClient.On_SocketIO_Stats_Live += (pool, data) =>
            {
                Assert.NotNull(data);
                responseReceived = true;
            };

            await _apiWebUIClient.SubscribeAsync(PocPool.BHD, PocPool.SIGNA);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            do
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            } while (!responseReceived && stopwatch.Elapsed.TotalSeconds < 22);
            stopwatch.Stop();

            Assert.True(responseReceived);
        }

        [Fact]
        public async Task StatsRoundTest()
        {
            if (!_apiWebUIClient.IsConnected)
            {
                await _apiWebUIClient.ConnectAsync();

                var checkConnectTask = CheckConnectAsync(_apiWebUIClient);
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(30));
                var taskIndex = Task.WaitAny(checkConnectTask, timeoutTask);

                Assert.Equal(0, taskIndex);
            }

            bool responseReceived = false;

            _apiWebUIClient.On_SocketIO_Stats_Round += (pool, data) =>
            {
                Assert.NotNull(data);
                responseReceived = true;
            };

            await _apiWebUIClient.SubscribeAsync(PocPool.BHD, PocPool.SIGNA);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            do
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            } while (!responseReceived && stopwatch.Elapsed.TotalSeconds < 22);
            stopwatch.Stop();

            Assert.True(responseReceived);
        }

        [Fact]
        public async Task GetMiningInfoTest()
        {
            if (!_apiMiningClient.IsConnected)
            {
                await _apiMiningClient.ConnectAsync();

                var checkConnectTask = CheckConnectAsync(_apiMiningClient);
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(30));
                var taskIndex = Task.WaitAny(checkConnectTask, timeoutTask);

                Assert.Equal(0, taskIndex);
            }

            var miningInfo = await _apiMiningClient.GetMiningInfoAsync(PocPool.BHD);

            Assert.NotNull(miningInfo);

            Assert.InRange(miningInfo.BaseTarget, 1L, 1000000L);

        }
    }
}
