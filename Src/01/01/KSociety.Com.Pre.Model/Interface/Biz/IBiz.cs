using System.Threading.Tasks;

namespace KSociety.Com.Pre.Model.Interface.Biz
{
    public interface IBiz
    {
        ValueTask SendHeartBeatAsync();

        ValueTask NotifyTagInvokeAsync(string tagGroup);

        ValueTask GetConnectionStatusAsync(string tagGroup, string connectionName);

        ValueTask GetTagValueAsync(string tagGroup, string tagName);

        ValueTask SetTagValueAsync(string tagGroup, string tagName, string value);
    }
}
