# Foxy Pool API

<img src="https://raw.githubusercontent.com/ByronAP/FoxyPoolApi/main/Assets/fox-128.png" width="64px"> 

FoxyPoolApi is a .NET library that simplifies the integration of the Foxy Pool API.

Foxy Pool: https://foxypool.io

Api Docs: https://api-docs.foxypool.io

## Installation

Package available [![NuGet version (SoftCircuits.Silk)](https://img.shields.io/nuget/v/FoxyPoolApi.svg?style=flat-square)](https://www.nuget.org/packages/FoxyPoolApi/)

## Usage

```c#
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
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.


## License
[MIT](https://choosealicense.com/licenses/mit/)

Not affiliated with Foxy Pool in any way, Logo used with permission