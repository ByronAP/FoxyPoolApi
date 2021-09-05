using FoxyPoolApi;
using System;
using System.Threading.Tasks;

namespace FoxyPoolApiDemo
{
    public class Program
    {
        private static async Task Main()
        {
            Console.WriteLine($"Creating FoxyPool POST Api Client Instance.{Environment.NewLine}");
            using var apiClient = new PostApiClient(PostPool.Chia_OG);

            Console.WriteLine("Requesting Pool Config.");
            var poolConfig = await apiClient.GetConfigAsync();
            Console.WriteLine($"Received Pool Config for {poolConfig.PoolName}.{Environment.NewLine}");

            await Task.Delay(500);

            Console.WriteLine("Requesting Pool Info.");
            var poolInfo = await apiClient.GetPoolAsync();
            Console.WriteLine($"Received Pool Info, Pool has a balance of {poolInfo.Balance}.{Environment.NewLine}");

            await Task.Delay(500);

            Console.WriteLine("Requesting Accounts Info.");
            var poolAccounts = await apiClient.GetAccountsAsync();
            Console.WriteLine($"Received Accounts, Pool has {poolAccounts.AccountsWithShares} active accounts.{Environment.NewLine}");

            await Task.Delay(500);
        }
    }
}
