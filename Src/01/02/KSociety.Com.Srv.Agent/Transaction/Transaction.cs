using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.App.Dto.Req.Transaction;
using KSociety.Com.Biz.IntegrationEvent.Event;
using KSociety.Com.Srv.Contract.Transaction;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace KSociety.Com.Srv.Agent.Transaction
{
    public class Transaction : KSociety.Base.Srv.Agent.Connection
    {
        public Transaction(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public IEnumerable<Dto.HeartBeat> SendHeartBeat(CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);

            using (Channel)
            {
                ITransaction client = Channel.CreateGrpcService<ITransaction>();

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
                ITransactionAsync client = Channel.CreateGrpcService<ITransactionAsync>();

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

        public IAsyncEnumerable<TagIntegrationEvent> NotifyTagInvokeAsync(Dto.Biz.NotifyTagReq request, CancellationToken cancellationToken = default)
        {
            //CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            using (Channel)
            {
                ITransactionAsync client = Channel.CreateGrpcService<ITransactionAsync>();

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

        public App.Dto.Res.Transaction.GetConnectionStatus ConnectionStatus(GetConnectionStatus request, CancellationToken cancellationToken = default)
        {
            //CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Transaction.GetConnectionStatus output = new App.Dto.Res.Transaction.GetConnectionStatus();
            try
            {
                using (Channel)
                {
                    ITransaction client = Channel.CreateGrpcService<ITransaction>();

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

        public async ValueTask<App.Dto.Res.Transaction.GetConnectionStatus> ConnectionStatusAsync(GetConnectionStatus request, CancellationToken cancellationToken = default)
        {
            //CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Transaction.GetConnectionStatus output = new App.Dto.Res.Transaction.GetConnectionStatus();
            try
            {
                using (Channel)
                {
                    ITransactionAsync client = Channel.CreateGrpcService<ITransactionAsync>();

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

        public App.Dto.Res.Transaction.SetTagValue SetTagValue(SetTagValue request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Transaction.SetTagValue output = new App.Dto.Res.Transaction.SetTagValue();
            try
            {
                using (Channel)
                {
                    ITransaction client = Channel.CreateGrpcService<ITransaction>();

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

        public async ValueTask<App.Dto.Res.Transaction.SetTagValue> SetTagValueAsync(SetTagValue request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Transaction.SetTagValue output = new App.Dto.Res.Transaction.SetTagValue();
            try
            {
                using (Channel)
                {
                    ITransactionAsync client = Channel.CreateGrpcService<ITransactionAsync>();

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

        public App.Dto.Res.Transaction.GetTagValue GetTagValue(GetTagValue request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Transaction.GetTagValue output = new App.Dto.Res.Transaction.GetTagValue();
            try
            {
                using (Channel)
                {
                    ITransaction client = Channel.CreateGrpcService<ITransaction>();

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

        public async ValueTask<App.Dto.Res.Transaction.GetTagValue> GetTagValueAsync(GetTagValue request, CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            App.Dto.Res.Transaction.GetTagValue output = new App.Dto.Res.Transaction.GetTagValue();
            try
            {
                using (Channel)
                {
                    ITransactionAsync client = Channel.CreateGrpcService<ITransactionAsync>();

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
