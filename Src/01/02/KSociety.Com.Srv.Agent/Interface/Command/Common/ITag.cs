using KSociety.Base.Srv.Agent;

namespace KSociety.Com.Srv.Agent.Interface.Command.Common
{
    public interface ITag : IAgentCommand<
            App.Dto.Req.Remove.Common.Tag,
            App.Dto.Req.Add.Common.Tag,
            App.Dto.Res.Add.Common.Tag,
            App.Dto.Req.Update.Common.Tag,
            App.Dto.Res.Update.Common.Tag,
            App.Dto.Req.Copy.Common.Tag,
            App.Dto.Res.Copy.Common.Tag,
            App.Dto.Req.ModifyField.Common.Tag>,
        IAgentExportModel<App.Dto.Req.Export.Common.Tag,
            App.Dto.Res.Export.Common.Tag>,
        IAgentImportModel<App.Dto.Req.Import.Common.Tag,
            App.Dto.Res.Import.Common.Tag>
    {


    }
}
