using CQRS.Commands.Interfaces;
using CQRS.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHistoryWriter
{
    public class WebJobCommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;      

        public WebJobCommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;         
        }

        public string Execute<TCommand>(TCommand command)
           where TCommand : CommandBase
        {
            var ch = this.GetCommandHandler(command);

            ch.Execute(command);

            return null;
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
