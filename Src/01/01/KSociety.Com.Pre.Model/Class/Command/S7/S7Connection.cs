using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Pre.Model.Interface.Command.S7;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Command.S7
{
    public class S7Connection : IS7Connection
    {
        private readonly Srv.Agent.Command.S7.S7Connection _s7Connection;

        public S7Connection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _s7Connection = new Srv.Agent.Command.S7.S7Connection(agentConfiguration, loggerFactory);
        }

        public bool Remove(App.Dto.Req.Remove.S7.S7Connection removeItem, CancellationToken cancellationToken = default)
        {
            return _s7Connection.Remove(removeItem);
        }

        public async ValueTask<bool> RemoveAsync(App.Dto.Req.Remove.S7.S7Connection removeS7Connection, CancellationToken cancellationToken = default)
        {
            return await _s7Connection.RemoveAsync(removeS7Connection, cancellationToken);
        }
        
        public App.Dto.Res.Add.S7.S7Connection Add(App.Dto.Req.Add.S7.S7Connection addS7Connection, CancellationToken cancellationToken = default)
        {
            return _s7Connection.Add(addS7Connection);
        }

        public App.Dto.Res.Update.S7.S7Connection Update(App.Dto.Req.Update.S7.S7Connection updateItem, CancellationToken cancellationToken = default)
        {
            return _s7Connection.Update(updateItem);
        }

        public async ValueTask<App.Dto.Res.Update.S7.S7Connection> UpdateAsync(App.Dto.Req.Update.S7.S7Connection updateS7Connection, CancellationToken cancellationToken = default)
        {
            return await _s7Connection.UpdateAsync(updateS7Connection, cancellationToken);
        }

        public App.Dto.Res.Copy.S7.S7Connection Copy(App.Dto.Req.Copy.S7.S7Connection copyItem, CancellationToken cancellationToken = default)
        {
            return _s7Connection.Copy(copyItem);
        }
        
        public async ValueTask<App.Dto.Res.Add.S7.S7Connection> AddAsync(App.Dto.Req.Add.S7.S7Connection addS7Connection, CancellationToken cancellationToken = default)
        {
            return await _s7Connection.AddAsync(addS7Connection, cancellationToken);
        }
        
        public async ValueTask<App.Dto.Res.Copy.S7.S7Connection> CopyAsync(App.Dto.Req.Copy.S7.S7Connection copyS7Connection, CancellationToken cancellationToken = default)
        {
            return await _s7Connection.CopyAsync(copyS7Connection, cancellationToken);
        }

        public bool ModifyField(App.Dto.Req.ModifyField.S7.S7Connection modifyS7ConnectionField, CancellationToken cancellationToken = default)
        {
            return _s7Connection.ModifyField(modifyS7ConnectionField);
        }
        
        public async ValueTask<bool> ModifyFieldAsync(App.Dto.Req.ModifyField.S7.S7Connection modifyS7ConnectionField, CancellationToken cancellationToken = default)
        {
            return await _s7Connection.ModifyFieldAsync(modifyS7ConnectionField, cancellationToken);
        }
    }
}
