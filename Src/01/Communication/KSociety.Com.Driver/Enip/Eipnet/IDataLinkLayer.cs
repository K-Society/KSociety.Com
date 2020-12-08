namespace KSociety.Com.Driver.Enip.Eipnet
{
    internal interface IDataLinkLayer
    {
        void SendData(byte[] data);
        byte[] ReceiveData();
    }
}
