using System.Threading.Tasks;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Command.Logix;

[Service]
//[ServiceContract(Name = "Com.Command.Logix", Namespace = Constants.Namespace)]
public interface ICommandAsync
{

    //[OperationContract]
    //[FaultContract(typeof(BusinessFault))]
    //ValueTask<int> LogixTest(int value);


    #region [LogixTag]

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<App.Dto.Res.Add.Logix.LogixTag> AddLogixTagAsync(App.Dto.Req.Add.Logix.LogixTag request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<App.Dto.Res.Update.Logix.LogixTag> UpdateLogixTagAsync(App.Dto.Req.Update.Logix.LogixTag request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<App.Dto.Res.Copy.Logix.LogixTag> CopyLogixTagAsync(App.Dto.Req.Copy.Logix.LogixTag request, CallContext context = default);

    [Operation]
    ValueTask<App.Dto.Res.Export.Logix.LogixTag> ExportLogixTagAsync(App.Dto.Req.Export.Logix.LogixTag request, CallContext context = default);

    [Operation]
    ValueTask<App.Dto.Res.Import.Logix.LogixTag> ImportLogixTagAsync(App.Dto.Req.Import.Logix.LogixTag request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<App.Dto.Res.ModifyField.Logix.LogixTag> ModifyLogixTagFieldAsync(App.Dto.Req.ModifyField.Logix.LogixTag request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<App.Dto.Res.Remove.Logix.LogixTag> RemoveLogixTagAsync(App.Dto.Req.Remove.Logix.LogixTag request, CallContext context = default);

    #endregion


    #region [LogixConnection]

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<App.Dto.Res.Add.Logix.LogixConnection> AddLogixConnectionAsync(App.Dto.Req.Add.Logix.LogixConnection request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<App.Dto.Res.Update.Logix.LogixConnection> UpdateLogixConnectionAsync(App.Dto.Req.Update.Logix.LogixConnection request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<App.Dto.Res.Copy.Logix.LogixConnection> CopyLogixConnectionAsync(App.Dto.Req.Copy.Logix.LogixConnection request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<App.Dto.Res.ModifyField.Logix.LogixConnection> ModifyLogixConnectionFieldAsync(App.Dto.Req.ModifyField.Logix.LogixConnection request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<App.Dto.Res.Remove.Logix.LogixConnection> RemoveLogixConnectionAsync(App.Dto.Req.Remove.Logix.LogixConnection request, CallContext context = default);

    #endregion
}