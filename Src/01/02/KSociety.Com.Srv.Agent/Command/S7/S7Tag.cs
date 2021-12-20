using KSociety.Base.Srv.Agent;
using KSociety.Com.Srv.Contract.Command.S7;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Agent.Command.S7;

public class S7Tag : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Command.S7.IS7Tag
{
    public S7Tag(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }

    public bool Remove(App.Dto.Req.Remove.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        var output = false;
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.RemoveS7Tag(request, ConnectionOptions(cancellationToken));

                output = result.Result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }

        return output;
    }

    public async ValueTask<bool> RemoveAsync(App.Dto.Req.Remove.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        var output = false;
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.RemoveS7TagAsync(request, ConnectionOptions(cancellationToken));

                output = result.Result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }

        return output;
    }

    public App.Dto.Res.Add.S7.S7Tag Add(App.Dto.Req.Add.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Add.S7.S7Tag output = new App.Dto.Res.Add.S7.S7Tag();
        try
        {
            using (Channel)
            {
                ICommand client = null;

                client = Channel.CreateGrpcService<ICommand>();

                var result = client.AddS7Tag(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Add.S7.S7Tag> AddAsync(App.Dto.Req.Add.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Add.S7.S7Tag output = new App.Dto.Res.Add.S7.S7Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.AddS7TagAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Update.S7.S7Tag Update(App.Dto.Req.Update.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Update.S7.S7Tag output = new App.Dto.Res.Update.S7.S7Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.UpdateS7Tag(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Update.S7.S7Tag> UpdateAsync(App.Dto.Req.Update.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Update.S7.S7Tag output = new App.Dto.Res.Update.S7.S7Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.UpdateS7TagAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Copy.S7.S7Tag Copy(App.Dto.Req.Copy.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Copy.S7.S7Tag output = new App.Dto.Res.Copy.S7.S7Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.CopyS7Tag(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Copy.S7.S7Tag> CopyAsync(App.Dto.Req.Copy.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Copy.S7.S7Tag output = new App.Dto.Res.Copy.S7.S7Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.CopyS7TagAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Export.S7.S7Tag Export(App.Dto.Req.Export.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Export.S7.S7Tag output = new App.Dto.Res.Export.S7.S7Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.ExportS7Tag(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Export.S7.S7Tag> ExportAsync(App.Dto.Req.Export.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Export.S7.S7Tag output = new App.Dto.Res.Export.S7.S7Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.ExportS7TagAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Import.S7.S7Tag Import(App.Dto.Req.Import.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Import.S7.S7Tag output = new App.Dto.Res.Import.S7.S7Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.ImportS7Tag(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Import.S7.S7Tag> ImportAsync(App.Dto.Req.Import.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        App.Dto.Res.Import.S7.S7Tag output = new App.Dto.Res.Import.S7.S7Tag();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.ImportS7TagAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public bool ModifyField(App.Dto.Req.ModifyField.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        var output = false;
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommand>();

                var result = client.ModifyS7TagField(request, ConnectionOptions(cancellationToken));

                output = result.Result;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<bool> ModifyFieldAsync(App.Dto.Req.ModifyField.S7.S7Tag request, CancellationToken cancellationToken = default)
    {
        var output = false;
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<ICommandAsync>();

                var result = await client.ModifyS7TagFieldAsync(request, ConnectionOptions(cancellationToken));

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