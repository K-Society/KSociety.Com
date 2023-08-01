using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Remove.Common
{
    [ProtoContract]
    public class Connection : IResponse
    {
        [ProtoMember(1)] public bool Result { get; set; }

        public Connection() { }

        public Connection(bool result)
        {
            Result = result;
        }
    }
}