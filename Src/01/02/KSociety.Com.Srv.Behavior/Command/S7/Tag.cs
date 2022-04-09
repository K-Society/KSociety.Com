using Autofac;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Com.Srv.Contract.Command.S7;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Srv.Behavior.Command.S7;
public class Tag : KSociety.Base.Srv.Behavior.CommandImportExport<
    KSociety.Com.App.Dto.Req.Add.S7.S7Tag, KSociety.Com.App.Dto.Res.Add.S7.S7Tag,
    KSociety.Com.App.Dto.Req.Update.S7.S7Tag, KSociety.Com.App.Dto.Res.Update.S7.S7Tag,
    KSociety.Com.App.Dto.Req.Copy.S7.S7Tag, KSociety.Com.App.Dto.Res.Copy.S7.S7Tag,
    KSociety.Com.App.Dto.Req.ModifyField.S7.S7Tag, KSociety.Com.App.Dto.Res.ModifyField.S7.S7Tag,
    KSociety.Com.App.Dto.Req.Remove.S7.S7Tag, KSociety.Com.App.Dto.Res.Remove.S7.S7Tag,
    KSociety.Com.App.Dto.Req.Import.S7.S7Tag, KSociety.Com.App.Dto.Res.Import.S7.S7Tag,
    KSociety.Com.App.Dto.Req.Export.S7.S7Tag, KSociety.Com.App.Dto.Res.Export.S7.S7Tag>, ITag
{
    public Tag(
        ILoggerFactory loggerFactory,
        IComponentContext componentContext,
        ICommandHandler commandHandler
    )
        : base(loggerFactory, componentContext, commandHandler)
    {

    }
}
