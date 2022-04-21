using KSociety.Base.App.Shared.Dto.Req;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Import.Logix;

[ProtoContract]
public class LogixConnection : ImportReq
{
    public LogixConnection() { }

    public LogixConnection(
        string fileName,
        byte[] byteArray
    )
    {
        FileName = fileName;
        ByteArray = byteArray;
    }
}