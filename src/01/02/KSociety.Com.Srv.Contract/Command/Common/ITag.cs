using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Command.Common;

[Service]
public interface ITag : KSociety.Base.Srv.Contract.ICommandImportExport<
    KSociety.Com.App.Dto.Req.Add.Common.Tag, KSociety.Com.App.Dto.Res.Add.Common.Tag,
    KSociety.Com.App.Dto.Req.Update.Common.Tag, KSociety.Com.App.Dto.Res.Update.Common.Tag,
    KSociety.Com.App.Dto.Req.Copy.Common.Tag, KSociety.Com.App.Dto.Res.Copy.Common.Tag,
    KSociety.Com.App.Dto.Req.ModifyField.Common.Tag, KSociety.Com.App.Dto.Res.ModifyField.Common.Tag,
    KSociety.Com.App.Dto.Req.Remove.Common.Tag, KSociety.Com.App.Dto.Res.Remove.Common.Tag,
    KSociety.Com.App.Dto.Req.Import.Common.Tag, KSociety.Com.App.Dto.Res.Import.Common.Tag,
    KSociety.Com.App.Dto.Req.Export.Common.Tag, KSociety.Com.App.Dto.Res.Export.Common.Tag>
{
}
