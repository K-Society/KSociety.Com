﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using KSociety.Com.Srv.Contract.Command.S7;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace KSociety.Com.Srv.Agent.Command.S7
{
    public class S7Connection : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Command.S7.IS7Connection
    {
        public S7Connection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public bool Remove(App.Dto.Req.Remove.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            var output = false;
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.RemoveS7Connection(request, callContext);

                    output = result.Result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }

            return output;
        }

        public async ValueTask<bool> RemoveAsync(App.Dto.Req.Remove.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            var output = false;
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.RemoveS7ConnectionAsync(request, callContext);

                    output = result.Result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }

            return output;
        }

        public App.Dto.Res.Add.S7.S7Connection Add(App.Dto.Req.Add.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Add.S7.S7Connection output = new App.Dto.Res.Add.S7.S7Connection();
            try
            {
                using (Channel)
                {
                    ICommand client = null;

                    client = Channel.CreateGrpcService<ICommand>();

                    var result = client.AddS7Connection(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Add.S7.S7Connection> AddAsync(App.Dto.Req.Add.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Add.S7.S7Connection output = new App.Dto.Res.Add.S7.S7Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.AddS7ConnectionAsync(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public App.Dto.Res.Update.S7.S7Connection Update(App.Dto.Req.Update.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Update.S7.S7Connection output = new App.Dto.Res.Update.S7.S7Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.UpdateS7Connection(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Update.S7.S7Connection> UpdateAsync(App.Dto.Req.Update.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Update.S7.S7Connection output = new App.Dto.Res.Update.S7.S7Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.UpdateS7ConnectionAsync(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public App.Dto.Res.Copy.S7.S7Connection Copy(App.Dto.Req.Copy.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Copy.S7.S7Connection output = new App.Dto.Res.Copy.S7.S7Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.CopyS7Connection(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Copy.S7.S7Connection> CopyAsync(App.Dto.Req.Copy.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Copy.S7.S7Connection output = new App.Dto.Res.Copy.S7.S7Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.CopyS7ConnectionAsync(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public App.Dto.Res.Export.S7.S7Connection Export(App.Dto.Req.Export.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Export.S7.S7Connection output = new App.Dto.Res.Export.S7.S7Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.ExportS7Connection(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Export.S7.S7Connection> ExportAsync(App.Dto.Req.Export.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Export.S7.S7Connection output = new App.Dto.Res.Export.S7.S7Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.ExportS7ConnectionAsync(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public App.Dto.Res.Import.S7.S7Connection Import(App.Dto.Req.Import.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Import.S7.S7Connection output = new App.Dto.Res.Import.S7.S7Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.ImportS7Connection(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Import.S7.S7Connection> ImportAsync(App.Dto.Req.Import.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Import.S7.S7Connection output = new App.Dto.Res.Import.S7.S7Connection();
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.ImportS7ConnectionAsync(request, callContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public bool ModifyField(App.Dto.Req.ModifyField.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            var output = false;
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommand>();

                    var result = client.ModifyS7ConnectionField(request, callContext);

                    output = result.Result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<bool> ModifyFieldAsync(App.Dto.Req.ModifyField.S7.S7Connection request, CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            var output = false;
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<ICommandAsync>();

                    var result = await client.ModifyS7ConnectionFieldAsync(request, callContext);

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
