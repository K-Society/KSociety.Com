namespace KSociety.Com.Driver.Enip.Eipnet
{
    internal interface IExpandable
    {
        void Expand(byte[] dataArray, int offset, out int newOffset);
    }
}