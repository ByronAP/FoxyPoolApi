// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="SocketIOState.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace FoxyPoolApi
{
    /// <summary>
    /// Enum SocketIOState
    /// </summary>
    public enum SocketIOState
    {
        /// <summary>
        /// The disconnected
        /// </summary>
        Disconnected,
        /// <summary>
        /// The connecting
        /// </summary>
        Connecting,
        /// <summary>
        /// The connected
        /// </summary>
        Connected,
        /// <summary>
        /// The error
        /// </summary>
        Error
    }
}
