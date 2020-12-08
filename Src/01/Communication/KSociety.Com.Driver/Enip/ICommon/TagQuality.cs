﻿namespace KSociety.Com.Driver.Enip.ICommon
{
    /// <summary>
    /// Tag Quality
    /// </summary>
    public enum TagQuality : byte
    {
        /// <summary>
        /// Tag quality is bad
        /// </summary>
        Bad = 0xFF,
        /// <summary>
        /// Tag quality is unknown
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Tag quality is good
        /// </summary>
        Good = 1
    }
}
