using System;
using MediatR;

namespace KSociety.Com.Domain.Entity.Event
{
    public class LogMessage : INotification
    {
        public DateTime MessageTime { get; }

        public LogMessage(DateTime messageTime)
        {
            MessageTime = messageTime;
        }
    }
}