namespace KSociety.Com.Driver.Enip.Eipnet.Cip
{
    public enum RoutingErrors : ushort
    {
        Timeout = 0x204,
        InvalidPortID = 0x311,
        InvalidNodeAddress = 0x313,
        InvalidSegmentType = 0x315
    }
}
