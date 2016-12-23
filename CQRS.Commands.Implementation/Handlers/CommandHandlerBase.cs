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
    public class CommandHandlerBase<TCommand> : ICommandHandler<TCommand>
     where TCommand : CommandBase
    {
        protected readonly ICoreRepository repository;

        public CommandHandlerBase(ICoreRepository repository)
        {
            this.repository = repository;
        }

        public virtual void Execute(TCommand command)
        {
            return;
        }

        public virtual CommandValidationResult Validate(TCommand command)
        {
            return null;
        }
    }
}
