// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="Delegates.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using FoxyPoolApi.Responses;

namespace FoxyPoolApi
{
    /// <summary>
    /// Delegate SocketIO_State_Changed
    /// </summary>
    /// <param name="oldState">The old state.</param>
    /// <param name="newState">The new state.</param>
    public delegate void SocketIO_State_Changed(SocketIOState oldState, SocketIOState newState);
    /// <summary>
    /// Delegate SocketIO_Connected
    /// </summary>
    public delegate void SocketIO_Connected();
    /// <summary>
    /// Delegate SocketIO_Disconnected
    /// </summary>
    /// <param name="reason">The reason.</param>
    public delegate void SocketIO_Disconnected(string reason);
    /// <summary>
    /// Delegate SocketIO_Error
    /// </summary>
    /// <param name="reason">The reason.</param>
    public delegate void SocketIO_Error(string reason);
    /// <summary>
    /// Delegate SocketIO_Stats_Live
    /// </summary>
    /// <param name="pool">The pool.</param>
    /// <param name="liveStatsDataResponse">The live stats data response.</param>
    public delegate void SocketIO_Stats_Live(PocPool pool, PocLiveStatsDataResponse liveStatsDataResponse);
    /// <summary>
    /// Delegate SocketIO_Stats_Round
    /// </summary>
    /// <param name="pool">The pool.</param>
    /// <param name="roundStatsDataResponse">The round stats data response.</param>
    public delegate void SocketIO_Stats_Round(PocPool pool, PocRoundStatsDataResponse roundStatsDataResponse);
    /// <summary>
    /// Delegate SocketIO_Mining_Info
    /// </summary>
    /// <param name="pool">The pool.</param>
    /// <param name="miningInfoResponse">The mining information response.</param>
    public delegate void SocketIO_Mining_Info(PocPool pool, PocMiningInfoResponse miningInfoResponse);
}
