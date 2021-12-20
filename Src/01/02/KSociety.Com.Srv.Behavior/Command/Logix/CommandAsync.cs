using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Com.Srv.Contract.Command.Logix;

namespace KSociety.Com.Srv.Behavior.Command.Logix;

//[ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
//[GlobalExceptionHandlerBehaviour(typeof(GlobalExceptionHandler))]
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

    public int LogixTest(int value)
    {
        return value;
    }
        
    #region [LogixTag]

    public async ValueTask<App.Dto.Res.Add.Logix.LogixTag> AddLogixTagAsync(App.Dto.Req.Add.Logix.LogixTag request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Add.Logix.LogixTag, App.Dto.Res.Add.Logix.LogixTag>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }

    public async ValueTask<App.Dto.Res.Update.Logix.LogixTag> UpdateLogixTagAsync(App.Dto.Req.Update.Logix.LogixTag request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Update.Logix.LogixTag, App.Dto.Res.Update.Logix.LogixTag>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }

    public async ValueTask<App.Dto.Res.Copy.Logix.LogixTag> CopyLogixTagAsync(App.Dto.Req.Copy.Logix.LogixTag request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Copy.Logix.LogixTag, App.Dto.Res.Copy.Logix.LogixTag>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }

    public async ValueTask<App.Dto.Res.Export.Logix.LogixTag> ExportLogixTagAsync(App.Dto.Req.Export.Logix.LogixTag request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Export.Logix.LogixTag, App.Dto.Res.Export.Logix.LogixTag>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }

    public async ValueTask<App.Dto.Res.Import.Logix.LogixTag> ImportLogixTagAsync(App.Dto.Req.Import.Logix.LogixTag request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Import.Logix.LogixTag, App.Dto.Res.Import.Logix.LogixTag>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }

    public async ValueTask<App.Dto.Res.ModifyField.Logix.LogixTag> ModifyLogixTagFieldAsync(App.Dto.Req.ModifyField.Logix.LogixTag request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.ModifyField.Logix.LogixTag, App.Dto.Res.ModifyField.Logix.LogixTag>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }

    public async ValueTask<App.Dto.Res.Remove.Logix.LogixTag> RemoveLogixTagAsync(App.Dto.Req.Remove.Logix.LogixTag request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Remove.Logix.LogixTag, App.Dto.Res.Remove.Logix.LogixTag>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }
        
    #endregion


    #region [LogixConnection]

    public async ValueTask<App.Dto.Res.Add.Logix.LogixConnection> AddLogixConnectionAsync(App.Dto.Req.Add.Logix.LogixConnection request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Add.Logix.LogixConnection, App.Dto.Res.Add.Logix.LogixConnection>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }

    public async ValueTask<App.Dto.Res.Update.Logix.LogixConnection> UpdateLogixConnectionAsync(App.Dto.Req.Update.Logix.LogixConnection request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Update.Logix.LogixConnection, App.Dto.Res.Update.Logix.LogixConnection>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }

    public async ValueTask<App.Dto.Res.Copy.Logix.LogixConnection> CopyLogixConnectionAsync(App.Dto.Req.Copy.Logix.LogixConnection request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Copy.Logix.LogixConnection, App.Dto.Res.Copy.Logix.LogixConnection>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }

    public async ValueTask<App.Dto.Res.ModifyField.Logix.LogixConnection> ModifyLogixConnectionFieldAsync(App.Dto.Req.ModifyField.Logix.LogixConnection request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.ModifyField.Logix.LogixConnection, App.Dto.Res.ModifyField.Logix.LogixConnection>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }

    public async ValueTask<App.Dto.Res.Remove.Logix.LogixConnection> RemoveLogixConnectionAsync(App.Dto.Req.Remove.Logix.LogixConnection request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<App.Dto.Req.Remove.Logix.LogixConnection, App.Dto.Res.Remove.Logix.LogixConnection>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }

    #endregion

}