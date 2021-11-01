// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="ComponentStatus.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace FoxyPoolApi
{
    /// <summary>
    /// The operational status of a component
    /// </summary>
    public enum ComponentStatus
    {
        /// <summary>
        /// Operational
        /// </summary>
        Operational,
        /// <summary>
        /// Degraded performance
        /// </summary>
        Degraded_Performance,
        /// <summary>
        /// A partial outage
        /// </summary>
        Partial_Outage,
        /// <summary>
        /// A major outage
        /// </summary>
        Major_Outage
    }
}
