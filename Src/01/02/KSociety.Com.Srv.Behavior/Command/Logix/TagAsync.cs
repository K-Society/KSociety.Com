using Autofac;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Com.Srv.Contract.Command.Logix;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Srv.Behavior.Command.Logix;
public class TagAsync : KSociety.Base.Srv.Behavior.CommandImportExportAsync<
    KSociety.Com.App.Dto.Req.Add.Logix.LogixTag, KSociety.Com.App.Dto.Res.Add.Logix.LogixTag,
    KSociety.Com.App.Dto.Req.Update.Logix.LogixTag, KSociety.Com.App.Dto.Res.Update.Logix.LogixTag,
    KSociety.Com.App.Dto.Req.Copy.Logix.LogixTag, KSociety.Com.App.Dto.Res.Copy.Logix.LogixTag,
    KSociety.Com.App.Dto.Req.ModifyField.Logix.LogixTag, KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixTag,
    KSociety.Com.App.Dto.Req.Remove.Logix.LogixTag, KSociety.Com.App.Dto.Res.Remove.Logix.LogixTag,
    KSociety.Com.App.Dto.Req.Import.Logix.LogixTag, KSociety.Com.App.Dto.Res.Import.Logix.LogixTag,
    KSociety.Com.App.Dto.Req.Export.Logix.LogixTag, KSociety.Com.App.Dto.Res.Export.Logix.LogixTag>, ITagAsync
{
    public TagAsync(
        ILoggerFactory loggerFactory,
        IComponentContext componentContext,
        ICommandHandlerAsync commandHandlerAsync
    )
        : base(loggerFactory, componentContext, commandHandlerAsync)
    {

    }
}
