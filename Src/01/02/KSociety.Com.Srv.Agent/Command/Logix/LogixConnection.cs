using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Srv.Contract.Command.Logix;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace KSociety.Com.Srv.Agent.Command.Logix
{
    public class LogixConnection : KSociety.Base.Srv.Agent.Connection
    {
        public LogixConnection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public bool Remove(App.Dto.Req.Remove.Logix.LogixConnection request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            var output = false;
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.RemoveLogixConnection(request, CallContext);

                    output = result.Result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }

            return output;
        }

        public async ValueTask<bool> RemoveAsync(App.Dto.Req.Remove.Logix.LogixConnection request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            var output = false;
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.RemoveLogixConnectionAsync(request, CallContext);

                    output = result.Result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }

            return output;
        }

        public App.Dto.Res.Add.Logix.LogixConnection Add(App.Dto.Req.Add.Logix.LogixConnection request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Add.Logix.LogixConnection output = new App.Dto.Res.Add.Logix.LogixConnection();
            try
            {
                using (Channel)
                {
                    ICommand client = null;

                    client = Channel.CreateGrpcService<ICommand>();

                    var result = client.AddLogixConnection(request, CallContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Add.Logix.LogixConnection> AddAsync(App.Dto.Req.Add.Logix.LogixConnection request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Add.Logix.LogixConnection output = new App.Dto.Res.Add.Logix.LogixConnection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.AddLogixConnectionAsync(request, CallContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public App.Dto.Res.Update.Logix.LogixConnection Update(App.Dto.Req.Update.Logix.LogixConnection request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Update.Logix.LogixConnection output = new App.Dto.Res.Update.Logix.LogixConnection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.UpdateLogixConnection(request, CallContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Update.Logix.LogixConnection> UpdateAsync(App.Dto.Req.Update.Logix.LogixConnection request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Update.Logix.LogixConnection output = new App.Dto.Res.Update.Logix.LogixConnection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.UpdateLogixConnectionAsync(request, CallContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public App.Dto.Res.Copy.Logix.LogixConnection Copy(App.Dto.Req.Copy.Logix.LogixConnection request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Copy.Logix.LogixConnection output = new App.Dto.Res.Copy.Logix.LogixConnection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.CopyLogixConnection(request, CallContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Copy.Logix.LogixConnection> CopyAsync(App.Dto.Req.Copy.Logix.LogixConnection request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Copy.Logix.LogixConnection output = new App.Dto.Res.Copy.Logix.LogixConnection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.CopyLogixConnectionAsync(request, CallContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public bool ModifyField(App.Dto.Req.ModifyField.Logix.LogixConnection request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            var output = false;
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.ModifyLogixConnectionField(request, CallContext);

                    output = result.Result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<bool> ModifyFieldAsync(App.Dto.Req.ModifyField.Logix.LogixConnection request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            var output = false;
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.ModifyLogixConnectionFieldAsync(request, CallContext);

                    output = result.Result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }
    }
}
