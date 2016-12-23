using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using CQRS.Commands.Models;
using Microsoft.ServiceBus.Messaging;
using DL.Interfaces;
using CQRS.Commands.Implementation;
using Enums;
using CQRS.Commands.Interfaces;

namespace MessageHistoryWriter
{
    public class SchedulerTask
    {
        private readonly IMessageRepository messageRepository;        

        public SchedulerTask(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;          
        }


        public async Task ProcessQueueMessage([ServiceBusTrigger("messages-topic", "MessageWriter")]  BrokeredMessage message,
       TextWriter logger)
        {
            try
            {
                string body = message.GetBody<string>();
                
                var commandType = (CommandType)Enum.Parse(typeof(CommandType), 
                    (string)message.Properties[Constants.CommandType]);
                       
                var command = JsonConvert.DeserializeObject(body, CommandTypeResolver.GetCommandType(commandType))
                    as CommandBase;

                string recipient = null;
                

                if (command is ICommandWithRecipient)
                {
                    recipient = ((ICommandWithRecipient)command).Recipient;
                }

                //this.commandDispatcher.Execute(command);

                await this.messageRepository.AddMessage(new DL.Models.Message()
                {
                    Id = message.MessageId,                    
                    Type = command.CommandType.ToString(),
                    Sender = command.Sender,                  
                    Recipient = recipient,                    
                    DateTime = message.EnqueuedTimeUtc
                });

                logger.WriteLine(command.Sender);
            }
            catch (Exception ex)
            {
                logger.WriteLine("Exception: " + ex.StackTrace);
            }
        }
    }
}
