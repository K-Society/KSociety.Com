using KSociety.Base.Srv.Agent;

namespace KSociety.Com.Srv.Agent.Interface.Command.Common;

public interface ITagGroup : IAgentCommandImportExport<
        App.Dto.Req.Add.Common.TagGroup,
        App.Dto.Res.Add.Common.TagGroup,
        App.Dto.Req.Update.Common.TagGroup,
        App.Dto.Res.Update.Common.TagGroup,
        App.Dto.Req.Copy.Common.TagGroup,
        App.Dto.Res.Copy.Common.TagGroup,
        App.Dto.Req.ModifyField.Common.TagGroup,
        App.Dto.Res.ModifyField.Common.TagGroup,
        App.Dto.Req.Remove.Common.TagGroup,
        App.Dto.Res.Remove.Common.TagGroup,
        App.Dto.Req.Import.Common.TagGroup,
        App.Dto.Res.Import.Common.TagGroup,
        App.Dto.Req.Export.Common.TagGroup,
        App.Dto.Res.Export.Common.TagGroup>
{
}