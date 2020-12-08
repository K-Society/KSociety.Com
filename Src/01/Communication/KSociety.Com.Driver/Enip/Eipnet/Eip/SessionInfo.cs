using System;
using System.Net.Sockets;
using KSociety.Com.Driver.Enip.Eipnet.Cip;

namespace KSociety.Com.Driver.Enip.Eipnet.Eip
{

    public delegate void SocketErrorCallback(SocketException se);
    public delegate void PreOperationCallback();
    public delegate void PostOperationCallback();

    /// <summary>
    /// Contains Session Information
    /// </summary>
    public class SessionInfo
    {
        private const int ConnectTimeout = 2000; //1000;
        internal Socket SessionSocket { get; set; }
        public bool Connected { get; internal set; }
        public uint SessionHandle { get; internal set; }
        public string HostNameOrIp { get; internal set; }

        //AK
        public bool IsConnected => (SessionSocket != null) && (SessionSocket.Connected);

        private byte[] _senderContext = new byte[8];
        public byte[] SenderContext
        {
            get { return _senderContext; }
            set
            {
                if (value == null)
                    _senderContext = new byte[8];
                if (value.Length > 8)
                    Buffer.BlockCopy(value, 0, _senderContext, 0, 8);
                if (value.Length <= 8)
                    Buffer.BlockCopy(value, 0, _senderContext, 0, value.Length);
            }
        }
        public int Port { get; internal set; }
        public string AccessPath { get; internal set; }
        public ConnectionParameters ConnectionParameters { get; internal set; }
        public IdentityItem IdentityInfo { get; internal set; }
        public bool Registered { get; internal set; }
        public bool Pinged { get; internal set; } //AK
        public int LastSessionError { get; internal set; }
        public string LastSessionErrorString { get; internal set; }
        internal string LastSessionErrorStack { get; set; }
        public int MillisecondTimeout { get; set; }
        public SocketErrorCallback OnSocketError { get; set; }
        public PreOperationCallback OnPreOperation { get; set; }
        public PostOperationCallback OnPostOperation { get; set; }

        byte[] _receiveBuffer = new byte[1024];

        public void SetConnectionParameters(ushort connectionSerialNumber,
            uint cipTimeoutMs, uint t2OConnectionId, ushort vendorId,
            uint originatorSerialNumber)
        {
            ConnectionParameters cp = new ConnectionParameters();
            cp.ConnectionSerialNumber = connectionSerialNumber;
            byte[] tickInfo = CalculateTickTime(cipTimeoutMs);
            if (tickInfo == null)
                throw new ApplicationException("Tick time could not be calculated");

            cp.PriorityAndTick = tickInfo[0];
            cp.ConnectionTimeoutTicks = tickInfo[1];
            cp.O2T_CID = 0;
            cp.T2O_CID = t2OConnectionId;
            cp.VendorID = vendorId;
            cp.OriginatorSerialNumber = originatorSerialNumber;

            ConnectionParameters = cp;
        }

        //AK
        public void TcpPing(string host, int port)
        {
            //bool output;
            // To Ping the PLC an Asynchronous socket is used rather then an ICMP packet.
            // This allows the use also across Internet and Firewalls (obviously the port must be opened)		   
            //LastError = 0;
            Socket pingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                IAsyncResult result = pingSocket.BeginConnect(host, port, null, null);
                bool success = result.AsyncWaitHandle.WaitOne(ConnectTimeout, true);

                Pinged = success;
                //return success;
                //if (!success)
                //{
                //    //LastError = S7Consts.errTCPConnectionFailed;
                //}
            }
            catch
            {
                Pinged = false;
                //return false;
                //LastError = S7Consts.errTCPConnectionFailed;
            };

            pingSocket.Close();
            
        }

        private byte[] CalculateTickTime(uint milliseconds)
        {
            byte[] retVal = new byte[2];

            if (milliseconds > 0x7F8000)
                milliseconds = 0x7F8000;

            while (milliseconds > 0xFF)
            {
                retVal[0]++;
                milliseconds = (unchecked(milliseconds >> 1));
            }

            retVal[1] = (byte)milliseconds;

            return retVal;
        }

