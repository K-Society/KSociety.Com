using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common.List
{
    [ProtoContract]
    public class Tag : KbList<Common.Tag>
    {
        public Tag()
        {

        }

        public Tag(List<Common.Tag> tags)
        {
            List = tags;
        }
    }
}
