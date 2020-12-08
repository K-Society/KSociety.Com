using System;
using System.Net.Sockets;
using System.Threading;

namespace KSociety.Com.Driver.Ping
{
    public interface IPinger : IDisposable
    {
        void Start(CancellationToken cancellationToken = default);
        void Stop();
        bool SingleProtocolPing(int port, ProtocolType type);
    }
}
