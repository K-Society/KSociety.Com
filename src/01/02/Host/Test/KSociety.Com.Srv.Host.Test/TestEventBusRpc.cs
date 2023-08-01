using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Host.Test;

public class TestEventBusRpc : TestEventBus
{
    private readonly IEventBusRpcClient _eventBusRpcClient;

    public TestEventBusRpc()
    {
        ;
        _eventBusRpcClient = new EventBusRabbitMqRpcClient(PersistentConnection, 
            LoggerFactory,
            new TagReadRpcClientHandler(LoggerFactory, ComponentContext),
            null, ExchangeDeclareParameters,
            QueueDeclareParameters, "TestEventBusRpcRead", CancellationToken.None);
        _eventBusRpcClient
            .SubscribeRpcClient<TagReadIntegrationEventReply, TagReadRpcClientHandler>("Test.automation.read.client.test");
    }

    public async Task SendData()
    {
        const string expectedName1 = "SuperPippo1";
        const string expectedName2 = "SuperPippo2";
        const string expectedName3 = "SuperPippo3";

        //TestIntegrationEventReply result1 = null;
        //TestIntegrationEventReply result2 = null;
        //TestIntegrationEventReply result3 = null;

        //for (int i = 0; i < 100; i++)
        //{
        ;
        try
        {
            var tt = new TagReadIntegrationEvent(
                "Test.automation.read.server", "Test.automation.read.client.test", "Test", "Test");
            ;
            var result1 = await _eventBusRpcClient
                .CallAsync<TagReadIntegrationEventReply>(tt);
            //.ConfigureAwait(false);
            ;
            var test = result1.GroupName;
            ;

            Console.WriteLine("" + result1.GroupName);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + " " + ex.StackTrace);
        }

        ;
        //result2 = await _eventBusRpcClient
        //    .CallAsync<TestIntegrationEventReply>(new TestIntegrationEventRpc("pippo.server", "pippo.client",
        //        expectedName2, null))
        //    .ConfigureAwait(false);
        //;
        //result3 = await _eventBusRpcClient
        //    .CallAsync<TestIntegrationEventReply>(new TestIntegrationEventRpc("pippo.server", "pippo.client",
        //        expectedName3, null))
        //    .ConfigureAwait(false);
        ;
        //}

        //;
        //Assert.NotNull(result1);
        //Assert.NotEmpty(result1.TestName);
        //Assert.Equal(expectedName1, result1.TestName);
        //;
        //Assert.NotNull(result2);
        //Assert.NotEmpty(result2.TestName);
        //Assert.Equal(expectedName2, result2.TestName);
        //;
        //Assert.NotNull(result3);
        //Assert.NotEmpty(result3.TestName);
        //Assert.Equal(expectedName3, result3.TestName);
        //;

            
    }
}