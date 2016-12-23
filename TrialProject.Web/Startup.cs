using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using System.Configuration;

[assembly: OwinStartup(typeof(TrialProject.Web.Startup))]

namespace TrialProject.Web
{
    public partial class Startup
    {
        private const string connectionStringKey = "serviceBus:connectionString";
        private const string topicNameKey = "serviceBus:topicName";

        public void Configuration(IAppBuilder app)
        {
            var connectionString = ConfigurationManager.AppSettings[connectionStringKey];
            var topicName = ConfigurationManager.AppSettings[topicNameKey];

//            GlobalHost.DependencyResolver.UseServiceBus(connectionString, topicName);

            app.MapSignalR();

            //ConfigureAuth(app);
        }
    }
}
