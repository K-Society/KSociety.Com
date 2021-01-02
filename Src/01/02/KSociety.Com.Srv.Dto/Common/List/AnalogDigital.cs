using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common.List
{
    [ProtoContract]
    public class AnalogDigital : ObjectList<Common.AnalogDigital>
    {
        public AnalogDigital()
        {
        }

        public AnalogDigital(List<Common.AnalogDigital> analogDigits)
        {
            List = analogDigits;
        }
    }
}
