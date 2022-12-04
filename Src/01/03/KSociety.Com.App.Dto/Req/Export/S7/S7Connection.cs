using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Export.S7
{
    [ProtoContract]
    public class S7Connection : ExportReq
    {
        public S7Connection() { }

        public S7Connection(
            string fileName
        )
        {
            FileName = fileName;
        }
    }
}