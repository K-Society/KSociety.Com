using KSociety.Base.Srv.Agent;

namespace KSociety.Com.Srv.Agent.Interface.Command.Common
{
    public interface IConnection : IAgentCommand<
            App.Dto.Req.Remove.Common.Connection,
            App.Dto.Req.Add.Common.Connection,
            App.Dto.Res.Add.Common.Connection,
            App.Dto.Req.Update.Common.Connection,
            App.Dto.Res.Update.Common.Connection,
            App.Dto.Req.Copy.Common.Connection,
            App.Dto.Res.Copy.Common.Connection,
            App.Dto.Req.ModifyField.Common.Connection>,
        IAgentExportModel<App.Dto.Req.Export.Common.Connection,
            App.Dto.Res.Export.Common.Connection>,
        IAgentImportModel<App.Dto.Req.Import.Common.Connection,
            App.Dto.Res.Import.Common.Connection>
    {

    }
}
