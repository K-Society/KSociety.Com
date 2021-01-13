using KSociety.Base.Pre.Model;

namespace KSociety.Com.Pre.Model.Interface.Command.Common
{
    public interface ITag : ICommandModel<
        App.Dto.Req.Remove.Common.Tag,
        App.Dto.Req.Add.Common.Tag,
        App.Dto.Res.Add.Common.Tag,
        App.Dto.Req.Update.Common.Tag,
        App.Dto.Res.Update.Common.Tag,
        App.Dto.Req.Copy.Common.Tag,
        App.Dto.Res.Copy.Common.Tag,
        App.Dto.Req.ModifyField.Common.Tag>, 
        IExportModel<App.Dto.Req.Export.Common.Tag,
        App.Dto.Res.Export.Common.Tag>
    {

        
    }
}
