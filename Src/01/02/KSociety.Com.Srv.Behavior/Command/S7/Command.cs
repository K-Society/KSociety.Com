using Autofac;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Com.Srv.Contract.Command.S7;

namespace KSociety.Com.Srv.Behavior.Command.S7
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

        #region [S7Tag]

        public App.Dto.Res.Add.S7.S7Tag AddS7Tag(App.Dto.Req.Add.S7.S7Tag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Add.S7.S7Tag, App.Dto.Res.Add.S7.S7Tag>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Update.S7.S7Tag UpdateS7Tag(App.Dto.Req.Update.S7.S7Tag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Update.S7.S7Tag, App.Dto.Res.Update.S7.S7Tag>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Copy.S7.S7Tag CopyS7Tag(App.Dto.Req.Copy.S7.S7Tag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Copy.S7.S7Tag, App.Dto.Res.Copy.S7.S7Tag>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Export.S7.S7Tag ExportS7Tag(App.Dto.Req.Export.S7.S7Tag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Export.S7.S7Tag, App.Dto.Res.Export.S7.S7Tag>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Import.S7.S7Tag ImportS7Tag(App.Dto.Req.Import.S7.S7Tag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Import.S7.S7Tag, App.Dto.Res.Import.S7.S7Tag>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.ModifyField.S7.S7Tag ModifyS7TagField(App.Dto.Req.ModifyField.S7.S7Tag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.ModifyField.S7.S7Tag, App.Dto.Res.ModifyField.S7.S7Tag>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Remove.S7.S7Tag RemoveS7Tag(App.Dto.Req.Remove.S7.S7Tag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Remove.S7.S7Tag, App.Dto.Res.Remove.S7.S7Tag>(_loggerFactory, _componentContext, request);
        }

        #endregion

        #region [S7Connection]

        public App.Dto.Res.Add.S7.S7Connection AddS7Connection(App.Dto.Req.Add.S7.S7Connection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Add.S7.S7Connection, App.Dto.Res.Add.S7.S7Connection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Update.S7.S7Connection UpdateS7Connection(App.Dto.Req.Update.S7.S7Connection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Update.S7.S7Connection, App.Dto.Res.Update.S7.S7Connection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Copy.S7.S7Connection CopyS7Connection(App.Dto.Req.Copy.S7.S7Connection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Copy.S7.S7Connection, App.Dto.Res.Copy.S7.S7Connection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Export.S7.S7Connection ExportS7Connection(App.Dto.Req.Export.S7.S7Connection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Export.S7.S7Connection, App.Dto.Res.Export.S7.S7Connection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Import.S7.S7Connection ImportS7Connection(App.Dto.Req.Import.S7.S7Connection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Import.S7.S7Connection, App.Dto.Res.Import.S7.S7Connection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.ModifyField.S7.S7Connection ModifyS7ConnectionField(App.Dto.Req.ModifyField.S7.S7Connection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.ModifyField.S7.S7Connection, App.Dto.Res.ModifyField.S7.S7Connection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Remove.S7.S7Connection RemoveS7Connection(App.Dto.Req.Remove.S7.S7Connection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Remove.S7.S7Connection, App.Dto.Res.Remove.S7.S7Connection>(_loggerFactory, _componentContext, request);
        }

        #endregion
    }
}
