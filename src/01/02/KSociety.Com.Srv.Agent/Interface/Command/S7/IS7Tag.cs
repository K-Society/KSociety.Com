using KSociety.Base.Srv.Agent;

namespace KSociety.Com.Srv.Agent.Interface.Command.S7;

public interface IS7Tag : IAgentCommandImportExport<
        App.Dto.Req.Add.S7.S7Tag,
        App.Dto.Res.Add.S7.S7Tag,
        App.Dto.Req.Update.S7.S7Tag,
        App.Dto.Res.Update.S7.S7Tag,
        App.Dto.Req.Copy.S7.S7Tag,
        App.Dto.Res.Copy.S7.S7Tag,
        App.Dto.Req.ModifyField.S7.S7Tag,
        App.Dto.Res.ModifyField.S7.S7Tag,
        App.Dto.Req.Remove.S7.S7Tag,
        App.Dto.Res.Remove.S7.S7Tag,
        App.Dto.Req.Import.S7.S7Tag,
        App.Dto.Res.Import.S7.S7Tag,
        App.Dto.Req.Export.S7.S7Tag,
        App.Dto.Res.Export.S7.S7Tag>
{

}