using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Export.Logix
{
    [ProtoContract]
    public class LogixConnection : ExportReq
    {
        public LogixConnection() { }

        public LogixConnection(
            string fileName
        )
        {
            FileName = fileName;
        }
    }
}