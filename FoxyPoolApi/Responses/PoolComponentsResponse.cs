// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-08-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PoolComponentsResponse.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PoolComponentsResponse.
    /// </summary>
    public class PoolComponentsResponse
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>The page.</value>
        [JsonProperty("page")]
        public PageItem? Page { get; set; }

        /// <summary>
        /// Gets or sets the components.
        /// </summary>
        /// <value>The components.</value>
        [JsonProperty("components")]
        public List<ComponentItem>? Components { get; set; }
    }
}
