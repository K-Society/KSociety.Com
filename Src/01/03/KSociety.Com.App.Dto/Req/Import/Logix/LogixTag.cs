using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Import.Logix;

[ProtoContract]
public class LogixTag : ImportReq
{
    public LogixTag() { }

    public LogixTag(
        string fileName,
        byte[] byteArray
    )
    {
        FileName = fileName;
        ByteArray = byteArray;
    }
}