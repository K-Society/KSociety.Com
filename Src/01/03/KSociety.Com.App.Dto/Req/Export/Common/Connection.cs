using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Export.Common;

[ProtoContract]
public class Connection : ExportReq
{
    public Connection() { }

    public Connection(
        string fileName
    )
    {
        FileName = fileName;
    }
}