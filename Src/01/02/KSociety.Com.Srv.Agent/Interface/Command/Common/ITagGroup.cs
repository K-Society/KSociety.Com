using KSociety.Base.Srv.Agent;

namespace KSociety.Com.Srv.Agent.Interface.Command.Common
{
    public interface ITagGroup : IAgentCommand<
        App.Dto.Req.Remove.Common.TagGroup,
        App.Dto.Req.Add.Common.TagGroup,
        App.Dto.Res.Add.Common.TagGroup,
        App.Dto.Req.Update.Common.TagGroup,
        App.Dto.Res.Update.Common.TagGroup,
        App.Dto.Req.Copy.Common.TagGroup,
        App.Dto.Res.Copy.Common.TagGroup,
        App.Dto.Req.ModifyField.Common.TagGroup>,
        IAgentExportModel<App.Dto.Req.Export.Common.TagGroup,
            App.Dto.Res.Export.Common.TagGroup>,
        IAgentImportModel<App.Dto.Req.Import.Common.TagGroup,
            App.Dto.Res.Import.Common.TagGroup>
    {
    }
}
