using System.Threading.Tasks;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Command.S7
{
    [Service]
    //[ServiceContract(Name = "Com.Command.S7", Namespace = Constants.Namespace)]
    public interface ICommandAsync
    {

        //[OperationContract]
        //[FaultContract(typeof(BusinessFault))]
        //ValueTask<int> S7Test(int value);


        #region [S7Tag]

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Add.S7.S7Tag> AddS7TagAsync(App.Dto.Req.Add.S7.S7Tag request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Update.S7.S7Tag> UpdateS7TagAsync(App.Dto.Req.Update.S7.S7Tag request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Copy.S7.S7Tag> CopyS7TagAsync(App.Dto.Req.Copy.S7.S7Tag request, CallContext context = default);

        [Operation]
        ValueTask<App.Dto.Res.Export.S7.S7Tag> ExportS7TagAsync(App.Dto.Req.Export.S7.S7Tag request, CallContext context = default);

        [Operation]
        ValueTask<App.Dto.Res.Import.S7.S7Tag> ImportS7TagAsync(App.Dto.Req.Import.S7.S7Tag request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.ModifyField.S7.S7Tag> ModifyS7TagFieldAsync(App.Dto.Req.ModifyField.S7.S7Tag request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Remove.S7.S7Tag> RemoveS7TagAsync(App.Dto.Req.Remove.S7.S7Tag request, CallContext context = default);

        #endregion


        #region [S7Connection]

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Add.S7.S7Connection> AddS7ConnectionAsync(App.Dto.Req.Add.S7.S7Connection request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Update.S7.S7Connection> UpdateS7ConnectionAsync(App.Dto.Req.Update.S7.S7Connection request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Copy.S7.S7Connection> CopyS7ConnectionAsync(App.Dto.Req.Copy.S7.S7Connection request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.ModifyField.S7.S7Connection> ModifyS7ConnectionFieldAsync(App.Dto.Req.ModifyField.S7.S7Connection request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Remove.S7.S7Connection> RemoveS7ConnectionAsync(App.Dto.Req.Remove.S7.S7Connection request, CallContext context = default);

        #endregion
    }
}
