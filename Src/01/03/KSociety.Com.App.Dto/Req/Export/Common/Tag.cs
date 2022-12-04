using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Export.Common
{
    [ProtoContract]
    public class Tag : ExportReq
    {
        public Tag() { }

        public Tag(
            string fileName
        )
        {
            FileName = fileName;
        }
    }
}