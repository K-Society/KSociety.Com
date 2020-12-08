using Autofac;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Com.Srv.Contract.Command.Logix;

namespace KSociety.Com.Srv.Behavior.Command.Logix
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

        public int LogixTest(int value)
        {
            return value;
        }

        #region [LogixTag]

        public App.Dto.Res.Add.Logix.LogixTag AddLogixTag(App.Dto.Req.Add.Logix.LogixTag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Add.Logix.LogixTag, App.Dto.Res.Add.Logix.LogixTag>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Update.Logix.LogixTag UpdateLogixTag(App.Dto.Req.Update.Logix.LogixTag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Update.Logix.LogixTag, App.Dto.Res.Update.Logix.LogixTag>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Copy.Logix.LogixTag CopyLogixTag(App.Dto.Req.Copy.Logix.LogixTag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Copy.Logix.LogixTag, App.Dto.Res.Copy.Logix.LogixTag>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.ModifyField.Logix.LogixTag ModifyLogixTagField(App.Dto.Req.ModifyField.Logix.LogixTag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.ModifyField.Logix.LogixTag, App.Dto.Res.ModifyField.Logix.LogixTag>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Remove.Logix.LogixTag RemoveLogixTag(App.Dto.Req.Remove.Logix.LogixTag request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Remove.Logix.LogixTag, App.Dto.Res.Remove.Logix.LogixTag>(_loggerFactory, _componentContext, request);
        }

        #endregion


        #region [LogixConnection]

        public App.Dto.Res.Add.Logix.LogixConnection AddLogixConnection(App.Dto.Req.Add.Logix.LogixConnection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Add.Logix.LogixConnection, App.Dto.Res.Add.Logix.LogixConnection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Update.Logix.LogixConnection UpdateLogixConnection(App.Dto.Req.Update.Logix.LogixConnection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Update.Logix.LogixConnection, App.Dto.Res.Update.Logix.LogixConnection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Copy.Logix.LogixConnection CopyLogixConnection(App.Dto.Req.Copy.Logix.LogixConnection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Copy.Logix.LogixConnection, App.Dto.Res.Copy.Logix.LogixConnection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.ModifyField.Logix.LogixConnection ModifyLogixConnectionField(App.Dto.Req.ModifyField.Logix.LogixConnection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.ModifyField.Logix.LogixConnection, App.Dto.Res.ModifyField.Logix.LogixConnection>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Remove.Logix.LogixConnection RemoveLogixConnection(App.Dto.Req.Remove.Logix.LogixConnection request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<App.Dto.Req.Remove.Logix.LogixConnection, App.Dto.Res.Remove.Logix.LogixConnection>(_loggerFactory, _componentContext, request);
        }

        #endregion

    }
}
