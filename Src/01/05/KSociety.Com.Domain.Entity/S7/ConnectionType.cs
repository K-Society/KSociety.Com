using System.Collections.Generic;

namespace KSociety.Com.Domain.Entity.S7
{
    public class ConnectionType
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public virtual ICollection<S7Connection> Connections { get; set; }

        //private ConnectionType() { }

        public ConnectionType(int id, string name)
        {
            Id = id;
            Name = name;

            //var s7WordLenValidator = new S7WordLenValidator();
            //s7WordLenValidator.ValidateAndThrow(this);
        }
    }
}
