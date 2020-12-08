using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using KSociety.Com.App.Dto.Req.Biz;
using KSociety.Com.Pre.Model.Interface.Biz;
using KSociety.Com.Srv.Agent;
using KSociety.Com.Srv.Dto.Biz;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Biz
{
    public class Biz : IBiz
    {
        private readonly ILogger<Biz> _logger;
        private readonly Srv.Agent.Biz.Biz _biz;
        private readonly CancellationTokenSource _cts;

        public Biz(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Biz>();
            _cts = new CancellationTokenSource();
            _biz = new Srv.Agent.Biz.Biz(agentConfiguration, loggerFactory);
        }

        public async ValueTask SendHeartBeatAsync()
        {
            
            try
            {
                await foreach (var time in _biz.SendHeartBeatAsync(_cts.Token))
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
                await foreach (var tagItem in _biz.NotifyTagInvokeAsync(new NotifyTagReq(tagGroup)))
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
                var result = await _biz.ConnectionStatusAsync(new GetConnectionStatus(tagGroup, connectionName));

                //_logger.LogTrace("GetConnectionStatus: " + result.ConnectionName + " " + result.ConnectionRead + " " + result.ConnectionWrite);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetConnectionStatusAsync: " + ex.Message + " " + ex.StackTrace);
            }
        }

        public async ValueTask GetTagValueAsync(string tagGroup, string tagName)
        {
            try
            {
                var result = await _biz.GetTagValueAsync(new GetTagValue(tagGroup, tagName));

                //_logger.LogTrace("GetTag: " + result.TagName + " " + result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetTagValueAsync: " + ex.Message + " " + ex.StackTrace);
            }
        }

        public async ValueTask SetTagValueAsync(string tagGroup, string tagName, string value)
        {
            try
            {
                var result = await _biz.SetTagValueAsync(new SetTagValue(tagGroup, tagName, value));

                //_logger.LogTrace("SetTagAsync: " + result.TagName + " " + result.Result);
            }
            catch (Exception ex)
            {
                _logger.LogError("SetTagValueAsync: " + ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
