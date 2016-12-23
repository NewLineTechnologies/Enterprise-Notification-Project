using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Models
{
    public class MessageUserCM : CommandBase, ICommandWithRecipient
    {
        public string Recipient { get; set; }

        public string MessageText { get; set; }

        public override CommandType CommandType
        {
            get
            {
                return CommandType.MessageUser;
            }
        }

        public override string Message
        {
            get
            {
                return $"User {this.Sender} sent message to {this.Recipient}";
            }
        }

        public MessageUserCM(string sender, string recipientUuid, string messageText)
        {
            this.Sender = sender;
            this.Recipient = recipientUuid;
            this.MessageText = messageText;
        }
    }
}
