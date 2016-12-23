using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using CQRS.Commands.Interfaces;
using CQRS.Commands.Models;
using System.Configuration;
using Microsoft.ServiceBus;
using Newtonsoft.Json;
using Enums;

namespace CQRS.Commands.Implementation
{
    public class AzureCommandQueue : IAzureCommandQueue
    {
        private readonly string connectionString;
        private readonly string topicName;

        public AzureCommandQueue(string connectionString, string topicName)
        {
            this.connectionString = connectionString;
            this.topicName = topicName;          
        }

        public string EnqueueCommand(CommandBase command)
        {
            var sz = JsonConvert.SerializeObject(command);

            TopicClient client =
                TopicClient.CreateFromConnectionString(this.connectionString, this.topicName);
                      
            var message = new BrokeredMessage(sz);
            message.Properties[Constants.CommandType] = command.CommandType.ToString();
            message.Properties[Constants.Sender] = command.Sender;


            client.Send(message);

            return message.MessageId;    
        }
    }
}