using System.Collections.Generic;

namespace KSociety.Com.Domain.Entity.S7
{
    public class CpuType
    {
        public int Id { get; private set; }

        public string CpuTypeName { get; private set; }

        public string Mean { get; private set; }

        public virtual ICollection<S7Connection> S7Connections { get; set; }


        public CpuType(int id, string cpuTypeName, string mean)
        {
            Id = id;
            CpuTypeName = cpuTypeName;
            Mean = mean;
        }
    }
}