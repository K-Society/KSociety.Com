using System.Collections.Generic;

namespace KSociety.Com.Domain.Entity.Common
{
    public class AutomationType
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Mean { get; private set; }

        public virtual ICollection<Connection> Connections { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public AutomationType(int id, string name, string mean)
        {
            Id = id;
            Name = name;
            Mean = mean;
        }
    }
}