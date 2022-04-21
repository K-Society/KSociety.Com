using KSociety.Base.Srv.Agent;

namespace KSociety.Com.Srv.Agent.Interface.Command.Common;

public interface IConnection : IAgentCommandImportExport<
        App.Dto.Req.Add.Common.Connection,
        App.Dto.Res.Add.Common.Connection,
        App.Dto.Req.Update.Common.Connection,
        App.Dto.Res.Update.Common.Connection,
        App.Dto.Req.Copy.Common.Connection,
        App.Dto.Res.Copy.Common.Connection,
        App.Dto.Req.ModifyField.Common.Connection,
        App.Dto.Res.ModifyField.Common.Connection,
        App.Dto.Req.Remove.Common.Connection,
        App.Dto.Res.Remove.Common.Connection,
        App.Dto.Req.Import.Common.Connection,
        App.Dto.Res.Import.Common.Connection,
        App.Dto.Req.Export.Common.Connection,
        App.Dto.Res.Export.Common.Connection>
{

}