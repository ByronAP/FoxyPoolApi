# Foxy Pool API

<img src="https://raw.githubusercontent.com/ByronAP/FoxyPoolApi/main/Assets/fox-128.png" width="64px"> 

FoxyPoolApi is a .NET library that simplifies the integration of the Foxy Pool API.

Foxy Pool: https://foxypool.io<br/>
POST Api Docs: https://api-docs.foxypool.io<br/>
POC Api Docs: https://docs.foxypool.io/proof-of-capacity/foxy-pool/api/overview<br/>
StatusPage: https://foxypool.statuspage.io

Supports POC (REST, Socket.io), POST (REST), and Statuspage (REST) APIs.<br/>
Contains a built in cache to reduce redundant calls.


## Installation

[![NuGet version (SoftCircuits.Silk)](https://img.shields.io/nuget/v/FoxyPoolApi.svg?style=flat-square)](https://www.nuget.org/packages/FoxyPoolApi/)


## Usage

#### Client Classes
* PostApiClient (Chia, Chia OG, Flax OG, Chives OG, HDDCoin OG)
* PocApiClient (BHD, SIGNA)
* PocSocketIOApiClient (BHD, SIGNA)
* PoolStatusApiClient (statuspage.io api)

[SEE DEMO PROJECT](https://github.com/ByronAP/FoxyPoolApi/blob/main/FoxyPoolApiDemo/Program.cs)


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.


## License
[MIT](https://choosealicense.com/licenses/mit/)

Not affiliated with Foxy Pool, Logo used with permission
