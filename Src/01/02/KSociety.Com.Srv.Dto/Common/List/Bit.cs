using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common.List
{
    [ProtoContract]
    public class Bit : ObjectList<Common.Bit>
    {
        public Bit()
        {

        }

        public Bit(List<Common.Bit> bits)
        {
            List = bits;
        }
    }
}