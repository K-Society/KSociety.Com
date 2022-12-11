using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.S7.List
{
    [ProtoContract]
    public class Area : ObjectList<S7.Area>
    {
        public Area()
        {
        }

        public Area(List<S7.Area> areas)
        {
            List = areas;
        }
    }
}