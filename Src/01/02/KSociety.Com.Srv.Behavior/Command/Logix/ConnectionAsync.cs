using Autofac;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Com.Srv.Contract.Command.Logix;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Srv.Behavior.Command.Logix;
public class ConnectionAsync : KSociety.Base.Srv.Behavior.CommandImportExportAsync<
    KSociety.Com.App.Dto.Req.Add.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Add.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Update.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Update.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Copy.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Copy.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.ModifyField.Logix.LogixConnection, KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Remove.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Remove.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Import.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Import.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Export.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Export.Logix.LogixConnection>, IConnectionAsync
{
    public ConnectionAsync(
        ILoggerFactory loggerFactory,
        IComponentContext componentContext,
        ICommandHandlerAsync commandHandlerAsync
    ) : base(loggerFactory, componentContext, commandHandlerAsync)
    {

    }
}
