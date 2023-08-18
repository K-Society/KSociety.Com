using System.Collections.Generic;

namespace KSociety.Com.Domain.Entity.S7
{
    public class ConnectionType
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public virtual ICollection<S7Connection> Connections { get; set; }

        public ConnectionType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}