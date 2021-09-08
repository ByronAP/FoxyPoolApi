using FoxyPoolApi.Responses;

namespace FoxyPoolApi
{
    public delegate void SocketIO_State_Changed(SocketIOState oldState, SocketIOState newState);
    public delegate void SocketIO_Connected();
    public delegate void SocketIO_Disconnected(string reason);
    public delegate void SocketIO_Error(string reason);
    public delegate void SocketIO_Stats_Live(PocPool pool, PocLiveStatsDataResponse liveStatsDataResponse);
    public delegate void SocketIO_Stats_Round(PocPool pool, PocRoundStatsDataResponse roundStatsDataResponse);
    public delegate void SocketIO_Mining_Info(PocPool pool, PocMiningInfoResponse miningInfoResponse);
}
