using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.View.Joined.List.GridView
{
    [ProtoContract]
    public class AllConnection : KbList<Joined.AllConnection>
    {
        public AllConnection() { }

        public AllConnection(List<Joined.AllConnection> allConnection)
        {
            List = allConnection;
        }
    }
}
