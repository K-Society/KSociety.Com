﻿namespace KSociety.Com.Driver.Enip.Eipnet.Eip
{
    public enum EncapsStatusCode : ushort
    {
        Success = 0x0000,
        InvalidCommand = 0x0001,
        InsufficientResources = 0x0002,
        PoorlyFormedData = 0x0003,
        InvalidSessionHandle = 0x0064,
        InvalidLength = 0x0065,
        UnsupportedEncapsVersion = 0x0069
    }
}
