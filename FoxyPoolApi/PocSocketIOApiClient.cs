// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocSocketIOApiClient.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using FoxyPoolApi.Responses;
using Microsoft.Extensions.Logging;
using SocketIOClient;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FoxyPoolApi
{
    /// <summary>
    /// Class PocSocketIOApiClient.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class PocSocketIOApiClient : IDisposable
    {
        /// <summary>
        /// The socket io API type
        /// </summary>
        public readonly SocketIOApi SocketIOApiType;
        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        /// <value><c>true</c> if this instance is connected; otherwise, <c>false</c>.</value>
        public bool IsConnected { get => _socketIOClient.Connected; }
        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
        public SocketIOState State { get; private set; }

        /// <summary>
        /// The socket io client
        /// </summary>
        private readonly SocketIO _socketIOClient;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<PocSocketIOApiClient>? _logger;
        /// <summary>
        /// The disposed value
        /// </summary>
        private bool _disposedValue;

        /// <summary>
        /// Occurs when [on socket io state changed].
        /// </summary>
        public event SocketIO_State_Changed? On_SocketIO_State_Changed;
        /// <summary>
        /// Occurs when [on socket io connected].
        /// </summary>
        public event SocketIO_Connected? On_SocketIO_Connected;
        /// <summary>
        /// Occurs when [on socket io disconnected].
        /// </summary>
        public event SocketIO_Disconnected? On_SocketIO_Disconnected;
        /// <summary>
        /// Occurs when [on socket io error].
        /// </summary>
        public event SocketIO_Error? On_SocketIO_Error;

        /// <summary>
        /// Occurs when [on socket io stats live].
        /// </summary>
        public event SocketIO_Stats_Live? On_SocketIO_Stats_Live;
        /// <summary>
        /// Occurs when [on socket io stats round].
        /// </summary>
        public event SocketIO_Stats_Round? On_SocketIO_Stats_Round;
        /// <summary>
        /// Occurs when [on socket io mining information].
        /// </summary>
        public event SocketIO_Mining_Info? On_SocketIO_Mining_Info;

        /// <summary>
        /// Initializes a new instance of the <see cref="PocSocketIOApiClient"/> class.
        /// </summary>
        /// <param name="socketIOApi">The socket io API.</param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="PocSocketIOApiClient"/> class.
        /// </summary>
        /// <param name="socketIOApi">The socket io API.</param>
        /// <param name="logger">The logger.</param>
        public PocSocketIOApiClient(SocketIOApi socketIOApi, ILogger<PocSocketIOApiClient> logger)
        {
            _logger = logger;
            SocketIOApiType = socketIOApi;

            _socketIOClient = BuildNewSocketIOClient(socketIOApi);

            AttachSocketIOEventHAndlers();

            _logger.LogDebug("Created new FoxyPool POC SockeetIO API instance");
        }

        /// <summary>
        /// Builds the new socket io client.
        /// </summary>
        /// <param name="socketIOApi">The socket io API.</param>
        /// <returns>SocketIO.</returns>
        private SocketIO BuildNewSocketIOClient(SocketIOApi socketIOApi)
        {
            var url = GetSocketIOUrl(socketIOApi);
            return new SocketIO(url);
        }

        /// <summary>
        /// Gets the socket io URL.
        /// </summary>
        /// <param name="socketIOApi">The socket io API.</param>
        /// <returns>System.String.</returns>
        private string GetSocketIOUrl(SocketIOApi socketIOApi)
        {
            return socketIOApi switch
            {
                SocketIOApi.Mining => Constants.PocSocketIOMiningUrl,
                SocketIOApi.Web_UI => Constants.PocSocketIOWebUiUrl,
                _ => throw new ArgumentException(nameof(socketIOApi)),
            };
        }

        /// <summary>
        /// Attaches the socket io event h andlers.
        /// </summary>
        private void AttachSocketIOEventHAndlers()
        {
            _socketIOClient.OnConnected += SocketIOClient_OnConnected;
            _socketIOClient.OnDisconnected += SocketIOClient_OnDisconnected;
            _socketIOClient.OnError += SocketIOClient_OnError;
#if DEBUG
            _socketIOClient.OnAny((eventName, data) =>
            {
                if (_logger == null)
                {
                    Console.WriteLine(eventName, data);
                }
                else
                {
                    _logger.LogDebug("OnAny recevied {EnentName} {Data}", eventName, data);
                }
            });
#endif
            _socketIOClient.On("stats/live", (data) => { SocketIOClient_On_Stats_Live(data); });
            _socketIOClient.On("stats/round", (data) => { SocketIOClient_On_Stats_Round(data); });
            _socketIOClient.On("miningInfo", (data) => { SocketIOClient_On_Mining_Info(data); });
        }

        /// <summary>
        /// Sockets the io client on stats live.
        /// </summary>
        /// <param name="response">The response.</param>
        private void SocketIOClient_On_Stats_Live(SocketIOResponse response)
        {
            var pool = response.GetValue<string>(0);
            var data = response.GetValue(1).GetRawText();
            var result = PocLiveStatsDataResponse.FromJson(data);
            On_SocketIO_Stats_Live?.Invoke((PocPool)Enum.Parse(typeof(PocPool), pool, true), result);
        }

        /// <summary>
        /// Sockets the io client on stats round.
        /// </summary>
        /// <param name="response">The response.</param>
        private void SocketIOClient_On_Stats_Round(SocketIOResponse response)
        {
            var pool = response.GetValue<string>(0);
            var data = response.GetValue(1).GetRawText();
            var result = PocRoundStatsDataResponse.FromJson(data);
            On_SocketIO_Stats_Round?.Invoke((PocPool)Enum.Parse(typeof(PocPool), pool, true), result);
        }

        /// <summary>
        /// Sockets the io client on mining information.
        /// </summary>
        /// <param name="response">The response.</param>
        private void SocketIOClient_On_Mining_Info(SocketIOResponse response)
        {
            var pool = response.GetValue<string>(0);
            var data = response.GetValue(1).GetRawText();
            var result = PocMiningInfoResponse.FromJson(data);
            On_SocketIO_Mining_Info?.Invoke((PocPool)Enum.Parse(typeof(PocPool), pool, true), result);
        }

        /// <summary>
        /// Sockets the io client on error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void SocketIOClient_OnError(object sender, string e)
        {
            On_SocketIO_Error?.Invoke(e);
        }

        /// <summary>
        /// Sockets the io client on disconnected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void SocketIOClient_OnDisconnected(object sender, string e)
        {
            if (State != SocketIOState.Disconnected)
            {
                On_SocketIO_State_Changed?.Invoke(State, SocketIOState.Disconnected);
                On_SocketIO_Disconnected?.Invoke(e);
            }

            State = SocketIOState.Disconnected;
        }

        /// <summary>
        /// Handles the OnConnected event of the SocketIOClient control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SocketIOClient_OnConnected(object sender, EventArgs e)
        {
            if (State != SocketIOState.Connected)
            {
                On_SocketIO_State_Changed?.Invoke(State, SocketIOState.Connected);
                On_SocketIO_Connected?.Invoke();
            }

            State = SocketIOState.Connected;
        }

        /// <summary>
        /// Connects the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        public Task ConnectAsync()
        {
            if (_socketIOClient.Connected)
                return Task.CompletedTask;

            if (State != SocketIOState.Connecting)
                On_SocketIO_State_Changed?.Invoke(State, SocketIOState.Connecting);

            State = SocketIOState.Connecting;

            return _socketIOClient.ConnectAsync();
        }

        /// <summary>
        /// Disconnects the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        public Task DisconnectAsync()
        {
            if (_socketIOClient.Connected)
            {
                return _socketIOClient.DisconnectAsync();
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Subscribes the asynchronous.
        /// </summary>
        /// <param name="pocPools">The poc pools.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.Exception">Socket not connected.</exception>
        public Task SubscribeAsync(params PocPool[] pocPools)
        {
            if (!_socketIOClient.Connected)
                throw new Exception("Socket not connected.");

            var pools = pocPools.Select(p => p.ToString().ToLowerInvariant());

            return _socketIOClient.EmitAsync("subscribe", pools);
        }

        /// <summary>
        /// Get mining information as an asynchronous operation.
        /// </summary>
        /// <param name="pocPool">The poc pool.</param>
        /// <returns>A Task&lt;PocMiningInfoResponse&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.Exception">Socket not connected.</exception>
        /// <exception cref="System.Exception">Failed to retreive mining info.</exception>
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

            if (result == null)
                throw new Exception("Failed to retreive mining info.");

            return result;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
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

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
