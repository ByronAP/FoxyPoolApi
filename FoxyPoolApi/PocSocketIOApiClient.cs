using Microsoft.Extensions.Logging;
using SocketIOClient;
using System;
using System.Threading.Tasks;

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

            _socketIOClient.OnAny(SocketIOClient_OnAny);
        }

        private void SocketIOClient_OnAny(string eventName, SocketIOResponse response)
        {
            Console.WriteLine(eventName, response);
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

        public Task SubscribeAsync(params PocPool[] pocPools)
        {
            if(!_socketIOClient.Connected)
                throw new Exception("Socket not connected.");

            return _socketIOClient.EmitAsync("subscribe", pocPools);
        }

        public async Task<object> EmitGetMiningInfo(PocPool pocPool)
        {
            if (!_socketIOClient.Connected)
                throw new Exception("Socket not connected.");

            object result = new object();

            await _socketIOClient.EmitAsync("getMiningInfo",
                response =>
                {
                    result = response.GetValue();
                },
                pocPool.ToString());

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
                        _socketIOClient.DisconnectAsync().Wait();
                    }
                    _socketIOClient?.Dispose();
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
