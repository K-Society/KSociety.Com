using System.Collections.Generic;
using KSociety.Com.Domain.Entity.S7;

namespace KSociety.Com.Domain.Entity.Common;

public class Bit
{      
    public byte BitOfByte { get; private set; }

    public string BitName { get; private set; }

    public virtual ICollection<S7Tag> S7Tags { get; set; }

    //public Bit() { }

    public Bit(byte bitOfByte, string bitName)
    {
        BitOfByte = bitOfByte;
        BitName = bitName;
    }
}