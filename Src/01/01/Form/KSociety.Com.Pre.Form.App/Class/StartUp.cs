using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSociety.Com.Pre.Form.App.Class
{
    public class StartUp
    {
        public StartUp()
        {

            //var tagGroupView = new Std.Pre.Com.View.Forms.Common.List.GridView.CommonTagGroup();
            //var tagGroupCommandModel = new Std.Pre.Com.Model.Class.Command.Common.TagGroup();
            //var tagGroupQueryModel = new Std.Pre.Com.Model.Class.Query.Common.List.GridView.TagGroup();
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", Microsoft.Extensions.Logging.LogLevel.Warning)
                    .AddFilter("System", Microsoft.Extensions.Logging.LogLevel.Warning);
            });

            //var tagGroupPresenter = new Std.Pre.Com.Presenter.Common.List.GridView.TagGroup(tagGroupView, tagGroupCommandModel, tagGroupQueryModel, loggerFactory);

            var agentConfiguration = new ComAgentConfiguration("http://localhost:5001", true);

            new Configuration(agentConfiguration, loggerFactory).Show();


        }
    }
}
