using KSociety.Base.Srv.Agent.ListKeyValue;
using KSociety.Base.Srv.Dto;

namespace KSociety.Com.Srv.Agent.Interface.Query.Common.ListKeyValue;

public interface IAutomationTypeId : IAgentQueryKeyValueModel<ListKeyValuePair<int, string>, int, string>
{
}