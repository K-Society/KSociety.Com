using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.View.Common.List.GridView
{
    [ProtoContract]
    public class TagGroupReady : KbList<Common.TagGroupReady>
    {
        public TagGroupReady() { }

        public TagGroupReady
        (
            List<Common.TagGroupReady> tagGroupReady
        )
        {
            List = tagGroupReady;
        }
    }
}
