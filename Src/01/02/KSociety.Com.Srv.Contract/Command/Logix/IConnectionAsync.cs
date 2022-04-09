using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Command.Logix;

[Service]
public interface IConnectionAsync : KSociety.Base.Srv.Contract.ICommandImportExportAsync<
    KSociety.Com.App.Dto.Req.Add.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Add.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Update.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Update.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Copy.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Copy.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.ModifyField.Logix.LogixConnection, KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Remove.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Remove.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Import.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Import.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Export.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Export.Logix.LogixConnection>
{
}
