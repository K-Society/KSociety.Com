using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Command.S7;

[Service]
public interface ICommand
{
    #region [S7Tag]

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    App.Dto.Res.Add.S7.S7Tag AddS7Tag(App.Dto.Req.Add.S7.S7Tag request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    App.Dto.Res.Update.S7.S7Tag UpdateS7Tag(App.Dto.Req.Update.S7.S7Tag request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    App.Dto.Res.Copy.S7.S7Tag CopyS7Tag(App.Dto.Req.Copy.S7.S7Tag request, CallContext context = default);

    [Operation]
    App.Dto.Res.Export.S7.S7Tag ExportS7Tag(App.Dto.Req.Export.S7.S7Tag request, CallContext context = default);

    [Operation]
    App.Dto.Res.Import.S7.S7Tag ImportS7Tag(App.Dto.Req.Import.S7.S7Tag request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    App.Dto.Res.ModifyField.S7.S7Tag ModifyS7TagField(App.Dto.Req.ModifyField.S7.S7Tag request,
        CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    App.Dto.Res.Remove.S7.S7Tag RemoveS7Tag(App.Dto.Req.Remove.S7.S7Tag request, CallContext context = default);

    #endregion


    #region [S7Connection]

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    App.Dto.Res.Add.S7.S7Connection AddS7Connection(App.Dto.Req.Add.S7.S7Connection request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    App.Dto.Res.Update.S7.S7Connection UpdateS7Connection(App.Dto.Req.Update.S7.S7Connection request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    App.Dto.Res.Copy.S7.S7Connection CopyS7Connection(App.Dto.Req.Copy.S7.S7Connection request, CallContext context = default);

    [Operation]
    App.Dto.Res.Export.S7.S7Connection ExportS7Connection(App.Dto.Req.Export.S7.S7Connection request, CallContext context = default);

    [Operation]
    App.Dto.Res.Import.S7.S7Connection ImportS7Connection(App.Dto.Req.Import.S7.S7Connection request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    App.Dto.Res.ModifyField.S7.S7Connection ModifyS7ConnectionField(App.Dto.Req.ModifyField.S7.S7Connection request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    App.Dto.Res.Remove.S7.S7Connection RemoveS7Connection(App.Dto.Req.Remove.S7.S7Connection request, CallContext context = default);

    #endregion
}