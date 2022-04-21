using Autofac;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Com.Srv.Contract.Command.Common;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Srv.Behavior.Command.Common;
public class Tag : KSociety.Base.Srv.Behavior.CommandImportExport<
    KSociety.Com.App.Dto.Req.Add.Common.Tag, KSociety.Com.App.Dto.Res.Add.Common.Tag,
    KSociety.Com.App.Dto.Req.Update.Common.Tag, KSociety.Com.App.Dto.Res.Update.Common.Tag,
    KSociety.Com.App.Dto.Req.Copy.Common.Tag, KSociety.Com.App.Dto.Res.Copy.Common.Tag,
    KSociety.Com.App.Dto.Req.ModifyField.Common.Tag, KSociety.Com.App.Dto.Res.ModifyField.Common.Tag,
    KSociety.Com.App.Dto.Req.Remove.Common.Tag, KSociety.Com.App.Dto.Res.Remove.Common.Tag,
    KSociety.Com.App.Dto.Req.Import.Common.Tag, KSociety.Com.App.Dto.Res.Import.Common.Tag,
    KSociety.Com.App.Dto.Req.Export.Common.Tag, KSociety.Com.App.Dto.Res.Export.Common.Tag>, ITag
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
