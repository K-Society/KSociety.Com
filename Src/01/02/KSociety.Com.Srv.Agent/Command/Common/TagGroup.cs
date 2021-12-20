using KSociety.Base.Srv.Agent;
using KSociety.Com.Srv.Agent.Interface.Command.Common;
using KSociety.Com.Srv.Contract.Command.Common;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Agent.Command.Common;

public class TagGroup : KSociety.Base.Srv.Agent.Connection, ITagGroup
{
    public TagGroup(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }

    public bool Remove(App.Dto.Req.Remove.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        var output = false;
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.RemoveTagGroup(request, ConnectionOptions(cancellationToken));

                output = result.Result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }

        return output;
    }

    public async ValueTask<bool> RemoveAsync(App.Dto.Req.Remove.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        var output = false;
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.RemoveTagGroupAsync(request, ConnectionOptions(cancellationToken));

                output = result.Result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }

        return output;
    }

    public App.Dto.Res.Add.Common.TagGroup Add(App.Dto.Req.Add.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Add.Common.TagGroup output = new App.Dto.Res.Add.Common.TagGroup();
        try
        {
            using (Channel)
            {
                ICommand client = null;

                client = Channel.CreateGrpcService<ICommand>();

                var result = client.AddTagGroup(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Add.Common.TagGroup> AddAsync(App.Dto.Req.Add.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Add.Common.TagGroup output = new App.Dto.Res.Add.Common.TagGroup();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.AddTagGroupAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Update.Common.TagGroup Update(App.Dto.Req.Update.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Update.Common.TagGroup output = new App.Dto.Res.Update.Common.TagGroup();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.UpdateTagGroup(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Update.Common.TagGroup> UpdateAsync(App.Dto.Req.Update.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Update.Common.TagGroup output = new App.Dto.Res.Update.Common.TagGroup();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.UpdateTagGroupAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Copy.Common.TagGroup Copy(App.Dto.Req.Copy.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Copy.Common.TagGroup output = new App.Dto.Res.Copy.Common.TagGroup();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.CopyTagGroup(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Copy.Common.TagGroup> CopyAsync(App.Dto.Req.Copy.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Copy.Common.TagGroup output = new App.Dto.Res.Copy.Common.TagGroup();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.CopyTagGroupAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Export.Common.TagGroup Export(App.Dto.Req.Export.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Export.Common.TagGroup output = new App.Dto.Res.Export.Common.TagGroup();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.ExportTagGroup(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Export.Common.TagGroup> ExportAsync(App.Dto.Req.Export.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Export.Common.TagGroup output = new App.Dto.Res.Export.Common.TagGroup();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.ExportTagGroupAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Import.Common.TagGroup Import(App.Dto.Req.Import.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Import.Common.TagGroup output = new App.Dto.Res.Import.Common.TagGroup();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.ImportTagGroup(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Import.Common.TagGroup> ImportAsync(App.Dto.Req.Import.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Import.Common.TagGroup output = new App.Dto.Res.Import.Common.TagGroup();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.ImportTagGroupAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public bool ModifyField(App.Dto.Req.ModifyField.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        var output = false;
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.ModifyTagGroupField(request, ConnectionOptions(cancellationToken));

                output = result.Result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<bool> ModifyFieldAsync(App.Dto.Req.ModifyField.Common.TagGroup request, CancellationToken cancellationToken = default)
    {
        var output = false;
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.ModifyTagGroupFieldAsync(request, ConnectionOptions(cancellationToken));

                output = result.Result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }
}