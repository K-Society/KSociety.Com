using KSociety.Base.Srv.Agent;

namespace KSociety.Com.Srv.Agent.Interface.Command.S7;

public interface IS7Connection : IAgentCommand<
        App.Dto.Req.Remove.S7.S7Connection,
        App.Dto.Req.Add.S7.S7Connection,
        App.Dto.Res.Add.S7.S7Connection,
        App.Dto.Req.Update.S7.S7Connection,
        App.Dto.Res.Update.S7.S7Connection,
        App.Dto.Req.Copy.S7.S7Connection,
        App.Dto.Res.Copy.S7.S7Connection,
        App.Dto.Req.ModifyField.S7.S7Connection>,
    IAgentExportModel<App.Dto.Req.Export.S7.S7Connection,
        App.Dto.Res.Export.S7.S7Connection>,
    IAgentImportModel<App.Dto.Req.Import.S7.S7Connection,
        App.Dto.Res.Import.S7.S7Connection>
{

}