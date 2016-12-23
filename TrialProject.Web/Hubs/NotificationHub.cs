using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.ServiceBus.Messaging;
using Enums;
using System.Configuration;
using TrialProject.Web.SBListener;

namespace TrialProject.Web.Hubs
{
    public class NotificationHub : Hub<INotificationClient>
    {
        private readonly SBClient _sbListener;

        public NotificationHub() : this(SBClient.Instance) { }

        public NotificationHub(SBClient sbListener)
        {
            _sbListener = sbListener;
        }
     
    }
}