using KSociety.Base.Pre.Model.ListKeyValue;
using KSociety.Base.Srv.Dto;
using System;

namespace KSociety.Com.Pre.Model.Interface.Query.Common.ListKeyValue
{
    public interface ITagGroupId : IKbQueryKeyValueModel<KbListKeyValuePair<Guid, string>, Guid, string>
    {
    }
}
