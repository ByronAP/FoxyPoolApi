// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="StatusEndpoint.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace FoxyPoolApi
{
    /// <summary>
    /// Enum StatusEndpoint
    /// </summary>
    public enum StatusEndpoint
    {
        /// <summary>
        /// The summary
        /// </summary>
        Summary,
        /// <summary>
        /// The status
        /// </summary>
        Status,
        /// <summary>
        /// The components
        /// </summary>
        Components,
        /// <summary>
        /// The incidents
        /// </summary>
        Incidents,
        /// <summary>
        /// The incidents unresolved
        /// </summary>
        Incidents_Unresolved,
        /// <summary>
        /// The scheduled maintenances
        /// </summary>
        Scheduled_Maintenances,
        /// <summary>
        /// The scheduled maintenances upcoming
        /// </summary>
        Scheduled_Maintenances_Upcoming,
        /// <summary>
        /// The scheduled maintenances active
        /// </summary>
        Scheduled_Maintenances_Active
    }
}
