using KSociety.Base.Pre.Model.ListKeyValue;
using KSociety.Base.Srv.Dto;

namespace KSociety.Com.Pre.Model.Interface.Query.Common.ListKeyValue
{
    public interface IInputOutput : IKbQueryKeyValueModel<KbListKeyValuePair<string, string>, string, string>
    {
    }
}
