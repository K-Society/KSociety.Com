using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;
using Xunit;

namespace KSociety.Com.Srv.Test.Agent.Command.Common;

public class Connection
{
    private readonly Srv.Agent.Command.Common.Connection _connection;

    public Connection()
    {
        var agentConnection = new AgentConnection();
        var loggerFactory = new LoggerFactory();
        _connection = new Srv.Agent.Command.Common.Connection((IComAgentConfiguration)agentConnection.Agent, loggerFactory);
    }

    [Fact]
    public void Remove()
    {
        var result = _connection.Remove(new App.Dto.Req.Remove.Common.Connection());

        Assert.True(result.Result);
    }
}