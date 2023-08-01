using KSociety.Base.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Srv.Agent.Command.Common;

public class TagGroup : KSociety.Base.Srv.Agent.AgentCommandImportExport<
    KSociety.Com.Srv.Contract.Command.Common.ITagGroup,
    KSociety.Com.Srv.Contract.Command.Common.ITagGroupAsync,
    KSociety.Com.App.Dto.Req.Add.Common.TagGroup, KSociety.Com.App.Dto.Res.Add.Common.TagGroup,
    KSociety.Com.App.Dto.Req.Update.Common.TagGroup, KSociety.Com.App.Dto.Res.Update.Common.TagGroup,
    KSociety.Com.App.Dto.Req.Copy.Common.TagGroup, KSociety.Com.App.Dto.Res.Copy.Common.TagGroup,
    KSociety.Com.App.Dto.Req.ModifyField.Common.TagGroup, KSociety.Com.App.Dto.Res.ModifyField.Common.TagGroup,
    KSociety.Com.App.Dto.Req.Remove.Common.TagGroup, KSociety.Com.App.Dto.Res.Remove.Common.TagGroup,
    KSociety.Com.App.Dto.Req.Import.Common.TagGroup, KSociety.Com.App.Dto.Res.Import.Common.TagGroup,
    KSociety.Com.App.Dto.Req.Export.Common.TagGroup, KSociety.Com.App.Dto.Res.Export.Common.TagGroup>, KSociety.Com.Srv.Agent.Interface.Command.Common.ITagGroup
{
    public TagGroup(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }
}