using KSociety.Com.Domain.Entity.Common;
using MediatR;

namespace KSociety.Com.Domain.Entity.Event
{
    public class NotifyTagEvent : INotification
    {
        public Tag Tag { get; }
        public string Name { get; }
        public string Value { get; }

        public NotifyTagEvent(Tag tag, string name, string value)
        {
            Tag = tag;
            Name = name;
            Value = value;
        }
    }
}
