using KSociety.Base.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Srv.Agent.Command.Logix;

public class LogixConnection : KSociety.Base.Srv.Agent.AgentCommandImportExport<
    KSociety.Com.Srv.Contract.Command.Logix.IConnection,
    KSociety.Com.Srv.Contract.Command.Logix.IConnectionAsync,
    KSociety.Com.App.Dto.Req.Add.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Add.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Update.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Update.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Copy.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Copy.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.ModifyField.Logix.LogixConnection, KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Remove.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Remove.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Import.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Import.Logix.LogixConnection,
    KSociety.Com.App.Dto.Req.Export.Logix.LogixConnection, KSociety.Com.App.Dto.Res.Export.Logix.LogixConnection>, KSociety.Com.Srv.Agent.Interface.Command.Logix.ILogixConnection
{
    public LogixConnection(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }
}