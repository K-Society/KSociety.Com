namespace KSociety.Com.Driver.Enip.ControlLogixNet
{
    internal class CommonDataServiceReply
    {
        public byte Service { get; set; }
        public byte Reserved { get; set; }
        public ushort Status { get; set; }
    }
}
