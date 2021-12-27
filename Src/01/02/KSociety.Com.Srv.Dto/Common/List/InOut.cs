using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common.List;

[ProtoContract]
public class InOut : ObjectList<Common.InOut>
{
    public InOut()
    {

    }

    public InOut(List<Common.InOut> inOuts)
    {
        List = inOuts;
    }
}