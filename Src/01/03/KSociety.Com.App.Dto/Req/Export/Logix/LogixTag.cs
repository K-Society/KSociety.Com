using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Export.Logix
{
    [ProtoContract]
    public class LogixTag : ExportReq
    {
        public LogixTag() { }

        public LogixTag(
            string fileName
        )
        {
            FileName = fileName;
        }
    }
}