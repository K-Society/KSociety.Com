using KSociety.Base.Pre.Model;

namespace KSociety.Com.Pre.Model.Interface.Command.Logix
{
    public interface ILogixTag : ICommandModel<
        App.Dto.Req.Remove.Logix.LogixTag,
        App.Dto.Req.Add.Logix.LogixTag,
        App.Dto.Res.Add.Logix.LogixTag,
        App.Dto.Req.Update.Logix.LogixTag,
        App.Dto.Res.Update.Logix.LogixTag,
        App.Dto.Req.Copy.Logix.LogixTag,
        App.Dto.Res.Copy.Logix.LogixTag,
        App.Dto.Req.ModifyField.Logix.LogixTag>,
        IExportModel<App.Dto.Req.Export.Logix.LogixTag,
            App.Dto.Res.Export.Logix.LogixTag>
    {
        
    }
}
