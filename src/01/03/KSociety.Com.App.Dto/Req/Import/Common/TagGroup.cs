using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Import.Common
{
    [ProtoContract]
    public class TagGroup : ImportReq
    {
        public TagGroup() { }

        public TagGroup(
            string fileName,
            byte[] byteArray
        )
        {
            FileName = fileName;
            ByteArray = byteArray;
        }
    }
}