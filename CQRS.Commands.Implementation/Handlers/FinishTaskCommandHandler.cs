using CQRS.Commands.Interfaces;
using CQRS.Commands.Models;
using DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Implementation.Handlers
{
    public class FinishTaskCommandHandler : CommandHandlerBase<FinishTaskCM>
    {
        private readonly ICommandDispatcher commandDispatcher;

        public FinishTaskCommandHandler(ICoreRepository repository, ICommandDispatcher commandDispatcher) : base(repository)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public override void Execute(FinishTaskCM command)
        {
            this.commandDispatcher.Execute<TakeTaskCM>(new TakeTaskCM(command.Sender, command.TaskUuid + "_next"));
        }

    }
}
