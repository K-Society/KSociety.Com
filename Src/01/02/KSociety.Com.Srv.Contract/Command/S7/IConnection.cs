using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Command.S7;

[Service]
public interface IConnection : KSociety.Base.Srv.Contract.ICommandImportExport<
    KSociety.Com.App.Dto.Req.Add.S7.S7Connection, KSociety.Com.App.Dto.Res.Add.S7.S7Connection,
    KSociety.Com.App.Dto.Req.Update.S7.S7Connection, KSociety.Com.App.Dto.Res.Update.S7.S7Connection,
    KSociety.Com.App.Dto.Req.Copy.S7.S7Connection, KSociety.Com.App.Dto.Res.Copy.S7.S7Connection,
    KSociety.Com.App.Dto.Req.ModifyField.S7.S7Connection, KSociety.Com.App.Dto.Res.ModifyField.S7.S7Connection,
    KSociety.Com.App.Dto.Req.Remove.S7.S7Connection, KSociety.Com.App.Dto.Res.Remove.S7.S7Connection,
    KSociety.Com.App.Dto.Req.Import.S7.S7Connection, KSociety.Com.App.Dto.Res.Import.S7.S7Connection,
    KSociety.Com.App.Dto.Req.Export.S7.S7Connection, KSociety.Com.App.Dto.Res.Export.S7.S7Connection>
{
}
