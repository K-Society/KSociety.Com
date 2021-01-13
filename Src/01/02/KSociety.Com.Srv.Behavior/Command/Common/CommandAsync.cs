using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Com.Srv.Contract.Command.Common;

namespace KSociety.Com.Srv.Behavior.Command.Common
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

        //public async ValueTask<App.Com.Dto.Res.ModifyField.Common.TagGroup> ModifyTagGroupFieldAsync(App.Com.Dto.Req.ModifyField.Common.TagGroup request, CallContext context = default)
        //{
        //    return await _commandHandler.ExecuteAsync<App.Com.Dto.Req.ModifyField.Common.TagGroup, App.Com.Dto.Res.ModifyField.Common.TagGroup>(_logger, _componentContext, request);
        //}

        #region [Tag]

        public async ValueTask<App.Dto.Res.Add.Common.Tag> AddTagAsync(App.Dto.Req.Add.Common.Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Add.Common.Tag, App.Dto.Res.Add.Common.Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Update.Common.Tag> UpdateTagAsync(App.Dto.Req.Update.Common.Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Update.Common.Tag, App.Dto.Res.Update.Common.Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Copy.Common.Tag> CopyTagAsync(App.Dto.Req.Copy.Common.Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Copy.Common.Tag, App.Dto.Res.Copy.Common.Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Export.Common.Tag> ExportTagAsync(App.Dto.Req.Export.Common.Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Export.Common.Tag, App.Dto.Res.Export.Common.Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Import.Common.Tag> ImportTagAsync(App.Dto.Req.Import.Common.Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Import.Common.Tag, App.Dto.Res.Import.Common.Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.ModifyField.Common.Tag> ModifyTagFieldAsync(App.Dto.Req.ModifyField.Common.Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.ModifyField.Common.Tag, App.Dto.Res.ModifyField.Common.Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Remove.Common.Tag> RemoveTagAsync(App.Dto.Req.Remove.Common.Tag request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Remove.Common.Tag, App.Dto.Res.Remove.Common.Tag>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        #endregion

        #region [TagGroup]

        public async ValueTask<App.Dto.Res.Add.Common.TagGroup> AddTagGroupAsync(App.Dto.Req.Add.Common.TagGroup request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Add.Common.TagGroup, App.Dto.Res.Add.Common.TagGroup>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Update.Common.TagGroup> UpdateTagGroupAsync(App.Dto.Req.Update.Common.TagGroup request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Update.Common.TagGroup, App.Dto.Res.Update.Common.TagGroup>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Copy.Common.TagGroup> CopyTagGroupAsync(App.Dto.Req.Copy.Common.TagGroup request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Copy.Common.TagGroup, App.Dto.Res.Copy.Common.TagGroup>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Export.Common.TagGroup> ExportTagGroupAsync(App.Dto.Req.Export.Common.TagGroup request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Export.Common.TagGroup, App.Dto.Res.Export.Common.TagGroup>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Import.Common.TagGroup> ImportTagGroupAsync(App.Dto.Req.Import.Common.TagGroup request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Import.Common.TagGroup, App.Dto.Res.Import.Common.TagGroup>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.ModifyField.Common.TagGroup> ModifyTagGroupFieldAsync(App.Dto.Req.ModifyField.Common.TagGroup request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.ModifyField.Common.TagGroup, App.Dto.Res.ModifyField.Common.TagGroup>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Remove.Common.TagGroup> RemoveTagGroupAsync(App.Dto.Req.Remove.Common.TagGroup request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Remove.Common.TagGroup, App.Dto.Res.Remove.Common.TagGroup>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        #endregion

        #region [Connection]

        public async ValueTask<App.Dto.Res.Add.Common.Connection> AddConnectionAsync(App.Dto.Req.Add.Common.Connection request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Add.Common.Connection, App.Dto.Res.Add.Common.Connection>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Update.Common.Connection> UpdateConnectionAsync(App.Dto.Req.Update.Common.Connection request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Update.Common.Connection, App.Dto.Res.Update.Common.Connection>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Copy.Common.Connection> CopyConnectionAsync(App.Dto.Req.Copy.Common.Connection request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Copy.Common.Connection, App.Dto.Res.Copy.Common.Connection>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Export.Common.Connection> ExportConnectionAsync(App.Dto.Req.Export.Common.Connection request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Export.Common.Connection, App.Dto.Res.Export.Common.Connection>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Import.Common.Connection> ImportConnectionAsync(App.Dto.Req.Import.Common.Connection request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Import.Common.Connection, App.Dto.Res.Import.Common.Connection>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.ModifyField.Common.Connection> ModifyConnectionFieldAsync(App.Dto.Req.ModifyField.Common.Connection request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.ModifyField.Common.Connection, App.Dto.Res.ModifyField.Common.Connection>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Remove.Common.Connection> RemoveConnectionAsync(App.Dto.Req.Remove.Common.Connection request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Remove.Common.Connection, App.Dto.Res.Remove.Common.Connection>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        #endregion
    }
}
