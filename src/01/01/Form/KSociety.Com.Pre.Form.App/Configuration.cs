using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Form.App;

public partial class Configuration : System.Windows.Forms.Form
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly IComAgentConfiguration _agentConfiguration;

    private readonly View.Abstractions.Common.List.GridView.ITagGroup _tagGroup;
    private readonly View.Abstractions.Logix.List.GridView.ILogixConnection _logixConnection;
    private readonly View.Abstractions.Logix.List.GridView.ILogixTag _logixTag;
    private readonly View.Abstractions.S7.List.GridView.IS7Connection _s7Connection;
    private readonly View.Abstractions.S7.List.GridView.IS7Tag _s7Tag;
    public Configuration(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
        _agentConfiguration = agentConfiguration;
        InitializeComponent();

        _tagGroup = generalTabUserControl1.GetCommonTagGroup();
        _logixConnection = generalTabUserControl1.GetLogixConnection();
        _logixTag = generalTabUserControl1.GetLogixTag();
        _s7Connection = generalTabUserControl1.GetS7Connection();
        _s7Tag = generalTabUserControl1.GetS7Tag();

        Initialize();
    }

    private void Initialize()
    {
        var tagGroupCommandModel = new KSociety.Com.Srv.Agent.Command.Common.TagGroup(_agentConfiguration, _loggerFactory);
        var tagGroupQueryModel = new KSociety.Com.Srv.Agent.Query.Common.List.GridView.TagGroup(_agentConfiguration, _loggerFactory);
        var tagGroupPresenter = new KSociety.Com.Pre.Form.Presenter.Common.List.GridView.TagGroup(_tagGroup, tagGroupCommandModel, tagGroupQueryModel, _loggerFactory);

        var logixConnectionCommandModel = new KSociety.Com.Srv.Agent.Command.Logix.LogixConnection(_agentConfiguration, _loggerFactory);
        var logixConnectionQueryModel = new KSociety.Com.Srv.Agent.Query.Logix.List.GridView.LogixConnection(_agentConfiguration, _loggerFactory);
        var logixConnectionPresenter = new KSociety.Com.Pre.Form.Presenter.Logix.List.GridView.LogixConnection(_logixConnection, logixConnectionCommandModel, logixConnectionQueryModel, _loggerFactory);

        var logixTagCommandModel = new KSociety.Com.Srv.Agent.Command.Logix.LogixTag(_agentConfiguration, _loggerFactory);
        var logixTagQueryModel = new KSociety.Com.Srv.Agent.Query.Logix.List.GridView.LogixTag(_agentConfiguration, _loggerFactory);
        var logixTagPresenter = new KSociety.Com.Pre.Form.Presenter.Logix.List.GridView.LogixTag(_logixTag, logixTagCommandModel, logixTagQueryModel, _loggerFactory);

        var s7ConnectionCommandModel = new KSociety.Com.Srv.Agent.Command.S7.S7Connection(_agentConfiguration, _loggerFactory);
        var s7ConnectionQueryModel = new KSociety.Com.Srv.Agent.Query.S7.List.GridView.S7Connection(_agentConfiguration, _loggerFactory);
        var s7Presenter = new KSociety.Com.Pre.Form.Presenter.S7.List.GridView.S7Connection(_s7Connection, s7ConnectionCommandModel, s7ConnectionQueryModel, _loggerFactory);

        var s7TagCommandModel = new KSociety.Com.Srv.Agent.Command.S7.S7Tag(_agentConfiguration, _loggerFactory);
        var s7TagQueryModel = new KSociety.Com.Srv.Agent.Query.S7.List.GridView.S7Tag(_agentConfiguration, _loggerFactory);
        var s7TagPresenter = new KSociety.Com.Pre.Form.Presenter.S7.List.GridView.S7Tag(_s7Tag, s7TagCommandModel, s7TagQueryModel, _loggerFactory);

    }
}