using KSociety.Base.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Srv.Agent.Command.Logix;

public class LogixTag : KSociety.Base.Srv.Agent.AgentCommandImportExport<
    KSociety.Com.Srv.Contract.Command.Logix.ITag,
    KSociety.Com.Srv.Contract.Command.Logix.ITagAsync,
    KSociety.Com.App.Dto.Req.Add.Logix.LogixTag, KSociety.Com.App.Dto.Res.Add.Logix.LogixTag,
    KSociety.Com.App.Dto.Req.Update.Logix.LogixTag, KSociety.Com.App.Dto.Res.Update.Logix.LogixTag,
    KSociety.Com.App.Dto.Req.Copy.Logix.LogixTag, KSociety.Com.App.Dto.Res.Copy.Logix.LogixTag,
    KSociety.Com.App.Dto.Req.ModifyField.Logix.LogixTag, KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixTag,
    KSociety.Com.App.Dto.Req.Remove.Logix.LogixTag, KSociety.Com.App.Dto.Res.Remove.Logix.LogixTag,
    KSociety.Com.App.Dto.Req.Import.Logix.LogixTag, KSociety.Com.App.Dto.Res.Import.Logix.LogixTag,
    KSociety.Com.App.Dto.Req.Export.Logix.LogixTag, KSociety.Com.App.Dto.Res.Export.Logix.LogixTag>, 
    KSociety.Com.Srv.Agent.Interface.Command.Logix.ILogixTag
{
    public LogixTag(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }
}