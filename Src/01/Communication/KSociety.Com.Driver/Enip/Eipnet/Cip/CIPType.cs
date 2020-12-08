namespace KSociety.Com.Driver.Enip.Eipnet.Cip
{
    /// <summary>
    /// Common CIP Data Types
    /// </summary>
    public enum CipType : ushort 
    {
        BOOL = 0x00C1,
        SINT = 0x00C2,
        INT = 0x00C3,
        DINT = 0x00C4,
        LINT = 0x00C5,
        REAL = 0x00CA,
        BITS = 0x00D3,
        STRUCT = 0x02A0
    }

    /// <summary>
    /// Common CIP Data Type Sizes
    /// </summary>
    public enum CIPTypeSize : byte
    {
        BOOL = 1,
        SINT = 1,
        INT = 2,
        DINT = 4,
        REAL = 4,
        BITS = 4
    }
}
