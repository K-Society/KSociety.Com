using KSociety.Base.Srv.Agent;

namespace KSociety.Com.Srv.Test.Agent
{
    public class AgentConnection 
    {
        public IAgentConfiguration Agent { get; }

        public AgentConnection()
        {
            Agent =  new KSociety.Base.Srv.Agent.AgentConfiguration("http://localhost:5001", true);
        }
    }
}
