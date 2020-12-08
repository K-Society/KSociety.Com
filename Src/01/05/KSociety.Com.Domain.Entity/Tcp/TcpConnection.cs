using System;
using FluentValidation;

namespace KSociety.Com.Domain.Entity.Tcp
{
    public class TcpConnection : Common.Connection
    {
        public int? Port { get; private set; }
        public TcpConnection(
            Guid id,
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable,
            int? port
        )
            : base(
                //LogManager.GetCurrentClassLogger(),
                id,
                automationTypeId,
                name,
                ip,
                enable,
                writeEnable
            )
        {
            Port = port;

            var tcpConnectionValidator = new Validator.Tcp.Connection();
            tcpConnectionValidator.ValidateAndThrow(this);
        }
    }
}
