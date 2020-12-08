using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.View.Joined.List.GridView
{
    [ProtoContract]
    public class AllTagGroupAllConnection : KbList<Joined.AllTagGroupAllConnection>
    {
        public AllTagGroupAllConnection() { }

        public AllTagGroupAllConnection(List<Joined.AllTagGroupAllConnection> allTagGroupAllConnection)
        {
            List = allTagGroupAllConnection;
        }
    }
}
