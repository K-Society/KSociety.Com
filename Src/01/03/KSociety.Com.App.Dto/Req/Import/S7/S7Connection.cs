using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Import.S7
{
    [ProtoContract]
    public class S7Connection : ImportReq
    {
        public S7Connection() { }

        public S7Connection(
            string fileName,
            byte[] byteArray
        )
        {
            FileName = fileName;
            ByteArray = byteArray;
        }
    }
}
