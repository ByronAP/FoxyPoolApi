using FoxyPoolApi;
using System;
using System.Threading.Tasks;

namespace FoxyPoolApiDemo
{
    public class Program
    {
        private static async Task Main()
        {
            //Pool Status
            Console.WriteLine($"Creating FoxyPool Status Api Client Instance.{Environment.NewLine}");
            using var apiStatusClient = new PoolStatusApiClient();

            Console.WriteLine("Requesting Pool Status.");
            var poolStatus = await apiStatusClient.GetStatusAsync();
            Console.WriteLine($"Received Pool Status for {poolStatus.Page.Name}.{Environment.NewLine}");

            await Task.Delay(500);

            Console.WriteLine("Requesting Pool Upcoming Maintenance.");
            var poolUpcomingMaintenance = await apiStatusClient.GetScheduledMaintenancesUpcomingAsync();
            Console.WriteLine($"Received Pool Upcoming Maintenance, {poolUpcomingMaintenance.ScheduledMaintenances.Count} events scheduled.{Environment.NewLine}");

            await Task.Delay(500);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("*************************************************************************************************");

            Console.WriteLine(Environment.NewLine);

            // POST
            Console.WriteLine($"Creating FoxyPool POST Api Client Instance.{Environment.NewLine}");
            using var apiPostClient = new PostApiClient(PostPool.Chia_OG);

            Console.WriteLine("Requesting Pool Config.");
            var postPoolConfig = await apiPostClient.GetConfigAsync();
            Console.WriteLine($"Received Pool Config for {postPoolConfig.PoolName}.{Environment.NewLine}");

            await Task.Delay(500);

            Console.WriteLine("Requesting Pool Info.");
            var postPoolInfo = await apiPostClient.GetPoolAsync();
            Console.WriteLine($"Received Pool Info, Pool has a balance of {postPoolInfo.Balance}.{Environment.NewLine}");

            await Task.Delay(500);

            Console.WriteLine("Requesting Accounts Info.");
            var postPoolAccounts = await apiPostClient.GetAccountsAsync();
            Console.WriteLine($"Received Accounts, Pool has {postPoolAccounts.AccountsWithShares} active accounts.{Environment.NewLine}");

            await Task.Delay(500);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("*************************************************************************************************");

            Console.WriteLine(Environment.NewLine);

            // POC
            Console.WriteLine($"Creating FoxyPool POC Api Client Instance.{Environment.NewLine}");
            using var apiPocClient = new PocApiClient(PocPool.BHD);

            Console.WriteLine("Requesting Pool Config.");
            var pocPoolConfig = await apiPocClient.GetConfigAsync();
            Console.WriteLine($"Received Pool Config for {pocPoolConfig.PoolName}.{Environment.NewLine}");

            await Task.Delay(500);

            Console.WriteLine("Requesting Pool Info.");
            var pocPoolInfo = await apiPocClient.GetPoolAsync();
            Console.WriteLine($"Received Pool Info, Pool has a balance of {pocPoolInfo.Balance}.{Environment.NewLine}");

            await Task.Delay(500);

            Console.WriteLine("Requesting Round Info.");
            var pocPoolRound = await apiPocClient.GetRoundAsync();
            Console.WriteLine($"Received Round, Round started at {pocPoolRound.RoundStart}.{Environment.NewLine}");

            await Task.Delay(500);

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("*************************************************************************************************");

            Console.WriteLine(Environment.NewLine);

            // POC Socket.IO
            Console.WriteLine($"Creating FoxyPool POC Socket.IO Api Client Instance.{Environment.NewLine}");
            using var apiPocSocketIOClient = new PocSocketIOApiClient(SocketIOApi.Web_UI);

            // hook up to the events we want to act on
            apiPocSocketIOClient.On_SocketIO_State_Changed += (oldState, newState) =>
            {
                Console.WriteLine($"Socket.IO state changed from {oldState} to {newState}.");
            };
            apiPocSocketIOClient.On_SocketIO_Connected += () =>
            {
                // now that we have a connection subscribe to events from the pool(s)
                _ = apiPocSocketIOClient.SubscribeAsync(PocPool.BHD, PocPool.SIGNA);
            };
            apiPocSocketIOClient.On_SocketIO_Stats_Live += (pool, data) =>
            {
                Console.WriteLine($"Received live stats for {pool}, {data.CurrentSubmissions.Count} subbmissions.");
            };

            // open the connection
            await apiPocSocketIOClient.ConnectAsync();

            // wait a couple minutes before letting the app exit
            await Task.Delay(TimeSpan.FromSeconds(120));
        }
    }
}
