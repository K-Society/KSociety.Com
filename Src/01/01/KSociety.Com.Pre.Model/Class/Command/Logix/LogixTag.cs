using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Pre.Model.Interface.Command.Logix;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Command.Logix
{
    public class LogixTag : ILogixTag
    {
        private readonly Srv.Agent.Command.Logix.LogixTag _logixTag;

        public LogixTag(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logixTag = new Srv.Agent.Command.Logix.LogixTag(agentConfiguration, loggerFactory);
        }

        public bool Remove(App.Dto.Req.Remove.Logix.LogixTag removeItem, CancellationToken cancellationToken = default)
        {
            return _logixTag.Remove(removeItem);
        }

        public async ValueTask<bool> RemoveAsync(App.Dto.Req.Remove.Logix.LogixTag removeTag, CancellationToken cancellationToken = default)
        {
            return await _logixTag.RemoveAsync(removeTag);
        }
        
        public App.Dto.Res.Add.Logix.LogixTag Add(App.Dto.Req.Add.Logix.LogixTag addTag, CancellationToken cancellationToken = default)
        {
            return _logixTag.Add(addTag);
        }

        public App.Dto.Res.Update.Logix.LogixTag Update(App.Dto.Req.Update.Logix.LogixTag updateItem, CancellationToken cancellationToken = default)
        {
            return _logixTag.Update(updateItem);
        }

        public async ValueTask<App.Dto.Res.Update.Logix.LogixTag> UpdateAsync(App.Dto.Req.Update.Logix.LogixTag updateTag, CancellationToken cancellationToken = default)
        {
            return await _logixTag.UpdateAsync(updateTag);
        }

        public App.Dto.Res.Copy.Logix.LogixTag Copy(App.Dto.Req.Copy.Logix.LogixTag copyItem, CancellationToken cancellationToken = default)
        {
            return _logixTag.Copy(copyItem);
        }

        public async ValueTask<App.Dto.Res.Add.Logix.LogixTag> AddAsync(App.Dto.Req.Add.Logix.LogixTag addTag, CancellationToken cancellationToken = default)
        {
            return await _logixTag.AddAsync(addTag);
        }
        
        public async ValueTask<App.Dto.Res.Copy.Logix.LogixTag> CopyAsync(App.Dto.Req.Copy.Logix.LogixTag copyTag, CancellationToken cancellationToken = default)
        {
            return await _logixTag.CopyAsync(copyTag);
        }

        public bool ModifyField(App.Dto.Req.ModifyField.Logix.LogixTag modifyTagField, CancellationToken cancellationToken = default)
        {
            return _logixTag.ModifyField(modifyTagField);
        }

        public async ValueTask<bool> ModifyFieldAsync(App.Dto.Req.ModifyField.Logix.LogixTag modifyTagField, CancellationToken cancellationToken = default)
        {
            return await _logixTag.ModifyFieldAsync(modifyTagField);
        }
    }
}
