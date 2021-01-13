using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Command.Logix
{
    [Service]
    public interface ICommand
    {
        #region [LogixTag]

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Add.Logix.LogixTag AddLogixTag(App.Dto.Req.Add.Logix.LogixTag request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Update.Logix.LogixTag UpdateLogixTag(App.Dto.Req.Update.Logix.LogixTag request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Copy.Logix.LogixTag CopyLogixTag(App.Dto.Req.Copy.Logix.LogixTag request, CallContext context = default);

        [Operation]
        App.Dto.Res.Export.Logix.LogixTag ExportLogixTag(App.Dto.Req.Export.Logix.LogixTag request, CallContext context = default);

        [Operation]
        App.Dto.Res.Import.Logix.LogixTag ImportLogixTag(App.Dto.Req.Import.Logix.LogixTag request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.ModifyField.Logix.LogixTag ModifyLogixTagField(App.Dto.Req.ModifyField.Logix.LogixTag request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Remove.Logix.LogixTag RemoveLogixTag(App.Dto.Req.Remove.Logix.LogixTag request, CallContext context = default);

        #endregion


        #region [LogixConnection]

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Add.Logix.LogixConnection AddLogixConnection(App.Dto.Req.Add.Logix.LogixConnection request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Update.Logix.LogixConnection UpdateLogixConnection(App.Dto.Req.Update.Logix.LogixConnection request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Copy.Logix.LogixConnection CopyLogixConnection(App.Dto.Req.Copy.Logix.LogixConnection request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.ModifyField.Logix.LogixConnection ModifyLogixConnectionField(App.Dto.Req.ModifyField.Logix.LogixConnection request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Remove.Logix.LogixConnection RemoveLogixConnection(App.Dto.Req.Remove.Logix.LogixConnection request, CallContext context = default);

        #endregion
    }
}
