using KSociety.Base.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Srv.Agent.Command.S7;

public class S7Connection : KSociety.Base.Srv.Agent.AgentCommandImportExport<
    KSociety.Com.Srv.Contract.Command.S7.IConnection,
    KSociety.Com.Srv.Contract.Command.S7.IConnectionAsync,
    KSociety.Com.App.Dto.Req.Add.S7.S7Connection, KSociety.Com.App.Dto.Res.Add.S7.S7Connection,
    KSociety.Com.App.Dto.Req.Update.S7.S7Connection, KSociety.Com.App.Dto.Res.Update.S7.S7Connection,
    KSociety.Com.App.Dto.Req.Copy.S7.S7Connection, KSociety.Com.App.Dto.Res.Copy.S7.S7Connection,
    KSociety.Com.App.Dto.Req.ModifyField.S7.S7Connection, KSociety.Com.App.Dto.Res.ModifyField.S7.S7Connection,
    KSociety.Com.App.Dto.Req.Remove.S7.S7Connection, KSociety.Com.App.Dto.Res.Remove.S7.S7Connection,
    KSociety.Com.App.Dto.Req.Import.S7.S7Connection, KSociety.Com.App.Dto.Res.Import.S7.S7Connection,
    KSociety.Com.App.Dto.Req.Export.S7.S7Connection, KSociety.Com.App.Dto.Res.Export.S7.S7Connection>, KSociety.Com.Srv.Agent.Interface.Command.S7.IS7Connection
{
    public S7Connection(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }
}