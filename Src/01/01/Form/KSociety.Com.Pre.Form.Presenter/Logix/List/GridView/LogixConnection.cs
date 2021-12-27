using KSociety.Base.Pre.Form.Presenter.Forms;
using KSociety.Com.Pre.Form.View.Abstractions.Logix.List.GridView;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSociety.Com.Pre.Form.Presenter.Logix.List.GridView;

public class LogixConnection
    : Presenter<
        ILogixConnection,
        Srv.Dto.Logix.LogixConnection,
        App.Dto.Req.Remove.Logix.LogixConnection,
        App.Dto.Req.Add.Logix.LogixConnection,
        App.Dto.Res.Add.Logix.LogixConnection,
        App.Dto.Req.Update.Logix.LogixConnection,
        App.Dto.Res.Update.Logix.LogixConnection,
        App.Dto.Req.Copy.Logix.LogixConnection,
        App.Dto.Res.Copy.Logix.LogixConnection,
        App.Dto.Req.ModifyField.Logix.LogixConnection,
        Srv.Dto.Logix.List.GridView.LogixConnection,
        Srv.Agent.Interface.Command.Logix.ILogixConnection,
        Srv.Agent.Interface.Query.Logix.List.GridView.ILogixConnection>
{
    public LogixConnection(ILogixConnection iView,
        Srv.Agent.Interface.Command.Logix.ILogixConnection commandModel,
        Srv.Agent.Interface.Query.Logix.List.GridView.ILogixConnection queryModel,
        ILoggerFactory loggerFactory)
        : base(iView, commandModel, queryModel, loggerFactory)
    {
        //View.DefaultValuesNeeded += ViewOnDefaultValuesNeeded;
    }
}