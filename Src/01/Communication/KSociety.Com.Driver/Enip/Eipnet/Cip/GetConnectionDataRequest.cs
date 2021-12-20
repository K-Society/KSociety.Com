using System;

namespace KSociety.Com.Driver.Enip.Eipnet.Cip;

/// <summary>
/// Get Connection Data - Request
/// </summary>
public class GetConnectionDataRequest : IPackable
{
    /// <summary>
    /// Connection Number
    /// </summary>
    /// <value>Get Connection Data Service - Request</value>
    public ushort ConnectionNumber
    {
        get;
        set;
    }
    
    /// <summary>
    /// Packs the data into a byte array representing the request
    /// </summary>
    /// <returns></returns>
    public byte[] Pack()
    {
        return BitConverter.GetBytes(ConnectionNumber);
    }
}