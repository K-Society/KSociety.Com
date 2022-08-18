using KSociety.Base.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Srv.Agent.Command.Common;

public class Connection : KSociety.Base.Srv.Agent.AgentCommandImportExport<
    KSociety.Com.Srv.Contract.Command.Common.IConnection,
    KSociety.Com.Srv.Contract.Command.Common.IConnectionAsync,
    KSociety.Com.App.Dto.Req.Add.Common.Connection, KSociety.Com.App.Dto.Res.Add.Common.Connection,
    KSociety.Com.App.Dto.Req.Update.Common.Connection, KSociety.Com.App.Dto.Res.Update.Common.Connection,
    KSociety.Com.App.Dto.Req.Copy.Common.Connection, KSociety.Com.App.Dto.Res.Copy.Common.Connection,
    KSociety.Com.App.Dto.Req.ModifyField.Common.Connection, KSociety.Com.App.Dto.Res.ModifyField.Common.Connection,
    KSociety.Com.App.Dto.Req.Remove.Common.Connection, KSociety.Com.App.Dto.Res.Remove.Common.Connection,
    KSociety.Com.App.Dto.Req.Import.Common.Connection, KSociety.Com.App.Dto.Res.Import.Common.Connection,
    KSociety.Com.App.Dto.Req.Export.Common.Connection, KSociety.Com.App.Dto.Res.Export.Common.Connection>, 
    KSociety.Com.Srv.Agent.Interface.Command.Common.IConnection
{
    public Connection(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }
    
}