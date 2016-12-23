using CQRS.Commands.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TrialProject.Web.Hubs;
using TrialProject.Web.ViewModels;

namespace TrialProject.Web.SBListener
{
    public class SBClient
    {
        private readonly static Lazy<SBClient> _instance = new Lazy<SBClient>(() => new SBClient(GlobalHost.ConnectionManager.GetHubContext<NotificationHub>().Clients));

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        private SBClient(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;

            var connectionString = ConfigurationManager.AppSettings["serviceBus:connectionString"];
            var topicName = ConfigurationManager.AppSettings["serviceBus:topicName"];
            this.AddReceiver(connectionString, topicName, "Test");

        }

        public static SBClient Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void AddReceiver(string connectionString, string topicName, string subscription)
        {
            SubscriptionClient Client = SubscriptionClient.CreateFromConnectionString(connectionString, topicName, subscription);

            // Configure the callback options.
            OnMessageOptions options = new OnMessageOptions();
            options.AutoComplete = false;
            options.AutoRenewTimeout = TimeSpan.FromMinutes(1);

            Client.OnMessage((message) =>
            {
                try
                {
                    string body = message.GetBody<string>();
                    var command = JsonConvert.DeserializeObject<CommandBase>(body)
                        as CommandBase;

                    this.Notify(new NotificationVM()
                    {
                        MessageId = message.MessageId,
                        Command = command
                    });

                    // Remove message from subscription.
                    message.Complete();
                }
                catch (Exception ex)
                {
                    // Indicates a problem, unlock message in subscription.
                    message.Abandon();
                }
            }, options);
        }

        public void Notify(NotificationVM message)
        {
            Clients.All.Notify(message);
        }
    }
}