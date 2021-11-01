// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-05-2021
//
// Last Modified By : bapen
// Last Modified On : 09-08-2021
// ***********************************************************************
// <copyright file="PocCurrentSubmissionItem.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace FoxyPoolApi.Responses
{
    /// <summary>
    /// Class PocCurrentSubmissionItem.
    /// </summary>
    public class PocCurrentSubmissionItem
    {
        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>The name of the account.</value>
        [JsonProperty("accountName")]
        public string? AccountName { get; set; }

        /// <summary>
        /// Gets or sets the deadline.
        /// </summary>
        /// <value>The deadline.</value>
        [JsonProperty("deadline")]
        public ulong Deadline { get; set; }
    }
}
