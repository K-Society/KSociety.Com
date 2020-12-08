using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Pre.Model.Interface.Command.Logix;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Command.Logix
{
    public class LogixConnection : ILogixConnection
    {
        private readonly Srv.Agent.Command.Logix.LogixConnection _logixConnection;

        public LogixConnection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logixConnection = new Srv.Agent.Command.Logix.LogixConnection(agentConfiguration, loggerFactory);
        }

        public bool Remove(App.Dto.Req.Remove.Logix.LogixConnection removeItem, CancellationToken cancellationToken = default)
        {
            return _logixConnection.Remove(removeItem);
        }

        public async ValueTask<bool> RemoveAsync(App.Dto.Req.Remove.Logix.LogixConnection removeConnection, CancellationToken cancellationToken = default)
        {
            return await _logixConnection.RemoveAsync(removeConnection);
        }

        public App.Dto.Res.Add.Logix.LogixConnection Add(App.Dto.Req.Add.Logix.LogixConnection addConnection, CancellationToken cancellationToken = default)
        {
            return _logixConnection.Add(addConnection);
        }

        public App.Dto.Res.Update.Logix.LogixConnection Update(App.Dto.Req.Update.Logix.LogixConnection updateItem, CancellationToken cancellationToken = default)
        {
            return _logixConnection.Update(updateItem);
        }

        public async ValueTask<App.Dto.Res.Update.Logix.LogixConnection> UpdateAsync(App.Dto.Req.Update.Logix.LogixConnection updateConnection, CancellationToken cancellationToken = default)
        {
            return await _logixConnection.UpdateAsync(updateConnection);
        }

        public App.Dto.Res.Copy.Logix.LogixConnection Copy(App.Dto.Req.Copy.Logix.LogixConnection copyItem, CancellationToken cancellationToken = default)
        {
            return _logixConnection.Copy(copyItem);
        }

        public async ValueTask<App.Dto.Res.Add.Logix.LogixConnection> AddAsync(App.Dto.Req.Add.Logix.LogixConnection addConnection, CancellationToken cancellationToken = default)
        {
            return await _logixConnection.AddAsync(addConnection);
        }
        
        public async ValueTask<App.Dto.Res.Copy.Logix.LogixConnection> CopyAsync(App.Dto.Req.Copy.Logix.LogixConnection copyConnection, CancellationToken cancellationToken = default)
        {
            return await _logixConnection.CopyAsync(copyConnection);
        }

        public bool ModifyField(App.Dto.Req.ModifyField.Logix.LogixConnection modifyConnectionField, CancellationToken cancellationToken = default)
        {
            return _logixConnection.ModifyField(modifyConnectionField);
        }
        
        public async ValueTask<bool> ModifyFieldAsync(App.Dto.Req.ModifyField.Logix.LogixConnection modifyConnectionField, CancellationToken cancellationToken = default)
        {
            return await _logixConnection.ModifyFieldAsync(modifyConnectionField);
        }
    }
}
