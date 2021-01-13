using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Pre.Model.Interface.Command.Common;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Command.Common
{
    public class Connection : IConnection
    {
        private readonly Srv.Agent.Command.Common.Connection _connection;

        public Connection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _connection = new Srv.Agent.Command.Common.Connection(agentConfiguration, loggerFactory);
        }

        public bool Remove(App.Dto.Req.Remove.Common.Connection removeItem, CancellationToken cancellationToken = default)
        {
            return _connection.Remove(removeItem);
        }

        public async ValueTask<bool> RemoveAsync(App.Dto.Req.Remove.Common.Connection removeCommonConnection, CancellationToken cancellationToken = default)
        {
            return await _connection.RemoveAsync(removeCommonConnection, cancellationToken);
        }
        
        public App.Dto.Res.Add.Common.Connection Add(App.Dto.Req.Add.Common.Connection addItem, CancellationToken cancellationToken = default)
        {
            return _connection.Add(addItem);
        }

        public App.Dto.Res.Update.Common.Connection Update(App.Dto.Req.Update.Common.Connection updateItem, CancellationToken cancellationToken = default)
        {
            return _connection.Update(updateItem);
        }

        public async ValueTask<App.Dto.Res.Update.Common.Connection> UpdateAsync(App.Dto.Req.Update.Common.Connection updateCommonConnection, CancellationToken cancellationToken = default)
        {
            return await _connection.UpdateAsync(updateCommonConnection, cancellationToken);
        }

        public App.Dto.Res.Copy.Common.Connection Copy(App.Dto.Req.Copy.Common.Connection copyItem, CancellationToken cancellationToken = default)
        {
            return _connection.Copy(copyItem);
        }

        public App.Dto.Res.Export.Common.Connection Export(App.Dto.Req.Export.Common.Connection exportItem, CancellationToken cancellationToken = default)
        {
            return _connection.Export(exportItem);
        }

        public App.Dto.Res.Import.Common.Connection Import(App.Dto.Req.Import.Common.Connection exportItem, CancellationToken cancellationToken = default)
        {
            return _connection.Import(exportItem);
        }

        public async ValueTask<App.Dto.Res.Add.Common.Connection> AddAsync(App.Dto.Req.Add.Common.Connection addCommonConnection, CancellationToken cancellationToken = default)
        {
            return await _connection.AddAsync(addCommonConnection, cancellationToken);
        }

        public async ValueTask<App.Dto.Res.Copy.Common.Connection> CopyAsync(App.Dto.Req.Copy.Common.Connection copyCommonConnection, CancellationToken cancellationToken = default)
        {
            return await _connection.CopyAsync(copyCommonConnection, cancellationToken);
        }

        public async ValueTask<App.Dto.Res.Export.Common.Connection> ExportAsync(App.Dto.Req.Export.Common.Connection exportItem, CancellationToken cancellationToken = default)
        {
            return await _connection.ExportAsync(exportItem, cancellationToken);
        }

        public async ValueTask<App.Dto.Res.Import.Common.Connection> ImportAsync(App.Dto.Req.Import.Common.Connection exportItem, CancellationToken cancellationToken = default)
        {
            return await _connection.ImportAsync(exportItem, cancellationToken);
        }

        public bool ModifyField(App.Dto.Req.ModifyField.Common.Connection modifyFieldItem, CancellationToken cancellationToken = default)
        {
            return _connection.ModifyField(modifyFieldItem);
        }
        
        public async ValueTask<bool> ModifyFieldAsync(App.Dto.Req.ModifyField.Common.Connection modifyCommonConnectionField, CancellationToken cancellationToken = default)
        {
            return await _connection.ModifyFieldAsync(modifyCommonConnectionField, cancellationToken);
        }
    }
}
