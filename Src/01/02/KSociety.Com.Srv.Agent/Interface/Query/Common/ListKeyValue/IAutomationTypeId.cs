using KSociety.Base.Srv.Agent.ListKeyValue;
using KSociety.Base.Srv.Dto;

namespace KSociety.Com.Srv.Agent.Interface.Query.Common.ListKeyValue;

public interface IAutomationTypeId : IAgentQueryKeyValueModel<int, string, ListKeyValuePair<int, string>>
{
}