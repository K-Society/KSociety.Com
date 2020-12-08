using Autofac;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Com.Srv.Contract.Command.Common;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Command.Common
{
    public class Command : ICommand
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IComponentContext _componentContext;
        private readonly ICommandHandler _commandHandler;

        public Command(
            ILoggerFactory loggerFactory,
            IComponentContext componentContext,
            ICommandHandler commandHandler
        )
        {
            _loggerFactory = loggerFactory;
            _componentContext = componentContext;
            _commandHandler = commandHandler;
        }

        #region [Tag]

        public App.Dto.Res.Add.Common.Tag AddTag(App.Dto.Req.Add.Common.Tag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Add.Common.Tag, App.Dto.Res.Add.Common.Tag>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Update.Common.Tag UpdateTag(App.Dto.Req.Update.Common.Tag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Update.Common.Tag, App.Dto.Res.Update.Common.Tag>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Copy.Common.Tag CopyTag(App.Dto.Req.Copy.Common.Tag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Copy.Common.Tag, App.Dto.Res.Copy.Common.Tag>(_loggerFactory, _componentContext, request);
        }
        
        public App.Dto.Res.ModifyField.Common.Tag ModifyTagField(App.Dto.Req.ModifyField.Common.Tag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.ModifyField.Common.Tag, App.Dto.Res.ModifyField.Common.Tag>(_loggerFactory, _componentContext, request);
        }
        
        public App.Dto.Res.Remove.Common.Tag RemoveTag(App.Dto.Req.Remove.Common.Tag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Remove.Common.Tag, App.Dto.Res.Remove.Common.Tag>(_loggerFactory, _componentContext, request);
        }

        #endregion

        #region [TagGroup]

        public App.Dto.Res.Add.Common.TagGroup AddTagGroup(App.Dto.Req.Add.Common.TagGroup request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Add.Common.TagGroup, App.Dto.Res.Add.Common.TagGroup>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Update.Common.TagGroup UpdateTagGroup(App.Dto.Req.Update.Common.TagGroup request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Update.Common.TagGroup, App.Dto.Res.Update.Common.TagGroup>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Copy.Common.TagGroup CopyTagGroup(App.Dto.Req.Copy.Common.TagGroup request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Copy.Common.TagGroup, App.Dto.Res.Copy.Common.TagGroup>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.ModifyField.Common.TagGroup ModifyTagGroupField(App.Dto.Req.ModifyField.Common.TagGroup request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.ModifyField.Common.TagGroup, App.Dto.Res.ModifyField.Common.TagGroup>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Remove.Common.TagGroup RemoveTagGroup(App.Dto.Req.Remove.Common.TagGroup request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Remove.Common.TagGroup, App.Dto.Res.Remove.Common.TagGroup>(_loggerFactory, _componentContext, request);
        }

        #endregion

        #region [Connection]

        public App.Dto.Res.Add.Common.Connection AddConnection(App.Dto.Req.Add.Common.Connection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Add.Common.Connection, App.Dto.Res.Add.Common.Connection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Update.Common.Connection UpdateConnection(App.Dto.Req.Update.Common.Connection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Update.Common.Connection, App.Dto.Res.Update.Common.Connection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Copy.Common.Connection CopyConnection(App.Dto.Req.Copy.Common.Connection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Copy.Common.Connection, App.Dto.Res.Copy.Common.Connection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Export.Common.Connection ExportConnection(App.Dto.Req.Export.Common.Connection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Export.Common.Connection, App.Dto.Res.Export.Common.Connection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.ModifyField.Common.Connection ModifyConnectionField(App.Dto.Req.ModifyField.Common.Connection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.ModifyField.Common.Connection, App.Dto.Res.ModifyField.Common.Connection>(_loggerFactory, _componentContext, request);
        }
        
        public App.Dto.Res.Remove.Common.Connection RemoveConnection(App.Dto.Req.Remove.Common.Connection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Remove.Common.Connection, App.Dto.Res.Remove.Common.Connection>(_loggerFactory, _componentContext, request);
        }

        #endregion
    }
}
