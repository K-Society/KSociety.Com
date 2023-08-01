using KSociety.Base.Pre.Form.Presenter.Forms;
using KSociety.Com.Pre.Form.View.Abstractions.Logix.List.GridView;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Form.Presenter.Logix.List.GridView;

public class LogixTag
    : Presenter<
        ILogixTag,
        Srv.Dto.Logix.LogixTag,
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
        Srv.Dto.Logix.List.GridView.LogixTag,
        Srv.Agent.Interface.Command.Logix.ILogixTag,
        Srv.Agent.Interface.Query.Logix.List.GridView.ILogixTag>
{
    public LogixTag(ILogixTag iView,
        Srv.Agent.Interface.Command.Logix.ILogixTag commandModel,
        Srv.Agent.Interface.Query.Logix.List.GridView.ILogixTag queryModel,
        ILoggerFactory loggerFactory)
        : base(iView, commandModel, queryModel, loggerFactory)
    {
        //View.DefaultValuesNeeded += ViewOnDefaultValuesNeeded;
    }
}