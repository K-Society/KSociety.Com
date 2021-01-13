using KSociety.Base.Pre.Model;

namespace KSociety.Com.Pre.Model.Interface.Command.Common
{
    public interface ITagGroup : ICommandModel<
        App.Dto.Req.Remove.Common.TagGroup,
        App.Dto.Req.Add.Common.TagGroup,
        App.Dto.Res.Add.Common.TagGroup,
        App.Dto.Req.Update.Common.TagGroup,
        App.Dto.Res.Update.Common.TagGroup,
        App.Dto.Req.Copy.Common.TagGroup,
        App.Dto.Res.Copy.Common.TagGroup,
        App.Dto.Req.ModifyField.Common.TagGroup>,
        IExportModel<App.Dto.Req.Export.Common.TagGroup,
            App.Dto.Res.Export.Common.TagGroup>,
        IImportModel<App.Dto.Req.Import.Common.TagGroup,
            App.Dto.Res.Import.Common.TagGroup>
    {
        
    }
}
