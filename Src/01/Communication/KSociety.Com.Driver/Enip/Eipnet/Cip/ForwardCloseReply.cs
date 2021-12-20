namespace KSociety.Com.Driver.Enip.Eipnet.Cip;

public abstract class ForwardCloseReply
{
    public ushort ConnectionSerialNumber { get; internal set; }
    public ushort OriginatorVendorId { get; internal set; }
    public uint OriginatorSerialNumber { get; internal set; }

        
}