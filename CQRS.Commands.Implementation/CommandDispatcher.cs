using CQRS.Commands.Implementation.Exceptions;
using CQRS.Commands.Interfaces;
using CQRS.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Implementation
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IAzureCommandQueue azureCommandQueue;

        public CommandDispatcher(IServiceProvider serviceProvider, IAzureCommandQueue azureCommandQueue)
        {
            this.serviceProvider = serviceProvider;
            this.azureCommandQueue = azureCommandQueue;
        }

        public string Execute<TCommand>(TCommand command)
           where TCommand : CommandBase
        {
            var ch = this.GetCommandHandler(command);

            var validationResult = ch.Validate(command);

            if(validationResult != null)
            {
                throw new CommandDispatchException(validationResult);
            }

            ch.Execute(command);
            return this.Dispatch(command);
        }


        private string Dispatch<TCommand>(TCommand command)
           where TCommand : CommandBase
        {
            return this.azureCommandQueue.EnqueueCommand(command);
        }

        private ICommandHandler<TCommand> GetCommandHandler<TCommand>(TCommand command)
            where TCommand : CommandBase
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            var handler = serviceProvider.GetService(typeof(ICommandHandler<TCommand>)) as
                ICommandHandler<TCommand>;               

            if (handler == null)
            {
                throw new KeyNotFoundException(typeof(TCommand).ToString());
            }

            return handler;
        }
    }
}
