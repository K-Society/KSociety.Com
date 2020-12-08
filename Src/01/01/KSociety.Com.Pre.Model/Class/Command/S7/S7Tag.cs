using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Pre.Model.Interface.Command.S7;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Command.S7
{
    public class S7Tag : IS7Tag
    {
        private readonly Srv.Agent.Command.S7.S7Tag _s7Tag;

        public S7Tag(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _s7Tag = new Srv.Agent.Command.S7.S7Tag(agentConfiguration, loggerFactory);
        }

        public bool Remove(App.Dto.Req.Remove.S7.S7Tag removeItem, CancellationToken cancellationToken = default)
        {
            return _s7Tag.Remove(removeItem);
        }

        public async ValueTask<bool> RemoveAsync(App.Dto.Req.Remove.S7.S7Tag removeTag, CancellationToken cancellationToken = default)
        {
            return await _s7Tag.RemoveAsync(removeTag);
        }

        public App.Dto.Res.Add.S7.S7Tag Add(App.Dto.Req.Add.S7.S7Tag addTag, CancellationToken cancellationToken = default)
        {
            return _s7Tag.Add(addTag);
        }

        public App.Dto.Res.Update.S7.S7Tag Update(App.Dto.Req.Update.S7.S7Tag updateItem, CancellationToken cancellationToken = default)
        {
            return _s7Tag.Update(updateItem);
        }

        public async ValueTask<App.Dto.Res.Update.S7.S7Tag> UpdateAsync(App.Dto.Req.Update.S7.S7Tag updateTag, CancellationToken cancellationToken = default)
        {
            return await _s7Tag.UpdateAsync(updateTag);
        }

        public App.Dto.Res.Copy.S7.S7Tag Copy(App.Dto.Req.Copy.S7.S7Tag copyItem, CancellationToken cancellationToken = default)
        {
            return _s7Tag.Copy(copyItem);
        }
        
        public async ValueTask<App.Dto.Res.Add.S7.S7Tag> AddAsync(App.Dto.Req.Add.S7.S7Tag addTag, CancellationToken cancellationToken = default)
        {
            return await _s7Tag.AddAsync(addTag);
        }
        
        public async ValueTask<App.Dto.Res.Copy.S7.S7Tag> CopyAsync(App.Dto.Req.Copy.S7.S7Tag copyTag, CancellationToken cancellationToken = default)
        {
            return await _s7Tag.CopyAsync(copyTag);
        }

        public bool ModifyField(App.Dto.Req.ModifyField.S7.S7Tag modifyTagField, CancellationToken cancellationToken = default)
        {
            return _s7Tag.ModifyField(modifyTagField);
        }

        public async ValueTask<bool> ModifyFieldAsync(App.Dto.Req.ModifyField.S7.S7Tag modifyTagField, CancellationToken cancellationToken = default)
        {
            return await _s7Tag.ModifyFieldAsync(modifyTagField);
        }
    }
}
