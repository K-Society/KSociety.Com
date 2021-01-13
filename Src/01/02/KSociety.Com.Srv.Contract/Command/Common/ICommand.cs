using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Command.Common
{
    [Service]
    public interface ICommand
    {
        #region [Tag]

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Add.Common.Tag AddTag(App.Dto.Req.Add.Common.Tag request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Update.Common.Tag UpdateTag(App.Dto.Req.Update.Common.Tag request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Copy.Common.Tag CopyTag(App.Dto.Req.Copy.Common.Tag request, CallContext context = default);

        [Operation]
        App.Dto.Res.Export.Common.Tag ExportTag(App.Dto.Req.Export.Common.Tag request, CallContext context = default);

        [Operation]
        App.Dto.Res.Import.Common.Tag ImportTag(App.Dto.Req.Import.Common.Tag request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //void ModifyTag(Application.Db.Dtos.Modify.Request.S7.TagRequest request);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //void ModifyTagField(App.Db.Dto.ModifyField.Req.Common.Tag request);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.ModifyField.Common.Tag ModifyTagField(App.Dto.Req.ModifyField.Common.Tag request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //bool RemoveTag(App.Db.Dto.Remove.Req.Common.Tag request);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Remove.Common.Tag RemoveTag(App.Dto.Req.Remove.Common.Tag request, CallContext context = default);

        #endregion

        #region [TagGroup]
        [Operation]
        ////[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Add.Common.TagGroup AddTagGroup(App.Dto.Req.Add.Common.TagGroup request, CallContext context = default);

        [Operation]
        ////[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Update.Common.TagGroup UpdateTagGroup(App.Dto.Req.Update.Common.TagGroup request, CallContext context = default);

        //[OperationContract]
        //[FaultContract(typeof(BusinessFault))]
        //ValueTask<App.Com.Dto.Res.Add.Common.TagGroup> AddTagGroupAsync(TagGroup request, CallContext context = default);

        [Operation]
        ////[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Copy.Common.TagGroup CopyTagGroup(App.Dto.Req.Copy.Common.TagGroup request, CallContext context = default);

        [Operation]
        App.Dto.Res.Export.Common.TagGroup ExportTagGroup(App.Dto.Req.Export.Common.TagGroup request, CallContext context = default);

        [Operation]
        App.Dto.Res.Import.Common.TagGroup ImportTagGroup(App.Dto.Req.Import.Common.TagGroup request, CallContext context = default);

        //[OperationContract]
        //[FaultContract(typeof(BusinessFault))]
        //ValueTask<App.Com.Dto.Res.Copy.Common.TagGroup> CopyTagGroupAsync(App.Com.Dto.Req.Copy.Common.TagGroup request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //void ModifyTag(Application.Db.Dtos.Modify.Request.S7.TagRequest request);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //void ModifyTagGroupField(App.Db.Dto.ModifyField.Req.Common.TagGroup request);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        //void ModifyTagGroupFieldAsync(App.Db.Dto.ModifyField.Req.Common.TagGroup request);
        App.Dto.Res.ModifyField.Common.TagGroup ModifyTagGroupField(App.Dto.Req.ModifyField.Common.TagGroup request, CallContext context = default);

        //[OperationContract]
        //[FaultContract(typeof(BusinessFault))]
        //void ModifyTagGroupFieldAsync(App.Db.Dto.ModifyField.Req.Common.TagGroup request);
        //ValueTask<App.Com.Dto.Res.ModifyField.Common.TagGroup> ModifyTagGroupFieldAsync(App.Com.Dto.Req.ModifyField.Common.TagGroup request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //bool RemoveTagGroup(App.Db.Dto.Remove.Req.Common.TagGroup request);

        [Operation]
        ////[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Remove.Common.TagGroup RemoveTagGroup(App.Dto.Req.Remove.Common.TagGroup request, CallContext context = default);

        //[OperationContract]
        //[FaultContract(typeof(BusinessFault))]
        //ValueTask<App.Com.Dto.Res.Remove.Common.TagGroup> RemoveTagGroupAsync(App.Com.Dto.Req.Remove.Common.TagGroup request, CallContext context = default);

        #endregion

        #region [Connection]

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Add.Common.Connection AddConnection(App.Dto.Req.Add.Common.Connection request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Update.Common.Connection UpdateConnection(App.Dto.Req.Update.Common.Connection request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Copy.Common.Connection CopyConnection(App.Dto.Req.Copy.Common.Connection request, CallContext context = default);

        [Operation]
        App.Dto.Res.Export.Common.Connection ExportConnection(App.Dto.Req.Export.Common.Connection request, CallContext context = default);

        [Operation]
        App.Dto.Res.Import.Common.Connection ImportConnection(App.Dto.Req.Import.Common.Connection request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //void ModifyConnection(Application.Db.Dtos.Modify.Request.S7.ConnectionRequest request);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //void ModifyConnectionField(App.Db.Dto.ModifyField.Req.S7.Connection request);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.ModifyField.Common.Connection ModifyConnectionField(App.Dto.Req.ModifyField.Common.Connection request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //bool RemoveConnection(App.Db.Dto.Remove.Req.S7.Connection request);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Remove.Common.Connection RemoveConnection(App.Dto.Req.Remove.Common.Connection request, CallContext context = default);

        #endregion
    }
}
