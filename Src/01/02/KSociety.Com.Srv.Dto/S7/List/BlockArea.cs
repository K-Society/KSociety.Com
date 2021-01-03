using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.S7.List
{
    [ProtoContract]
    public class BlockArea : ObjectList<S7.BlockArea>
    {
        public BlockArea()
        {
        }

        public BlockArea(List<S7.BlockArea> blockAreas)
        {
            List = blockAreas;
        }
    }
}
