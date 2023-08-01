using System;
using FluentValidation;

namespace KSociety.Com.Domain.Entity.Tcp
{
    public class TcpTag : Common.Tag
    {
        public TcpTag(
            Guid id,
            int automationTypeId,
            string name,
            Guid connectionId,
            bool enable,
            string inputOutput,
            string analogDigitalSignal,
            string memoryAddress,
            bool invoke,
            Guid tagGroupId
        )
            : base(
                id,
                automationTypeId,
                name,
                connectionId,
                enable,
                inputOutput,
                analogDigitalSignal,
                memoryAddress,
                invoke,
                tagGroupId
            )
        {
            var tcpTagValidator = new Validator.Tcp.Tag();
            tcpTagValidator.ValidateAndThrow(this);
        }
    }
}