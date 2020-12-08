using KSociety.Base.Srv.Agent;

namespace KSociety.Com.Srv.Agent
{
    public class ComAgentConfiguration : AgentConfiguration, IComAgentConfiguration
    {
        public ComAgentConfiguration(string connectionUrl, bool debugFlag)
            : base(connectionUrl, debugFlag)
        {

        }
    }
}
