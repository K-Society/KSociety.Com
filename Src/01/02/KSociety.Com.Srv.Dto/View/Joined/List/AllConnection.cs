using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.View.Joined.List
{
    [ProtoContract]
    public class AllConnection : ObjectList<Joined.AllConnection>
    {
        public AllConnection() { }

        public AllConnection(List<Joined.AllConnection> allConnection)
        {
            List = allConnection;
        }
    }
}
