using KSociety.Base.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Srv.Agent.Command.Common;

public class Tag : KSociety.Base.Srv.Agent.AgentCommandImportExport<
    KSociety.Com.Srv.Contract.Command.Common.ITag, 
    KSociety.Com.Srv.Contract.Command.Common.ITagAsync,
    KSociety.Com.App.Dto.Req.Add.Common.Tag, KSociety.Com.App.Dto.Res.Add.Common.Tag,
    KSociety.Com.App.Dto.Req.Update.Common.Tag, KSociety.Com.App.Dto.Res.Update.Common.Tag,
    KSociety.Com.App.Dto.Req.Copy.Common.Tag, KSociety.Com.App.Dto.Res.Copy.Common.Tag,
    KSociety.Com.App.Dto.Req.ModifyField.Common.Tag, KSociety.Com.App.Dto.Res.ModifyField.Common.Tag,
    KSociety.Com.App.Dto.Req.Remove.Common.Tag, KSociety.Com.App.Dto.Res.Remove.Common.Tag,
    KSociety.Com.App.Dto.Req.Import.Common.Tag, KSociety.Com.App.Dto.Res.Import.Common.Tag,
    KSociety.Com.App.Dto.Req.Export.Common.Tag, KSociety.Com.App.Dto.Res.Export.Common.Tag>, 
    KSociety.Com.Srv.Agent.Interface.Command.Common.ITag
{
    public Tag(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }
}