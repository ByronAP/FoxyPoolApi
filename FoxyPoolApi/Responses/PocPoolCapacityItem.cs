// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-05-2021
// ***********************************************************************
// <copyright file="PocPoolCapacityItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocPoolCapacityItem.
    /// </summary>
    public class PocPoolCapacityItem
    {
        /// <summary>
        /// Gets or sets the ec.
        /// </summary>
        /// <value>The ec.</value>
        [JsonProperty("ec")]
        public decimal Ec { get; set; }

        /// <summary>
        /// Gets or sets the account ec sum.
        /// </summary>
        /// <value>The account ec sum.</value>
        [JsonProperty("accountEcSum")]
        public decimal AccountEcSum { get; set; }
    }
}
