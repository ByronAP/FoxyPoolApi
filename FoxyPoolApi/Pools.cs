// ***********************************************************************
// Assembly         : FoxyPoolApi
// Author           : bapen
// Created          : 09-04-2021
//
// Last Modified By : bapen
// Last Modified On : 11-11-2021
// ***********************************************************************
// <copyright file="Pools.cs" company="ByronAP">
//     © 2008-2021 ByronAP
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace FoxyPoolApi
{
    /// <summary>
    /// The available POST pools
    /// </summary>
    public enum PostPool
    {
        /// <summary>
        /// The Chia NFT Pool
        /// </summary>
        Chia = 1,
        /// <summary>
        /// The Chia OG Pool
        /// </summary>
        Chia_OG = 2,
        /// <summary>
        /// The Flax OG Pool
        /// </summary>
        Flax_OG = 4,
        /// <summary>
        /// The Chives OG Pool
        /// </summary>
        Chives_OG = 8,
        /// <summary>
        /// The HDDCoin OG Pool
        /// </summary>
        HddCoin_OG = 16,
        /// <summary>
        /// The Stai OG Pool
        /// </summary>
        Stai_OG = 32
    }

    /// <summary>
    /// The available POC pools
    /// </summary>
    public enum PocPool
    {
        /// <summary>
        /// The BHD Pool
        /// </summary>
        BHD = 1,
        /// <summary>
        /// The Signa Pool
        /// </summary>
        SIGNA = 2
    }
}
