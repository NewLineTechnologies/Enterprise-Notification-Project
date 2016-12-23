using CQRS.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrialProject.Web.ViewModels
{
    public class NotificationVM
    {
        public string MessageId { get; set; }

        public CommandBase Command { get; set; }
    }
}