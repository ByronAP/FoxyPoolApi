// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="IncidentImpact.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace FoxyPoolApi
{
    /// <summary>
    /// Enum IncidentImpact
    /// </summary>
    public enum IncidentImpact
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The minor
        /// </summary>
        Minor,
        /// <summary>
        /// The major
        /// </summary>
        Major,
        /// <summary>
        /// The critical
        /// </summary>
        Critical,
        /// <summary>
        /// The maintenance
        /// </summary>
        Maintenance
    }

    /// <summary>
    /// Class IncidentImpactExtensions.
    /// </summary>
    public static class IncidentImpactExtensions
    {
        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Color.</returns>
        public static Color GetColor(this IncidentImpact value)
        {
            return value switch
            {
                IncidentImpact.None => Color.Black,
                IncidentImpact.Minor => Color.Yellow,
                IncidentImpact.Major => Color.Orange,
                IncidentImpact.Critical => Color.Red,
                IncidentImpact.Maintenance => Color.Blue,
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}
