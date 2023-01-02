using KSociety.Base.Srv.Agent.ListKeyValue;
using KSociety.Base.Srv.Dto;

namespace KSociety.Com.Srv.Agent.Interface.Query.Common.ListKeyValue;

public interface IInputOutput : IAgentQueryKeyValueModel< string, string, ListKeyValuePair<string, string>>
{
}