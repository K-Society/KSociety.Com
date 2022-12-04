using KSociety.Com.Driver.Enip.Eipnet.Cip;

namespace KSociety.Com.Driver.Enip.ControlLogixNet
{
    internal class LogixRead
    {
        public CipType DataType { get; set; }
        public int VarCount { get; set; }
        public int TotalSize { get; set; }
        public int ElementSize { get; set; }
        public uint Mask { get; set; }
    }
}