using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using KSociety.Com.App.Dto.Req.Transaction;
using KSociety.Com.Pre.Model.Interface.Transaction;
using KSociety.Com.Srv.Agent;
using KSociety.Com.Srv.Dto.Biz;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Transaction
{
    public class Transaction : ITransaction
    {
        private readonly ILogger<Transaction> _logger;
        private readonly Srv.Agent.Transaction.Transaction _transaction;
        private readonly CancellationTokenSource _cts;

        public Transaction(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Transaction>();
            _cts = new CancellationTokenSource();
            _transaction = new Srv.Agent.Transaction.Transaction(agentConfiguration, loggerFactory);
        }

        public async ValueTask SendHeartBeatAsync()
        {
            
            try
            {
                await foreach (var time in _transaction.SendHeartBeatAsync(_cts.Token))
                {
                    //Console.WriteLine("SendHeartBeat: " + time.Timestamp);
                    _logger.LogTrace("SendHeartBeat: " + time.Timestamp);
                }
            }
            catch (RpcException rpc) when (rpc.Status.StatusCode == StatusCode.Cancelled)
            {
                //Console.WriteLine("Streaming was cancelled from the client!");
                _logger.LogError("Streaming was cancelled from the client!");
            }

        }

        public async ValueTask NotifyTagInvokeAsync(string tagGroup)
        {
            try
            {
                await foreach (var tagItem in _transaction.NotifyTagInvokeAsync(new NotifyTagReq(tagGroup)))
                {
                    //Console.WriteLine(
                    //    "NotifyTagInvoke: " + tagItem.Timestamp + " " + tagItem.Name + " " + tagItem.Value);

                    _logger.LogTrace("NotifyTagInvoke: " + tagItem.Timestamp + " " + tagItem.Name + " " + tagItem.Value);
                }
            }
            catch (RpcException rpc) when (rpc.Status.StatusCode == StatusCode.Cancelled)
            {
                //Console.WriteLine("Streaming was cancelled from the client!");
                _logger.LogError("Streaming was cancelled from the client!");
            }
        }

        //public async Task NotifyTagReadAsync()
        //{
        //    await foreach (var tagItem in _transactionAsync.NotifyTagReadAsync(new NotifyTagReq("Group_01")))
        //    {
        //        Console.WriteLine("NotifyTagRead: " + tagItem.CreationDate + " " + tagItem.Name);
        //    }
        //}

        public async ValueTask GetConnectionStatusAsync(string tagGroup, string connectionName)
        {
            try
            {
                var result = await _transaction.ConnectionStatusAsync(new GetConnectionStatus(tagGroup, connectionName));

                //Console.WriteLine("GetConnectionStatus: " + result.ConnectionName + " " + result.ConnectionRead + " " + result.ConnectionWrite);
                _logger.LogTrace("GetConnectionStatus: " + result.ConnectionName + " " + result.ConnectionRead + " " + result.ConnectionWrite);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("GetConnectionStatusAsync: " + ex.Message + " " + ex.StackTrace);
                _logger.LogError("GetConnectionStatusAsync: " + ex.Message + " " + ex.StackTrace);
            }
        }

        public async ValueTask GetTagValueAsync(string tagGroup, string tagName)
        {
            try
            {
                var result = await _transaction.GetTagValueAsync(new GetTagValue(tagGroup, tagName));

                //Console.WriteLine("GetTag: " + result.TagName + " " + result.Value);
                _logger.LogTrace("GetTag: " + result.TagName + " " + result.Value);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("GetTagValueAsync: " + ex.Message + " " + ex.StackTrace);
                _logger.LogError("GetTagValueAsync: " + ex.Message + " " + ex.StackTrace);
            }
        }

        public async ValueTask SetTagValueAsync(string tagGroup, string tagName, string value)
        {
            try
            {
                var result = await _transaction.SetTagValueAsync(new SetTagValue(tagGroup, tagName, value));

                _logger.LogTrace("SetTag: " + result.TagName + " " + result.Result);
            }
            catch (Exception ex)
            {
                _logger.LogError("SetTagValueAsync: " + ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
