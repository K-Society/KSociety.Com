using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Import.Common
{
    [ProtoContract]
    public class Tag : ImportReq
    {
        public Tag() { }

        public Tag(
            string fileName,
            byte[] byteArray
        )
        {
            FileName = fileName;
            ByteArray = byteArray;
        }
    }
}