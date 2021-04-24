using KSociety.Base.Pre.Form.Presenter.Forms;
using KSociety.Com.Pre.Form.View.Abstractions.Common.List.GridView;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Form.Presenter.Common.List.GridView
{
    public class TagGroup
        : Presenter<
            ITagGroup,
            Srv.Dto.Common.TagGroup,
            App.Dto.Req.Remove.Common.TagGroup,
            App.Dto.Req.Add.Common.TagGroup,
            App.Dto.Res.Add.Common.TagGroup,
            App.Dto.Req.Update.Common.TagGroup,
            App.Dto.Res.Update.Common.TagGroup,
            App.Dto.Req.Copy.Common.TagGroup,
            App.Dto.Res.Copy.Common.TagGroup,
            App.Dto.Req.ModifyField.Common.TagGroup,
            Srv.Dto.Common.List.GridView.TagGroup,
            Srv.Agent.Interface.Command.Common.ITagGroup,
            Srv.Agent.Interface.Query.Common.List.GridView.ITagGroup>
    {

        //private static ILoggerFactory _loggerFactory;

        public TagGroup(ITagGroup iView,
            Srv.Agent.Interface.Command.Common.ITagGroup commandModel,
            Srv.Agent.Interface.Query.Common.List.GridView.ITagGroup queryModel,
            ILoggerFactory loggerFactory)
            : base(iView, commandModel, queryModel, loggerFactory)
        //: base(iView, new Model.Class.Command.Common.TagGroup(), new Model.Class.Query.Common.List.GridView.TagGroup(), loggerFactory)
        {
            //View.DefaultValuesNeeded += ViewOnDefaultValuesNeeded;

            //_loggerFactory = loggerFactory;
            ////Logger.LogInformation("Test");
            ////Console.WriteLine("Test");
            //var test = Test();

        }

        //private async Task Test()
        //{
        //    Logger.LogInformation("Test");
        //    Console.WriteLine("Test");
        //    try
        //    {
        //        var t = new Model.Class.Command.Common.Connection();
        //        Logger.LogInformation("Test2");
        //        var result = t.FindAsync(new StdIdObject(Guid.NewGuid()));

        //        Console.WriteLine("Result: " + result.Result.Name);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("" + ex.Message);
        //        Logger.LogError(ex.Message + " " + ex.StackTrace);
        //    }

        //    //var t = new Model.Class.Transaction.Transaction(_loggerFactory);
        //    ////await t.SendHeartBeatAsync();
        //    ////await t.NotifyTagInvokeAsync();
        //    ////await t.NotifyTagReadAsync();
        //    //await t.GetConnectionStatusAsync("Plc1");
        //    //await t.GetTagValueAsync("Tag01");
        //    //await t.SetTagValueAsync("Tag01", "10");
        //    //await t.GetTagValueAsync("Tag01");
        //    //await t.SetTagValueAsync("Tag02", "15");
        //    //await t.GetTagValueAsync("Tag02");
        //    //await t.GetTagValueAsync("Tag03");
        //    //await t.GetTagValueAsync("Tag04");
        //    //await t.GetTagValueAsync("Tag05");
        //}
    }
}
