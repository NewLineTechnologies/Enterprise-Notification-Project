using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrialProject.ViewModels
{
    public class MessageUserVM
    {
        public string Sender { get; set; }

        public string Recipient { get; set; }

        public string MessageText { get; set; }
    }
}