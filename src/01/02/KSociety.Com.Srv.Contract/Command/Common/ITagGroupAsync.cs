using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Command.Common;

[Service]
public interface ITagGroupAsync : KSociety.Base.Srv.Contract.ICommandImportExportAsync<
    KSociety.Com.App.Dto.Req.Add.Common.TagGroup, KSociety.Com.App.Dto.Res.Add.Common.TagGroup,
    KSociety.Com.App.Dto.Req.Update.Common.TagGroup, KSociety.Com.App.Dto.Res.Update.Common.TagGroup,
    KSociety.Com.App.Dto.Req.Copy.Common.TagGroup, KSociety.Com.App.Dto.Res.Copy.Common.TagGroup,
    KSociety.Com.App.Dto.Req.ModifyField.Common.TagGroup, KSociety.Com.App.Dto.Res.ModifyField.Common.TagGroup,
    KSociety.Com.App.Dto.Req.Remove.Common.TagGroup, KSociety.Com.App.Dto.Res.Remove.Common.TagGroup,
    KSociety.Com.App.Dto.Req.Import.Common.TagGroup, KSociety.Com.App.Dto.Res.Import.Common.TagGroup,
    KSociety.Com.App.Dto.Req.Export.Common.TagGroup, KSociety.Com.App.Dto.Res.Export.Common.TagGroup>
{
}
