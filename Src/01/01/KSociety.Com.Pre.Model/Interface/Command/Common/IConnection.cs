using KSociety.Base.Pre.Model;

namespace KSociety.Com.Pre.Model.Interface.Command.Common
{
    public interface IConnection : IKbCommandModel<
        App.Dto.Req.Remove.Common.Connection, 
        App.Dto.Req.Add.Common.Connection,
        App.Dto.Res.Add.Common.Connection,
        App.Dto.Req.Update.Common.Connection,
        App.Dto.Res.Update.Common.Connection,
        App.Dto.Req.Copy.Common.Connection,
        App.Dto.Res.Copy.Common.Connection,
        App.Dto.Req.ModifyField.Common.Connection
    >, IKbExportModel<App.Dto.Req.Export.Common.Connection,
        App.Dto.Res.Export.Common.Connection>
    {

    }
}
