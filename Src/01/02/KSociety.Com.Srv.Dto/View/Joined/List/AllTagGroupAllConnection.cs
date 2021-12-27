using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.View.Joined.List;

[ProtoContract]
public class AllTagGroupAllConnection : ObjectList<Joined.AllTagGroupAllConnection>
{
    public AllTagGroupAllConnection() { }

    public AllTagGroupAllConnection(List<Joined.AllTagGroupAllConnection> allTagGroupAllConnection)
    {
        List = allTagGroupAllConnection;
    }
}