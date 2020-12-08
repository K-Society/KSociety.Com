using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.View.Joined.List
{
    [ProtoContract]
    public class AllTagGroupConnection : KbList<Joined.AllTagGroupConnection>
    {
        public AllTagGroupConnection() { }

        public AllTagGroupConnection(List<Joined.AllTagGroupConnection> allTagGroupConnection)
        {
            List = allTagGroupConnection;
        }
    }
}
