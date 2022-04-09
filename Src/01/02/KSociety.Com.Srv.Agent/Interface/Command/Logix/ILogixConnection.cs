using KSociety.Base.Srv.Agent;

namespace KSociety.Com.Srv.Agent.Interface.Command.Logix;

public interface ILogixConnection : IAgentCommandImportExport<
    App.Dto.Req.Add.Logix.LogixConnection,
    App.Dto.Res.Add.Logix.LogixConnection,
    App.Dto.Req.Update.Logix.LogixConnection,
    App.Dto.Res.Update.Logix.LogixConnection,
    App.Dto.Req.Copy.Logix.LogixConnection,
    App.Dto.Res.Copy.Logix.LogixConnection,
    App.Dto.Req.ModifyField.Logix.LogixConnection,
    App.Dto.Res.ModifyField.Logix.LogixConnection,
    App.Dto.Req.Remove.Logix.LogixConnection,
    App.Dto.Res.Remove.Logix.LogixConnection,
    App.Dto.Req.Import.Logix.LogixConnection,
    App.Dto.Res.Import.Logix.LogixConnection,
    App.Dto.Req.Export.Logix.LogixConnection,
    App.Dto.Res.Export.Logix.LogixConnection>
{

}