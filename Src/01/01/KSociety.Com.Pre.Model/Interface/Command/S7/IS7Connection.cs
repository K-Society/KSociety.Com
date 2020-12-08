using KSociety.Base.Pre.Model;

namespace KSociety.Com.Pre.Model.Interface.Command.S7
{
    public interface IS7Connection : IKbCommandModel<
        App.Dto.Req.Remove.S7.S7Connection,
        App.Dto.Req.Add.S7.S7Connection,
        App.Dto.Res.Add.S7.S7Connection,
        App.Dto.Req.Update.S7.S7Connection,
        App.Dto.Res.Update.S7.S7Connection,
        App.Dto.Req.Copy.S7.S7Connection,
        App.Dto.Res.Copy.S7.S7Connection,
        App.Dto.Req.ModifyField.S7.S7Connection>
    {
        
    }
}
