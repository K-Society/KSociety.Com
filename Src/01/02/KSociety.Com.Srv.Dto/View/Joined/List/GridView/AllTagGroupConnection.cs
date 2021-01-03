using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.View.Joined.List.GridView
{
    [ProtoContract]
    public class AllTagGroupConnection : ObjectList<Joined.AllTagGroupConnection>
    {
        public AllTagGroupConnection() { }

        public AllTagGroupConnection(List<Joined.AllTagGroupConnection> allTagGroupConnection)
        {
            List = allTagGroupConnection;
        }
    }
}
