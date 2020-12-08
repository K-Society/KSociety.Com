using System.Net.Sockets;
using KSociety.Com.Driver.Base;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Driver.Modbus
{
    public class ModbusSocket : StdSocket
    {
        public ModbusSocket(ILoggerFactory loggerFactory, string name, string host, int port, ProtocolType protocolType) 
            : base(loggerFactory, name, host, port, protocolType)
        {
        }

        internal override void CreateSocket()
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType) { NoDelay = true };
        }
    }
}
