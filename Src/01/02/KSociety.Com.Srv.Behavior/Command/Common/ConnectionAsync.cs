using Autofac;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Com.Srv.Contract.Command.Common;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Srv.Behavior.Command.Common;
public class ConnectionAsync : KSociety.Base.Srv.Behavior.CommandImportExportAsync<
    KSociety.Com.App.Dto.Req.Add.Common.Connection, KSociety.Com.App.Dto.Res.Add.Common.Connection,
    KSociety.Com.App.Dto.Req.Update.Common.Connection, KSociety.Com.App.Dto.Res.Update.Common.Connection,
    KSociety.Com.App.Dto.Req.Copy.Common.Connection, KSociety.Com.App.Dto.Res.Copy.Common.Connection,
    KSociety.Com.App.Dto.Req.ModifyField.Common.Connection, KSociety.Com.App.Dto.Res.ModifyField.Common.Connection,
    KSociety.Com.App.Dto.Req.Remove.Common.Connection, KSociety.Com.App.Dto.Res.Remove.Common.Connection,
    KSociety.Com.App.Dto.Req.Import.Common.Connection, KSociety.Com.App.Dto.Res.Import.Common.Connection,
    KSociety.Com.App.Dto.Req.Export.Common.Connection, KSociety.Com.App.Dto.Res.Export.Common.Connection>, IConnectionAsync
{
    public ConnectionAsync(
        ILoggerFactory loggerFactory,
        IComponentContext componentContext,
        ICommandHandlerAsync commandHandlerAsync
    ) : base (loggerFactory, componentContext, commandHandlerAsync)
    {

    }
}
