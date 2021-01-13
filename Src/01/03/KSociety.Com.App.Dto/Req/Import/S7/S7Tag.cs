using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Import.S7
{
    [ProtoContract]
    public class S7Tag : ImportReq
    {
        public S7Tag() { }

        public S7Tag(
            string fileName,
            byte[] byteArray
        )
        {
            FileName = fileName;
            ByteArray = byteArray;
        }
    }
}
