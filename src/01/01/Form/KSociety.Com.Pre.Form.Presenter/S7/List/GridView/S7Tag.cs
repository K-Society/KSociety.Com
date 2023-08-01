using KSociety.Base.Pre.Form.Presenter.Forms;
using KSociety.Com.Pre.Form.View.Abstractions.S7.List.GridView;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Form.Presenter.S7.List.GridView;

public class S7Tag
    : Presenter<
        IS7Tag,
        Srv.Dto.S7.S7Tag,
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
        Srv.Dto.S7.List.GridView.S7Tag,
        Srv.Agent.Interface.Command.S7.IS7Tag,
        Srv.Agent.Interface.Query.S7.List.GridView.IS7Tag>
{
    public S7Tag(IS7Tag iView,
        Srv.Agent.Interface.Command.S7.IS7Tag commandModel,
        Srv.Agent.Interface.Query.S7.List.GridView.IS7Tag queryModel,
        ILoggerFactory loggerFactory)
        : base(iView, commandModel, queryModel, loggerFactory)
    {
        //View.DefaultValuesNeeded += ViewOnDefaultValuesNeeded;
    }
}