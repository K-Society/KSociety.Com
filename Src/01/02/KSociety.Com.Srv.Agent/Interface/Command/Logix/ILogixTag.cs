using KSociety.Base.Srv.Agent;

namespace KSociety.Com.Srv.Agent.Interface.Command.Logix;

public interface ILogixTag : IAgentCommandImportExport<
        App.Dto.Req.Add.Logix.LogixTag,
        App.Dto.Res.Add.Logix.LogixTag,
        App.Dto.Req.Update.Logix.LogixTag,
        App.Dto.Res.Update.Logix.LogixTag,
        App.Dto.Req.Copy.Logix.LogixTag,
        App.Dto.Res.Copy.Logix.LogixTag,
        App.Dto.Req.ModifyField.Logix.LogixTag,
        App.Dto.Res.ModifyField.Logix.LogixTag,
        App.Dto.Req.Remove.Logix.LogixTag,
        App.Dto.Res.Remove.Logix.LogixTag,
        App.Dto.Req.Import.Logix.LogixTag,
        App.Dto.Res.Import.Logix.LogixTag,
        App.Dto.Req.Export.Logix.LogixTag,
        App.Dto.Res.Export.Logix.LogixTag>
{

}