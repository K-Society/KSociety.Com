using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Com.Srv.Contract.Command.S7;

namespace KSociety.Com.Srv.Behavior.Command.S7
{
    public class CommandAsync : ICommandAsync
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IComponentContext _componentContext;
        private readonly ICommandHandlerAsync _commandHandlerAsync;

        public CommandAsync(
            ILoggerFactory loggerFactory,
            IComponentContext componentContext,
            ICommandHandlerAsync commandHandlerAsync
        )
        {
            _loggerFactory = loggerFactory;
            _componentContext = componentContext;
            _commandHandlerAsync = commandHandlerAsync;

        }

        #region [S7Tag]

        public async ValueTask<App.Dto.Res.Add.S7.S7Tag> AddS7TagAsync(App.Dto.Req.Add.S7.S7Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Add.S7.S7Tag, App.Dto.Res.Add.S7.S7Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Update.S7.S7Tag> UpdateS7TagAsync(App.Dto.Req.Update.S7.S7Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Update.S7.S7Tag, App.Dto.Res.Update.S7.S7Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Copy.S7.S7Tag> CopyS7TagAsync(App.Dto.Req.Copy.S7.S7Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Copy.S7.S7Tag, App.Dto.Res.Copy.S7.S7Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Export.S7.S7Tag> ExportS7TagAsync(App.Dto.Req.Export.S7.S7Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Export.S7.S7Tag, App.Dto.Res.Export.S7.S7Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Import.S7.S7Tag> ImportS7TagAsync(App.Dto.Req.Import.S7.S7Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Import.S7.S7Tag, App.Dto.Res.Import.S7.S7Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.ModifyField.S7.S7Tag> ModifyS7TagFieldAsync(App.Dto.Req.ModifyField.S7.S7Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.ModifyField.S7.S7Tag, App.Dto.Res.ModifyField.S7.S7Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }
        
        public async ValueTask<App.Dto.Res.Remove.S7.S7Tag> RemoveS7TagAsync(App.Dto.Req.Remove.S7.S7Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Remove.S7.S7Tag, App.Dto.Res.Remove.S7.S7Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }
        
        #endregion
        
        #region [S7Connection]

        public async ValueTask<App.Dto.Res.Add.S7.S7Connection> AddS7ConnectionAsync(App.Dto.Req.Add.S7.S7Connection request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Add.S7.S7Connection, App.Dto.Res.Add.S7.S7Connection>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Update.S7.S7Connection> UpdateS7ConnectionAsync(App.Dto.Req.Update.S7.S7Connection request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Update.S7.S7Connection, App.Dto.Res.Update.S7.S7Connection>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Copy.S7.S7Connection> CopyS7ConnectionAsync(App.Dto.Req.Copy.S7.S7Connection request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Copy.S7.S7Connection, App.Dto.Res.Copy.S7.S7Connection>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.ModifyField.S7.S7Connection> ModifyS7ConnectionFieldAsync(App.Dto.Req.ModifyField.S7.S7Connection request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.ModifyField.S7.S7Connection, App.Dto.Res.ModifyField.S7.S7Connection>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }
        
        public async ValueTask<App.Dto.Res.Remove.S7.S7Connection> RemoveS7ConnectionAsync(App.Dto.Req.Remove.S7.S7Connection request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Remove.S7.S7Connection, App.Dto.Res.Remove.S7.S7Connection>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        #endregion
    }
}
