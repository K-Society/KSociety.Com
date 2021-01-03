using KSociety.Base.Pre.Model;

namespace KSociety.Com.Pre.Model.Interface.Command.S7
{
    public interface IS7Tag : ICommandModel<
        App.Dto.Req.Remove.S7.S7Tag,
        App.Dto.Req.Add.S7.S7Tag,
        App.Dto.Res.Add.S7.S7Tag,
        App.Dto.Req.Update.S7.S7Tag,
        App.Dto.Res.Update.S7.S7Tag,
        App.Dto.Req.Copy.S7.S7Tag,
        App.Dto.Res.Copy.S7.S7Tag,
        App.Dto.Req.ModifyField.S7.S7Tag>
    {
        
    }
}
