using KSociety.Base.Srv.Agent;

namespace KSociety.Com.Srv.Agent.Interface.Command.Logix
{
    public interface ILogixConnection : IAgentCommand<
        App.Dto.Req.Remove.Logix.LogixConnection,
        App.Dto.Req.Add.Logix.LogixConnection,
        App.Dto.Res.Add.Logix.LogixConnection,
        App.Dto.Req.Update.Logix.LogixConnection,
        App.Dto.Res.Update.Logix.LogixConnection,
        App.Dto.Req.Copy.Logix.LogixConnection,
        App.Dto.Res.Copy.Logix.LogixConnection,
        App.Dto.Req.ModifyField.Logix.LogixConnection>
    {

    }
}
