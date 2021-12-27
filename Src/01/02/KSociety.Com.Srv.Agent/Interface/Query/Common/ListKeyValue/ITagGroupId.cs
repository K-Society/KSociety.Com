using KSociety.Base.Srv.Agent.ListKeyValue;
using KSociety.Base.Srv.Dto;
using System;

namespace KSociety.Com.Srv.Agent.Interface.Query.Common.ListKeyValue;

public interface ITagGroupId : IAgentQueryKeyValueModel<ListKeyValuePair<Guid, string>, Guid, string>
{
}