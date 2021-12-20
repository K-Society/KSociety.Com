using System;

namespace KSociety.Com.Srv.Host.Test.ProtoModel;

public static class Configuration
{
    public static void ProtoBufConfiguration()
    {
        try
        {
            //ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEvent), true)
            //    .AddSubType(610, typeof(TagIntegrationEvent));

            //ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEventRpc), true)
            //    .AddSubType(611, typeof(TagReadIntegrationEvent));

            //ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEventReply), true)
            //    .AddSubType(612, typeof(TagReadIntegrationEventReply));

            //ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEventRpc), true)
            //    .AddSubType(613, typeof(TagWriteIntegrationEvent));

            //ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEventReply), true)
            //    .AddSubType(614, typeof(TagWriteIntegrationEventReply));

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationEvent), true)
                .AddSubType(610, typeof(IntegrationComEvent));

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEvent), true)
                .AddSubType(610, typeof(TagIntegrationEvent));


            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationEventRpc), true)
                .AddSubType(611, typeof(IntegrationComEventRpc));

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEventRpc), true)
                .AddSubType(611, typeof(TagReadIntegrationEvent));


            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationEventReply), true)
                .AddSubType(612, typeof(IntegrationComEventReply));

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEventReply), true)
                .AddSubType(612, typeof(TagReadIntegrationEventReply));


            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationEventRpc), true)
                .AddSubType(613, typeof(IntegrationComEventRpc));

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEventRpc), true)
                .AddSubType(613, typeof(TagWriteIntegrationEvent));


            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationEventReply), true)
                .AddSubType(614, typeof(IntegrationComEventReply));

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEventReply), true)
                .AddSubType(614, typeof(TagWriteIntegrationEventReply));


            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationEvent), true)
                .AddSubType(615, typeof(IntegrationComEvent));

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEvent), true)
                .AddSubType(615, typeof(ConnectionStatusIntegrationEvent));


            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationEventReply), true)
                .AddSubType(616, typeof(IntegrationComEventReply));

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEventReply), true)
                .AddSubType(616, typeof(ConnectionStatusIntegrationEventReply));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Configuration " + ex.Message + " " + ex.StackTrace);
        }
    }
}