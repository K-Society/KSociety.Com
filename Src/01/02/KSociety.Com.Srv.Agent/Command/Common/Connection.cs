using Grpc.Core;
using KSociety.Com.Srv.Agent.Interface.Command.Common;
using KSociety.Com.Srv.Contract.Command.Common;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Agent.Command.Common
{
    public class Connection : KSociety.Base.Srv.Agent.Connection, IConnection
    {
        public Connection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public bool Remove(App.Dto.Req.Remove.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            var output = false;
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.RemoveConnection(request, callContext);

                    output = result.Result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }

            return output;
        }

        public async ValueTask<bool> RemoveAsync(App.Dto.Req.Remove.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            var output = false;
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.RemoveConnectionAsync(request, callContext);

                    output = result.Result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }

            return output;
        }

        public App.Dto.Res.Add.Common.Connection Add(App.Dto.Req.Add.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Add.Common.Connection output = new App.Dto.Res.Add.Common.Connection();
            try
            {
                using (Channel)
                {

                    ICommand client = Channel.CreateGrpcService<ICommand>();

                    var result = client.AddConnection(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Add.Common.Connection> AddAsync(App.Dto.Req.Add.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Add.Common.Connection output = new App.Dto.Res.Add.Common.Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.AddConnectionAsync(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public App.Dto.Res.Update.Common.Connection Update(App.Dto.Req.Update.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Update.Common.Connection output = new App.Dto.Res.Update.Common.Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.UpdateConnection(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Update.Common.Connection> UpdateAsync(App.Dto.Req.Update.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Update.Common.Connection output = new App.Dto.Res.Update.Common.Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.UpdateConnectionAsync(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public App.Dto.Res.Copy.Common.Connection Copy(App.Dto.Req.Copy.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Copy.Common.Connection output = new App.Dto.Res.Copy.Common.Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.CopyConnection(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Copy.Common.Connection> CopyAsync(App.Dto.Req.Copy.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Copy.Common.Connection output = new App.Dto.Res.Copy.Common.Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.CopyConnectionAsync(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public App.Dto.Res.Export.Common.Connection Export(App.Dto.Req.Export.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Export.Common.Connection output = new App.Dto.Res.Export.Common.Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.ExportConnection(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Export.Common.Connection> ExportAsync(App.Dto.Req.Export.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Export.Common.Connection output = new App.Dto.Res.Export.Common.Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.ExportConnectionAsync(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public App.Dto.Res.Import.Common.Connection Import(App.Dto.Req.Import.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Import.Common.Connection output = new App.Dto.Res.Import.Common.Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.ImportConnection(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Import.Common.Connection> ImportAsync(App.Dto.Req.Import.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Import.Common.Connection output = new App.Dto.Res.Import.Common.Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.ImportConnectionAsync(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public bool ModifyField(App.Dto.Req.ModifyField.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            var output = false;
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.ModifyConnectionField(request, callContext);

                    output = result.Result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<bool> ModifyFieldAsync(App.Dto.Req.ModifyField.Common.Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            var output = false;
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.ModifyConnectionFieldAsync(request, callContext);

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
