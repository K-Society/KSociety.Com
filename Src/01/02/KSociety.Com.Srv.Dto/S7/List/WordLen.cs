using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.S7.List;

[ProtoContract]
public class WordLen : ObjectList<S7.WordLen>
{
    public WordLen()
    {
    }

    public WordLen(List<S7.WordLen> wordLens)
    {
        List = wordLens;
    }
}