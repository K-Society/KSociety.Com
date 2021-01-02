using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common.List
{
    [ProtoContract]
    public class Connection : ObjectList<Common.Connection>
    {
        //[DataMember]
        //public List<S7Connection> S7Connections { get; set; }

        //[DataMember]
        //public List<S7.Connection> List { get; set; }

        //[DataMember]
        //public List<S7Connection> List
        //{
        //    get
        //    {
        //        return S7Connections;
        //    }
        //}

        public Connection()
        {
        }

        public Connection(List<Common.Connection> connections)
        {
            List = connections;
        }
    }
}
