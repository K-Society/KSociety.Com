using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Export.S7;

[ProtoContract]
public class S7Tag : ExportReq
{
    public S7Tag() { }

    public S7Tag(
        string fileName
    )
    {
        FileName = fileName;
    }
}