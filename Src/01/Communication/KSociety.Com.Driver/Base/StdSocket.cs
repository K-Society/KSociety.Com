using System.Net.Sockets;
using KSociety.Base.InfraSub.Shared.Class;
using KSociety.Com.Driver.Ping;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Driver.Base
{
    public class StdSocket : DisposableObject
    {
        private readonly ILogger<StdSocket> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly string _instanceName;
        internal Socket Socket;
        private readonly string _host;
        private readonly int _port;
        internal readonly ProtocolType ProtocolType;

        private readonly Pinger _pinger;

        public bool Connected => (Socket != null) && (Socket.Connected);

        protected StdSocket(ILoggerFactory loggerFactory, string name, string host, int port, ProtocolType protocolType)
        {
            _loggerFactory = loggerFactory;
            _instanceName = name;
            _host = host;
            _port = port;
            ProtocolType = protocolType;
            _pinger = new Pinger(_loggerFactory, _host, _instanceName); //ToDo
        }

        ~StdSocket()
        {
            Dispose();
        }

        internal virtual void CreateSocket()
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType) { NoDelay = true };
        }

        public void Connect()
        {
            if (!Connected)
            {
                if (SinglePing())
                {
                    try
                    {
                        CreateSocket();
                        Socket.Connect(_host, _port);
                    }
                    catch
                    {
                        ;
                    }
                }
            }
        }

        public void Disconnect()
        {
            Dispose();
        }

        private bool SinglePing()
        {
            return _pinger.SingleProtocolPing(_port, ProtocolType);
        }

        public int Send(byte[] buffer, int size)
        {
            return Socket.Send(buffer, size, SocketFlags.None);
        }

        protected override void DisposeManagedResources()
        {
            if (Socket == null) return;

            if (Socket.Connected)
            {
                try
                {
                    Socket.Shutdown(SocketShutdown.Both);
                }
                catch
                {
                    // ignored
                }

                Socket.Close();
            }
            Socket.Dispose();
            Socket = null;
        }
    }
}
