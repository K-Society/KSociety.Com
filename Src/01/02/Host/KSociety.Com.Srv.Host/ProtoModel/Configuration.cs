using System;
using KSociety.Base.App.Shared.Dto.Req;
using KSociety.Base.EventBus.Events;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Biz.IntegrationEvent.Event;

namespace KSociety.Com.Srv.Host.ProtoModel
{
    public static class Configuration
    {
        public static void ProtoBufConfiguration()
        {
            try
            {
                //Common
                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ObjectList<Srv.Dto.Common.TagGroup>), true)
                    .AddSubType(120, typeof(Srv.Dto.Common.List.GridView.TagGroup));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ObjectList<Srv.Dto.Common.Tag>), true)
                    .AddSubType(121, typeof(Srv.Dto.Common.List.GridView.Tag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ObjectList<Srv.Dto.Common.Connection>), true)
                    .AddSubType(122, typeof(Srv.Dto.Common.List.GridView.Connection));

                //S7
                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ObjectList<Srv.Dto.S7.S7Tag>), true)
                    .AddSubType(123, typeof(Srv.Dto.S7.List.GridView.S7Tag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ObjectList<Srv.Dto.S7.S7Connection>), true)
                    .AddSubType(124, typeof(Srv.Dto.S7.List.GridView.S7Connection));

                //Logix
                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ObjectList<Srv.Dto.Logix.LogixTag>), true)
                    .AddSubType(125, typeof(Srv.Dto.Logix.List.GridView.LogixTag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ObjectList<Srv.Dto.Logix.LogixConnection>), true)
                    .AddSubType(126, typeof(Srv.Dto.Logix.List.GridView.LogixConnection));

                //View
                ProtoBuf.Meta.RuntimeTypeModel.Default
                    .Add(typeof(IList<Srv.Dto.View.Common.TagGroupReady>), true)
                    .AddSubType(127, typeof(Srv.Dto.View.Common.List.GridView.TagGroupReady));

                ProtoBuf.Meta.RuntimeTypeModel.Default
                    .Add(typeof(IList<Srv.Dto.View.Common.TagGroupReady>), true)
                    .AddSubType(117, typeof(Srv.Dto.View.Common.List.TagGroupReady));

                ProtoBuf.Meta.RuntimeTypeModel.Default
                    .Add(typeof(IList<Srv.Dto.View.Joined.AllConnection>), true)
                    .AddSubType(128, typeof(Srv.Dto.View.Joined.List.GridView.AllConnection));

                ProtoBuf.Meta.RuntimeTypeModel.Default
                    .Add(typeof(IList<Srv.Dto.View.Joined.AllTagGroupAllConnection>), true)
                    .AddSubType(129, typeof(Srv.Dto.View.Joined.List.GridView.AllTagGroupAllConnection));

                //

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ModifyFieldReq), true)
                    .AddSubType(200, typeof(App.Dto.Req.ModifyField.Common.TagGroup));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ModifyFieldReq), true)
                    .AddSubType(201, typeof(App.Dto.Req.ModifyField.Common.Tag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ModifyFieldReq), true)
                    .AddSubType(202, typeof(App.Dto.Req.ModifyField.Common.Connection));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ModifyFieldReq), true)
                    .AddSubType(203, typeof(App.Dto.Req.ModifyField.S7.S7Tag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ModifyFieldReq), true)
                    .AddSubType(204, typeof(App.Dto.Req.ModifyField.S7.S7Connection));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ModifyFieldReq), true)
                    .AddSubType(205, typeof(App.Dto.Req.ModifyField.Logix.LogixTag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ModifyFieldReq), true)
                    .AddSubType(206, typeof(App.Dto.Req.ModifyField.Logix.LogixConnection));


                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(RemoveReq), true)
                    .AddSubType(300, typeof(App.Dto.Req.Remove.Common.TagGroup));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(RemoveReq), true)
                    .AddSubType(301, typeof(App.Dto.Req.Remove.Common.Tag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(RemoveReq), true)
                    .AddSubType(302, typeof(App.Dto.Req.Remove.Common.Connection));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(RemoveReq), true)
                    .AddSubType(303, typeof(App.Dto.Req.Remove.S7.S7Tag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(RemoveReq), true)
                    .AddSubType(304, typeof(App.Dto.Req.Remove.S7.S7Connection));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(RemoveReq), true)
                    .AddSubType(305, typeof(App.Dto.Req.Remove.Logix.LogixTag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(RemoveReq), true)
                    .AddSubType(306, typeof(App.Dto.Req.Remove.Logix.LogixConnection));

                //Export
                //ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IStdExport), true)
                //    .AddSubType(200, typeof(App.Dto.Req.Export.Common.TagGroup));

                //ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IStdExport), true)
                //    .AddSubType(201, typeof(App.Dto.Req.Export.Common.Tag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ExportReq), true)
                    .AddSubType(402, typeof(App.Dto.Req.Export.Common.Connection));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ExportReq), true)
                    .AddSubType(403, typeof(App.Dto.Req.Export.Common.Tag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ExportReq), true)
                    .AddSubType(404, typeof(App.Dto.Req.Export.S7.S7Tag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ExportReq), true)
                    .AddSubType(405, typeof(App.Dto.Req.Export.Logix.LogixTag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ExportReq), true)
                    .AddSubType(406, typeof(App.Dto.Req.Export.Common.TagGroup));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ExportReq), true)
                    .AddSubType(407, typeof(App.Dto.Req.Export.S7.S7Connection));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ImportReq), true)
                    .AddSubType(502, typeof(App.Dto.Req.Import.Common.Connection));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ImportReq), true)
                    .AddSubType(503, typeof(App.Dto.Req.Import.Common.Tag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ImportReq), true)
                    .AddSubType(504, typeof(App.Dto.Req.Import.S7.S7Tag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ImportReq), true)
                    .AddSubType(505, typeof(App.Dto.Req.Import.Logix.LogixTag));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ImportReq), true)
                    .AddSubType(506, typeof(App.Dto.Req.Import.Common.TagGroup));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(ImportReq), true)
                    .AddSubType(507, typeof(App.Dto.Req.Import.S7.S7Connection));

                //IntegrationEvent
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


                //ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationEventRpc), true)
                //    .AddSubType(613, typeof(IntegrationComEventRpc));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEventRpc), true)
                    .AddSubType(613, typeof(TagWriteIntegrationEvent));


                //ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationEventReply), true)
                //    .AddSubType(614, typeof(IntegrationComEventReply));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEventReply), true)
                    .AddSubType(614, typeof(TagWriteIntegrationEventReply));


                //ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationEvent), true)
                //    .AddSubType(615, typeof(IntegrationComEvent));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEvent), true)
                    .AddSubType(615, typeof(ConnectionStatusIntegrationEvent));


                //ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationEventReply), true)
                //    .AddSubType(616, typeof(IntegrationComEventReply));

                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationComEventReply), true)
                    .AddSubType(616, typeof(ConnectionStatusIntegrationEventReply));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Configuration " + ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
