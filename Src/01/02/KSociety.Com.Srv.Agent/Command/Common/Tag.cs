using KSociety.Base.Srv.Agent;
using KSociety.Com.Srv.Agent.Interface.Command.Common;
using KSociety.Com.Srv.Contract.Command.Common;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Agent.Command.Common;

public class Tag : KSociety.Base.Srv.Agent.Connection, ITag
{
    public Tag(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }

    public bool Remove(App.Dto.Req.Remove.Common.Tag request, CancellationToken cancellationToken = default)
    {
        var output = false;
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.RemoveTag(request, ConnectionOptions(cancellationToken));

                output = result.Result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }

        return output;
    }

    public async ValueTask<bool> RemoveAsync(App.Dto.Req.Remove.Common.Tag request, CancellationToken cancellationToken = default)
    {
        var output = false;
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.RemoveTagAsync(request, ConnectionOptions(cancellationToken));

                output = result.Result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace); Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }

        return output;
    }

    public App.Dto.Res.Add.Common.Tag Add(App.Dto.Req.Add.Common.Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Add.Common.Tag output = new App.Dto.Res.Add.Common.Tag();
        try
        {
            using (Channel)
            {
                ICommand client = null;

                client = Channel.CreateGrpcService<ICommand>();

                var result = client.AddTag(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Add.Common.Tag> AddAsync(App.Dto.Req.Add.Common.Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Add.Common.Tag output = new App.Dto.Res.Add.Common.Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.AddTagAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Update.Common.Tag Update(App.Dto.Req.Update.Common.Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Update.Common.Tag output = new App.Dto.Res.Update.Common.Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.UpdateTag(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Update.Common.Tag> UpdateAsync(App.Dto.Req.Update.Common.Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Update.Common.Tag output = new App.Dto.Res.Update.Common.Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.UpdateTagAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Copy.Common.Tag Copy(App.Dto.Req.Copy.Common.Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Copy.Common.Tag output = new App.Dto.Res.Copy.Common.Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.CopyTag(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Copy.Common.Tag> CopyAsync(App.Dto.Req.Copy.Common.Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Copy.Common.Tag output = new App.Dto.Res.Copy.Common.Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.CopyTagAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Export.Common.Tag Export(App.Dto.Req.Export.Common.Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Export.Common.Tag output = new App.Dto.Res.Export.Common.Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.ExportTag(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Export.Common.Tag> ExportAsync(App.Dto.Req.Export.Common.Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Export.Common.Tag output = new App.Dto.Res.Export.Common.Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.ExportTagAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Import.Common.Tag Import(App.Dto.Req.Import.Common.Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Import.Common.Tag output = new App.Dto.Res.Import.Common.Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.ImportTag(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Import.Common.Tag> ImportAsync(App.Dto.Req.Import.Common.Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Import.Common.Tag output = new App.Dto.Res.Import.Common.Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.ImportTagAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public bool ModifyField(App.Dto.Req.ModifyField.Common.Tag request, CancellationToken cancellationToken = default)
    {
        var output = false;
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.ModifyTagField(request, ConnectionOptions(cancellationToken));

                output = result.Result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<bool> ModifyFieldAsync(App.Dto.Req.ModifyField.Common.Tag request, CancellationToken cancellationToken = default)
    {
        var output = false;
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.ModifyTagFieldAsync(request, ConnectionOptions(cancellationToken));

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