        internal int SendData(byte[] data)
        {
            if (!Connected)
                return -1;

            try
            {
                return SessionSocket.Send(data);
            }
            catch (SocketException se)
            {
                OnSocketError?.Invoke(se);
            }

            return -1;
        }

        internal byte[] ReceiveData()
        {
            try
            {

                //Orignally I thought about clearing the buffer here, but I changed
                //my mind since you should never get more bytes in the returned
                //buffer than what you receive.

                SessionSocket.ReceiveTimeout = MillisecondTimeout;
                int bytesRecvd = SessionSocket.Receive(_receiveBuffer);


                byte[] retVal = new byte[bytesRecvd];
                Buffer.BlockCopy(_receiveBuffer, 0, retVal, 0, bytesRecvd);

                return retVal;

            }
            catch (SocketException se)
            {
                //The connection has timed out probably
                OnSocketError?.Invoke(se);
            }

            return null;
        }

        private void ClearRecvBuffer()
        {
            _receiveBuffer.Initialize();
        }

        public byte[] SendData_WaitReply(byte[] data)
        {
            if (SendData(data) != -1)
            {
                return ReceiveData();
            }

            return null;
        }
		
        public EncapsReply SendRRData(CommonPacketItem AddressItem, CommonPacketItem DataItem, CommonPacketItem[] AdditionalItems = null)
		{
            if (OnPreOperation != null)
                OnPreOperation();

            if ((CommonPacketTypeId)AddressItem.TypeId == CommonPacketTypeId.ConnectionBased)
            {
                //The connection ID may have changed, so we have to reset it
                AddressItem.Data = BitConverter.GetBytes(ConnectionParameters.O2T_CID);
            }
            
            EncapsRRData rrData = new EncapsRRData();
            rrData.CPF = new CommonPacket();
            rrData.Timeout = (ushort)MillisecondTimeout;
            rrData.CPF.AddressItem = AddressItem;
            rrData.CPF.DataItem = DataItem;

            if (AdditionalItems != null)
            {
                for (int i = 0; i < AdditionalItems.Length; i++)
                    rrData.CPF.AddItem(AdditionalItems[i]);
            }

            EncapsPacket request = EncapsPacketFactory.CreateSendRRData(SessionHandle, 0, SenderContext, rrData.Pack());
            byte[] rawRequest = request.Pack();

            byte[] rawReply = SendData_WaitReply(rawRequest);

            if (OnPostOperation != null)
                OnPostOperation();

            if (rawReply == null)
                return null;

            EncapsReply reply = new EncapsReply();
            int temp = 0;
            reply.Expand(rawReply, 0, out temp);

            return reply;
        }
		
        public EncapsReply SendUnitData(CommonPacketItem addressItem, CommonPacketItem dataItem, CommonPacketItem[] additionalItems = null)
		{
            OnPreOperation?.Invoke();

            if ((CommonPacketTypeId)addressItem.TypeId == CommonPacketTypeId.ConnectionBased)
            {
                //The connection ID may have changed, so we have to reset it
                addressItem.Data = BitConverter.GetBytes(ConnectionParameters.O2T_CID);
            }

            EncapsRRData rrData = new EncapsRRData();
            rrData.CPF = new CommonPacket();
            rrData.Timeout = (ushort)MillisecondTimeout;
            rrData.CPF.AddressItem = addressItem;
            rrData.CPF.DataItem = dataItem;

            if (additionalItems != null)
            {
                for (int i = 0; i < additionalItems.Length; i++)
                    rrData.CPF.AddItem(additionalItems[i]);
            }

            EncapsPacket request = EncapsPacketFactory.CreateSendUnitData(SessionHandle, SenderContext, rrData.Pack());
            byte[] rawRequest = request.Pack();

            byte[] rawReply = SendData_WaitReply(rawRequest);

            OnPostOperation?.Invoke();

            if (rawReply == null)
                return null;

            EncapsReply reply = new EncapsReply();
            int temp = 0;
            reply.Expand(rawReply, 0, out temp);

            return reply;
        }
    }
}
