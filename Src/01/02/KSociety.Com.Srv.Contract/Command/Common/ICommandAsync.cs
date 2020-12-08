using System.Threading.Tasks;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Command.Common
{
    [Service]
    public interface ICommandAsync
    {
        #region [Tag]

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //App.Db.Dto.Add.Res.Common.Tag AddTag(App.Db.Dto.Add.Req.Common.Tag request);
        ////AddS7TagResponse AddTag(AddS7TagRequest request);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Add.Common.Tag> AddTagAsync(App.Dto.Req.Add.Common.Tag request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Update.Common.Tag> UpdateTagAsync(App.Dto.Req.Update.Common.Tag request, CallContext context = default);


        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Copy.Common.Tag> CopyTagAsync(App.Dto.Req.Copy.Common.Tag request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //void ModifyTag(Application.Db.Dtos.Modify.Request.S7.TagRequest request);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //void ModifyTagField(App.Db.Dto.ModifyField.Req.Common.Tag request);

        [Operation]
        //[FaultContract(ypeof(BusinessFault))]
        ValueTask<App.Dto.Res.ModifyField.Common.Tag> ModifyTagFieldAsync(App.Dto.Req.ModifyField.Common.Tag request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //bool RemoveTag(App.Db.Dto.Remove.Req.Common.Tag request);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Remove.Common.Tag> RemoveTagAsync(App.Dto.Req.Remove.Common.Tag request, CallContext context = default);

        #endregion

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        ////void ModifyTagGroupFieldAsync(App.Db.Dto.ModifyField.Req.Common.TagGroup request);
        //ValueTask<App.Com.Dto.Res.ModifyField.Common.TagGroup> ModifyTagGroupFieldAsync(App.Com.Dto.Req.ModifyField.Common.TagGroup request, CallContext context = default);

        #region [TagGroup]
        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //App.Com.Dto.Res.Add.Common.TagGroup AddTagGroup(TagGroup request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Add.Common.TagGroup> AddTagGroupAsync(App.Dto.Req.Add.Common.TagGroup request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //App.Com.Dto.Res.Copy.Common.TagGroup CopyTagGroup(App.Com.Dto.Req.Copy.Common.TagGroup request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Update.Common.TagGroup> UpdateTagGroupAsync(App.Dto.Req.Update.Common.TagGroup request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Copy.Common.TagGroup> CopyTagGroupAsync(App.Dto.Req.Copy.Common.TagGroup request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //void ModifyTag(Application.Db.Dtos.Modify.Request.S7.TagRequest request);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //void ModifyTagGroupField(App.Db.Dto.ModifyField.Req.Common.TagGroup request);

        //[OperationContract]
        //[FaultContract(typeof(BusinessFault))]
        //void ModifyTagGroupFieldAsync(App.Db.Dto.ModifyField.Req.Common.TagGroup request);
        //App.Com.Dto.Res.ModifyField.Common.TagGroup ModifyTagGroupField(App.Com.Dto.Req.ModifyField.Common.TagGroup request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        //void ModifyTagGroupFieldAsync(App.Db.Dto.ModifyField.Req.Common.TagGroup request);
        ValueTask<App.Dto.Res.ModifyField.Common.TagGroup> ModifyTagGroupFieldAsync(App.Dto.Req.ModifyField.Common.TagGroup request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //bool RemoveTagGroup(App.Db.Dto.Remove.Req.Common.TagGroup request);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //App.Com.Dto.Res.Remove.Common.TagGroup RemoveTagGroup(App.Com.Dto.Req.Remove.Common.TagGroup request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Remove.Common.TagGroup> RemoveTagGroupAsync(App.Dto.Req.Remove.Common.TagGroup request, CallContext context = default);

        #endregion

        #region [Connection]

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Add.Common.Connection> AddConnectionAsync(App.Dto.Req.Add.Common.Connection request, CallContext context = default);


        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Update.Common.Connection> UpdateConnectionAsync(App.Dto.Req.Update.Common.Connection request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Copy.Common.Connection> CopyConnectionAsync(App.Dto.Req.Copy.Common.Connection request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Export.Common.Connection> ExportConnectionAsync(App.Dto.Req.Export.Common.Connection request, CallContext context = default);


        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //void ModifyConnection(Application.Db.Dtos.Modify.Request.S7.ConnectionRequest request);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //void ModifyConnectionField(App.Db.Dto.ModifyField.Req.S7.Connection request);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.ModifyField.Common.Connection> ModifyConnectionFieldAsync(App.Dto.Req.ModifyField.Common.Connection request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //bool RemoveConnection(App.Db.Dto.Remove.Req.S7.Connection request);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Remove.Common.Connection> RemoveConnectionAsync(App.Dto.Req.Remove.Common.Connection request, CallContext context = default);

        #endregion
    }
}
