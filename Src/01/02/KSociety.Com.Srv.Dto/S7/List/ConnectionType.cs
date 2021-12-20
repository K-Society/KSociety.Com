using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.S7.List;

[ProtoContract]
public class ConnectionType : ObjectList<S7.ConnectionType>
{
    public ConnectionType()
    {
    }

    public ConnectionType(List<S7.ConnectionType> connectionTypes)
    {
        List = connectionTypes;
    }
}