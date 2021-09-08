using Microsoft.Extensions.Logging;
using SocketIOClient;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using FoxyPoolApi.Responses;

namespace FoxyPoolApi
{
    public class PocSocketIOApiClient : IDisposable
    {
        public readonly SocketIOApi SocketIOApiType;
        public bool IsConnected {  get => _socketIOClient.Connected; }
        public SocketIOState State { get; private set; }

        private readonly SocketIO _socketIOClient;
        private readonly ILogger<PocSocketIOApiClient>? _logger;
        private bool _disposedValue;

        public event SocketIO_State_Changed? On_SocketIO_State_Changed;
        public event SocketIO_Connected? On_SocketIO_Connected;
        public event SocketIO_Disconnected? On_SocketIO_Disconnected;
        public event SocketIO_Error? On_SocketIO_Error;

        public event SocketIO_Stats_Live? On_SocketIO_Stats_Live;
        public event SocketIO_Stats_Round? On_SocketIO_Stats_Round;
        public event SocketIO_Mining_Info? On_SocketIO_Mining_Info;

        public PocSocketIOApiClient(SocketIOApi socketIOApi)
        {
            _logger = null;
            SocketIOApiType = socketIOApi;

            _socketIOClient = BuildNewSocketIOClient(socketIOApi);

            AttachSocketIOEventHAndlers();

#if DEBUG
            Console.WriteLine($"{DateTime.UtcNow}: Created new FoxyPool POC SocketIO API instance.");
#endif
        }

        public PocSocketIOApiClient(SocketIOApi socketIOApi, ILogger<PocSocketIOApiClient> logger)
        {
            _logger = logger;
            SocketIOApiType = socketIOApi;

            _socketIOClient = BuildNewSocketIOClient(socketIOApi);

            AttachSocketIOEventHAndlers();

            _logger.LogDebug("Created new FoxyPool POC SockeetIO API instance");
        }

        private SocketIO BuildNewSocketIOClient(SocketIOApi socketIOApi)
        {
            var url = GetSocketIOUrl(socketIOApi);
            return new SocketIO(url);
        }

        private string GetSocketIOUrl(SocketIOApi socketIOApi)
        {
            return socketIOApi switch
            {
                SocketIOApi.Mining => Constants.PocSocketIOMiningUrl,
                SocketIOApi.Web_UI => Constants.PocSocketIOWebUiUrl,
                _ => throw new ArgumentException(nameof(socketIOApi)),
            };
        }

        private void AttachSocketIOEventHAndlers()
        {
            _socketIOClient.OnConnected += SocketIOClient_OnConnected;
            _socketIOClient.OnDisconnected += SocketIOClient_OnDisconnected;
            _socketIOClient.OnError += SocketIOClient_OnError;
#if DEBUG
            _socketIOClient.OnAny((eventName, data) => 
            { 
                if(_logger == null)
                {
                    Console.WriteLine(eventName, data);
                }
                else
                {
                    _logger.LogDebug("OnAny recevied {EnentName} {Data}", eventName, data);
                }
            });
#endif
            _socketIOClient.On("stats/live", (data) => {SocketIOClient_On_Stats_Live(data);});
            _socketIOClient.On("stats/round", (data) => {SocketIOClient_On_Stats_Round(data);});
            _socketIOClient.On("miningInfo", (data) => {SocketIOClient_On_Mining_Info(data); });
        }

        private void SocketIOClient_On_Stats_Live(SocketIOResponse response)
        {
            var pool = response.GetValue<string>(0);
            var data = response.GetValue(1).GetRawText();
            var result = PocLiveStatsDataResponse.FromJson(data);
            On_SocketIO_Stats_Live?.Invoke((PocPool)Enum.Parse(typeof(PocPool), pool, true), result);
        }

        private void SocketIOClient_On_Stats_Round(SocketIOResponse response)
        {
            var pool = response.GetValue<string>(0);
            var data = response.GetValue(1).GetRawText();
            var result = PocRoundStatsDataResponse.FromJson(data);
            On_SocketIO_Stats_Round?.Invoke((PocPool)Enum.Parse(typeof(PocPool), pool, true), result);
        }

        private void SocketIOClient_On_Mining_Info(SocketIOResponse response)
        {
            var pool = response.GetValue<string>(0);
            var data = response.GetValue(1).GetRawText();
            var result = PocMiningInfoResponse.FromJson(data);
            On_SocketIO_Mining_Info?.Invoke((PocPool)Enum.Parse(typeof(PocPool), pool, true), result);
        }

        private void SocketIOClient_OnError(object sender, string e)
        {
            On_SocketIO_Error?.Invoke(e);
        }

        private void SocketIOClient_OnDisconnected(object sender, string e)
        {
            if(State != SocketIOState.Disconnected)
            {
                On_SocketIO_State_Changed?.Invoke(State, SocketIOState.Disconnected);
                On_SocketIO_Disconnected?.Invoke(e);
            }

            State = SocketIOState.Disconnected;
        }

        private void SocketIOClient_OnConnected(object sender, EventArgs e)
        {
            if (State != SocketIOState.Connected)
            {
                On_SocketIO_State_Changed?.Invoke(State, SocketIOState.Connected);
                On_SocketIO_Connected?.Invoke();
            }

            State = SocketIOState.Connected;
        }

        public Task ConnectAsync()
        {
            if(_socketIOClient.Connected)
                return Task.CompletedTask;

            if (State != SocketIOState.Connecting)
                On_SocketIO_State_Changed?.Invoke(State, SocketIOState.Connecting);

            State = SocketIOState.Connecting;

            return _socketIOClient.ConnectAsync();
        }

        public Task DisconnectAsync()
        {
            if(_socketIOClient.Connected)
            {
                return _socketIOClient.DisconnectAsync();
            }

            return Task.CompletedTask;
        }

        public Task SubscribeAsync(params PocPool[] pocPools)
        {
            if(!_socketIOClient.Connected)
                throw new Exception("Socket not connected.");

            var pools = pocPools.Select(p => p.ToString().ToLowerInvariant());

            return _socketIOClient.EmitAsync("subscribe", pools);
        }

        public async Task<PocMiningInfoResponse> GetMiningInfoAsync(PocPool pocPool)
        {
            if (!_socketIOClient.Connected)
                throw new Exception("Socket not connected.");

            PocMiningInfoResponse? result = null;

            var pool = pocPool.ToString().ToLowerInvariant();

            await _socketIOClient.EmitAsync("getMiningInfo",
                response =>
                {
                    var json = response.GetValue().GetRawText();
                    result = PocMiningInfoResponse.FromJson(json);
                },
                pool);

            // TODO: this is terrible, write this properly
            var stopwatch = new Stopwatch();
            stopwatch.Start();
                do
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                } while (result == null && stopwatch.Elapsed.TotalSeconds < 22);
            stopwatch.Stop();

            if(result == null)
                throw new Exception("Failed to retreive mining info.");

            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_socketIOClient.Connected)
                    {
                        _socketIOClient.DisconnectAsync().Wait(TimeSpan.FromSeconds(2));
                    }
                    _socketIOClient.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
