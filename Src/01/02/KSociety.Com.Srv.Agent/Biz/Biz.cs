using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.App.Dto.Req.Biz;
using KSociety.Com.Srv.Contract.Biz;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace KSociety.Com.Srv.Agent.Biz
{
    public class Biz : KSociety.Base.Srv.Agent.Connection
    {
        public Biz(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public IEnumerable<Dto.HeartBeat> SendHeartBeat(CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);

            using (Channel)
            {
                IBiz client = Channel.CreateGrpcService<IBiz>();

                return client.SendHeartBeat(CallContext);
            }

        }

        public IAsyncEnumerable<Dto.HeartBeat> SendHeartBeatAsync(CancellationToken cancellationToken = default)
        {
            //CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);

            using (Channel)
            {
                IBizAsync client = Channel.CreateGrpcService<IBizAsync>();

                return client.SendHeartBeatAsync(CallContext);
            }
            
        }

        //public IEnumerable<TagIntegrationEvent> NotifyTagInvoke(Dto.Common.NotifyTagReq request, CancellationToken cancellationToken = default)
        //{
        //    //CallOptions = CallOptions.WithCancellationToken(cancellationToken);
        //    CallOptions = CallOptions.WithCancellationToken(cancellationToken);
        //    CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
        //    using (Channel)
        //    {
        //        ITransaction client = Channel.CreateGrpcService<ITransaction>();

        //        return client.NotifyTagInvoke(request, CallContext);
        //    }
        //}

        public IAsyncEnumerable<Dto.Biz.NotifyTagRes> NotifyTagInvokeAsync(Dto.Biz.NotifyTagReq request, CancellationToken cancellationToken = default)
        {
            //CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            using (Channel)
            {
                IBizAsync client = Channel.CreateGrpcService<IBizAsync>();

                return client.NotifyTagInvokeAsync(request, CallContext);
            }
        }

        //public IAsyncEnumerable<TagReadIntegrationEvent> NotifyTagReadAsync(Srv.Dto.Common.NotifyTagReq request, CancellationToken cancellationToken = default)
        //{
        //    CallOptions = CallOptions.WithCancellationToken(cancellationToken);
        //    using (Channel)
        //    {
        //        ITransactionAsync client = null;

        //        client = Channel.CreateGrpcService<ITransactionAsync>();

        //        return client.NotifyTagReadAsync(request, CallOptions);
        //    }
        //}

        public App.Dto.Res.Biz.GetConnectionStatus ConnectionStatus(GetConnectionStatus request, CancellationToken cancellationToken = default)
        {
            //CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Biz.GetConnectionStatus output = new App.Dto.Res.Biz.GetConnectionStatus();
            try
            {
                using (Channel)
                {
                    IBiz client = Channel.CreateGrpcService<IBiz>();

                    var result = client.ConnectionStatus(request, CallContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Biz.GetConnectionStatus> ConnectionStatusAsync(GetConnectionStatus request, CancellationToken cancellationToken = default)
        {
            //CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Biz.GetConnectionStatus output = new App.Dto.Res.Biz.GetConnectionStatus();
            try
            {
                using (Channel)
                {
                    IBizAsync client = Channel.CreateGrpcService<IBizAsync>();

                    var result = await client.ConnectionStatusAsync(request, CallContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public App.Dto.Res.Biz.SetTagValue SetTagValue(SetTagValue request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Biz.SetTagValue output = new App.Dto.Res.Biz.SetTagValue();
            try
            {
                using (Channel)
                {
                    IBiz client = Channel.CreateGrpcService<IBiz>();

                    var result = client.SetTagValue(request, CallContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Biz.SetTagValue> SetTagValueAsync(SetTagValue request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Biz.SetTagValue output = new App.Dto.Res.Biz.SetTagValue();
            try
            {
                using (Channel)
                {
                    IBizAsync client = Channel.CreateGrpcService<IBizAsync>();

                    var result = await client.SetTagValueAsync(request, CallContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public App.Dto.Res.Biz.GetTagValue GetTagValue(GetTagValue request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Biz.GetTagValue output = new App.Dto.Res.Biz.GetTagValue();
            try
            {
                using (Channel)
                {
                    IBiz client = Channel.CreateGrpcService<IBiz>();

                    var result = client.GetTagValue(request, CallContext);

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<App.Dto.Res.Biz.GetTagValue> GetTagValueAsync(GetTagValue request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Biz.GetTagValue output = new App.Dto.Res.Biz.GetTagValue();
            try
            {
                using (Channel)
                {
                    IBizAsync client = Channel.CreateGrpcService<IBizAsync>();

                    var result = await client.GetTagValueAsync(request, CallContext);

                    output = result;
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
