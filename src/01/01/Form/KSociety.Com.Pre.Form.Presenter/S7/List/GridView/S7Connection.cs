using KSociety.Base.Pre.Form.Presenter.Forms;
using KSociety.Com.Pre.Form.View.Abstractions.S7.List.GridView;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Form.Presenter.S7.List.GridView;

public class S7Connection
    : Presenter<
        IS7Connection,
        Srv.Dto.S7.S7Connection,
        App.Dto.Req.Add.S7.S7Connection,
        App.Dto.Res.Add.S7.S7Connection,
        App.Dto.Req.Update.S7.S7Connection,
        App.Dto.Res.Update.S7.S7Connection,
        App.Dto.Req.Copy.S7.S7Connection,
        App.Dto.Res.Copy.S7.S7Connection,
        App.Dto.Req.ModifyField.S7.S7Connection,
        App.Dto.Res.ModifyField.S7.S7Connection,
        App.Dto.Req.Remove.S7.S7Connection,
        App.Dto.Res.Remove.S7.S7Connection,
        Srv.Dto.S7.List.GridView.S7Connection,
        Srv.Agent.Interface.Command.S7.IS7Connection,
        Srv.Agent.Interface.Query.S7.List.GridView.IS7Connection>
{
    public S7Connection(IS7Connection iView,
        Srv.Agent.Interface.Command.S7.IS7Connection commandModel,
        Srv.Agent.Interface.Query.S7.List.GridView.IS7Connection queryModel,
        ILoggerFactory loggerFactory)
        : base(iView, commandModel, queryModel, loggerFactory)
    {
        //View.DefaultValuesNeeded += ViewOnDefaultValuesNeeded;
    }
}