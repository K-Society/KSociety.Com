using System;
using KSociety.Com.Domain.Entity.Common;
using MediatR;

namespace KSociety.Com.Domain.Entity.Event
{
    public class TagValueChanged : INotification
    {
        public Tag Tag { get; }
        public string Name { get; }
        public string Value { get; }
        public DateTime Timestamp { get; }

        public TagValueChanged(/*ILogger logger,*/ Tag tag, string name, string value, DateTime timestamp)
        {
            Tag = tag;
            Name = name;
            Value = value;
            Timestamp = timestamp;

            //logger.LogTrace(Tag.Name + " " + Name + " " + Value);
        }
    }
}
